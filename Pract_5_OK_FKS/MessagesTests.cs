using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

using System.Windows;

using Xunit;
namespace Pract_5_OK_FKS
{
    public class TestsWithAuthorisation : IDisposable
    {
        private IWebDriver _driver;
        private static string BaseUrl = "https://test.webmx.ru/";

        public TestsWithAuthorisation()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        private void LogIn()
        {
            string xpathbutton = "//*[@id=\"authSubmit\"]";
            IWebElement loginButton = _driver.FindElement(By.XPath(xpathbutton));
            string xpathUsername = "//*[@id=\"authUsername\"]";
            IWebElement usernameInput = _driver.FindElement(By.XPath(xpathUsername));
            string passwordxpath2 = "//*[@id=\"authPassword\"]";
            IWebElement passwordInput = _driver.FindElement(By.XPath(passwordxpath2));
            usernameInput.SendKeys("1234");
            passwordInput.SendKeys("123456");
            loginButton.Click();
            Thread.Sleep(100);
        }
        private void CreateNew(string title)
        {
            string xpathclass1 = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(xpathclass1));
            name.SendKeys(title);
            string xpathclass = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathclass));
            save.Click();
        }

        private void DeleteNew()
        {
            string xpathdelete = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(xpathdelete));
            delete.Click();
        }


        [Fact]
        public void TestAccesToSave_BySaveButton()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathsavebtn = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathsavebtn));
            Assert.True(save.Displayed);
        }

        [Fact]
        public void TestAccesToDelete_ByDeleteButton()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathdelete = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(xpathdelete));
            Assert.True(delete.Displayed);
        }

        [Fact]
        public void TestAccesToCreateNew_ByCreateNewButton()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathnewnote = "//*[@id=\"newNoteBtn\"]";
            IWebElement createnew = _driver.FindElement(By.XPath(xpathnewnote));
            Assert.True(createnew.Displayed);
        }

        [Fact]
        public void TestAccesToLogout_ByLogoutButton()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathlogoutbtn = "//*[@id=\"logoutBtn\"]";
            IWebElement logout = _driver.FindElement(By.XPath(xpathlogoutbtn));
            Assert.True(logout.Displayed);
        }



        [Fact]
        public void TestAccesToDeleteNull_ByDeleteButton()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathdelete = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(xpathdelete));
            Assert.False(delete.Enabled);
        }

        [Fact]
        public void TestAccesToOpenNull_ByOpenButton()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathshare = "//*[@id=\"shareBtn\"]";
            IWebElement share = _driver.FindElement(By.XPath(xpathshare));
            Assert.False(share.Displayed);
        }







        public void Dispose()
        {
            _driver.Quit();
        }
    }
}