using TestExecutor.Common.TestResultEntities;

namespace TestExecutor.Common.FacadeInterfaces
{
    public interface ITestExecutor
    {
        TestResult Run(string exePath, string exercise);
    }
}