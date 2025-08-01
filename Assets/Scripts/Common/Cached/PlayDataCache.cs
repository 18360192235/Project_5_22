public class PlayDataCache : CachedDataBase<PlayDataInfo>
{
    protected override string Path => "PlayData";
    
    public PlayDataCache()
    {
        defaultValue = "{}";
        OnReload();
    }
}

public class PlayDataInfo
{
    public int playLevel;
}