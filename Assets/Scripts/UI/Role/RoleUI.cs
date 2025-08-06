using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleUI : CommonUIBase
{
    private Button _closeBtn;
    private Button _openRoleInfoBtn;

    public GameObject _RoleItemExamples;
    private List<RoleItem> _showRoleItems = new List<RoleItem>();

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
        UIManager.single.ShowUI(UIDataDefault.RoleInfoUI);
    }

    private void ClickCloseBtn()
    {
        UIManager.single.HideUI(m_data);
    }

    public override void Show(params object[] data)
    {
        base.Show(data);
        if(null== _RoleItemExamples) return;

        var roleCfg = ConfigMgr.RoleListCfg.Data;
        Transform itemPanel = _RoleItemExamples.transform.parent;
        if (_showRoleItems.Count == 0)
        {
            for (int i = 0; i < roleCfg.Count; i++)
            {
                RoleItem roleItem;
                if (_showRoleItems.Count <= i)
                {
                    GameObject roleObj = Instantiate(_RoleItemExamples, itemPanel);
                    roleItem = roleObj.GetComponent<RoleItem>();
                    if (roleItem != null)
                    {
                        _showRoleItems.Add(roleItem);
                    }
                }else
                {
                    roleItem = _showRoleItems[i];
                }
                roleItem.gameObject.SetActiveEx(true);
                roleItem.Initialize(roleCfg[i]);
            }
        }
    }
}