using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;
using SpecFlowProjectPractice.Helper;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class SelectableSteps
    {
        private WebDriverManager _driverManager;
        private readonly SelectablePage _selectablePage;
        private PopUpHandler popUpHandler;


        public SelectableSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            popUpHandler = new PopUpHandler(driverManager);
            _selectablePage = new SelectablePage(_driverManager);
        }

        [Given(@"I switch to the Grid tab")]
        public void WhenISwitchToTheGridTab()
        {
            _selectablePage.SwitchToGridTab();
        }

        [When(@"I select squares 1, 3, 5, 7, and 9")]
        public void WhenISelectSquares1357And9()
        {
            _selectablePage.SelectOptions();
        }

        [Then(@"the selected squares should display One, Three, Five, Seven, and Nine")]
        public void ThenTheSelectedSquaresShouldDisplayOneThreeFiveSevenAndNine()
        {
            List<string> expectedValues = new List<string>() { "One", "Three", "Five", "Seven", "Nine" };

            _selectablePage.GetSelectedSquareValues();
            _selectablePage.VerifySelectedValues(expectedValues);
        }
    }
}
