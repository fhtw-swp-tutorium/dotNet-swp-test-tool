using System;
using System.Collections.Generic;
using System.Linq;
using DotNetAttributes.Command;
using Tests.Common.Proxy;
using Tests.Common.TestTypes;

namespace Tests.Command.Driver
{
    public class CommandDriver
    {
        private List<InvokerProxy> _invoker = new List<InvokerProxy>();
        private List<CommandProxy> _commands = new List<CommandProxy>();

        public void GenerateCommands(TypeContext typeContext)
        {
            var onlyMethodsWithAttribute = typeContext.OnlyMethodsWithAttribute(typeof (InvokeCommandAttribute));
            var invokerInterfaces = new List<Type>();
            onlyMethodsWithAttribute.ClassMethodList.Values.ToList().ForEach(m =>
            {
                var parameterType = m.First().GetParameters().First().ParameterType;
                if(!parameterType.IsInterface) throw new ArgumentException("Parameter is no interface");
                invokerInterfaces.Add(parameterType);
            });

            _commands = invokerInterfaces.Select(CommandProxy.Create).ToList();
        }

        public void GenerateInvoker(TypeContext typeContext)
        {
            var types = typeContext.ClassMethodList.Keys;
            var invokerObjects = new ObjectFactory().GenerateObjects(typeof (InvokerAttribute), types);

            _invoker = invokerObjects.Select(InvokerProxy.Create).ToList();
        }

        public void ExecuteCommandsOnInvokers()
        {
            if(_invoker.Count != _commands.Count)
                throw new Exception("there are not the some number of  Invoker and Commander");

            for (var i = 0; i < _invoker.Count; i++)
            {
                _invoker[i].ExecuteCommand(_commands[i]);
            }
        }

        public bool AtLeastOneCommandMethodHasBeenCalled()
        {
            return _commands.All(c => c.Interceptor.Count > 0);
        }
    }
}