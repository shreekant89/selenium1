using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitTest
{
    public  static class Config 
    {
        public static string browser;
        public static IWebDriver driver;
        public static string BaseUrl;
        static Config()
        {
            var configProvider = new ConfigurationProvider();
            browser = configProvider.Configuration.GetSection("TestConfig")["Browser"];
            driver = CreateDriver(browser);
            BaseUrl = configProvider.Configuration.GetSection("TestConfig")["BaseUrl"];
        }
        private static  IWebDriver CreateDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver(); 
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new NotSupportedException($"Browser '{browser}' is not supported.");
            }
        }
    }
}
