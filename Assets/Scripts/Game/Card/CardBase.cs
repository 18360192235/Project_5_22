using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardBase
{
    public CardType cardType;
    public abstract void OnUse();
    public abstract void OnGain();
    public abstract void OnRiscard();
}

public enum CardType
{
    ATK, // 攻击
    BUF, // 对自己Buff
    DBF, // 对对方Buff
    DEF, // 防御
    RES, // 特殊效果
}


