using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class TransformEx
{
    public static void SetActiveEx(this Transform tran,bool value)
    {
        if (tran != null)
        {
            if (tran.gameObject.activeInHierarchy != value)
            {
                tran.gameObject.SetActive(value);
            }
        }
    }
    public static void SetActiveEx(this GameObject obj,bool value)
    {
        if (obj != null)
        {
            if (obj.activeInHierarchy != value)
            {
                obj.SetActive(value);
            }
        }
    }

    public static T FindComponent<T>(this Transform tran, string path = "") where T : Component
    {
        if (tran != null)
        {
            Transform componentTran = tran;
            if (!string.IsNullOrEmpty(path))
            {
                componentTran = tran.Find(path);
            }

            if (componentTran != null)
            {
                return componentTran.GetComponent<T>();
            }
        }
        string tranName = tran == null ? "NULL" : tran.name;
        DebugEr.LogError($"FindComponent not Find Component Path = {path} tran = {tranName}");
        return null;
    }
    public static T FindComponent<T>(this GameObject obj, string path = "") where T : Component
    {
        if (obj != null)
        {
            Transform componentTran = obj.transform;
            if (!string.IsNullOrEmpty(path))
            {
                componentTran = obj.transform.Find(path);
            }

            if (componentTran != null)
            {
                return componentTran.GetComponent<T>();
            }
        }
        string tranName = obj == null ? "NULL" : obj.name;
        DebugEr.LogError($"FindComponent not Find Component Path = {path} tran = {tranName}");
        return null;
    }
}
