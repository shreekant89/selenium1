using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Xunit;

namespace XunitTest
{
    public class UnitTest1
    {
        //private readonly IWebDriver _driver;
        //public UnitTest1() => _driver = new ChromeDriver();
        private readonly IWebDriver _driver;
        private readonly string _baseUrl;
        private string _username = "Admin";
        private string _password = "admin123";

        public UnitTest1()
        {
            _driver = Config.driver;
            _baseUrl = Config.BaseUrl;
        }
        public void LogInToPortal()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
            Thread.Sleep(2000);
            IWebElement loginButton = _driver.FindElement(By.ClassName("orangehrm-login-button"));
            IWebElement username = _driver.FindElement(By.Name("username"));
            IWebElement password = _driver.FindElement(By.Name("password"));
            username.SendKeys(_username);
            password.SendKeys(_password);
            loginButton.Click();
            Thread.Sleep(2000);
        }
        [Fact]
        public void LogInRequiredfiledEnabled()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
            Thread.Sleep(2000);
            IWebElement loginButton = _driver.FindElement(By.ClassName("orangehrm-login-button"));
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorMsg = _driver.FindElement(By.ClassName("oxd-input-field-error-message"));
            Assert.True(errorMsg.Displayed);
        }

        [Fact]
        public void LoginSuccess()
        {
            LogInToPortal();
            string currentUrl = _driver.Url;
            Console.WriteLine("Current URL:----------- " + currentUrl);
            //_driver.Quit();
            Assert.NotEqual(currentUrl, _baseUrl);
            Assert.Contains("dashboard", currentUrl);
        }

        [Fact]
        public void IsDashboardLoadSucessfull()
        {
            LogInToPortal();
            IWebElement DashBoardGrid = _driver.FindElement(By.ClassName("orangehrm-dashboard-grid"));
            IList<IWebElement> childDivs = DashBoardGrid.FindElements(By.CssSelector(".oxd-grid-item.oxd-grid-item--gutters.orangehrm-dashboard-widget"));
            
            Assert.Equal(7, childDivs.Count);

        }



    }
}