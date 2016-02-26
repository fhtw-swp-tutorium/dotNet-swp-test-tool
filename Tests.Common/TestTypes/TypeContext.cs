using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using TestExecutor.Common.Reflection;

namespace Tests.Common.TestTypes
{
    public class TypeContext
    {
        public IDictionary<Type, List<MethodInfo>> ClassMethodList { get; } = new Dictionary<Type, List<MethodInfo>>();

        public TypeContext SetClassList(Type attributeType)
        {
            ClassMethodList.Clear();

            var classes = TypeProvider.GetTypesWithAttribute(attributeType);

            foreach (var cls in classes)
            {
                ClassMethodList.Add(new KeyValuePair<Type, List<MethodInfo>>(cls, cls.Methods().ToList()));
            }

            return this;
        }

        public TypeContext OnlyMethodsWithAttribute(Type attributeType)
        {
            for (var i = 0; i < ClassMethodList.Count; i++)
            {
                var cls = ClassMethodList.ElementAt(i);
                ClassMethodList[cls.Key] =
                    new List<MethodInfo>(cls.Value.Where(m => m.CustomAttributes.Any(a => a.AttributeType == attributeType))).ToList();
            }

            return this;
        }

        public TypeContext OnlyMethodsWithExactParameterCount(int numberOfParameters)
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