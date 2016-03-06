using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Common;
using Tests.Common.TestTypes;
using Tests.Singleton.Driver;

namespace Tests.Singleton
{
    [Binding]
    public class SingletonSteps : TypeContextSteps
    {
        private readonly SingletonDriver _singletonDriver;
        private readonly TypeContext _typeContext;

        public SingletonSteps(SingletonDriver singletonDriver, TypeContext typeContext) : base(typeContext)
        {
            _singletonDriver = singletonDriver;
            _typeContext = typeContext;
        }

        [Then(@"sollen alle Singletons eine Methode zum Zugriff auf die Instanz haben")]
        public void DannSollenAlleSingletonsEineMethodeZumZugriffAufDieInstanzHaben()
        {
            _singletonDriver.GenerateSingletons(_typeContext);
            _singletonDriver.SingletonsCanBeAccessed().Should().BeTrue();
        }

        [Then(@"sollen alle Singletons einen privaten Konstruktor haben")]
        public void DannSollenAlleSingletonsEinenPrivatenKonstruktorHaben()
        {
            _singletonDriver.GenerateSingletons(_typeContext);
            _singletonDriver.SingletonsHavePrivateConstructor().Should().BeTrue();
        }

        [Then(@"sollen alle Singletons immer dieselbe Instanz zurückgeben")]
        public void DannSollenAlleSingletonsImmerDieselbeInstanzZuruckgeben()
        {
            _singletonDriver.GenerateSingletons(_typeContext);
            _singletonDriver.SingletonsAlwaysReturnTheSameInstance().Should().BeTrue();
        }

        [Then(@"diese darf nicht null sein")]
        public void DannDieseDarfNichtNullSein()
        {
            _singletonDriver.GenerateSingletons(_typeContext);
            _singletonDriver.SingletonsNeverReturnNull().Should().BeTrue();
        }

    }
}