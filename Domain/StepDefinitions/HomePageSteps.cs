using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Domain.Helper;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Diagnostics;

namespace Domain.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {
        [Given(@"Open the home page in chrome bowser\.")]
        public void GivenOpenTheHomePageInChromeBowser_()
        {   
            string homePageTitle = "Real Estate | Properties for Sale, Rent and Share | Domain";
            var actualHomePageTitle = Driver.Instance.Title;
            Assert.IsTrue(homePageTitle == actualHomePageTitle,"ChromeDriver is not in homepage");
        }

        [Given(@"I click on the tab (.*)\.")]
        public void GivenClickOnTheTab_(string tabName)
        {
            try
            {
                var mainNavigationLink = Driver.Instance.FindElement(By.ClassName("main-nav-ul"));                
                var listOfNavigationItems = mainNavigationLink.FindElement(By.XPath("li//*[text()='" +tabName.Trim()+"']"));
                listOfNavigationItems.Click();
                
            }
            catch (Exception ex)
            {

                Assert.Fail("Unable to navigate to the tab {0}. Exception is {1}", tabName,ex.Message);
            }
            
        }

        [Then(@"The page should be successfully loaded with title (.*)\.")]
        public void ThenThePageShouldBeSuccessfullyLoadedWithTitle_(string expectedPageTitle)
        {
            var actualPageTitle = Driver.Instance.Title;
            Assert.IsTrue(expectedPageTitle == actualPageTitle, "Expected result {0} not matched with actual results {1}.", actualPageTitle);
            Driver.GoTo();
            
        }

        [BeforeTestRun]
        private static void IntializeChromeDriver()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }

            Driver.Intialize();
            try
            {
                Driver.GoTo();
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to vavigate to the homepage.Please check the exception {0}", ex.InnerException.ToString());
            }
        }

        [AfterTestRun]
        private static void GraceFullExitChromeDriver()
        {
            Driver.Close();
            Driver.Quit();
        }

    }
}
