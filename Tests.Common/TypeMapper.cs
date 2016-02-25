﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DotNetAttributes;

namespace Tests.Common
{
    public static class TypeMapper
    {
        private static readonly ReadOnlyDictionary<string, Type> TypeMap;

        static TypeMapper()
        {
            var mappings = new Dictionary<string, Type>
            {
                {"Subjekt", typeof (SubjectAttribute)},
                {"Singleton", typeof (SingletonAttribute)},
                {"Invoker", typeof (InvokerAttribute)},
                {"InvokerCommand", typeof (InvokeCommandAttribute)}
            };

            TypeMap = new ReadOnlyDictionary<string, Type>(mappings);
        }

        public static Type GetType(string name)
        {
            if(!TypeMap.ContainsKey(name))
                throw new Exception($"Type for typename ({name}) can not be found");

            return TypeMap[name];
        }
    }
}