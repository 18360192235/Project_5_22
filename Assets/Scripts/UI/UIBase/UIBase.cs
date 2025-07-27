using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    protected Transform m_panel;
    public eUIHierarchy m_hierarchy;

    /// <summary>
    /// 初始化构建
    /// </summary>
    public virtual void InitComponent()
    {
        m_panel = transform.Find("Panel");
    }
    /// <summary>
    /// 显示
    /// </summary>
    /// <param name="data"></param>
    public virtual void Show(params object[] data)
    {

    }

    /// <summary>
    /// 刷新
    /// </summary>
    public virtual void Refresh()
    {

    }

    /// <summary>
    /// 隐藏
    /// </summary>
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }



    #region mono函数
    private void Awake()
    {
        InitComponent();
    }
    private void Start()
    {

    }
    private void OnDisable()
    {
        
    }
    private void OnDestroy()
    {
        
    }
    #endregion
}
