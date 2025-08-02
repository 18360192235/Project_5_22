using System.Collections.Generic;
using UnityEngine;

public class DestructibleTerrain : MonoBehaviour
{
    public Texture2D sourceTexture;
    private Texture2D runtimeTexture;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        runtimeTexture = Instantiate(sourceTexture);
        runtimeTexture.Apply();
        spriteRenderer.sprite = Sprite.Create(runtimeTexture, new Rect(0, 0, runtimeTexture.width, runtimeTexture.height), new Vector2(0.5f, 0.5f));
    }

    /// <summary>
    /// 在指定世界坐标和半径范围内破坏地形
    /// </summary>
    public void DestroyAt(Vector2 worldPos, float radius)
    {
        Vector2 localPos = transform.InverseTransformPoint(worldPos);
        Vector2 texCoord = new Vector2(
            (localPos.x + spriteRenderer.bounds.extents.x) / spriteRenderer.bounds.size.x,
            (localPos.y + spriteRenderer.bounds.extents.y) / spriteRenderer.bounds.size.y
        );
        int px = Mathf.RoundToInt(texCoord.x * runtimeTexture.width);
        int py = Mathf.RoundToInt(texCoord.y * runtimeTexture.height);

        int r = Mathf.RoundToInt(radius * runtimeTexture.width / spriteRenderer.bounds.size.x);

        for (int y = -r; y <= r; y++)
        {
            for (int x = -r; x <= r; x++)
            {
                if (x * x + y * y <= r * r)
                {
                    int tx = px + x;
                    int ty = py + y;
                    if (tx >= 0 && tx < runtimeTexture.width && ty >= 0 && ty < runtimeTexture.height)
                    {
                        Color c = runtimeTexture.GetPixel(tx, ty);
                        c.a = 0;
                        runtimeTexture.SetPixel(tx, ty, c);
                    }
                }
            }
        }
        runtimeTexture.Apply();
        UpdateCollider();
    }

    struct NodeStruct
    {
        public int x;
        public int y;
        public int linkX;
        public int linkY;
        
        public NodeStruct(int x, int y, int linkX, int linkY)
        {
            this.x = x;
            this.y = y;
            this.linkX = linkX;
            this.linkY = linkY;
        }
    }
    
    // 简单轮廓提取：只检测最外层像素
    void UpdateCollider()
    {
        List<Vector2> points = new List<Vector2>();
        int[,] nodeList = new int[runtimeTexture.height,runtimeTexture.width];
        for (int y = 0; y < runtimeTexture.height; y++)
        {
            for (int x = 0; x < runtimeTexture.width; x++)
            {
                if (runtimeTexture.GetPixel(x, y).a > 0.1f)
                {
                    // 检查四邻域是否有透明像素，若有则为边界
                    if (IsEdge(x, y))
                    {
                        // 转换为本地坐标
                        float px = (float)x / runtimeTexture.width - 0.5f;
                        float py = (float)y / runtimeTexture.height - 0.5f;
                        points.Add(new Vector2(px * spriteRenderer.bounds.size.x, py * spriteRenderer.bounds.size.y));
                        nodeList[y,x] = 1;
                    }
                    else
                    {
                        nodeList[y,x] = 0;
                    }
                }
                else
                {
                    nodeList[y,x] = 0;
                }
            }
        }
        polygonCollider.pathCount = 1;
        polygonCollider.SetPath(0, points.ToArray());
    }

    bool IsEdge(int x, int y)
    {
        int w = runtimeTexture.width;
        int h = runtimeTexture.height;
        for (int dy = -1; dy <= 1; dy++) // 遍历九宫格
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                if (dx == 0 && dy == 0) continue;
                int nx = x + dx;
                int ny = y + dy;
                if (nx < 0 || nx >= w || ny < 0 || ny >= h) return true; // 边缘判断
                if (runtimeTexture.GetPixel(nx, ny).a < 0.1f) return true; // 透明度判断
            }
        }
        return false;
    }
}