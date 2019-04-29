using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace RozetkaCatalog.Pages
{
    public class BasketPage
    {
        public IWebDriver driver;
        public BasketPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[class='header-actions__button header-actions__button_type_basket']")]
        public IWebElement basketButton;

        [FindsBy(How = How.CssSelector, Using = "li[class='header-actions__item header-actions__item_type_cart'] [class='header-actions__dummy-title']")]
        public IWebElement basketPopupMessage;

        [FindsBy(How = How.CssSelector, Using = "[class='header-actions__dummy-content header-actions__dummy-content_type_cart'] p")]
        public IList<IWebElement> searchTextOnPopupMessageButton;
    }
}