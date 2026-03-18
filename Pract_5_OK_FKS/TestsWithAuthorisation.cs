using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

using System.Windows;

using Xunit;
namespace Pract_5_OK_FKS
{
    public class UserRestrictionsAndRights : IDisposable
    {
        private IWebDriver _driver;
        private static string BaseUrl = "https://test.webmx.ru/";

        public UserRestrictionsAndRights()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl(BaseUrl);
        }



        [Fact]
        public void TestLoginClick_ByLogText()
        {
            string xpathbutton = "//*[@id=\"authSubmit\"]";
            IWebElement loginButton = _driver.FindElement(By.XPath(xpathbutton));
            string xpathusername = "//*[@id=\"authUsername\"]";
            IWebElement usernameInput = _driver.FindElement(By.XPath(xpathusername));
            string xpathpassord = "//*[@id=\"authPassword\"]";
            IWebElement passwordInput = _driver.FindElement(By.XPath(xpathpassord));
            usernameInput.SendKeys("1234");
            passwordInput.SendKeys("123456");
            loginButton.Click();
            Thread.Sleep(100);
            string xpathclass = "//*[@id=\"welcomeText\"]";
            IWebElement logtext = _driver.FindElement(By.XPath(xpathclass));
            string logouttext = "Здравствуйте, 1234!";
            Assert.Equal(logouttext, logtext.Text);
        }

        [Fact]
        public void TestLogoutClick_ByLogoutVisible()
        {
            string xpathbutton = "//*[@id=\"authSubmit\"]";
            IWebElement loginButton = _driver.FindElement(By.XPath(xpathbutton));
            string xpathUsername = "//*[@id=\"authUsername\"]";
            IWebElement usernameInput = _driver.FindElement(By.XPath(xpathUsername));
            string xpathPassword = "//*[@id=\"authPassword\"]";
            IWebElement passwordInput = _driver.FindElement(By.XPath(xpathPassword));
            usernameInput.SendKeys("1234");
            passwordInput.SendKeys("123456");
            loginButton.Click();
            //Thread.Sleep(10000);
            string xpathlogout = "//*[@id=\"logoutBtn\"]";
            IWebElement logoutButton = _driver.FindElement(By.XPath(xpathlogout));
            logoutButton.Click();
            string warningclass = "//*[@id=\"message\"]/span";
            IWebElement logouttext = _driver.FindElement(By.XPath(warningclass));
            string logoutext = "Вы вышли из системы.";
            Assert.Equal(logoutext, logouttext.Text);
        }


        [Fact]
        public void TestAddTextClick_DontRight()
        {
            string xpathbutton = "//*[@id=\"authSubmit\"]";
            IWebElement loginButton = _driver.FindElement(By.XPath(xpathbutton));
            string xpathUserName = "//*[@id=\"authUsername\"]";
            IWebElement usernameInput = _driver.FindElement(By.XPath(xpathUserName));
            string xpathPassword = "//*[@id=\"authPassword\"]";
            IWebElement passwordInput = _driver.FindElement(By.XPath(xpathPassword));
            usernameInput.SendKeys("1234");
            passwordInput.SendKeys("123456");
            loginButton.Click();
            //Thread.Sleep(10000);
            string savebuttonxpath = "//*[@id=\"saveBtn\"]";
            IWebElement savebutton = _driver.FindElement(By.XPath(savebuttonxpath));
            savebutton.Click();
            string editpath = "//*[@id=\"editorTitle\"]";
            IWebElement editText = _driver.FindElement(By.XPath(editpath));
            string edittext = "Новая заметка";
            Assert.Equal(edittext, editText.Text);
        }





        public void Dispose()
        {
            _driver.Quit();
        }
    }
}