using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using System.Collections.ObjectModel;
using System.Windows;

using Xunit;
namespace Pract_5_OK_FKS
{
    public class ShowAndFindData : IDisposable
    {
        private IWebDriver _driver;
        private static string BaseUrl = "https://test.webmx.ru/";

        public ShowAndFindData()
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
        private void DeleteAll()
        {
            
        }

        [Fact]
        public void TestFind_BySearchHim()
        {
            DeleteAll();
            Thread.Sleep(100);
            CreateNew("q");
            CreateNew("q");
            CreateNew("q");
            Thread.Sleep(100);
            string xpathfind = "//*[@id=\"searchInput\"]";
            IWebElement find = _driver.FindElement(By.XPath(xpathfind));
            find.SendKeys("q");
            Thread.Sleep(100);
            string xpathlist = "//*[@id=\"notesList\"]/li";
            ReadOnlyCollection<IWebElement> list = _driver.FindElements(By.XPath(xpathlist));
            Thread.Sleep(100);
            Assert.Equal(2, list.Count);
            DeleteAll();
        }

        [Fact]
        public void TestFind_ByEnterNameAndSearchNotHim()
        {
            DeleteAll();
            LogIn();
            CreateNew("q");
            Thread.Sleep(100);
            string xpathfind = "//*[@id=\"searchInput\"]";
            IWebElement find = _driver.FindElement(By.XPath(xpathfind));
            find.SendKeys("q");
            Thread.Sleep(100);
            find.SendKeys("w");
            Thread.Sleep(100);
            string xpathlist = "//*[@id=\"notesList\"]/li";
            IWebElement list = _driver.FindElement(By.XPath(xpathlist));
            Assert.Equal("empty", list.GetAttribute("class"));
        }

        [Fact]
        public void TestFind_ByEnterNameAndSearchHim()
        {
            LogIn();
            CreateNew("q");
            Thread.Sleep(100);
            string xpathfind = "//*[@id=\"searchInput\"]";
            IWebElement find = _driver.FindElement(By.XPath(xpathfind));
            find.SendKeys("q");
            string xpathlist = "//*[@id=\"notesList\"]/li/strong";
            IWebElement list = _driver.FindElement(By.XPath(xpathlist));
            Assert.Equal("q", list.Text);
        }




        [Fact]
        public void TestFind_BySearchHimWithNotMainType()
        {
            LogIn();
            CreateNew("q");
            Thread.Sleep(100);
            string xpathfind = "//*[@id=\"searchInput\"]";
            IWebElement find = _driver.FindElement(By.XPath(xpathfind));
            find.SendKeys("q");
            string xpathchoose = "//*[@id=\"noteScopeFilter\"]";
            IWebElement choose = _driver.FindElement(By.XPath(xpathchoose));
            choose.Click();
            string notmain = "//*[@id=\"noteScopeFilter\"]/option[3]";
            IWebElement notmainchoose = _driver.FindElement(By.XPath(notmain));
            notmainchoose.Click();
            Thread.Sleep(100);
            string xpathlist = "//*[@id=\"notesList\"]/li";
            ReadOnlyCollection<IWebElement> list = _driver.FindElements(By.XPath(xpathlist));
            Assert.Equal(0, list.Count - 1);

        }
        public void Dispose()
        {
            _driver.Quit();
        }
    }
}