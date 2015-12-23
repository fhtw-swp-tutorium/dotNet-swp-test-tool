using System.Collections.Generic;
using System.Linq;
using Testrunner.Common;

namespace TestExecutor.Nunit
{
    public class TestResult
    {
        public TestResult()
        {
            TestGroupResults = new List<TestCaseGroupResult>();
        }

        public IReadOnlyCollection<TestCaseGroupResult> TestGroupResults { get; private set; }
        public int TestCaseCount { get { return TestGroupResults.Sum(tg => tg.TestCasesCount); } }
        public int TestCaseSuccessCount { get { return TestGroupResults.Sum(tg => tg.TestCaseSuccessCount); } }
        public int TestCaseFailureCount { get { return TestGroupResults.Sum(tg => tg.TestCaseFailureCount); } }

        public void AddTestCaseGroupResult(TestCaseGroupResult testCaseGroupResult)
        {
            TestGroupResults = new List<TestCaseGroupResult>(TestGroupResults) { testCaseGroupResult };
        }
    }
}