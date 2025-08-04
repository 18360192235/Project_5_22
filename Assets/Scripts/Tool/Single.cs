public class Single<T> where T : class, new()
{
    private static T sin;

    public static T single
    {
        get
        {
            if (null == sin) sin = new T();
            return sin;
        }
    }

    public virtual void Init()
    {
    }

    public virtual void OnRefresh()
    {
    }
}
