﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests.Observer
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Beobachter")]
    public partial class BeobachterFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Observer.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("de"), "Beobachter", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
  #line 7
    testRunner.Given("eine Liste von Klassen mit dem Attribut \"Subject\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Gegeben sei ");
#line 8
    testRunner.Then("darf diese Liste nicht leer sein", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dann ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Alle Subjekte sollen eine Methode zum Hinzufügen eines Beobachters bieten")]
        public virtual void AlleSubjekteSollenEineMethodeZumHinzufugenEinesBeobachtersBieten()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Alle Subjekte sollen eine Methode zum Hinzufügen eines Beobachters bieten", ((string[])(null)));
#line 10
  this.ScenarioSetup(scenarioInfo);
#line 6
  this.FeatureBackground();
#line 11
    testRunner.When("ich in jeder Klasse nach einer Methode mit dem Attribut \"RegisterObserver\" suche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wenn ");
#line 12
    testRunner.Then("erwarte ich mir jeweils genau eine Methode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dann ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Eine Methode zum Hinzufügen eines Beobachters muss strukturell korrekt sein")]
        public virtual void EineMethodeZumHinzufugenEinesBeobachtersMussStrukturellKorrektSein()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Eine Methode zum Hinzufügen eines Beobachters muss strukturell korrekt sein", ((string[])(null)));
#line 14
  this.ScenarioSetup(scenarioInfo);
#line 6
  this.FeatureBackground();
#line 15
    testRunner.When("ich in jeder Klasse nach einer Methode mit dem Attribut \"RegisterObserver\" suche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wenn ");
#line 16
    testRunner.Then("erwarte ich mir eine Methode, die mit einem dieser Präfixe beginnt: \"add, registe" +
                    "r, attach, subscribe\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dann ");
#line 17
    testRunner.And("jede Methode muss genau \"1\" Parameter haben", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line 18
    testRunner.And("jeder Parameter muss ein Interface sein", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Alle Subjekte sollen eine Methode zum Entfernen eines Beobachters bieten")]
        public virtual void AlleSubjekteSollenEineMethodeZumEntfernenEinesBeobachtersBieten()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Alle Subjekte sollen eine Methode zum Entfernen eines Beobachters bieten", ((string[])(null)));
#line 20
  this.ScenarioSetup(scenarioInfo);
#line 6
  this.FeatureBackground();
#line 21
    testRunner.When("ich in jeder Klasse nach einer Methode mit dem Attribut \"UnregisterObserver\" such" +
                    "e", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wenn ");
#line 22
    testRunner.Then("erwarte ich mir jeweils genau eine Methode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dann ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Eine Methode zum Entfernen eines Beobachters muss strukturell korrekt sein")]
        public virtual void EineMethodeZumEntfernenEinesBeobachtersMussStrukturellKorrektSein()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Eine Methode zum Entfernen eines Beobachters muss strukturell korrekt sein", ((string[])(null)));
#line 24
  this.ScenarioSetup(scenarioInfo);
#line 6
  this.FeatureBackground();
#line 25
    testRunner.When("ich in jeder Klasse nach einer Methode mit dem Attribut \"UnregisterObserver\" such" +
                    "e", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wenn ");
#line 26
    testRunner.Then("erwarte ich mir eine Methode, die mit einem dieser Präfixe beginnt: \"remove, unre" +
                    "gister, detach, unsubscribe\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dann ");
#line 27
    testRunner.And("jede Methode muss genau \"1\" Parameter haben", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line 28
    testRunner.And("jeder Parameter muss ein Interface sein", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Alle Subjekte sollen eine Methode zum Aktualisieren der Beobachters bieten")]
        public virtual void AlleSubjekteSollenEineMethodeZumAktualisierenDerBeobachtersBieten()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Alle Subjekte sollen eine Methode zum Aktualisieren der Beobachters bieten", ((string[])(null)));
#line 30
  this.ScenarioSetup(scenarioInfo);
#line 6
  this.FeatureBackground();
#line 31
    testRunner.When("ich in jeder Klasse nach einer Methode mit dem Attribut \"NotifyObservers\" suche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wenn ");
#line 32
    testRunner.Then("erwarte ich mir jeweils genau eine Methode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dann ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Eine Methode zum Aktualisieren der Beobachter muss strukturell korrekt sein")]
        public virtual void EineMethodeZumAktualisierenDerBeobachterMussStrukturellKorrektSein()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Eine Methode zum Aktualisieren der Beobachter muss strukturell korrekt sein", ((string[])(null)));
#line 34
  this.ScenarioSetup(scenarioInfo);
#line 6
  this.FeatureBackground();
#line 35
    testRunner.When("ich in jeder Klasse nach einer Methode mit dem Attribut \"NotifyObservers\" suche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wenn ");
#line 36
    testRunner.Then("erwarte ich mir eine Methode, die mit einem dieser Präfixe beginnt: \"update, noti" +
                    "fy\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dann ");
#line 37
    testRunner.And("jede Methode muss genau \"0\" Parameter haben", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Beobachter sollen aufgerufen werden, wenn sie registriert sind")]
        public virtual void BeobachterSollenAufgerufenWerdenWennSieRegistriertSind()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Beobachter sollen aufgerufen werden, wenn sie registriert sind", ((string[])(null)));
#line 40
  this.ScenarioSetup(scenarioInfo);
#line 6
  this.FeatureBackground();
#line 41
    testRunner.Given("eine Instanz des Subjekts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Gegeben sei ");
#line 42
    testRunner.And("eine Instanz des Beobachters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line 43
    testRunner.When("ich diesen Beobachter hinzufügen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wenn ");
#line 44
    testRunner.And("die Methode zum Aktualisieren aufrufe", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line 45
    testRunner.Then("soll mindestens eine Methode des Beobachters aufgerufen werden", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dann ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Beobachter sollen nicht mehr aufgerufen werden, wenn sie sich vom Subjekt abmelde" +
            "n")]
        public virtual void BeobachterSollenNichtMehrAufgerufenWerdenWennSieSichVomSubjektAbmelden()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Beobachter sollen nicht mehr aufgerufen werden, wenn sie sich vom Subjekt abmelde" +
                    "n", ((string[])(null)));
#line 47
  this.ScenarioSetup(scenarioInfo);
#line 6
  this.FeatureBackground();
#line 48
    testRunner.Given("eine Instanz des Subjekts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Gegeben sei ");
#line 49
    testRunner.And("eine Instanz des Beobachters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line 50
    testRunner.When("ich diesen Beobachter hinzufügen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wenn ");
#line 51
    testRunner.And("ich diesen Beobachter entferne", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line 52
    testRunner.And("die Methode zum Aktualisieren aufrufe", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Und ");
#line 53
    testRunner.Then("soll keine Methode des Beobachters aufgerufen werden", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dann ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
