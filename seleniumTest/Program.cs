using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var driver =new ChromeDriver();

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            Thread.Sleep(2000);

            IWebElement ele1 = driver.FindElement(By.ClassName("orangehrm-login-button"));           

            ele1.Click();
            driver.Close();
            Console.Write("test case ended ");

        }

    }
}
