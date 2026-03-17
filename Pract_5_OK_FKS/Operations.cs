using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using System.Windows;

using Xunit;
namespace Pract_5_OK_FKS
{
    public class Operations : IDisposable
    {
        private IWebDriver _driver;
        private static string BaseUrl = "https://test.webmx.ru/";

        public Operations()
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
        }

        [Fact]
        public void TestMain_BySave()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathclass1 = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(xpathclass1));
            name.SendKeys("1");
            string xpathclass = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathclass));
            save.Click();
            string xpathclass2 = "//*[@id=\"notesList\"]/li/strong";
            IWebElement list = _driver.FindElement(By.XPath(xpathclass2));
            Assert.Equal("1", list.Text);
        }
        [Fact]
        public void TestMain_BySaveAndChange()
        {
            LogIn();
            Thread.Sleep(100);
            string namexpath = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(namexpath));
            name.SendKeys("1");
            string xpathsave = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathsave));
            save.Click();
            name.SendKeys("2");
            save.Click();
            string xpathlist = "//*[@id=\"notesList\"]/li/strong";
            IWebElement list = _driver.FindElement(By.XPath(xpathlist));
            Assert.Equal("12", list.Text);
        }

        [Fact]
        public void TestMain_ByCreateNew()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathNewText = "//*[@id=\"newNoteBtn\"]";
            IWebElement NewText = _driver.FindElement(By.XPath(xpathNewText));
            NewText.Click();
            string namexpath = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(namexpath));
            name.SendKeys("123");
            string xpathsave = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathsave));
            save.Click();
            string xpathlist = "//*[@id=\"notesList\"]/li/strong";
            IWebElement list = _driver.FindElement(By.XPath(xpathlist));
            Assert.Equal("123", list.Text);
        }

        [Fact]
        public void TestMain_ByCreateNewAndDelete()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathNewText = "//*[@id=\"newNoteBtn\"]";
            IWebElement NewText = _driver.FindElement(By.XPath(xpathNewText));
            NewText.Click();
            string namexpath = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(namexpath));
            name.SendKeys("1");
            string xpathsave = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathsave));
            save.Click();
            string deletexpath = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(deletexpath));
            delete.Click();
            string xpathlist = "//*[@id=\"notesList\"]/li";
            IWebElement list = _driver.FindElement(By.XPath(xpathlist));
            Assert.Equal("Нет заметок. Создайте первую заметку.", list.Text);
        }

        [Fact]
        public void TestMain_ByCreateNewAndDeleteAndCreateNew()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathNewText = "//*[@id=\"newNoteBtn\"]";
            IWebElement NewText = _driver.FindElement(By.XPath(xpathNewText));
            NewText.Click();
            string namexpath = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(namexpath));
            name.SendKeys("1");
            string xpathsave = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathsave));
            save.Click();
            string deletexpath = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(deletexpath));
            delete.Click();
            name.SendKeys("1");
            save.Click();
            string xpathlist = "//*[@id=\"notesList\"]/li/strong";
            IWebElement list = _driver.FindElement(By.XPath(xpathlist));
            Assert.Equal("1", list.Text);
        }



        [Fact]
        public void TestMain_BySaveAndDelete()
        {
            LogIn();
            Thread.Sleep(100);
            string xpathclass1 = "//*[@id=\"noteTitle\"]";
            IWebElement name = _driver.FindElement(By.XPath(xpathclass1));
            name.SendKeys("1");
            string xpathclass = "//*[@id=\"saveBtn\"]";
            IWebElement save = _driver.FindElement(By.XPath(xpathclass));
            save.Click();
            string xpathdelete = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(xpathdelete));
            delete.Click();
            string xpathclass2 = "//*[@id=\"notesList\"]/li";
            IWebElement list = _driver.FindElement(By.XPath(xpathclass2));

            Assert.Equal("empty", list.GetAttribute("class"));
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}