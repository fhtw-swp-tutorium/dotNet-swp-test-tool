using System.Collections.Generic;
using Test.Common;

namespace TestExecutor.Nunit
{
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