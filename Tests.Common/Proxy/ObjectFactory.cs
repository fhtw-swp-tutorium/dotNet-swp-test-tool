using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DotNetAttributes;
using FluentAssertions.Common;

namespace Tests.Common.Proxy
{
    public class ObjectFactory
    {
        public IEnumerable<object> GenerateObjects(Type classAttribute, IEnumerable<Type> sourceTypes)
        {
            var matchingAttributes = sourceTypes.Where(s => s.CustomAttributes.Any(a => a.AttributeType == classAttribute));

            var objects = new List<object>();
            foreach (var type in matchingAttributes)
            {
                var customAttributes = type.GetCustomAttribute(classAttribute);
                object instance;

                var attributeUsesFactory = 
                    customAttributes.GetType().Implements(typeof(IFactoryAttribute)) 
                    && ((IFactoryAttribute)customAttributes).Factory != null;

                if (attributeUsesFactory)
                {
                    var factory = Activator.CreateInstance(((IFactoryAttribute)customAttributes).Factory);
                    var createMethod = factory.GetType().GetMethods().First(m => m.IsPublic && !m.GetParameters().Any() && m.ReturnType == type);
                    instance = createMethod.Invoke(factory, new object[] { });
                }
                else
                {
                    instance = Activator.CreateInstance(type);
                }

                objects.Add(instance);
            }
            return objects;
        }  
    }
}