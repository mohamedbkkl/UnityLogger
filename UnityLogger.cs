using System.Collections.Generic;
using UnityEngine;

namespace Plugins
{
    public class UnityLogger
    {
        private readonly string loggerName;
        private readonly string hexColor;
        
        private readonly Dictionary<LogType, Color> ColorMap = new()
        {
            { LogType.Network,   new Color(0.3f, 0.7f, 1.0f, 1.0f) },    // Light Blue
            { LogType.FireBase,  new Color(0.2f, 0.8f, 0.3f, 1.0f) },    // Green
            { LogType.UI_UX,     new Color(1.0f, 0.9f, 0.2f, 1.0f) },    // Yellow
            { LogType.GameLogic, new Color(1.0f, 0.6f, 0.2f, 1.0f) },    // Orange
            { LogType.Data,      new Color(0.8f, 0.4f, 0.9f, 1.0f) },    // Purple
            { LogType.Other,     new Color(0.7f, 0.7f, 0.7f, 1.0f) }     // Gray
        };

        public void LogInfo(string message)
        {
            if (Application.isEditor)
                Debug.Log($"<color=#{hexColor}>[{loggerName}] {message}</color>");
        }

        public void LogWarning(string message)
        {
            if (Application.isEditor)
                Debug.LogWarning($"[{loggerName}] {message}");
        }

        public void LogError(string message)
        {
            if (Application.isEditor)
                Debug.LogError($"[{loggerName}] {message}");
        }

        public UnityLogger(string loggerName, LogType logType = LogType.Other)
        {
            this.loggerName = loggerName;
            hexColor = ColorUtility.ToHtmlStringRGBA(ColorMap[logType]);
        }

        public enum LogType
        {
            Network,
            FireBase,
            UI_UX,
            GameLogic,
            Data,
            Other
        }
    }
}