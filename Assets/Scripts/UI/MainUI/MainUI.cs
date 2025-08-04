using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : ResidentUIBase
{
    private Button levelBtn;
    private Button roleBtn;
    private Button gameBtn;

    public override void InitComponent()
    {
        base.InitComponent();
        levelBtn = m_panel.FindComponent<Button>("DownNode/Level/Button");
        roleBtn = m_panel.FindComponent<Button>("DownNode/Role/Button");
        gameBtn = m_panel.FindComponent<Button>("DownNode/Game/Button");
    }

    public override void AddEvent()
    {
        base.AddEvent();
        levelBtn.AddOnClick(OnClickLevelBtn);
        roleBtn.AddOnClick(OnClickRoleBtn);
        gameBtn.AddOnClick(OnClickGameBtn);
    }

    private void OnClickGameBtn()
    {
        SceneManager.LoadScene(1);
    }
    private void OnClickRoleBtn()
    {
        UIManager.single.ShowUI(UIDataDefault.RoleUI);
    }

    private void OnClickLevelBtn()
    {
        UIManager.single.ShowUI(UIDataDefault.LevelUI);
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