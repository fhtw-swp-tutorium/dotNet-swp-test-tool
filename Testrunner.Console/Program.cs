using System;
using System.Linq;
using System.Reflection;
using TestExecutor.Common.TestResultEntities;
using TestExecutor.Nunit;
using Testrunner.Console.ArgumentParsing;
using Testrunner.Console.Logging;

namespace Testrunner.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var argumentParser = new ArgumentParser();
            var arguments = argumentParser.Parse(args);
            if (!arguments.IsValid)
            {
                PrintUsage();
                return;
            }

            var log= new LoggingManager().GetLogger();

            try
            {
                var testResult = new NUnitTestRunner().Run(arguments.ExePath, arguments.Exercise.ExerciseAbbreviation);
                PrintTestResult(testResult);
            }
            catch (Exception e)
            {
                log.Error(e, "uncaught exception");
                System.Console.WriteLine();
                ColorLine(ConsoleColor.Red, ConsoleColor.White, "Bei Ausführen der Tests in ein Fehler aufgetreten.");
                System.Console.WriteLine(e);
            }

            System.Console.ReadKey();
        }

        private static void PrintUsage()
        {
            System.Console.WriteLine();
            var usage = "Usage: CheckSwpProject.exe -exe pathToExe (-ue1|-ue2|-ue3)";
            ColorLine(ConsoleColor.Red, ConsoleColor.White, usage);
            System.Console.ReadKey();
        }

        private static void PrintTestResult(TestResult testResult)
        {
            const string tabulator = "       ";

            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

            System.Console.WriteLine();
            ColorLine(ConsoleColor.DarkCyan, ConsoleColor.Black, "CheckSwpProject (C#) v." + assemblyVersion);
            System.Console.WriteLine();

            testResult.TestGroupResults.ToList().ForEach(tgr =>
            {
                ColorLine(ConsoleColor.White, ConsoleColor.Black, tgr.TestGroupName + ":");
                System.Console.WriteLine("{0}{1}/{2} Tests passed", tabulator, tgr.TestCaseSuccessCount, tgr.TestCasesCount);

                tgr.Errors.ToList().ForEach(err =>
                {
                    System.Console.WriteLine();
                    ColorLine(ConsoleColor.Red, ConsoleColor.White, tabulator + "Error:");
                    System.Console.WriteLine("{0}{1}", tabulator, err);
                });

                System.Console.WriteLine();
            });

            System.Console.WriteLine();
            ColorLine(ConsoleColor.White, ConsoleColor.Black, "Total: " + testResult.TestCaseSuccessCount + "/" + testResult.TestCaseCount + " Tests passed");
        }

        private static void ColorLine(ConsoleColor background, ConsoleColor foreground, string line)
        {
            System.Console.BackgroundColor = background;
            System.Console.ForegroundColor = foreground;
            System.Console.WriteLine(line);
            System.Console.ResetColor();
        }
    }
}
