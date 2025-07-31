using System.IO;
using UnityEngine;

public abstract class CachedDataBase<T>
{
    protected abstract string Path { get; }
    protected string defaultValue = "{}";

    private string practicalPath = "";
    private string PracticalPath
    {
        get
        {
            if (string.IsNullOrEmpty(practicalPath))
            {
                practicalPath = $"{Application.temporaryCachePath}/{Path}.json";
            }
            return practicalPath;
        }
    }
    private T _value;
    
    public T Value
    {
        get { return _value; }
        private set { _value = value; }
    }
    
    public virtual void OnReload()
    {
        string json = defaultValue;
        if (File.Exists(PracticalPath))
        {
            json = File.ReadAllText(PracticalPath);
            if(string.IsNullOrEmpty(json)) json = defaultValue;
            //_value = JsonConvert.DeserializeObject<T>(json);
        }
        _value = JsonUtility.FromJson<T>(json);
    }
    
    public virtual void OnSave()
    {
        //string json = JsonConvert.SerializeObject(_value, Formatting.Indented);
        string json = JsonUtility.ToJson(_value);
        File.WriteAllText(PracticalPath, json);
    }
    
    public void SetValue(T value)
    {
        _value = value;
    }
}
