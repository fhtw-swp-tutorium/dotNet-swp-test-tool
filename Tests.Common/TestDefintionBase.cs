using System;
using TestExecutor.Common.Reflection;
using Tests.Common.TestTypes;

namespace Tests.Common
{
    public abstract class TestDefintionBase
    {
        protected TestDefintionBase(string testGroupName)
        {
            TestGroupName = testGroupName;
        }

        public abstract void RegisterTypeMappings(TypeMappingContainer typeMappingContainer);

        public Type GetAssemblyIdentifier { get { return GetType(); } }
        public string TestGroupName { get; private set; }
    }
}