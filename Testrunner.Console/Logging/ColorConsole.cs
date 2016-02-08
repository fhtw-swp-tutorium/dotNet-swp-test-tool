using System;

namespace Testrunner.Console.Logging
{
    public static class ColorConsole
    {
        public static void WriteLine(ConsoleColor background, ConsoleColor foreground, string line)
        {
            System.Console.BackgroundColor = background;
            System.Console.ForegroundColor = foreground;
            System.Console.WriteLine(line);
            System.Console.ResetColor();
        }
    }
}