using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 协程管理
/// </summary>
public class CoroutineUtile : MonoBehaviour
{
    private static CoroutineUtile _instance;
    private readonly List<Coroutine> _coroutines = new List<Coroutine>();

    public static CoroutineUtile Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gamemain = GameMain.instance.gameObject;
                _instance = gamemain.GetComponent<CoroutineUtile>();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 启动协程
    /// </summary>
    public Coroutine OnStart(IEnumerator routine)
    {
        Coroutine co = StartCoroutine(routine);
        _coroutines.Add(co);
        return co;
    }

    /// <summary>
    /// 停止指定协程
    /// </summary>
    public void OnStop(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            _coroutines.Remove(coroutine);
        }
    }

    /// <summary>
    /// 清空所有协程
    /// </summary>
    public void OnClearAll()
    {
        foreach (var co in _coroutines)
        {
            if (co != null)
                StopCoroutine(co);
        }
        _coroutines.Clear();
    }
}