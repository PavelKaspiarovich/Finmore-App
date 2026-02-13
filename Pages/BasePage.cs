using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinmoreApp.Pages

{
    public class BasePage
    {
        protected IWebDriver Driver = null!;

        protected WebDriverWait Wait = null!;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitForVisible(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void Click(By locator)
        {
            WaitForVisible(locator).Click();
        }

        protected string GetText(By locator)
        {
            return WaitForVisible(locator).Text;
        }

        protected string GetAttribute(By locator, string attribute)
        {
            return WaitForVisible(locator).GetAttribute(attribute);
        }

        protected void Type(By locator, string text)
        {
            var element = WaitForVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

       
    }



}