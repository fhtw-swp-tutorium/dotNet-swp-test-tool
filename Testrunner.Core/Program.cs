using System;
using System.Linq;
using System.Reflection;
using TestExecutor.Nunit;
using Testrunner.Core.Services;
using Testrunner.NunitTestRunner;

namespace Testrunner.Core
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

            var testResult = new NUnitTestRunner().Run(arguments.ExePath, arguments.Exercise.ExerciseAbbreviation);

            PrintTestResult(testResult);

            Console.ReadKey();
        }

        private static void PrintUsage()
        {
            Console.WriteLine();
            var usage = "Usage: CheckSwpProject.exe -exe pathToExe (-ue1|-ue2|-ue3)";
            ColorLine(ConsoleColor.Red, ConsoleColor.White, usage);
            Console.ReadKey();
        }

        private static void PrintTestResult(TestResult testResult)
        {
            const string tabulator = "       ";

            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            
            Console.WriteLine();
            ColorLine(ConsoleColor.DarkCyan, ConsoleColor.Black, "CheckSwpProject (C#) v." + assemblyVersion);
            Console.WriteLine();

            testResult.TestGroupResults.ToList().ForEach(tgr =>
            {
                ColorLine(ConsoleColor.White, ConsoleColor.Black, tgr.TestGroupName + ":");
                Console.WriteLine("{0}{1}/{2} Tests passed", tabulator, tgr.TestCaseSuccessCount, tgr.TestCasesCount);

                tgr.Errors.ToList().ForEach(err =>
                {
                    Console.WriteLine();
                    ColorLine(ConsoleColor.Red, ConsoleColor.White, tabulator + "Error:");
                    Console.WriteLine("{0}{1}", tabulator, err);
                });

                Console.WriteLine();
            });

            Console.WriteLine();
            ColorLine(ConsoleColor.White, ConsoleColor.Black, "Total: " + testResult.TestCaseSuccessCount + "/" + testResult.TestCaseCount + " Tests passed");
        }

        private static void ColorLine(ConsoleColor background, ConsoleColor foreground, string line)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.WriteLine(line);
            Console.ResetColor();
        }
    }
}
