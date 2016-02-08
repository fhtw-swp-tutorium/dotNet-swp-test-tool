using System;
using System.Configuration;
using Autofac;
using Common;
using Serilog;
using TestExecutor.Common;
using TestExecutor.Nunit;
using Testrunner.Common.Arguments;
using Testrunner.Console.ArgumentParsing;
using Testrunner.Console.Logging;

namespace Testrunner.Console
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var containerBuilder = new ContainerBuilder();

            ConfigureLogging(containerBuilder);

            containerBuilder.RegisterType<ArgumentParser>().As<IArgumentParser>();
            containerBuilder.RegisterType<NUnitTestRunner>().As<ITestExecutor>();
            containerBuilder.RegisterType<Application>().AsSelf();
            return containerBuilder.Build();
        }

        private static void ConfigureLogging(ContainerBuilder containerBuilder)
        {
            var endpoint = new Uri(ConfigurationManager.AppSettings.Get("DocumentDbEndpoint"));
            var seed = ConfigurationManager.AppSettings.Get("DocumentDbSeed");

            ILogger seriLogger;

            try
            {
                seriLogger = new LoggerConfiguration()
                    .WriteTo.AzureDocumentDB(endpoint, seed)
                    .WriteTo.RollingFile("CheckSwpProject.log")
                    .CreateLogger();
            }
            catch (Exception)
            {
                seriLogger = new LoggerConfiguration()
                    .WriteTo.RollingFile("CheckSwpProject.log")
                    .CreateLogger();
            }

            var consoleLogger = new ConsoleLogger(seriLogger);

            containerBuilder.RegisterInstance(consoleLogger).As<ILoggerFacade>().SingleInstance();
        }
    }
}