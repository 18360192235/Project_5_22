using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : CommonUIBase
{
    private Button _closeBtn;
    private Button _openLevelPlayBtn;

    public override void InitComponent()
    {
        base.InitComponent();
        _closeBtn = m_panel.FindComponent<Button>("CloseButton");
        _openLevelPlayBtn = m_panel.FindComponent<Button>("LevelPlayButton");
    }

    public override void AddEvent()
    {
        base.AddEvent();
        _closeBtn.AddOnClick(ClickCloseBtn);
        _openLevelPlayBtn.AddOnClick(ClickOpenLevelPlayBtn);
    }

    public override void RemoveEvent()
    {
        base.RemoveEvent();
        _closeBtn.OnRemoveClick(ClickCloseBtn);
        _openLevelPlayBtn.OnRemoveClick(ClickOpenLevelPlayBtn);
    }

    private void ClickOpenLevelPlayBtn()
    {
        UIManager.single.ShowUI(UIDataDefault.LevelPlayUI);
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