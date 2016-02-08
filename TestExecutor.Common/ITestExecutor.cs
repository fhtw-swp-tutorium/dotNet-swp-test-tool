using TestExecutor.Common.TestResultEntities;

namespace TestExecutor.Common
{
    public interface ITestExecutor
    {
        TestResult Run(string exePath, string exercise);
    }
}