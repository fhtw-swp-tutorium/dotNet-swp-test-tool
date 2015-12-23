using System;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Filters;

namespace Testrunner.NunitTestRunner
{
    public class TestMethodFilter : ValueMatchFilter
    {
        public TestMethodFilter() : base(String.Empty) { }

        public override bool Match(ITest test)
        {
            return (test is TestMethod);
        }

        protected override string ElementName
        {
            get { return "all"; }
        }
    }
}