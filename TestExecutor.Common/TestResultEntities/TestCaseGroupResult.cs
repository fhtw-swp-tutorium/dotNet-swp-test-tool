using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestExecutor.Common.TestResultEntities
{

    public class TestCaseGroupResult
    {
        public string TestGroupName { get; private set; }
        public IReadOnlyList<string> Errors { private set; get; }
        public int TestCasesCount { get; private set; }
        public int TestCaseFailureCount { get; private set; }
        public int TestCaseSuccessCount { get { return TestCasesCount - TestCaseFailureCount; } }
        
        public TestCaseGroupResult(string testGroupName)
        {
            TestGroupName = testGroupName;
            Errors = new List<string>();
        }

        public void AddError(string message)
        {
            var errorList = new List<string>(Errors) {message};
            Errors = new ReadOnlyCollection<string>(errorList);
            TestCaseFailureCount++;
        }

        public void IncrementTestCaseCount()
        {
            TestCasesCount++;
        }
    }
}