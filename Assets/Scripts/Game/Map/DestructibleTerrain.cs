using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class DestructibleTerrain : MonoBehaviour
{
    public Texture2D sourceTexture;
    private Texture2D runtimeTexture;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        runtimeTexture = Instantiate(sourceTexture);
        runtimeTexture.Apply();
        spriteRenderer.sprite = Sprite.Create(runtimeTexture,
            new Rect(0, 0, runtimeTexture.width, runtimeTexture.height), new Vector2(0.5f, 0.5f));
        SimpleUpdateCollider();
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
        // UpdateCollider();
        SimpleUpdateCollider();
    }

    void SimpleUpdateCollider()
    {
        if(null != polygonCollider) Destroy(polygonCollider);
        polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
        polygonCollider.useDelaunayMesh = true;
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

    
    /// <summary>
    /// 代码更新碰撞框节点
    /// </summary>
    void UpdateCollider()
    {
        List<Vector2> points = new List<Vector2>();
        for (int y = 0; y < runtimeTexture.height; y++)
        {
            for (int x = 0; x < runtimeTexture.width; x++)
            {
                if (runtimeTexture.GetPixel(x, y).a > 0.1f && IsEdge(x, y))
                {
                    float px = (float)x / runtimeTexture.width - 0.5f;
                    float py = (float)y / runtimeTexture.height - 0.5f;
                    points.Add(new Vector2(px * spriteRenderer.bounds.size.x, py * spriteRenderer.bounds.size.y));
                }
            }
        }

        // 可选：对点进行排序，形成连贯轮廓（如按极角排序或轮廓追踪）
        // 这里只做简化处理
        var simplified = RamerDouglasPeucker(points, 0.05f); // 0.05f为容差，可调整

        polygonCollider.pathCount = 1;
        polygonCollider.SetPath(0, simplified.ToArray());
    }

// Ramer–Douglas–Peucker 算法实现
    List<Vector2> RamerDouglasPeucker(List<Vector2> pointList, float epsilon)
    {
        if (pointList == null || pointList.Count < 3)
            return new List<Vector2>(pointList);

        int index = -1;
        float dist = 0f;
        for (int i = 1; i < pointList.Count - 1; i++)
        {
            float cDist = PerpendicularDistance(pointList[i], pointList[0], pointList[pointList.Count - 1]);
            if (cDist > dist)
            {
                dist = cDist;
                index = i;
            }
        }

        if (dist > epsilon)
        {
            var left = RamerDouglasPeucker(pointList.Take(index + 1).ToList(), epsilon);
            var right = RamerDouglasPeucker(pointList.Skip(index).ToList(), epsilon);
            left.RemoveAt(left.Count - 1);
            left.AddRange(right);
            return left;
        }
        else
        {
            return new List<Vector2> { pointList[0], pointList[pointList.Count - 1] };
        }
    }

    float PerpendicularDistance(Vector2 pt, Vector2 lineStart, Vector2 lineEnd)
    {
        if (lineStart == lineEnd)
            return Vector2.Distance(pt, lineStart);
        float num = Mathf.Abs((lineEnd.y - lineStart.y) * pt.x - (lineEnd.x - lineStart.x) * pt.y +
            lineEnd.x * lineStart.y - lineEnd.y * lineStart.x);
        float den = Mathf.Sqrt(Mathf.Pow(lineEnd.y - lineStart.y, 2) + Mathf.Pow(lineEnd.x - lineStart.x, 2));
        return num / den;
    }
}