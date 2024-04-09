using System;

namespace LoggingKata
{
    public class TacoLogger : ILog
    {
        public void LogFatal(string log, Exception exception = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Fatal: {log}, Exception {exception}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void LogError(string log, Exception exception = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Error: {log}, Exception {exception}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void LogWarning(string log)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Warning: {log}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void LogInfo(string log)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Info: {log}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public void LogDebug(string log)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Debug: {log}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
