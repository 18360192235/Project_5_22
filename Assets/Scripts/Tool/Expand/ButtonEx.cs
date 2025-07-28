using UnityEngine.Events;
using UnityEngine.UI;

public static class ButtonEx
{

    public static void AddOnClick(this Button btn, UnityAction action)
    {
        if (btn != null)
        {
            btn.onClick.AddListener(action);
        }
    }

    public static void OnRemoveClick(this Button btn, UnityAction action)
    {
        if (btn != null)
        {
            btn.onClick.RemoveListener(action);
        }
    }

    public static void OnRemoveAllClick(this Button btn)
    {
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
        }
    }
}