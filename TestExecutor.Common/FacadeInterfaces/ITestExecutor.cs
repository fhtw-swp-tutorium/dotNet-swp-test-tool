using TestExecutor.Nunit;
using Testrunner.Common;

namespace Testrunner.NunitTestRunner
{
    public interface ITestExecutor
    {
        TestResult Run(string exePath, string exercise);
    }
}