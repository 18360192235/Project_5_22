using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleItem : MonoBehaviour
{
    private Image _icon;
    private Text _name;
    private Text _level;
    private Button _selectBtn;

    private bool _isInit = false;
    private RoleListItem _data;

    public void Initialize(RoleListItem data)
    {
        InitComponent();
        _data = data;
        _name.text = _data.name;
    }
    
    public void InitComponent()
    {
        if(_isInit) return;
        _isInit = true;
        _icon = transform.FindComponent<Image>("Icon");
        _name = transform.FindComponent<Text>("TextName");
        _level = transform.FindComponent<Text>("TextLevel");
        _selectBtn = transform.FindComponent<Button>("SelectButton");
        
        _selectBtn.AddOnClick(OnClickSelectBtn);
    }

    private void OnClickSelectBtn()
    {
        DebugEr.Log($"Click {_data.name}");
    }
    
    #region 生命周期

    private void Awake()
    {
        InitComponent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
