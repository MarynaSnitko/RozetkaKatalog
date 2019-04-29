using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RozetkaCatalog
{
    public class RozetkaCatalogPage
    {
        public IWebDriver driver;
        public RozetkaCatalogPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector
            , Using = "div[class='menu-wrapper display-block menu-wrapper_state_static'] a[href='https://rozetka.com.ua/computers-notebooks/c80253/']")]
        public IWebElement laptopCatalog;

        [FindsBy(How = How.CssSelector, Using = "a[href='https://rozetka.com.ua/notebooks/asus/c80004/v004/']")]
        public IWebElement asusLaptopCatalog;

        [FindsBy(How = How.CssSelector, Using = "[class='filter-active'] a[href='https://rozetka.com.ua/notebooks/c80004/filter/']")]
        public IWebElement asusLabel;
        }
}
