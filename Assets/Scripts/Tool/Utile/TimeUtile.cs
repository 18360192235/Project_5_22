using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 计时回调工具
/// </summary>
public static class TimeUtile
{
    private static Dictionary<string,Coroutine> _coroutines = new Dictionary<string,Coroutine>();

    /// <summary>
    /// 注册延迟回调
    /// </summary>
    public static void Delay(string name,float seconds, Action callback)
    {
        if (!_coroutines.ContainsKey(name))
        {
            Coroutine co = CoroutineUtile.Instance.OnStart(DelayCoroutine(seconds, callback));
            _coroutines.Add(name,co);
        }
        
    }

    private static IEnumerator DelayCoroutine(float seconds, Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
    }

    /// <summary>
    /// 注册循环回调
    /// </summary>
    public static void Loop(string name,float interval, Action callback)
    {
        if (!_coroutines.ContainsKey(name))
        {
            Coroutine co = CoroutineUtile.Instance.OnStart(LoopCoroutine(interval, callback));
            _coroutines.Add(name,co);
        }
    }

    private static IEnumerator LoopCoroutine(float interval, Action callback)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            callback?.Invoke();
        }
    }

    /// <summary>
    /// 清空所有回调
    /// </summary>
    public static void ClearAll()
    {
        foreach (var co in _coroutines.Values)
        {
            if (co != null)
                CoroutineUtile.Instance.OnStop(co);
        }
        _coroutines.Clear();
    }
}