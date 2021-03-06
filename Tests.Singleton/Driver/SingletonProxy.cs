using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tests.Singleton.Driver
{
    public class SingletonProxy
    {
        private readonly Type _singleton;
        public static SingletonProxy Generate(Type type)
        {
            return new SingletonProxy(type);
        }

        private SingletonProxy(Type singleton)
        {
            _singleton = singleton;
        }

        public object GetInstance()
        {
            if (SingletonInstanceProperty().Count > 0)
                return SingletonInstanceProperty().First().GetValue(null);

            if (SingletonInstanceMethod().Count > 0)
                return SingletonInstanceMethod().First().Invoke(null, new object[] { });

            return null;
        }

        public bool HasNoPublicConstructor()
        {
            return _singleton.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).Length > 0;
        }

        public bool HasInstancePropertyOrMethod()
        {
            return (SingletonInstanceMethod().Count + SingletonInstanceProperty().Count >= 1);
        }

        private List<MethodInfo> SingletonInstanceMethod()
        {
            return _singleton
                .GetMethods()
                .Where(m => m.IsStatic)
                .Where(m => m.IsPublic)
                .Where(m => !m.IsSpecialName)
                .Where(m => m.GetParameters().Length == 0)
                .Where(m => m.ReturnType == _singleton)
                .ToList();
        }

        private List<PropertyInfo> SingletonInstanceProperty()
        {
            return _singleton
                .GetProperties()
                .Where(p => p.GetMethod.IsStatic)
                .Where(p => p.CanRead)
                .Where(p => !p.CanWrite)
                .Where(p => p.PropertyType == _singleton)
                .ToList();
        }
    }
}