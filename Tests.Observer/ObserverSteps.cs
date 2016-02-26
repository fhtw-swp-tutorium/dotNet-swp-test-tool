using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Observer.Driver;

namespace Tests.Observer
{
    [Binding]
    class ObserverSteps
    {
        private readonly ObserverDriver _observerContext;

        public ObserverSteps(ObserverDriver observerContext)
        {
            _observerContext = observerContext;
        }

        [Given(@"mindestens ein Subjekte")]
        public void AngenommenMindestensEinSubjekte()
        {
            var subjectProxies = _observerContext.Subjects;
            subjectProxies.Count.Should().BeGreaterThan(0);
        }

        [Then(@"haben Subjekte eine passende Register Methode")]
        public void DannHabenSubjekteEineReigsterMethode()
        {
            var subjectProxies = _observerContext.Subjects;
            subjectProxies.ForEach(sp => sp.HasAppropriateAddMethod.Should().BeTrue());
        }

        [Then(@"haben Subjekte eine passende Update Methode")]
        public void DannHabenSubjekteEineUpdateMethode()
        {
            var subjectProxies = _observerContext.Subjects;
            subjectProxies.ForEach(sp => sp.HasAppropriateUpdateMethod.Should().BeTrue());
        }

        [Then(@"haben Subjekte eine passende Unregister Methode")]
        public void DannHabenSubjekteEineUnregisterMethode()
        {
            var subjectProxies = _observerContext.Subjects;
            subjectProxies.ForEach(sp => sp.HasAppropriateRemvoeMethod.Should().BeTrue());
        }

        [When(@"sich bei allen Subjekten je ein Observer mit den Namen ""(.*)"" registiert")]
        public void WennSichBeiAllenSubjektenJeEinObserverMitDenNamenRegistiert(string name)
        {
            var subjectProxies = _observerContext.Subjects;
            subjectProxies.ForEach(s => s.RegisterObserver(name));
        }

        [When(@"Subjekte die Update Methode Aufrufen")]
        public void WennSubjekteDieUpdateMethodeAufrufen()
        {
            var subjectProxies = _observerContext.Subjects;
            subjectProxies.ForEach(sp => sp.UpdateObserver());
        }

        [Then(@"sollen alle Observer ""(.*)"" ""(.*)"" mal aufgerufen worden sein")]
        public void DannSollenAlleObserverMalAufgerufenWordenSein(string name, int invocations)
        {
            var subjectProxies = _observerContext.Subjects;
            subjectProxies.ForEach(sp => sp.GetObserver(name).Interceptor.Count.Should().Be(invocations));
        }
    }
}
