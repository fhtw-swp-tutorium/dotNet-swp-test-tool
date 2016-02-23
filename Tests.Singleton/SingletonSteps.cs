using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Singleton.Driver;

namespace Tests.Singleton
{
    [Binding]
    public class SingletonSteps
    {
        private readonly SingletonDriver _singletonDriver;

        public SingletonSteps(SingletonDriver singletonDriver)
        {
            _singletonDriver = singletonDriver;
        }

        [Given(@"mindestens ein Singleton")]
        public void AngenommenMindestensEinSingleton()
        {
            _singletonDriver.Singletons.Count.Should().BeGreaterThan(0);
        }

        [Then(@"bieten Singletons eine passende Methode zur Instanzierung")]
        public void DannBietenSingletonsEinePassendeMethodeZurInstanzierung()
        {
            _singletonDriver.Singletons.ForEach(s => s.HasInstancePropertyOrMethod().Should().BeTrue());
        }

        [Then(@"haben singletons einen privaten Konstruktor")]
        public void DannHabenSingletonsEinenPrivatenKonstruktor()
        {
            _singletonDriver.Singletons.ForEach(s => s.HasNoPublicConstructor().Should().BeTrue());
        }

        [Then(@"geben singletons immer dieselbe Instanz zurück")]
        public void DannGebenSingletonsImmerDieselbeInstanzZuruck()
        {
            _singletonDriver.Singletons.ForEach(s =>
            {
                var firstInstance = s.GetInstance();
                var secondInstance = s.GetInstance();

                firstInstance.Should().BeSameAs(secondInstance);
            });
        }

    }
}