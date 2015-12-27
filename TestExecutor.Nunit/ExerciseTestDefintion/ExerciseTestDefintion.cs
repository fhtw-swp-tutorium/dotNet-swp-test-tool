using System.Collections.Generic;
using Tests.Common;

namespace TestExecutor.Nunit.ExerciseTestDefintion
{
    public class ExerciseTestDefintion
    {
        public List<TestDefintionBase> TestDefintions { get; private set; }

        public ExerciseTestDefintion()
        {
            TestDefintions = new List<TestDefintionBase>();
        }

        public ExerciseTestDefintion AddTestDefintion(TestDefintionBase testDefintion)
        {
            TestDefintions.Add(testDefintion);
            return this;
        }
    }
}