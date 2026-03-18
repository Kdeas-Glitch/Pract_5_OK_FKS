using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

using System.Collections.ObjectModel;
using System.Windows;

using Xunit;
namespace Pract_5_OK_FKS
{
    public class MainBlock : IDisposable
    {
        private IWebDriver _driver;
        private static string BaseUrl = "https://test.webmx.ru/";

        private void LogIn()
        {
            string xpathbutton = "//*[@id=\"authSubmit\"]";
            IWebElement loginButton = _driver.FindElement(By.XPath(xpathbutton));
            string xpath = "//*[@id=\"authUsername\"]";
            IWebElement usernameInput = _driver.FindElement(By.XPath(xpath));
            string xpath2 = "//*[@id=\"authPassword\"]";
            IWebElement passwordInput = _driver.FindElement(By.XPath(xpath2));
            usernameInput.SendKeys("1234");
            passwordInput.SendKeys("123456");
            loginButton.Click();
        }
        
        public MainBlock()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        [Fact]
        public void TestMain_BySaveAndDelete()
        {
            /*DeleteAll();*/
            LogIn();
            Thread.Sleep(100);
            string xpathtitle = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(xpathtitle));
            name.SendKeys("1");
            string xpathsavebtn = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathsavebtn));
            save.Click();
            Thread.Sleep(100);

            string xpathdelete = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(xpathdelete));
            delete.Click();
            Thread.Sleep(100);

            IAlert alert = _driver.SwitchTo().Alert();
            Assert.Contains("Удалить заметку? Это действие необратимо.", alert.Text);
            alert.Accept();
            Thread.Sleep(100);
            string xpathlist = "//*[@id=\"notesList\"]/li";
            IWebElement list = _driver.FindElement(By.XPath(xpathlist));
            Thread.Sleep(100);
            string empty = "Нет заметок. Создайте первую заметку.";
            Assert.Equal(empty, list.Text);
        }


        [Fact]
        public void TestLogin_ByLogText()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathloginwelcome = "//*[@id=\"welcomeText\"]";
            IWebElement logtext = _driver.FindElement(By.XPath(xpathloginwelcome));
            string logouttext = "Здравствуйте, 1234!";
            Assert.Equal(logouttext, logtext.Text);
        }

        [Fact]
        public void TestMain_ByLogout()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathlogoutbtn = "//*[@id=\"logoutBtn\"]";
            IWebElement logout = _driver.FindElement(By.XPath(xpathlogoutbtn));
            Assert.True(logout.Displayed);
        }


        [Fact]
        public void TestMain_ByNewText()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathnewnote = "//*[@id=\"newNoteBtn\"]";
            IWebElement newtext = _driver.FindElement(By.XPath(xpathnewnote));
            Assert.True(newtext.Displayed);
        }


        [Fact]
        public void TestMain_BySaveButton()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathsavebtn = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathsavebtn));
            Assert.True(save.Displayed);
        }

        [Fact]
        public void TestMain_ByInputName()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathtitle = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(xpathtitle));
            Assert.True(name.Displayed);
        }

        [Fact]
        public void TestMain_ByDeleteButton()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathclassdelete = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(xpathclassdelete));
            Assert.False(delete.Enabled);
        }

        [Fact]
        public void TestMain_BySaveSButton()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathsave = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathsave));
            Assert.True(save.Enabled);
        }


        [Fact]
        public void TestLogoutClick_ByLogoutText()
        {
            LogIn();
            Thread.Sleep(100);
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
        public void TestLogInClick_ByLogoutText()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathwelcome = "//*[@id=\"welcomeText\"]";
            IWebElement logtext = _driver.FindElement(By.XPath(xpathwelcome));
            string logouttext = "Здравствуйте, 1234!";
            Assert.Equal(logouttext, logtext.Text);
        }


        [Fact]
        public void TestMain_BySave()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathtitle = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(xpathtitle));
            name.SendKeys("1");
            string xpathsave = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathsave));
            save.Click();
            string xpathlist = "//*[@id=\"notesList\"]/li/strong";
            IWebElement list = _driver.FindElement(By.XPath(xpathlist));
            Assert.Equal("1", list.Text);
        }


        public void Dispose()
        {
            _driver.Quit();
        }
    }
}