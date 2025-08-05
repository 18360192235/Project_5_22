
using System.Collections.Generic;

public enum RoundOperationType
{
    None = 0, // 异常不处理
    RoundEnd = 1, // 回合结束
    SkillEffect = 2, // 技能效果
    BuffEffect = 3, // Buff效果
    PropEffect = 4, // 道具效果
    CardEffect = 5, // 卡牌效果
}
public class GameRoundMgr : Single<GameRoundMgr>
{
    private List<RoundItemBase> roundItems = new List<RoundItemBase>();
    // 一名单位对应行动条的一个单位 行动条上不会同时存在相同的两个单位
    // 单位进场时添加 离场时移除 
    // 现在需要一个储存方式可以快速重新排列行动条
#region 对外接口

    /// <summary>
    /// 添加回合单位
    /// 传入单位信息
    /// </summary>
    /// <param name="item"></param>
    public void AddUnit()
    {
        // 查询单位信息后传入内部接口
        //AddRoundItem();
    }

    /// <summary>
    /// 移除回合单位
    /// 传入单位id
    /// </summary>
    /// <param name="item"></param>
    public void RemoveUnit()
    {
        // 查询单位信息后传入内部接口
        //RemoveRoundItem();
    }

    /// <summary>
    /// 回合结束
    /// </summary>
    public void RoundEnd()
    {
        
    }
    
#endregion
    
    
    /// <summary>
    /// 添加回合单位
    /// </summary>
    /// <param name="item"></param>
    private void AddRoundItem(RoundItemBase item)
    {
        
    }
    /// <summary>
    /// 移除回合单位
    /// </summary>
    /// <param name="item"></param>
    private void RemoveRoundItem(RoundItemBase item)
    {
        
    }
    
    /// <summary>
    /// 进入下一回合
    /// </summary>
    private void NextRound()
    {
        
    }
}
