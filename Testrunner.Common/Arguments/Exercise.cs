using System.Collections.Generic;

namespace Testrunner.Common.Arguments
{
    public class Exercise
    {
        public static Exercise Exercise1 = new Exercise("ue1");
        public static Exercise Exercise2 = new Exercise("ue2");
        public static Exercise Exercise3 = new Exercise("ue3");

        public string ExerciseAbbreviation { get; private set; }

        public static IEnumerable<Exercise> All()
        {
            yield return Exercise1;
            yield return Exercise2;
            yield return Exercise3;
        } 

        private Exercise(string exerciseAbbreviation)
        {
            ExerciseAbbreviation = exerciseAbbreviation;
        }
    }
}