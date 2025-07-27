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
}
