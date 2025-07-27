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
/// UI枚举
/// </summary>
public enum eUIType
{
    MainUI,
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
}
