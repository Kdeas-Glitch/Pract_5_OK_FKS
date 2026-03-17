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
            /*LogIn();
            string xpathdelete = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(xpathdelete));
            string xpath = "//*[@id=\"notesList\"]/li[1]";
            ReadOnlyCollection<IWebElement> list = _driver.FindElements(By.XPath(xpath));
            for(int i=0;i<list.Count-1;i++)
            {
                list[i].Click();
                delete.Click();
            }*/
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
            string xpathclass2 = "//*[@id=\"notesList\"]/li";
            IWebElement list = _driver.FindElement(By.XPath(xpathclass2));
            list.Click();
            string xpathdelete = "//*[@id=\"deleteBtn\"]";
            IWebElement delete = _driver.FindElement(By.XPath(xpathdelete));
            delete.Click();
            Assert.Equal("empty", list.GetAttribute("class"));
        }


        //[Fact]
        //public void TestLogin_ByLogText()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    string xpathclass = "//*[@id=\"welcomeText\"]";
        //    IWebElement logtext = _driver.FindElement(By.XPath(xpathclass));
        //    string logouttext = "Здравствуйте, 1234!";
        //    Assert.Equal(logouttext, logtext.Text);
        //}

        //[Fact]
        //public void TestMain_ByLogout()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    string xpathclass = "//*[@id=\"logoutBtn\"]";
        //    IWebElement logout = _driver.FindElement(By.XPath(xpathclass));
        //    Assert.True(logout.Displayed);
        //}


        //[Fact]
        //public void TestMain_ByNewText()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    string xpathclass = "//*[@id=\"newNoteBtn\"]";
        //    IWebElement newtext = _driver.FindElement(By.XPath(xpathclass));
        //    Assert.True(newtext.Displayed);
        //}


        //[Fact]
        //public void TestMain_BySaveButton()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    string xpathclass = "//*[@id=\"saveBtn\"]";
        //    IWebElement save = _driver.FindElement(By.XPath(xpathclass));
        //    Assert.True(save.Displayed);
        //}

        //[Fact]
        //public void TestMain_ByInputName()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    string xpathclass = "//*[@id=\"noteTitle\"]";
        //    IWebElement name = _driver.FindElement(By.XPath(xpathclass));
        //    Assert.True(name.Displayed);
        //}

        //[Fact]
        //public void TestMain_ByDeleteButton()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    string xpathclass = "//*[@id=\"deleteBtn\"]";
        //    IWebElement delete = _driver.FindElement(By.XPath(xpathclass));
        //    Assert.False(delete.Enabled);
        //}

        //[Fact]
        //public void TestMain_BySaveSButton()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    string xpathclass = "//*[@id=\"saveBtn\"]";
        //    IWebElement save = _driver.FindElement(By.XPath(xpathclass));
        //    Assert.True(save.Enabled);
        //}


        //[Fact]
        //public void TestLogoutClick_ByLogoutText()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    //Thread.Sleep(10000);
        //    string xpathclass = "//*[@id=\"logoutBtn\"]";
        //    IWebElement logoutButton = _driver.FindElement(By.XPath(xpathclass));
        //    logoutButton.Click();
        //    string warningclass = "//*[@id=\"message\"]/span";
        //    IWebElement logouttext = _driver.FindElement(By.XPath(warningclass));
        //    string logoutext = "Вы вышли из системы.";
        //    Assert.Equal(logoutext, logouttext.Text);
        //}

        //[Fact]
        //public void TestLogInClick_ByLogoutText()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    string xpathclass = "//*[@id=\"welcomeText\"]";
        //    IWebElement logtext = _driver.FindElement(By.XPath(xpathclass));
        //    string logouttext = "Здравствуйте, 1234!";
        //    Assert.Equal(logouttext, logtext.Text);
        //}


        //[Fact]
        //public void TestMain_BySave()
        //{
        //    LogIn();
        //    Thread.Sleep(100);
        //    string xpathclass1 = "//*[@id=\"noteTitle\"]";
        //    IWebElement name = _driver.FindElement(By.XPath(xpathclass1));
        //    name.SendKeys("1");
        //    string xpathclass = "//*[@id=\"saveBtn\"]";
        //    IWebElement save = _driver.FindElement(By.XPath(xpathclass));
        //    save.Click();
        //    string xpathclass2 = "//*[@id=\"notesList\"]/li/strong";
        //    IWebElement list = _driver.FindElement(By.XPath(xpathclass2));
        //    Assert.Equal("1", list.Text);
        //}


        public void Dispose()
        {
            _driver.Quit();
        }
    }
}