using System;
using System.Linq;
using System.Reflection;
using Common;
using TestExecutor.Common;
using TestExecutor.Common.FacadeInterfaces;
using TestExecutor.Common.TestResultEntities;
using Testrunner.Common.Arguments;
using Testrunner.Console.Logging;

namespace Testrunner.Console
{
    public class Application
    {
        private readonly ITestExecutor _testExecutor;
        private readonly ILoggerFacade _logger;

        public Application(ITestExecutor testExecutor, ILoggerFacade logger)
        {
            _testExecutor = testExecutor;
            _logger = logger;
        }

        public void Run(Arguments arguments)
        {
            PrintVersion();

            if (!arguments.IsValid)
            {
                _logger.Error("Usage: CheckSwpProject.exe -exe pathToExe (-ue1|-ue2|-ue3)");
                return;
            }

            try
            {
                var testResult = _testExecutor.Run(arguments.ExePath, arguments.Exercise.ExerciseAbbreviation);
                PrintTestResult(testResult);
            }
            catch (SwpTestToolException e)
            {
                _logger.Fatal(e.Message, e);
            }
            catch (Exception e)
            {
                _logger.Fatal("uncaught exception", e);
            }

            System.Console.ReadKey();
        }

        private static void PrintVersion()
        {
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

            System.Console.WriteLine();
            ColorConsole.WriteLine(ConsoleColor.DarkCyan, ConsoleColor.Black, "CheckSwpProject (C#) v." + assemblyVersion);
            System.Console.WriteLine();
        }

        private static void PrintTestResult(TestResult testResult)
        {
            const string tabulator = "       ";

            testResult.TestGroupResults.ToList().ForEach(tgr =>
            {
                ColorConsole.WriteLine(ConsoleColor.White, ConsoleColor.Black, tgr.TestGroupName + ":");
                System.Console.WriteLine("{0}{1}/{2} Tests passed", tabulator, tgr.TestCaseSuccessCount, tgr.TestCasesCount);

                tgr.Errors.ToList().ForEach(err =>
                {
                    System.Console.WriteLine();
                    ColorConsole.WriteLine(ConsoleColor.Red, ConsoleColor.White, tabulator + "Error:");
                    System.Console.WriteLine("{0}{1}", tabulator, err);
                });

                System.Console.WriteLine();
            });

            System.Console.WriteLine();
            ColorConsole.WriteLine(ConsoleColor.White, ConsoleColor.Black, "Total: " + testResult.TestCaseSuccessCount + "/" + testResult.TestCaseCount + " Tests passed");
        }
    }
}