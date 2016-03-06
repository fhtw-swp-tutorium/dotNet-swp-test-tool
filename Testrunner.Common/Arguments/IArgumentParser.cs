using System.IO;

namespace Testrunner.Common.Arguments
{
    public interface IArgumentParser
    {
        bool TryParse(string[] args, out TestRunArguments testRunArguments);
    }
}