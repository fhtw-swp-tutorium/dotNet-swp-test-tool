using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework.Api;
using Testrunner.NunitTestRunner;
using ReflectionContext = Test.Common.ReflectionContext;

namespace TestExecutor.Nunit
{
    public class NUnitTestRunner : ITestExecutor
    {
        public TestResult Run(string exePath, string exercise)
        {
            ReflectionContext.Initialize(exePath);

            var exerciseTestDefintion = ExerciseTestDefintionFactory.Get(exercise);

            var defaultTestAssemblyBuilder = new DefaultTestAssemblyBuilder();
            var nUnitTestAssemblyRunner = new NUnitTestAssemblyRunner(defaultTestAssemblyBuilder);

            var testGroupResults = new TestResult();

            foreach (var testDefintion in exerciseTestDefintion.TestDefintions)
            {
                var testListener = new CustomTestListener(testDefintion.TestGroupName);
                nUnitTestAssemblyRunner.Load(Assembly.GetAssembly(testDefintion.GetAssemblyIdentifier), new Dictionary<string, string>());
                nUnitTestAssemblyRunner.Run(testListener, new TestMethodFilter());
                testGroupResults.AddTestCaseGroupResult(testListener.TestCaseGroupResult);
            }

            return testGroupResults;
        }
    }
}