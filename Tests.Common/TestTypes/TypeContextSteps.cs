using System.Collections.Generic;
using Castle.Core.Internal;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Tests.Common.TestTypes
{
    [Binding]
    public class TypeContextSteps
    {
        private readonly TypeContext _typeContext;

        public TypeContextSteps(TypeContext typeContext)
        {
            _typeContext = typeContext;
        }

        [Given(@"eine Liste von Klassen mit dem Attribut ""(.*)""")]
        public void AngenommenEineListeVonKlassenMitDemAttribut(string attributeName)
        {
            _typeContext.SetClassList(attributeName);
        }

        [Then(@"darf diese Liste nicht leer sein")]
        public void DannDarfDieseListeNichtLeerSein()
        {
            _typeContext.ClassListHasEntries().Should().BeTrue();
        }

        [When(@"ich in jeder Klasse nach einer Methode mit dem Attribut ""(.*)"" suche")]
        public void WennIchInJederKlasseNachEinerMethodeMitDemAttributSuche(string attributeName)
        {
            _typeContext.OnlyMethodsWithAttribute(attributeName);
        }

        [Then(@"erwarte ich mir jeweils genau eine Methode")]
        public void DannErwarteIchMirJeweilsEineMethode()
        {
            _typeContext.EveryClassHasOneMethod().Should().BeTrue();
        }

        [Then(@"muss jede Methode genau einen Parameter haben")]
        public void DannDarfJedeMethodeNurEinenParameterHaben()
        {
            _typeContext.EveryClassMethodHasParameters(1).Should().BeTrue();
        }

        [Then(@"jede Methode muss genau ""(.*)"" Parameter haben")]
        public void DannJedeMethodeMussGenauParameterHaben(int numberOfParameters)
        {
            _typeContext.EveryClassMethodHasParameters(numberOfParameters).Should().BeTrue();
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

        [Then(@"erwarte ich mir eine Methode, die mit einem dieser Präfixe beginnt: ""(.*)""")]
        public void DannErwarteIchMirEineMethodeDieMitEinemDieserPrafixeBeginnt(string prefixes)
        {
            var prefixList = new List<string>();
            prefixes.Split(',').ForEach(s => prefixList.Add(s.Trim().ToLower()));

            _typeContext.EveryClassHasOneMethodWithPrefix(prefixList);
        }

    }
}
