﻿using System;
using Tests.ExerciseOne;
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
                        .AddTestDefintion(new SingletonDefintion());
            }

            throw new Exception("no ExericseDefition Found fo exercise");
        }
    }
}