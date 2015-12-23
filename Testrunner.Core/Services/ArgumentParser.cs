using System;
using System.Linq;
using Testrunner.Common;

namespace Testrunner.Core.Services
{
    public class ArgumentParser
    {
        public Arguments Parse(string[] args)
        {
            var exercises = Exercise.All().ToList();

            args = args.Select(a => a.TrimStart('-')).ToArray();

            var invalidArgumentResult = new Func<Arguments>(() => new Arguments() {IsValid = false});

            if (!args.Contains("exe") || exercises.Count(e => args.Contains(e.ExerciseAbbreviation)) != 1)
                return invalidArgumentResult();

            var exeIndex = Array.IndexOf(args, "exe") + 1;
            if (args.Length <= exeIndex) return invalidArgumentResult();

            var exePath = args[exeIndex];
            if (!exePath.EndsWith(".exe")) return invalidArgumentResult();

            return new Arguments()
            {
                ExePath = args[exeIndex],
                Exercise = exercises.First(e => args.Contains(e.ExerciseAbbreviation)),
                IsValid = true
            };
        }
    }
}