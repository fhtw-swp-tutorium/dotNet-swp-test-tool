using System;
using System.Collections.Generic;

namespace TestExecutor.Common.Reflection
{
    public class TypeMappingContainer
    {
        private readonly Dictionary<string, Type> _typeMap = new Dictionary<string, Type>();

        public Dictionary<string, Type> TypeMap => new Dictionary<string, Type>(_typeMap);

        public void RegisterType(string name, Type type)
        {
            _typeMap.Add(name, type);
        }
    }
}