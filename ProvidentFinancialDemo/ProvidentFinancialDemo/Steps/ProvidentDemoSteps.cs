using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ProvidentFinancialDemo
{
    [Binding]
    public class ProvidentDemoSteps
    {
        IWebDriver driver = WebOps.driver;
        WebOps webops = new WebOps();

        [BeforeScenario]
        public void OpenBrowser()
        {
            driver = WebOps.driver;
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

        By RepresentativeExample = By.XPath(".//div/p/strong[contains(text(),'Representative example')]");
        By TwentySixWeeks=By.Id("lbl26WeeksDesktop");
        By WeeklyPaymentValue = By.XPath(".//h4[@id='loanCalcWeeklyRepaymentLabel']");
        By applyNow = By.Id("applyNowLink");
        By continueButton = By.Id("lbl_continue");
        By Day = By.Id("applyFormDOBDay");
        By Month = By.Id("applyFormDOBMonth");
        By Year = By.Id("applyFormDOBYear");
        By houseNumber = By.Id("applyFormHouseNameNumber");
        By Postcode = By.Id("applyFormPostCode");
        By FindAddress = By.Id("findAddressCurrent");
        By currentAddress = By.XPath(".//div[@id='currentAddressShow']");
        By ErrorMessage = By.XPath("//*[@id=\"currentAddressZero\"]");

        [Given(@"I navigate to provident financial website")]
        public void GivenILoginToProvidentFinancialWebsite()
        {
           
            webops.NavigateToSite("https://www.providentpersonalcredit.com/");
        }

      

        [Then(@"I can verify that text (.*) is present")]
        public void ThenICanVerifyThatTextRepresentativeExampleLoanOverWeeks_PaymentsOfPerWeek_RateOfInterestP_A_Fixed_RepresentativeAPR_TotalAmountPayable_IsPresent(string text)
        {
            webops.AssertTextPresent(RepresentativeExample, text);
        }


        [Then(@"I click on TwentySix weeks")]
        public void ThenIClickOnTwentySixWeeks()
        {
            
            webops.ClickButton(TwentySixWeeks);
          
  
        }

        

        [Then(@"I can verify weekly payment value is (.*)")]
        public void ThenICanVerifyWeeklyPaymentValueIs(string amount)
        {
            webops.AssertTextPresent(WeeklyPaymentValue, amount);
        }


        [Given(@"I click on apply now")]
        public void GivenIClickOnApplyNow()
        {
            webops.ClickButton(applyNow);
            webops.ClickButton(continueButton);
        }

        [Given(@"I enter date of birth greater than twenty one")]
        public void GivenIEnterDateOfBirthGreaterThanTwentyOne()
        {
            webops.SelectElements(Day,"1");
            webops.SelectElements(Month, "10");
            webops.SelectElements(Year, "1923");
        }

        [Given(@"I enter address")]
        public void GivenIEnterAddress()
        {
            webops.SendElementKey(houseNumber, "1");
            webops.SendElementKey(Postcode, "BD1 2SU");
            webops.ClickButton(FindAddress);
        }

        [Then(@"I can verify that address (.*) is present")]
        public void ThenICanVerifyThatAddressGodwinStreetBRADFORDWestYorkshireBDSUIsPresent(string address)
        {
            webops.AssertTextPresent(currentAddress, address);
        }

        [Then(@"I enter wrong address")]
        public void ThenIEnterWrongAddress()
        {
            webops.SendElementKey(houseNumber, "1");
            webops.SendElementKey(Postcode, "1");
            webops.ClickButton(FindAddress);
        }

        [Then(@"I should get an error message that says (.*)")]
        public void ThenIShouldGetAnErrorMessageThatSaysUnfortunatelyWeCanTFindYourAddressAndThereforeCannotContinueWithYourLoanApplicationOnline_PleaseCallToSpeakToOurCustomerServicesTeam_OpenAm_PmMon_FriAm_PmSat_(string errorMessage)
        {
            webops.AssertTextPresent(ErrorMessage, errorMessage);
        }









    }
}
