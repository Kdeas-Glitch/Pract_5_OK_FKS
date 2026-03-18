using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

using System.Windows;

using Xunit;
namespace Pract_5_OK_FKS
{
    public class MessagesTests : IDisposable
    {
        private IWebDriver _driver;
        private static string BaseUrl = "https://test.webmx.ru/";

        public MessagesTests()
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
            IAlert alert = _driver.SwitchTo().Alert();
            string alertText = alert.Text;
            Assert.Contains("Удалить заметку? Это действие необратимо.", alert.Text);
            alert.Accept();
        }
        private void DeleteNewNotAccept()
        {
            string xpathdelete = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(xpathdelete));
            delete.Click();
            IAlert alert = _driver.SwitchTo().Alert();
            Assert.Contains("Удалить заметку? Это действие необратимо.", alert.Text);
            alert.Dismiss();
        }

        [Fact]
        public void TestCreateMessage()
        {
            LogIn();
            CreateNew("q");
            Thread.Sleep(100);
            string xpathMessage = "//*[@id=\"message\"]/span";
            IWebElement list = _driver.FindElement(By.XPath(xpathMessage));
            string allrgiht = "Заметка создана.";
            Assert.Equal(allrgiht, list.Text);
        }


        [Fact]
        public void TestChangeMessage()
        {
            LogIn();
            CreateNew("q");
            Thread.Sleep(100);
            string xpathchenge = "//*[@id=\"noteTitle\"]";
            IWebElement change = _driver.FindElement(By.XPath(xpathchenge));
            change.SendKeys("2");
            Thread.Sleep(100);
            string xpathbtn = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathbtn));
            save.Click();
            Thread.Sleep(100);
            string xpathMessage = "//*[@id=\"message\"]/span";
            IWebElement list = _driver.FindElement(By.XPath(xpathMessage));
            string allrgiht = "Заметка обновлена.";
            Assert.Equal(allrgiht, list.Text);
        }

        [Fact]
        public void TestDeleteMessage()
        {
            LogIn();
            CreateNew("q");
            Thread.Sleep(100);
            DeleteNew();
            Thread.Sleep(100);
            string xpathMessage = "//*[@id=\"message\"]/span";
            IWebElement list = _driver.FindElement(By.XPath(xpathMessage));
            string allrgiht = "Заметка удалена.";
            Assert.Equal(allrgiht, list.Text);
        }

        [Fact]//fixid
        public void TestDeleteMessageNothing()
        {
            LogIn();
            string title = "q";
            CreateNew(title);
            Thread.Sleep(100);
            DeleteNewNotAccept();
            Thread.Sleep(100);
            string xpathMessage = "//*[@id=\"notesList\"]/li[1]/strong";
            IWebElement list = _driver.FindElement(By.XPath(xpathMessage));
            Assert.Equal(title, list.Text);
        }


        public void Dispose()
        {
            _driver.Quit();
        }
    }
}