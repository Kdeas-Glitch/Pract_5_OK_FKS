using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

using Xunit;
namespace Pract_5_OK_FKS
{
    public class FirstDisplayTests : IDisposable
    {
        private IWebDriver _driver;
        private static string BaseUrl = "https://test.webmx.ru/";

        public FirstDisplayTests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        //[Fact]
        //public void TestOpenSiteWithTitle()
        //{
        //    const string expectedTitle = "Сервис заметок";
        //    string actualTitle = _driver.Title;
        //    Assert.Equal(expectedTitle, actualTitle);
        //}

        //[Fact]
        //public void LoginPage_Title()
        //{
        //    const string path = "//*[@id=\"mainView\"]/header/div[1]/h1";
        //    IWebElement pageTitle = _driver.FindElement(By.XPath(path));
        //    Assert.NotNull(pageTitle);
        //}

        //[Fact]
        //public void TestLoginField_ByXPath()
        //{
        //    string xpath = "//*[@id=\"authUsername\"]\r\n";
        //    IWebElement usernameInput = _driver.FindElement(By.XPath(xpath));
        //    Assert.NotNull(usernameInput);
        //}

        //[Fact]
        //public void TestPasswordField_ByXPath()
        //{
        //    string xpath = "//*[@id=\"authPassword\"]";
        //    IWebElement passwordInput = _driver.FindElement(By.XPath(xpath));
        //    Assert.True(passwordInput.Displayed);
        //}

        //[Fact]
        //public void TestLoginButton_ByXPath()
        //{
        //    string xpath = "//*[@id=\"authSubmit\"]";
        //    IWebElement loginButton = _driver.FindElement(By.XPath(xpath));
        //    Assert.True(loginButton.Enabled);
        //}

        //[Fact]
        //public void TestLoginButton_ByXpath()
        //{
        //    string xpath = "//*[@id=\"authSubmit\"]";
        //    IWebElement loginButton = _driver.FindElement(By.XPath(xpath));
        //    Assert.Contains("Войти", loginButton.Text);
        //}

        //[Fact]
        //public void TestRegisterLink_ByButton()
        //{
        //    string xpath = "//*[@id=\"registerTab\"]";
        //    IWebElement registerLink = _driver.FindElement(By.XPath(xpath));
        //    Assert.True(registerLink.Displayed);
        //}

        //[Fact]
        //public void TestRegisterLink_ByText()
        //{
        //    string xpath = "//*[@id=\"registerTab\"]";
        //    IWebElement registerLink = _driver.FindElement(By.XPath(xpath));
        //    Assert.NotNull(registerLink);
        //    string textreb = "Регистрация";
        //    Assert.Equal(textreb, registerLink.Text);
        //}

        //[Fact]
        //public void TestRegisterClick_ByText()
        //{
        //    string xpath = "//*[@id=\"registerTab\"]";
        //    IWebElement registerLink = _driver.FindElement(By.XPath(xpath));
        //    registerLink.Click();
        //    string xpath2 = "//*[@id=\"authSubmit\"]";
        //    IWebElement loginButton = _driver.FindElement(By.XPath(xpath2));
        //    string textreb = "Зарегистрироваться";
        //    Assert.Equal(textreb, loginButton.Text);
        //}

        //[Fact]
        //public void TestRegisterDoubleClick_ByText()
        //{
        //    string xpath = "//*[@id=\"registerTab\"]";
        //    IWebElement registerLink = _driver.FindElement(By.XPath(xpath));
        //    registerLink.Click();
        //    string xpath2 = "//*[@id=\"loginTab\"]";
        //    IWebElement loginLink = _driver.FindElement(By.XPath(xpath2));
        //    loginLink.Click();
        //    string xpathbutton = "//*[@id=\"authSubmit\"]";
        //    IWebElement loginButton = _driver.FindElement(By.XPath(xpathbutton));
        //    string textreb = "Войти";
        //    Assert.Equal(textreb, loginButton.Text);
        //}



        //[Fact]
        //public void TestLoginClick_ByTitle()
        //{
        //    string xpathbutton = "//*[@id=\"authSubmit\"]";
        //    IWebElement loginButton = _driver.FindElement(By.XPath(xpathbutton));
        //    loginButton.Click();
        //    string xpathclass = "//*[@id=\"authSection\"]";
        //    IWebElement Class = _driver.FindElement(By.XPath(xpathclass));
        //    const string expected = "card auth-card";
        //    Assert.Equal(expected, Class.GetAttribute("class"));
        //}


        //[Fact]
        //public void TestLoginClick_ByTitleWithLoginRight()
        //{
        //    string xpathbutton = "//*[@id=\"authSubmit\"]";
        //    IWebElement loginButton = _driver.FindElement(By.XPath(xpathbutton));
        //    string xpath = "//*[@id=\"authUsername\"]\r\n";
        //    IWebElement usernameInput = _driver.FindElement(By.XPath(xpath));
        //    usernameInput.SendKeys("1234");
        //    loginButton.Click();
        //    string xpathclass = "//*[@id=\"authSection\"]";
        //    IWebElement Class = _driver.FindElement(By.XPath(xpathclass));
        //    const string expected = "card auth-card";
        //    Assert.Equal(expected, Class.GetAttribute("class"));
        //}

        //[Fact]
        //public void TestLoginClick_ByTitleWithLoginRightAndPassword()
        //{
        //    string xpathbutton = "//*[@id=\"authSubmit\"]";
        //    IWebElement loginButton = _driver.FindElement(By.XPath(xpathbutton));
        //    string xpath = "//*[@id=\"authUsername\"]\r\n";
        //    IWebElement usernameInput = _driver.FindElement(By.XPath(xpath));
        //    usernameInput.SendKeys("1234");
        //    string xpath2 = "//*[@id=\"authPassword\"]";
        //    IWebElement passwordInput = _driver.FindElement(By.XPath(xpath2));
        //    usernameInput.SendKeys("12345");
        //    passwordInput.SendKeys("123456");
        //    loginButton.Click();
        //    string xpatherror = "//*[@id=\"message\"]/span";
        //    IWebElement errorInput = _driver.FindElement(By.XPath(xpatherror));
        //    Assert.NotNull(errorInput);
        //}



        public void Dispose()
        {
            _driver.Close();
        }
    }
}