using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : ResidentUIBase
{
    private Button levelBtn;
    private Button roleBtn;

    public override void InitComponent()
    {
        base.InitComponent();
        levelBtn = m_panel.FindComponent<Button>("DownNode/Level/Button");
        roleBtn = m_panel.FindComponent<Button>("DownNode/Role/Button");
    }

    public override void AddEvent()
    {
        base.AddEvent();
        levelBtn.AddOnClick(OnClickLevelBtn);
        roleBtn.AddOnClick(OnClickRoleBtn);
    }

    private void OnClickRoleBtn()
    {
        UIManager.Sing.ShowUI(UIDataDefault.RoleUI);
    }

    private void OnClickLevelBtn()
    {
        UIManager.Sing.ShowUI(UIDataDefault.LevelUI);
    }

    public override void RemoveEvent()
    {
        base.RemoveEvent();
    }

    public override void Show(params object[] data)
    {
        base.Show(data);

        Debug.Log("ShowMainUI");
    }
}