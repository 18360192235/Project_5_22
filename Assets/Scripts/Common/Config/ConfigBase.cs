using UnityEngine;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class ConfigBase<T>
{
    protected abstract string Path { get; }
    protected string defaultValue = "{}";
    protected T _data;

    /// <summary>
    /// 初始化配置
    /// </summary>
    public virtual void Init()
    {
        // 加载 Resources/Cfgs/Path.json
        string fullPath = $"Cfgs/{Path}";
        TextAsset configAsset = Resources.Load<TextAsset>(fullPath);
        string json = configAsset != null ? configAsset.text : defaultValue;
        _data = JsonConvert.DeserializeObject<T>(json);
        //_data = JsonUtility.FromJson<T>(json);
    }
}