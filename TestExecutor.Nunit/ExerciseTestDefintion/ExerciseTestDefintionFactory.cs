using System;
using Tests.ExerciseOne;

namespace TestExecutor.Nunit
{
    public class ExerciseTestDefintionFactory
    {
        public static ExerciseTestDefintion Get(string exercise)
        {
            switch (exercise)
            {
                case "ue1":
                    return new ExerciseTestDefintion().AddTestDefintion(new ObserverDefintion());
            }

            throw new Exception("no ExericseDefition Found fo exercise");
        }
    }
}