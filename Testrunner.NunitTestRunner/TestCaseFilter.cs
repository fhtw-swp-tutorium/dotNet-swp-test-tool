using System;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal.Filters;

namespace Testrunner.NunitTestRunner
{
    public class TestCaseFilter : ValueMatchFilter
    {
        public TestCaseFilter() : base(String.Empty) { }

        public override bool Match(ITest test)
        {
            return !test.IsSuite;
        }

        protected override string ElementName
        {
            get { return "all"; }
        }
    }
}