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
                var arguments = argumentParser.Parse(args);

                var app = scope.Resolve<Application>();
                app.Run(arguments);
            }
        }
    }
}
