using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleInfoUI : PopupUIBase
{
    private Button _closeBtn;
    private Button _openLevelPlayBtn;
    private Button _openRoleBtn;
    private Button _openLevelBtn;
    public override void InitComponent()
    {
        base.InitComponent();
        _closeBtn = m_panel.FindComponent<Button>("CloseButton");
        _openLevelPlayBtn = m_panel.FindComponent<Button>("LevelPlayButton");
        _openRoleBtn = m_panel.FindComponent<Button>("RoleButton");
        _openLevelBtn = m_panel.FindComponent<Button>("LevelButton");
    }

    public override void AddEvent()
    {
        base.AddEvent();
        _closeBtn.AddOnClick(ClickCloseBtn);
        _openLevelPlayBtn.AddOnClick(ClickOpenLevelPlayBtn);
        _openRoleBtn.AddOnClick(ClickOpenRoleBtnBtn);
        _openLevelBtn.AddOnClick(ClickOpenLevelBtnBtn);
    }

    public override void RemoveEvent()
    {
        base.RemoveEvent();
        _closeBtn.OnRemoveClick(ClickCloseBtn);
        _openLevelPlayBtn.OnRemoveClick(ClickOpenLevelPlayBtn);
        _openRoleBtn.OnRemoveClick(ClickOpenRoleBtnBtn);
        _openLevelBtn.OnRemoveClick(ClickOpenLevelBtnBtn);
    }
    private void ClickOpenLevelPlayBtn()
    {
        UIManager.single.ShowUI(UIDataDefault.LevelPlayUI);
    }

    private void ClickOpenRoleBtnBtn()
    {
        UIManager.single.ShowUI(UIDataDefault.RoleUI);
    }
    
    private void ClickOpenLevelBtnBtn()
    {
        UIManager.single.ShowUI(UIDataDefault.LevelUI);
    }

    private void ClickCloseBtn()
    {
        UIManager.single.HideUI(m_data);
    }

    public override void Show(params object[] data)
    {
        base.Show(data);
    }
}