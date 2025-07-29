using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PopupUIBase : UIBase
{
     [HideInInspector] public ePopupMaskType MaskType;
     [HideInInspector] public ePopupMaskClickFun MaskClickFun;
     [HideInInspector] public ePopupUIPattern PopupPattern;

     public override void InitUISetting()
     {
          SetMask();
          SetPattern();
     }

     /// <summary>
     /// 设置遮罩信息
     /// </summary>
     protected virtual void SetMask()
     {
          MaskType = ePopupMaskType.Translucence;
          MaskClickFun = ePopupMaskClickFun.Close;
     }
     /// <summary>
     /// 设置PopupUI信息
     /// </summary>
     protected virtual void SetPattern()
     {
          PopupPattern = ePopupUIPattern.Sole;
     }
     
    
}
