using System.Collections.Generic;
using Tests.Common;

namespace TestExecutor.Nunit.ExerciseTestDefintion
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