using System;
using System.IO;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpExample
{
    [TestClass]
    public class SidetradeExample
    {
        [TestMethod]
        public void SearchForAimieBanner()
        {
            // Find folder with Chrome driver
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Set Chrome to start with maximized window
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            // Open Chrome
            using var chromeDriver = new ChromeDriver(browserDriverPath, options);

            // Assign the target URL
            var targetUrl = "https://www.sidetrade.com/aimie/";

            // Go to target URL
            chromeDriver.Navigate().GoToUrl(targetUrl);

            // Create new wait timer and set it to 30 seconds
            var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 0, 30));

            // Wait until the content is available
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("b-content")));

            // Find the Aimie banner element
            var aimieElement = chromeDriver.FindElement(By.CssSelector(".kt-inside-inner-col .has-orange-color"));

            // Confirm the element contains the word AIMIE
            Assert.IsTrue(aimieElement.Text.Contains("AIMIE"));

            // Close browser
            chromeDriver.Close();
        }
    }
}