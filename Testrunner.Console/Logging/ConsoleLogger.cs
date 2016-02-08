using System;
using Common;
using Serilog;

namespace Testrunner.Console.Logging
{
    public class ConsoleLogger : ILoggerFacade
    {
        private readonly ILogger _serilogLogger;

        public ConsoleLogger(ILogger logger)
        {
            _serilogLogger = logger;
        }

        public void Error(string message)
        {
            System.Console.WriteLine();
            ColorConsole.WriteLine(ConsoleColor.Red, ConsoleColor.White, "Bei Ausführen der Tests in ein Fehler aufgetreten.");
            System.Console.WriteLine(message);
        }

        public void Fatal(string message, Exception e)
        {
            Error(message);
            _serilogLogger.Error(e, message);
                
        }
    }
}