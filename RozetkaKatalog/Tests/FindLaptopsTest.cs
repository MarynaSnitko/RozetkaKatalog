using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace RozetkaCatalog
{
    public class FindLaptopTest
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Navigate().GoToUrl("https://rozetka.com.ua/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test()
        {
            Actions actions = new Actions(driver);
            RozetkaCatalogPage rozetkaCatalogPage = new RozetkaCatalogPage(driver);

            var laptopCatalog = rozetkaCatalogPage.laptopCatalog;
            var asusLaptopCatalog = rozetkaCatalogPage.asusLaptopCatalog;
            actions.MoveToElement(laptopCatalog).Perform();
            Thread.Sleep(7000); 

            actions.MoveToElement(asusLaptopCatalog).Click().Perform();
            //rozetkaCatalogPage.laptopCatalog.Click();

            Thread.Sleep(7000);

            Console.WriteLine(rozetkaCatalogPage.asusLabel.Text.Trim());
            Assert.True(IsElementPresent(rozetkaCatalogPage.asusLabel),
                $"Element '{rozetkaCatalogPage.asusLabel}' is not present on the page as expected");
        }

        public bool IsElementPresent(IWebElement element)
        {
            SetImplicitWaitTimeout(driver, 10);
            try
            {
                var result = element.Displayed;
                return true;
            }

            catch (NoSuchElementException)
            {
                SetImplicitWaitTimeout(driver, 10);
                return false;
            }
            throw new Exception("Unexpected exception.");
        }

        void SetImplicitWaitTimeout(IWebDriver driver, int timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }
    }
}
