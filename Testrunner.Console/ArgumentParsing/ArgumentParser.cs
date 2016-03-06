using System;
using System.Linq;
using Testrunner.Common.Arguments;

namespace Testrunner.Console.ArgumentParsing
{
    public class ArgumentParser : IArgumentParser
    {
        public TestRunArguments Parse(string[] args)
        {
            var exercises = Exercise.All().ToList();

            args = args.Select(a => a.TrimStart('-')).ToArray();

            var invalidArgumentResult = new Func<TestRunArguments>(() => new TestRunArguments() {IsValid = false});

            if (!args.Contains("exe") || exercises.Count(e => args.Contains(e.ExerciseAbbreviation)) != 1)
                return invalidArgumentResult();

            var exeIndex = Array.IndexOf(args, "exe") + 1;
            if (args.Length <= exeIndex) return invalidArgumentResult();

            var exePath = args[exeIndex];
            if (!exePath.EndsWith(".exe")) return invalidArgumentResult();

            return new TestRunArguments()
            {
                ExePath = args[exeIndex],
                Exercise = exercises.First(e => args.Contains(e.ExerciseAbbreviation)),
                IsValid = true
            };
        }
    }
}