using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Command.Driver;
using Tests.Common.TestTypes;

namespace Tests.Command
{
    [Binding]
    public class CommandSteps : TypeContextSteps
    {
        private readonly TypeContext _typeContext;
        private readonly CommandDriver _commandDriver;

        public CommandSteps(TypeContext typeContext, CommandDriver commandDriver) : base(typeContext)
        {
            _typeContext = typeContext;
            _commandDriver = commandDriver;
        }

        [When(@"ich eine Instanz des Invokers erzeuge")]
        public void WennIchEineInstanzDesInvokersErzeuge()
        {
            _commandDriver.GenerateInvoker(_typeContext);
        }

        [When(@"ich eine dynamische Instanz des Kommandos erzeuge")]
        public void WennIchEineDynamischeInstanzDesKommandosErzeuge()
        {
            _commandDriver.GenerateCommands(_typeContext);
        }

        [When(@"dieses Kommando an den Invoker übergebe")]
        public void WennDiesesKommandoAnDenInvokerUbergebe()
        {
            _commandDriver.ExecuteCommandsOnInvokers();
        }

        [Then(@"soll mindestens eine Methode des Kommandos aufgerufen werden")]
        public void DannSollMindestensEineMethodeDesKommandosAufgerufenWerden()
        {
            _commandDriver.AtLeastOneCommandMethodHasBeenCalled().Should().BeTrue();
        }

    }
}