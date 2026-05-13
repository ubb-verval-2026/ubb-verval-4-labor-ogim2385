using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DatesAndStuff.Web.Tests
{
    [TestFixture]
    public class FlightTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void BlazeDemo_MexicoCity_To_Dublin_ShouldShowFlights()
        {
            driver.Navigate().GoToUrl("https://blazedemo.com/");

            // Departure
            var from = driver.FindElement(By.Name("fromPort"));
            from.SendKeys("Mexico City");

            // Destination
            var to = driver.FindElement(By.Name("toPort"));
            to.SendKeys("Dublin");

            // Search
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // Egyszerű várakozás az eredmény táblára
            System.Threading.Thread.Sleep(2000);

            var flights = driver.FindElements(By.CssSelector("table tbody tr"));

            Assert.That(flights.Count, Is.GreaterThanOrEqualTo(2),
                $"Várható legalább 2 járat, de csak {flights.Count} található.");
        }
    }
}