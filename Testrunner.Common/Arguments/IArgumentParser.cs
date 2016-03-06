namespace Testrunner.Common.Arguments
{
    public interface IArgumentParser
    {
        TestRunArguments Parse(string[] args);
    }
}