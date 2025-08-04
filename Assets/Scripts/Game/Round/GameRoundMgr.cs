
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
}

/// <summary>
/// 回合数据基类 一个单位只有一个回合基类
/// 提供回合信息
/// 以及到回合时主动发送消息进行通知
/// </summary>
public abstract class RoundItemBase
{
    public long roundId; // 回合ID
    public long roleId; // 角色ID
    public long roundValue; // 回合行动值
    
    /// <summary>
    /// 扣减行动值（行动提前）
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    public virtual void OnReduceRoundValue(RoundOperationType type,long value)
    {
        // 减少回合值 行动值小于等于0会进行行动
        // 这里可以添加具体的逻辑
    }

    /// <summary>
    /// 添加行动值（行动延后）
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    public virtual void OnAddRoundValue(RoundOperationType type, long value)
    {
        // 减少回合值 行动值小于等于0会进行行动
        // 这里可以添加具体的逻辑
    }

    /// <summary>
    /// 回合结束时调用 根据角色信息重新获取行动值并插入行动队列
    /// 额外回合不重置行动值
    /// </summary>
    public abstract void OnRoundEnd();

    /// <summary>
    /// 回合开始
    /// </summary>
    public abstract void OnRoundStart();
}