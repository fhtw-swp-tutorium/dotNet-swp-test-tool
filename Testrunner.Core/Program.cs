using System;
using Testrunner.Core.Services;
using Testrunner.NunitTestRunner;

namespace Testrunner.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var argumentParser = new ArgumentParser();
            var arguments = argumentParser.Parse(args);
            if (!arguments.IsValid) PrintUsage();

            new NUnitTestRunner().Run(arguments);




            Console.ReadLine();
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage goes here");
        }


    }
}
