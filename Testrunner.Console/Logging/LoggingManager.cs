using System;
using System.Configuration;
using Serilog;

namespace Testrunner.Core
{
    internal class LoggingManager
    {
        public ILogger GetLogger()
        {
            try
            {
                return new LoggerConfiguration()
                    .WriteTo.AzureDocumentDB(new Uri(ConfigurationManager.AppSettings.Get("DocumentDbEndpoint2")), ConfigurationManager.AppSettings.Get("DocumentDbSeed"))
                    .WriteTo.RollingFile("CheckSwpProject.log")
                    .CreateLogger();
            }
            catch (Exception)
            {
                return new LoggerConfiguration()
                    .WriteTo.RollingFile("CheckSwpProject.log")
                    .CreateLogger();
            }
        }
    }
}