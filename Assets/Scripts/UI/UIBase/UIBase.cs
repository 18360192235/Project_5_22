using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    protected Transform m_panel;
    [HideInInspector] public UIData m_data;

    #region UI基础功能
    /// <summary>
    /// 初始化构建  Awake调用
    /// </summary>
    public virtual void InitComponent()
    {
        m_panel = transform.Find("Panel");
    }
    /// <summary>
    /// 初始化UI设置 Awake调用
    /// </summary>
    public virtual void InitUISetting(){}
    
    /// <summary>
    /// 显示
    /// </summary>
    /// <param name="data"></param>
    public virtual void Show(params object[] data)
    {
        gameObject.SetActive(true);
    }
    
    /// <summary>
    /// 注册事件 Start调用
    /// </summary>
    public virtual void AddEvent(){}
    

    /// <summary>
    /// 刷新
    /// </summary>
    public virtual void Refresh(){}

    /// <summary>
    /// 隐藏
    /// </summary>
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// 注销事件 OnDisable 和 OnDestroy 调用
    /// </summary>
    public virtual void RemoveEvent(){}

    #endregion

    #region mono函数
    private void Awake()
    {
        InitComponent();
        InitUISetting();
    }
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        AddEvent();
    }

    private void OnDisable()
    {
        RemoveEvent();
    }
    private void OnDestroy()
    {
        RemoveEvent();
    }
    #endregion
}
