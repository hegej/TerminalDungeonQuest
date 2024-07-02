using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Utilities
{
    public static class ConsoleStyle
    {
        public static bool UseUnicode { get; set; }


        private const string ANSI_RED = "\u001b[31m";
        private const string ANSI_BLUE = "\u001b[34m";
        private const string ANSI_YELLOW = "\u001b[33m";
        private const string ANSI_RESET = "\u001b[0m";

        public static string SWORD => UseUnicode ? "\u2694" : "/";
        public static string SHIELD => UseUnicode ? "\u1F6E1" : "[";
        public static string MAGIC => UseUnicode ? "\U0001F9D9" : "*";
        public static string SKULL => UseUnicode ? "\U0001F480" : "X";
        public static string CRITICAL => UseUnicode ? "\u2757" : "!";
    
    
        public static void LogAction(string message, LogType type, string symbol = "")
        {
            var colorCode = type switch
            {
                LogType.Enemy => ANSI_RED,
                LogType.Friendly => ANSI_BLUE,
                LogType.Critical => ANSI_YELLOW,
                _ => ANSI_RESET
            };
        }
    
    
    }
}
