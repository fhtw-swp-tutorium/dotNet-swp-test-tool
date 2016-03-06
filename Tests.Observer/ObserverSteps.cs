using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Common.TestTypes;
using Tests.Observer.Driver;

namespace Tests.Observer
{
    [Binding]
    class ObserverSteps : TypeContextSteps
    {
        private readonly ObserverDriver _observerContext;
        private readonly TypeContext _typeContext;

        public ObserverSteps(ObserverDriver observerContext, TypeContext typeContext) : base(typeContext)
        {
            _observerContext = observerContext;
            _typeContext = typeContext;
        }

        [Given(@"eine Instanz des Subjekts")]
        public void AngenommenEineInstanzDesSubjekts()
        {
            _observerContext.GenerateSubjects(_typeContext);
        }

        [Given(@"eine Instanz des Beobachters")]
        public void AngenommenEineInstanzDesBeobachters()
        {
            _observerContext.GenerateObserver(_typeContext);
        }

        [When(@"ich diesen Beobachter hinzufügen")]
        public void WennIchDiesenBeobachterHinzufugen()
        {
            _observerContext.RegisterObserver();
        }

        [When(@"die Methode zum Aktualisieren aufrufe")]
        public void WennDieMethodeZumAktualisierenAufrufe()
        {
            _observerContext.NotifyObservers();
        }

        [Then(@"soll mindestens eine Methode des Beobachters aufgerufen werden")]
        public void DannSollMindestensEineMethodeDesBeobachtersAufgerufenWerden()
        {
            _observerContext.ObserversHaveBeenCalledAtLeast(1).Should().BeTrue();
        }

        [When(@"ich diesen Beobachter entferne")]
        public void WennIchDiesenBeobachterEntferne()
        {
            _observerContext.UnregisterObserver();
        }

        [Then(@"soll keine Methode des Beobachters aufgerufen werden")]
        public void DannSollKeineMethodeDesBeobachtersAufgerufenWerden()
        {
            _observerContext.ObserversHaveNeverBeenCalled().Should().BeTrue();
        }
    }
}
