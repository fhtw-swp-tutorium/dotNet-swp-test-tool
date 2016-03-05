using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Command.Driver;
using Tests.Common;
using Tests.Common.TestTypes;

namespace Tests.Command
{
    [Binding]
    public class CommandSteps
    {
        private readonly TypeContext _typeContext;
        private readonly CommandDriver _commandDriver;

        public CommandSteps(TypeContext typeContext, CommandDriver commandDriver)
        {
            _typeContext = typeContext;
            _commandDriver = commandDriver;
        }


        [Given(@"eine Liste von Klassen mit dem Attribut ""(.*)""")]
        public void AngenommenEineListeVonKlassenMitDemAttribut(string attributeName)
        {
            _typeContext.SetClassList(TypeMapper.GetType(attributeName));
        }

        [Then(@"darf diese Liste nicht leer sein")]
        public void DannDarfDieseListeNichtLeerSein()
        {
            _typeContext.ClassListHasEntries().Should().BeTrue();
        }

        [When(@"ich in jeder Klasse nach einer Methode mit dem Attribut ""(.*)"" suche")]
        public void WennIchInJederKlasseNachEinerMethodeMitDemAttributSuche(string attributeName)
        {
            _typeContext.OnlyMethodsWithAttribute(TypeMapper.GetType(attributeName));
        }

        [Then(@"erwarte ich mir jeweils eine Methode")]
        public void DannErwarteIchMirJeweilsEineMethode()
        {
            _typeContext.EveryClassHasOneMethod().Should().BeTrue();
        }

        [Then(@"muss jede Methode genau einen Parameter haben")]
        public void DannDarfJedeMethodeNurEinenParameterHaben()
        {
            _typeContext.EveryClassMethodHasOneParamter().Should().BeTrue();
        }

        [Then(@"jeder Parameter muss ein Interface sein")]
        public void DannDerErsteParameterMussEinInterfaceSein()
        {
            _typeContext.EveryClassMethodsParameterIsAnInterface().Should().BeTrue();
        }

        [Then(@"muss es für jeden Interface Parameter eine Implementierung geben")]
        public void DannMussEsFurJedenInterfaceParameterEineImplementierungGeben()
        {
            _typeContext.EveryInterfaceParameterHasAnImplementation().Should().BeTrue();
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