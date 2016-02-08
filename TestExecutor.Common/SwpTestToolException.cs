using System;

namespace TestExecutor.Common
{
    public class SwpTestToolException : Exception
    {
        public SwpTestToolException(string message, Exception innerException) : base(message, innerException) { }

        public SwpTestToolException(string message) : base(message) { }
    }
}