using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Common;
using NUnit.Framework.Api;
using TestExecutor.Common;
using TestExecutor.Common.Reflection;
using TestExecutor.Nunit.ExerciseTestDefintion;
using TestExecutor.Nunit.NUnitTestRunnerUtils;
using TestResult = TestExecutor.Common.TestResultEntities.TestResult;

namespace TestExecutor.Nunit
{
    public class NUnitTestRunner : ITestExecutor
    {
        private readonly ILoggerFacade _loggerFacade;

        public NUnitTestRunner(ILoggerFacade loggerFacade)
        {
            _loggerFacade = loggerFacade;
        }

        public TestResult Run(string exePath, string exercise)
        {
            if(!File.Exists(exePath))
                throw new SwpTestToolException("Der angegebene Pfad führt zu keiner Exe Datei");

            TypeProvider.Initialize(_loggerFacade, exePath);

            var exerciseTestDefintion = ExerciseTestDefintionFactory.Get(exercise);

            var defaultTestAssemblyBuilder = new DefaultTestAssemblyBuilder();
            var nUnitTestAssemblyRunner = new NUnitTestAssemblyRunner(defaultTestAssemblyBuilder);

            var testGroupResults = new TestResult();

            foreach (var testDefintion in exerciseTestDefintion.TestDefintions)
            {
                if(!TypeProvider.CheckIfAttributesExist()) break;
                if(!TypeProvider.CheckCorrectVersionOfAttributes(testDefintion.GetAssemblyIdentifier)) break;
                
                var testListener = new CustomTestListener(testDefintion.TestGroupName);
                nUnitTestAssemblyRunner.Load(Assembly.GetAssembly(testDefintion.GetAssemblyIdentifier), new Dictionary<string, string>());
                nUnitTestAssemblyRunner.Run(testListener, new TestMethodFilter());
                testGroupResults.AddTestCaseGroupResult(testListener.TestCaseGroupResult);
            }

            return testGroupResults;
        }
    }
}