using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using TestExecutor.Common.Reflection;

namespace Tests.Common
{
    public class TestTypeContext
    {
        public IDictionary<Type, List<MethodInfo>> ClassMethodList { get; } = new Dictionary<Type, List<MethodInfo>>();

        public TestTypeContext SetClassList(string attributeName)
        {
            ClassMethodList.Clear();

            var attributeType = TypeMapper.GetType(attributeName);
            var classes = TypeProvider.GetTypesWithAttribute(attributeType);

            foreach (var cls in classes)
            {
                ClassMethodList.Add(new KeyValuePair<Type, List<MethodInfo>>(cls, cls.Methods().ToList()));
            }

            return this;
        }

        public TestTypeContext OnlyMethodsWithAttribute(string attributeName)
        {
            var attributeType = TypeMapper.GetType(attributeName);

            for (var i = 0; i < ClassMethodList.Count; i++)
            {
                var cls = ClassMethodList.ElementAt(i);
                ClassMethodList[cls.Key] =
                    new List<MethodInfo>(cls.Value.Where(m => m.Attributes.GetType() == attributeType).ToList());
            }

            return this;
        }

        public TestTypeContext OnlyMethodsWithExactParameterCount(int numberOfParameters)
        {
            for (var i = 0; i < ClassMethodList.Count; i++)
            {
                var cls = ClassMethodList.ElementAt(i);
                ClassMethodList[cls.Key] =
                    new List<MethodInfo>(cls.Value.Where(m => m.GetParameters().Length == numberOfParameters).ToList());
            }

            return this;
        }
    }
}