using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace Testrunner.NunitTestRunner
{
    public class OwnTestListener : ITestListener
    {
        public List<ITestResult> Results { get; private set; }

        public OwnTestListener()
        {
            Results = new List<ITestResult>();
        }

        public void TestStarted(ITest test)
        {

        }

        public void TestFinished(ITestResult result)
        {
            Results.Add(result);
        }

    }
}