using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using TestExecutor.Common.TestResultEntities;

namespace TestExecutor.Nunit.NUnitTestRunnerUtils
{
    public class CustomTestListener : ITestListener
    {
        public TestCaseGroupResult TestCaseGroupResult { get; private set; }

        public CustomTestListener(string testGroupName)
        {
            TestCaseGroupResult = new TestCaseGroupResult(testGroupName);
        }

        public void TestStarted(ITest test){}

        public void TestFinished(ITestResult result)
        {
            if (!(result.Test is TestMethod)) return;
            
            if (!Equals(result.ResultState, ResultState.Success)) TestCaseGroupResult.AddError(result.Message);

            TestCaseGroupResult.IncrementTestCaseCount();
        }

    }
}