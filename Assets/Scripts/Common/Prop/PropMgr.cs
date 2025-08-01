using System.Collections.Generic;

public class PropMgr: Single<PropMgr>
{
    private PropCache propCache = new PropCache();

    public override void Init()
    {
        base.Init();
    }
    
    /// <summary>
    /// 添加道具
    /// </summary>
    /// <param name="id"></param>
    /// <param name="num"></param>
    public void AddProp(int id, long num)
    {
        if (propCache.Value.ContainsKey(id))
        {
            propCache.Value[id] += num;
        }
        else
        {
            propCache.Value.Add(id, num);
        }
    }
    
    /// <summary>
    /// 扣减道具
    /// </summary>
    /// <param name="id"></param>
    /// <param name="num"></param>
    public void RemoveProp(int id, long num)
    {
        if (propCache.Value.ContainsKey(id))
        {
            propCache.Value[id] -= num;
            if (propCache.Value[id] <= 0)
            {
                propCache.Value.Remove(id);
            }
        }
    }
    /// <summary>
    /// 查询道具数量
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public long GetPropNum(int id)
    {
        if (propCache.Value.ContainsKey(id))
        {
            return propCache.Value[id];
        }
        return 0;
    }

    /// <summary>
    /// 保存
    /// </summary>
    public void OnSave()
    {
        propCache.OnSave();
    }
}

public class PropCache : CachedDataBase<Dictionary<int,long>>
{
    protected override string Path => "PropData";
    
    public PropCache()
    {
        defaultValue = "{}";
        OnReload();
    }
}