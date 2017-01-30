using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Configuration;

namespace Domain.Helper
{
    public class Driver
    {
        private static int DefaultTimeOut
        {
           get
            {
                var deafultTimeOut = ConfigurationManager.AppSettings["DefaultTimeOutInSeconds"];
                return Convert.ToInt32(deafultTimeOut);
            }
        }

        public static string HomePageXpath
        {
            get
            {
                var homePageXpath = ConfigurationManager.AppSettings["HomePageXpath"];
                return homePageXpath;
            }
        }

        public static IWebDriver Instance { get; set; }

        private static ChromeOptions Options { get; set; }

        public static void Intialize()
        {
            Instance = new ChromeDriver();
            Options = new ChromeOptions();
            Options.AddArguments("--disable-extensions");
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(DefaultTimeOut));
            Instance.Manage().Window.Maximize();
        }

        public static void Close()
        {
            Instance.Close();            
        }

        public static void Quit()
        {
            Instance.Quit();
        }

        public static void GoTo()
        {
            var currentEnviorment = ConfigurationManager.AppSettings["currentEnviorment"];
            var currentEnviormentUrl = ConfigurationManager.AppSettings[currentEnviorment + "_Url"];
            Driver.Instance.Navigate().GoToUrl(currentEnviormentUrl);
            WaitUntilPageLoad(By.XPath(HomePageXpath));
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }

        public static void WaitUntilPageLoad(By by)
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(DefaultTimeOut));
            wait.Until(d => d.FindElement(by));     
        }

    }
}
