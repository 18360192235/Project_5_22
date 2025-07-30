public abstract class CachedDataBase<T>
{   
    private T _value;

    public T Value
    {
        get { return _value; }
        private set { _value = value; }
    }

    public virtual void OnReload()
    {
        
    }
}
