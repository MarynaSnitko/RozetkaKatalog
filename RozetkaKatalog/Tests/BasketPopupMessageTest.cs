using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using RozetkaCatalog.Pages;
using System;
using System.Threading;

namespace RozetkaCatalog.Tests
{
    public class BasketPopupMessageTest
    {
        IWebDriver driver;

        public const string titleTextMessage = "Ваша корзина пуста";
        public const string bodyTextMessage = "Добавляйте понравившиеся товары в корзину";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(70);
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
            BasketPage basketPage = new BasketPage(driver);

            var basketButton = basketPage.basketButton;
            var basketPopupMessage = basketPage.basketPopupMessage;

            actions.MoveToElement(basketButton).MoveToElement(basketButton).Perform();

            var searchTextOnPopupMessageButton = basketPage.searchTextOnPopupMessageButton;


            Thread.Sleep(7000);

            foreach (var textItem in searchTextOnPopupMessageButton)
            {
                Console.WriteLine(textItem.Text.Trim());
                Assert.True(textItem.Text.Trim().ToLower().Contains(titleTextMessage.Trim().ToLower()) || textItem.Text.Trim().ToLower().Contains(bodyTextMessage.Trim().ToLower()),
                   $"Element '{basketPage.searchTextOnPopupMessageButton}' is not present on the page as expected");
            }
        }
    }
}
