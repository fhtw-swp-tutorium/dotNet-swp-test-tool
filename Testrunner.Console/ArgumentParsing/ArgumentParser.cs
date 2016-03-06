using System;
using Common;
using NDesk.Options;
using Testrunner.Common.Arguments;
using Testrunner.Console.Logging;

namespace Testrunner.Console.ArgumentParsing
{
    public class ArgumentParser : IArgumentParser
    {
        private readonly ILoggerFacade _loggerFacade;

        public ArgumentParser(ILoggerFacade loggerFacade)
        {
            _loggerFacade = loggerFacade;
        }

        public bool TryParse(string[] args, out TestRunArguments testRunArguments)
        {
            string exePath = null;
            string exercise = null;

            var p = new OptionSet()
            {
                {"e|exercise=", "the name of the exercise. (ue1|ue2|ue3)", v => { exercise = v; }},
                {"p|path=", "the path to the executable.", v => exePath = v}
            };
            
            p.Parse(args);
            
            if (exercise == null || exePath == null)
            {
                PrintUsage(p);

                testRunArguments = new TestRunArguments(null, null);
                return false;
            }

            testRunArguments = new TestRunArguments(exercise.ToLower(), exePath);
            return true;
        }

        private static void PrintUsage(OptionSet p)
        {
            System.Console.WriteLine();
            ColorConsole.WriteLine(ConsoleColor.Red, ConsoleColor.White, "Usage:");
            System.Console.WriteLine();
            p.WriteOptionDescriptions(System.Console.Out);
        }
    }
}