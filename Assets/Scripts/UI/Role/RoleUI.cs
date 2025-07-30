using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleUI : CommonUIBase
{
    private Button _closeBtn;
    private Button _openRoleInfoBtn;

    public override void InitComponent()
    {
        base.InitComponent();
        _closeBtn = m_panel.FindComponent<Button>("CloseButton");
        _openRoleInfoBtn = m_panel.FindComponent<Button>("RoleInfoButton");
    }

    public override void AddEvent()
    {
        base.AddEvent();
        _closeBtn.AddOnClick(ClickCloseBtn);
        _openRoleInfoBtn.AddOnClick(ClickOpenRoleInfoBtn);
    }

    public override void RemoveEvent()
    {
        base.RemoveEvent();
        _closeBtn.OnRemoveClick(ClickCloseBtn);
        _openRoleInfoBtn.OnRemoveClick(ClickOpenRoleInfoBtn);
    }

    private void ClickOpenRoleInfoBtn()
    {
        UIManager.Sing.ShowUI(UIDataDefault.RoleInfoUI);
    }

    private void ClickCloseBtn()
    {
        UIManager.Sing.HideUI(m_data);
    }

    public override void Show(params object[] data)
    {
        base.Show(data);
    }
}