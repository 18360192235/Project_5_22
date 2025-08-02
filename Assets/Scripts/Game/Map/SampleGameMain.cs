using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGameMain : MonoBehaviour
{
    public DestructibleTerrain map;
    private void PlayGame()
    {
        
    }

    #region 生命周期函数
    private void Awake()
    {
        PlayGame();
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            map.DestroyAt
            (Camera.main.ScreenToWorldPoint(Input.mousePosition),
                0.5f);
        }
    }

    private void OnDestroy()
    {
    }
    #endregion
}
