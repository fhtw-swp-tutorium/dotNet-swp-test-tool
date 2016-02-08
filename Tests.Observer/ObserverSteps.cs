using TechTalk.SpecFlow;

namespace Tests.ExerciseOne
{
    [Binding]
    class ObserverSteps
    {
        [Given(@"Zugriff auf alle verfügbaren Subjekte")]
        public void AngenommenZugriffAufAlleVerfugbarenSubjekte()
        {
            ////C:\Work\FH\dotNet-sampleSolution\SampleSolution\SampleSolution\bin\Debug\SampleSolution.exe
        }

        [Then(@"existiert mindestens ein Subjekt")]
        public void DannExistiertMindestensEinSubjekt()
        {
            ////C:\Work\FH\dotNet-sampleSolution\SampleSolution\SampleSolution\bin\Debug\SampleSolution.exe
        }

        [Then(@"sollen alle Subjekte eine Reigster Methode haben")]
        public void DannSollenAlleSubjekteEineReigsterMethodeHaben()
        {
            //C:\Work\FH\dotNet-sampleSolution\SampleSolution\SampleSolution\bin\Debug\SampleSolution.exe
        }

        [Then(@"sollen alle Subjekte eine Update Methode haben")]
        public void DannSollenAlleSubjekteEineUpdateMethodeHaben()
        {
            //C:\Work\FH\dotNet-sampleSolution\SampleSolution\SampleSolution\bin\Debug\SampleSolution.exe
        }

        [When(@"sich bei jedem Subjekt ein Observer mit den Namen ""(.*)"" registiert")]
        public void WennSichBeiJedemSubjektEinObserverMitDenNamenRegistiert(string p0)
        {
            //C:\Work\FH\dotNet-sampleSolution\SampleSolution\SampleSolution\bin\Debug\SampleSolution.exe
        }

        [When(@"alle Subjekte die Update Methode Aufrufen")]
        public void WennAlleSubjekteDieUpdateMethodeAufrufen()
        {
            //C:\Work\FH\dotNet-sampleSolution\SampleSolution\SampleSolution\bin\Debug\SampleSolution.exe
        }

        [Then(@"sollen ""(.*)"" ""(.*)"" mal aufgerufen worden sein")]
        public void DannSollenMalAufgerufenWordenSein(string p0, int p1)
        {
            //C:\Work\FH\dotNet-sampleSolution\SampleSolution\SampleSolution\bin\Debug\SampleSolution.exe
        }

    }
}
