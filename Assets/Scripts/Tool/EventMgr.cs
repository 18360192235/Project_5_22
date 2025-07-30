using System;

public class EventMgr
{
    public static EventAction startEvent = new EventAction(); // 测试样例
    public static EventAction<int> startEvent1 = new EventAction<int>();
}


public class EventAction
{
    private Action _action;

    public void AddEvent(Action action)
    {
        if (action != null)
        {
            _action += action;
        }
    }

    public void RemoveEvent(Action action)
    {
        if (action != null)
        {
            _action -= action;
        }
    }

    public void Invoke()
    {
        _action.Invoke();
    }
}

public class EventAction<T>
{
    private Action<T> _action;

    public void AddEvent(Action<T> action)
    {
        if (action != null)
        {
            _action += action;
        }
    }

    public void RemoveEvent(Action<T> action)
    {
        if (action != null)
        {
            _action -= action;
        }
    }

    public void Invoke(T value)
    {
        _action.Invoke(value);
    }
}

public class EventAction<T1,T2>
{
    private Action<T1,T2> _action;

    public void AddEvent(Action<T1,T2> action)
    {
        if (action != null)
        {
            _action += action;
        }
    }

    public void RemoveEvent(Action<T1,T2> action)
    {
        if (action != null)
        {
            _action -= action;
        }
    }

    public void Invoke(T1 value1 ,T2 value2)
    {
        _action.Invoke(value1,value2);
    }
}

public class EventAction<T1,T2,T3>
{
    private Action<T1,T2,T3> _action;

    public void AddEvent(Action<T1,T2,T3> action)
    {
        if (action != null)
        {
            _action += action;
        }
    }

    public void RemoveEvent(Action<T1,T2,T3> action)
    {
        if (action != null)
        {
            _action -= action;
        }
    }

    public void Invoke(T1 value1 ,T2 value2,T3 value3)
    {
        _action.Invoke(value1, value2, value3);
    }
}