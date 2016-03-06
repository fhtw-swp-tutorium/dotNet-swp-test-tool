using Autofac;
using Testrunner.Common.Arguments;

namespace Testrunner.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var argumentParser = scope.Resolve<IArgumentParser>();

                TestRunArguments arguments;
                if (!argumentParser.TryParse(args, out arguments))
                {
                    System.Console.ReadLine();
                    return;
                }

                var app = scope.Resolve<Application>();
                app.Run(arguments);
            }
        }
    }
}
