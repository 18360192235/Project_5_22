using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMask : MonoBehaviour
{
    private Button _button;
    private Image _image;
    private ePopupMaskType _maskType;
    private ePopupMaskClickFun _clickFun;
    
    private Color TranslucenceColor = new Color(0f, 0f, 0f, 0.5f);
    private Color AllBlackColor = new Color(0f, 0f, 0f, 1f);
    private Color FullyTranslucenceColor = new Color(1f, 1f, 1f, 0f);
    private void Awake()
    {
        _button = transform.FindComponent<Button>("MaskBtn");
        _image = transform.FindComponent<Image>("MaskBtn");
    }

    private void Start()
    {
        _button.AddOnClick(OnClick);
    }

    private void OnDisable()
    {
        _button.OnRemoveClick(OnClick);
    }

    private void OnClick()
    {
        UIManager.Sing.ClickPopupMask(_clickFun);
    }

    public void Show(ePopupMaskType maskType, ePopupMaskClickFun clickFun)
    {
        transform.SetActiveEx(true);
        _maskType = maskType;
        _clickFun = clickFun;
        // 处理显示层级
        SetPopupMaskType();
        // 处理按钮事件
        SetPopupMaskClickFun();
    }

    public void Hide()
    {
        transform.SetActiveEx(false);
    }
    private void SetPopupMaskType()
    {
        switch (_maskType)
        {
            case ePopupMaskType.Translucence:
            {
                _image.color = TranslucenceColor;
                break;
            }
            case ePopupMaskType.AllBlack:
            {
                _image.color = AllBlackColor;
                break;
            }
            case ePopupMaskType.FullyTranslucence:
            {
                _image.color = FullyTranslucenceColor;
                break;
            }
            default: break;
        }

        transform.SetAsLastSibling();
    }

    private void SetPopupMaskClickFun()
    {
        _image.raycastTarget = _clickFun != ePopupMaskClickFun.None;
    }
}
