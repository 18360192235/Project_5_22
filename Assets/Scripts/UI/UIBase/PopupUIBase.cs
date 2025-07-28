using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PopupUIBase : UIBase
{
     public ePopupMaskType MaskType;
     public ePopupMaskClickFun MaskClickFun;
     /// <summary>
     /// 设置遮罩信息
     /// </summary>
     protected virtual void SetMask()
     {
          MaskType = ePopupMaskType.Translucence;
          MaskClickFun = ePopupMaskClickFun.Close;
     }
    
}
