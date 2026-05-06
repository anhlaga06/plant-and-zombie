using System;
using UnityEngine;

static class Log
{
    public enum Level
    {
        Verbose,
        Debug,
        Info,
        Error
    }

    public static Level level = Level.Verbose;

    public static void Verbose(object message)
    {
        Write(Level.Verbose, message, null);
    }

    public static void Verbose(object message, UnityEngine.Object context)
    {
        Write(Level.Verbose, message, context);
    }

    public static void Debug(object message)
    {
        Write(Level.Debug, message, null);
    }

    public static void Debug(object message, UnityEngine.Object context)
    {
        Write(Level.Debug, message, context);
    }

    public static void Info(object message)
    {
        Write(Level.Info, message, null);
    }

    public static void Info(object message, UnityEngine.Object context)
    {
        Write(Level.Info, message, context);
    }

    public static void Error(object message)
    {
        Write(Level.Error, message, null);
    }

    public static void Error(object message, UnityEngine.Object context)
    {
        Write(Level.Error, message, context);
    }

    public static void Error(Exception exception)
    {
        Write(Level.Error, exception?.ToString() ?? "null", null);
    }

    static void Write(Level messageLevel, object message, UnityEngine.Object context)
    {
        if (messageLevel < level)
        {
            return;
        }

        var finalMessage = message?.ToString() ?? "null";

        switch (messageLevel)
        {
            case Level.Verbose:
                if (context != null) UnityEngine.Debug.Log($"[VERBOSE] {finalMessage}", context);
                else UnityEngine.Debug.Log($"[VERBOSE] {finalMessage}");
                break;
            case Level.Debug:
                if (context != null) UnityEngine.Debug.Log($"[DEBUG] {finalMessage}", context);
                else UnityEngine.Debug.Log($"[DEBUG] {finalMessage}");
                break;
            case Level.Info:
                if (context != null) UnityEngine.Debug.Log($"[INFO] {finalMessage}", context);
                else UnityEngine.Debug.Log($"[INFO] {finalMessage}");
                break;
            case Level.Error:
                if (context != null) UnityEngine.Debug.LogError($"[ERROR] {finalMessage}", context);
                else UnityEngine.Debug.LogError($"[ERROR] {finalMessage}");
                break;
            default:
                if (context != null) UnityEngine.Debug.Log(finalMessage, context);
                else UnityEngine.Debug.Log(finalMessage);
                break;
        }
    }
}
