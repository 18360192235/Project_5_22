public static class DebugEr
{
    public static void Log(string message)
    {
        if (GameDefault.OpenLog)
        {
            UnityEngine.Debug.Log(message);
        }
    }

    public static void LogError(string message)
    {
        if (GameDefault.OpenLog)
        {
            UnityEngine.Debug.LogError(message);
        }
    }

    public static void LogWarning(string message)
    {
        if (GameDefault.OpenLog)
        {
            UnityEngine.Debug.LogWarning(message);
        }
    }
}