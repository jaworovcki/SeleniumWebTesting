using Lab2Testing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Lab2Testing.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly TestingService _page;

        public LoginSteps()
        {
            _driver = new ChromeDriver();
            _page = new TestingService(_driver);
        }

        [Given(@"I navigate to ""(.*)""")]
        public void GivenINavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [When(@"I enter ""(.*)"" into the username field")]
        public void WhenIEnterIntoTheUsernameField(string username)
        {
            _page.EnterUsername(username);
        }

        [When(@"I enter ""(.*)"" into the password field")]
        public void WhenIEnterIntoThePasswordField(string password)
        {
            _page.EnterPassword(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _page.ClickLoginButton();
        }

        [Then(@"I should see an error message containing ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessageContaining(string expectedErrorMessage)
        {
            string actualErrorMessage = _page.GetErrorMessage();
            if (!actualErrorMessage.Contains(expectedErrorMessage))
            {
                throw new Exception($"Expected error message to contain '{expectedErrorMessage}', but got '{actualErrorMessage}'");
            }
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
