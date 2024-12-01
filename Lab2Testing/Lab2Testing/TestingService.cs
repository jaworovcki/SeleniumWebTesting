using OpenQA.Selenium;

namespace Lab2Testing
{
    internal class TestingService
    {
        private readonly IWebDriver _driver;

        public TestingService(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterUsername(string username)
        {
            var usernameField = _driver.FindElement(By.Id("user-name"));
            usernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            var passwordField = _driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            var loginButton = _driver.FindElement(By.Id("login-button"));
            loginButton.Click();
        }

        public string GetErrorMessage()
        {
            var errorMessage = _driver.FindElement(By.XPath("//h3[@data-test='error']"));
            return errorMessage.Text;
        }

    }
}
