using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Common;

namespace Tests.Command
{
    [Binding]
    public class CommandSteps
    {
        private readonly TestTypeContext _testTypeContext;

        public CommandSteps(TestTypeContext testTypeContext)
        {
            _testTypeContext = testTypeContext;
        }


        [Given(@"eine Liste von Klassen mit dem Attribut ""(.*)""")]
        public void AngenommenEineListeVonKlassenMitDemAttribut(string attributeName)
        {
            _testTypeContext.SetClassList(attributeName);
        }

        [Then(@"darf diese Liste nicht leer sein")]
        public void DannDarfDieseListeNichtLeerSein()
        {
            _testTypeContext.ClassListHasEntries().Should().BeTrue();
        }

        [When(@"ich in jeder Klasse nach einer Methode mit dem Attribut ""(.*)"" suche")]
        public void WennIchInJederKlasseNachEinerMethodeMitDemAttributSuche(string attributeName)
        {
            _testTypeContext.OnlyMethodsWithAttribute(attributeName);
        }

        [Then(@"erwarte ich mir jeweils eine Methode")]
        public void DannErwarteIchMirJeweilsEineMethode()
        {
            _testTypeContext.EveryClassHasOneMethod().Should().BeTrue();
        }

        [Then(@"muss jede Methode genau einen Parameter haben")]
        public void DannDarfJedeMethodeNurEinenParameterHaben()
        {
            _testTypeContext.EveryClassMethodHasOneParamter().Should().BeTrue();
        }

        [Then(@"muss jeder Parameter ein Interface sein")]
        public void DannDerErsteParameterMussEinInterfaceSein()
        {
            _testTypeContext.EveryClassMethodsParameterIsAnInterface().Should().BeTrue();
        }

        [Then(@"muss es für jeden Interface Parameter eine Implementierung geben")]
        public void DannMussEsFurJedenInterfaceParameterEineImplementierungGeben()
        {
            _testTypeContext.EveryInterfaceParameterHasAnImplementation();
        }

        [When(@"ich eine Instanz des Invokers erzeuge")]
        public void WennIchEineInstanzDesInvokersErzeuge()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"ich eine dynamische Instanz des Kommandos erzeuge")]
        public void WennIchEineDynamischeInstanzDesKommandosErzeuge()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"dieses Kommando an den Invoker übergebe")]
        public void WennDiesesKommandoAnDenInvokerUbergebe()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"soll mindestens eine Methode des Kommandos aufgerufen werden")]
        public void DannSollMindestensEineMethodeDesKommandosAufgerufenWerden()
        {
            ScenarioContext.Current.Pending();
        }

    }
}