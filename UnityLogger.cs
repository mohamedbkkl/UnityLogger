using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// Provides color-coded logging utilities for Unity editor development, 
    /// supporting context-specific logger names and log types.
    /// </summary>
    public class UnityLogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityLogger"/> class with the specified logger name and log type.
        /// </summary>
        /// <param name="loggerName">The name to display as the log context.</param>
        /// <param name="logType">The log type determining the message color. Defaults to <see cref="LogType.Other"/> if not specified.</param>
        public UnityLogger(string loggerName, LogType logType = LogType.Other)
        {
            this.loggerName = loggerName;
            hexColor = ColorUtility.ToHtmlStringRGBA(ColorMap[logType]);
        }
        
        /// <summary>
        /// Enumeration of supported log types for categorizing log output.
        /// </summary>
        public enum LogType
        {
            /// <summary>Networking-related log messages.</summary>
            Network,
            /// <summary>User Interface log messages.</summary>
            UI,
            /// <summary>User Experience log messages.</summary>
            UX,
            /// <summary>Core gameplay logic log messages.</summary>
            GameLogic,
            /// <summary>Data or persistence log messages.</summary>
            Data,
            /// <summary>Ads or monetization log messages.</summary>
            Ads, // <-- Added for Ads
            /// <summary>Other miscellaneous log messages.</summary>
            Other
        }

        // Maps log types to their associated colors for log visualization.
        private readonly Dictionary<LogType, Color> ColorMap = new()
        {
            { LogType.Network, new Color(0.25f, 0.5f, 0.95f, 1.0f) },
            { LogType.UI, new Color(0.65f, 0.45f, 0.85f, 1.0f) },
            { LogType.UX, new Color(1.0f, 0.8f, 0.0f, 1.0f) },
            { LogType.GameLogic, new Color(0.95f, 0.3f, 0.2f, 1.0f) },
            { LogType.Data, new Color(0.5f, 1.0f, 0.0f, 1.0f) },
            { LogType.Ads, new Color(0.15f, 0.85f, 0.80f, 1.0f) },
            { LogType.Other, new Color(0.6f, 0.6f, 0.6f, 1.0f) }
        };
        
        // The display name used for log messages.
        private readonly string loggerName;
        // Cached hex color string for log message coloring.
        private readonly string hexColor;

        #region Internal

        /// <summary>
        /// Logs an informational message to the Unity console in the Editor, 
        /// using colored text based on the logger's log type.
        /// </summary>
        /// <param name="message">The informational message to log.</param>
        public void LogInfo(string message)
        {
            LogInfoGlobal(loggerName, $"<color=#{hexColor}>{message}</color>");
        }
        /// <summary>
        /// Logs a warning message to the Unity console in the Editor.
        /// </summary>
        /// <param name="message">The warning message to log.</param>
        public void LogWarning(string message)
        {
            LogWarningGlobal(loggerName, message);
        }

        /// <summary>
        /// Logs an error message to the Unity console in the Editor.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        public void LogError(string message)
        {
            LogErrorGlobal(loggerName, message);
        }

        #endregion

        #region Global

        /// <summary>
        /// Logs an informational message globally to the Unity console (Editor only).
        /// </summary>
        /// <param name="loggerName">The context logger name for the log entry.</param>
        /// <param name="message">The informational message to log.</param>
        public static void LogInfoGlobal(string loggerName, string message)
        {
#if DEVELOPMENT_BUILD || UNITY_EDITOR
            Debug.Log($"[{loggerName}] {message}");
#endif
        }

        /// <summary>
        /// Logs a warning message globally to the Unity console (Editor only).
        /// </summary>
        /// <param name="loggerName">The context logger name for the warning.</param>
        /// <param name="message">The warning message to log.</param>
        public static void LogWarningGlobal(string loggerName, string message)
        {
#if DEVELOPMENT_BUILD || UNITY_EDITOR
            Debug.LogWarning($"[{loggerName}] {message}");
#endif
        }

        /// <summary>
        /// Logs an error message globally to the Unity console (Editor only).
        /// </summary>
        /// <param name="loggerName">The context logger name for the error.</param>
        /// <param name="message">The error message to log.</param>
        public static void LogErrorGlobal(string loggerName, string message)
        {
#if DEVELOPMENT_BUILD || UNITY_EDITOR
            Debug.LogError($"[{loggerName}] {message}");
#endif
        }

        #endregion
    }
}