namespace Testrunner.Common.Arguments
{
    public interface IArgumentParser
    {
        Arguments Parse(string[] args);
    }
}