using System;

namespace Common
{
    public interface ILoggerFacade
    {
        void Error(string message);
        void Fatal(string message, Exception e);
    }
}