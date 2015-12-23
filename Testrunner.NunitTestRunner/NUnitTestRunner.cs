using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using NUnit.Framework.Api;
using Test.Common;
using Testrunner.Common;
using Tests.ExerciseOne;
using Tests.ExerciseOne.ObserverTest;
using ReflectionContext = Test.Common.ReflectionContext;

namespace Testrunner.NunitTestRunner
{
    public class NUnitTestRunner
    {
        public TestRunnerResult Run(Arguments arguments)
        {
            var exerciseTestDefintion = ExerciseTestDefintionFactory.Get(arguments.Exercise);

            ReflectionContext.Initialize(arguments.ExePath);

            foreach (var testDefintion in exerciseTestDefintion.TestDefintions)
            {
                var defaultTestAssemblyBuilder = new DefaultTestAssemblyBuilder();

                var nUnitTestAssemblyRunner = new NUnitTestAssemblyRunner(defaultTestAssemblyBuilder);
                nUnitTestAssemblyRunner.Load(Assembly.GetAssembly(testDefintion.GetAssemblyType), new Dictionary<string, string>());

                var testListener = new OwnTestListener();

                nUnitTestAssemblyRunner.Run(testListener, new TestCaseFilter());

                var results = testListener.Results;

                foreach (var result in results)
                {
                    if (result.Test.IsSuite) continue;
                    Console.WriteLine(result.ResultState.Status + " " + result.Message + "");
                }
            }

            return null;

        }

        public class ExerciseTestDefintionFactory
        {
            public static ExerciseTestDefintion Get(Exercise exercise)
            {
                switch (exercise.ExerciseAbbreviation)
                {
                    case "ue1":
                        return new ExerciseTestDefintion().AddTestDefintion(new ObserverDefintion());
                }

                throw new Exception("no ExericseDefition Found fo exercise");
            }
        }

        public class ExerciseTestDefintion
        {
            public List<ITestDefintion> TestDefintions { get; private set; }

            public ExerciseTestDefintion()
            {
                TestDefintions = new List<ITestDefintion>();
            }

            public ExerciseTestDefintion AddTestDefintion(ITestDefintion testDefintion)
            {
                TestDefintions.Add(testDefintion);
                return this;
            }
        }
    }
}