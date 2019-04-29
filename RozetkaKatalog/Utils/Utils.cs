using OpenQA.Selenium;
using System;

namespace RozetkaCatalog
{
    class Utils
    {
        public void SetImplicitWaitTimeout(IWebDriver driver, int timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }
    }
}
