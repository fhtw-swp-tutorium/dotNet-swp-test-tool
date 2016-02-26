using System;
using Tests.Command;
using Tests.Observer;
using Tests.Singleton;

namespace TestExecutor.Nunit.ExerciseTestDefintion
{
    public class ExerciseTestDefintionFactory
    {
        public static ExerciseTestDefintion Get(string exercise)
        {
            switch (exercise)
            {
                case "ue1":
                    return new ExerciseTestDefintion()
                        .AddTestDefintion(new ObserverDefintion())
                        .AddTestDefintion(new SingletonDefintion())
                        .AddTestDefintion(new CommandDefintion());
            }

            throw new Exception("no ExericseDefition Found fo exercise");
        }
    }
}