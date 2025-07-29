using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI层级类型
/// </summary>
public enum eUIHierarchy
{
    Resident,   // 常驻UI 固定显示在最低层 且不会被关闭
    Common,     // 通用UI 默认只能同时显示一个，并会互相排斥 
    Popup,      // 弹窗UI 可以存在与Common节点上，可以重叠也可以互斥
    Tips,       // 提示UI 最上层级，数量和存在不受限制
}

/// <summary>
/// PopupMask透明模式
/// </summary>
public enum ePopupMaskType
{
    Translucence,   // 半透明
    AllBlack,       // 全黑
    FullyTranslucence, // 全透明
}

/// <summary>
/// PopupMask点击功能
/// </summary>
public enum ePopupMaskClickFun
{
    Mask,   // 无功能，不可穿透
    None,   // 无功能，可穿透
    Close,  // 关闭当前界面
}

/// <summary>
/// PopupUI模式 
/// </summary>
public enum ePopupUIPattern
{
    Sole, // 关闭上一层UI
    More, // 不处理
}

/// <summary>
/// UI枚举
/// </summary>
public enum eUIType
{
    MainUI,
    RoleUI,
    RoleInfoUI,
    LevelUI,
    LevelPlayUI,
}

public struct UIData
{
    public eUIType Type;
    public eUIHierarchy Hierarchy;
    public string Name;
    public string Path;

    public UIData(eUIType type,eUIHierarchy uIHierarchy,string name,string path)
    {
        Type = type;
        Hierarchy = uIHierarchy;
        Name = name;
        Path = path;
    }
}

public static class UIDataDefault
{
    public static UIData MainUI = new UIData(eUIType.MainUI, eUIHierarchy.Resident, "MianUI", "Prefab/UI/MainUI");
    public static UIData RoleUI = new UIData(eUIType.RoleUI, eUIHierarchy.Common, "RoleUI", "Prefab/UI/Role/RoleUI");
    public static UIData RoleInfoUI = new UIData(eUIType.RoleInfoUI, eUIHierarchy.Popup, "RoleInfoUI", "Prefab/UI/Role/RoleInfoUI");
    public static UIData LevelUI = new UIData(eUIType.LevelUI, eUIHierarchy.Common, "LevelUI", "Prefab/UI/Level/LevelUI");
    public static UIData LevelPlayUI = new UIData(eUIType.LevelPlayUI, eUIHierarchy.Popup, "LevelPlayUI", "Prefab/UI/Level/LevelPlayUI");
}
