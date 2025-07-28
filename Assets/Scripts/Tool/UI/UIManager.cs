using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Single<UIManager>
{
    // UI池，曾经显示过隐藏的UI
    private Dictionary<eUIType, UIBase> UIPool = new Dictionary<eUIType, UIBase>();

    // 显示UI列表
    private Dictionary<eUIType,UIBase> ShowUIList = new Dictionary<eUIType, UIBase>();

    // 弹窗栈
    private Stack<UIBase> PopupUIStack = new Stack<UIBase>();
    
    // 弹窗Mask 
    private PopupMask _popupMask;

#region 对外接口
    
    /// <summary>
    /// 显示UI，根据不同UI类型去处理UI关系
    /// </summary>
    /// <param name="uIData"></param>
    /// <param name="data"></param>
    public void ShowUI(UIData uIData, params object[] data)
    {
        if (ShowUIList.ContainsKey(uIData.Type))
        {
            Log($"{uIData.Type} UI已经打开了");
        }
        
        UIBase ui = GetUI(uIData);
        if (null != ui)
        {
            switch (ui.m_hierarchy)
            {
                case eUIHierarchy.Resident:
                    ResidentUIBase residentUI = ui as ResidentUIBase;
                    if (residentUI != null) ShowResidentUI(residentUI);
                    break;
                case eUIHierarchy.Common:
                    CommonUIBase commonUI = ui as CommonUIBase;
                    if (commonUI != null) ShowCommonUI(commonUI);
                    break;
                case eUIHierarchy.Popup:
                    PopupUIBase popupUI = ui as PopupUIBase;
                    if (popupUI != null) ShowPopupUI(popupUI);
                    break;
                case eUIHierarchy.Tips:
                    TipsUIBase tipsUI = ui as TipsUIBase;
                    if (tipsUI != null) ShowTipsUI(tipsUI);
                    break;
            }
            ShowUIList.Add(uIData.Type, ui);
            ui.transform.SetAsLastSibling();
        }
        else
        {
            Log($"ShowUI {uIData.Type} GetUI is null");
        }
    }

    public void HideUI(UIData uIData)
    {

    }

    public bool GetUIIsShow(UIData uIData)
    {
        // 返回该UI是否处于显示状态
        return false; 
    }


    #endregion

    private UIBase GetUI(UIData uIData)
    {
        UIBase uIBase;
        if(UIPool.TryGetValue(uIData.Type,out uIBase))
        {
            return uIBase;
        }
        else
        {
            GameObject gameObject = InstantiateUI(uIData);
            if (null != gameObject)
            {
                gameObject.name = uIData.Name;
                uIBase = gameObject.GetComponent<UIBase>();
                if(null != uIBase)
                {
                    UIPool.Add(uIData.Type, uIBase);
                }
                else return null;
            }else return null;
        }
        return uIBase;
    }

    /// <summary>
    /// 实例化UI界面
    /// </summary>
    /// <param name="uIData"></param>
    /// <returns></returns>
    private GameObject InstantiateUI(UIData uIData)
    {
        Transform panel = null;

        switch (uIData.Hierarchy)
        {
            case eUIHierarchy.Resident:
                panel = GameMain.instance.m_resident;
                break;
            case eUIHierarchy.Common:
                panel = GameMain.instance.m_common;
                break;
            case eUIHierarchy.Popup:
                panel = GameMain.instance.m_popup;
                break;
            case eUIHierarchy.Tips:
                panel = GameMain.instance.m_tips;
                break;
        }
        if (null != panel) return GameObject.Instantiate(Resources.Load<GameObject>(uIData.Path), panel);
        return null;
    }

    /// <summary>
    /// 点击弹窗遮罩
    /// </summary>
    /// <param name="clickFun"></param>
    public void ClickPopupMask(ePopupMaskClickFun clickFun)
    {
        switch (clickFun)
        {
            case ePopupMaskClickFun.Close:
            {
                break;
            }
            case ePopupMaskClickFun.Mask:
            {
                break;
            }
            case ePopupMaskClickFun.None:
            {
                DebugEr.Log("UIManager ClickPopupMask 异常 点击类型异常");
                break;
            }
        }
    }

    #region 处理层级和Mask遮罩
    private void ShowResidentUI(ResidentUIBase ui)
    {
    }
    private void ShowCommonUI(CommonUIBase ui)
    {
    }
    private void ShowPopupUI(PopupUIBase ui)
    {
        GetPopupMask().Show(ui.MaskType,ui.MaskClickFun);
    }
    private void ShowTipsUI(TipsUIBase ui)
    {
    }

    private void HideResidentUI(ResidentUIBase ui)
    {
    }
    private void HideCommonUI(CommonUIBase ui)
    {
    }
    private void HidePopupUI(PopupUIBase ui)
    {
    }
    private void HideTipsUI(TipsUIBase ui)
    {
    }
    
    #endregion

    private PopupMask GetPopupMask()
    {
        if (null == _popupMask)
        {
            GameObject maskObj = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/UI/PopupMask"), GameMain.instance.m_popup);
            maskObj.name = "PopupMask";
            _popupMask =  maskObj.GetComponent<PopupMask>();
        }
        return _popupMask;
    }
    private void Log(string msg)
    {
        DebugEr.Log($"UIManegr >> {msg}");
    }
}
