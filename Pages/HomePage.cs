using FinmoreApp.Pages;
using OpenQA.Selenium;

namespace FinmoreApp.Pages{

public class HomePage : BasePage
{
    private readonly By RegisterButton = By.CssSelector("[data-testid='switch-to-register-button']");

    public HomePage(IWebDriver driver) : base(driver)  // инициализировали конструктор
    {} 

    public void OpenHomePage()   
        {
            Driver.Navigate().GoToUrl("https://finmore.netlify.app/");
        }

    public string GetHomePageUrl()
        {
            return Driver.Url;
        }

    public string GetHomePageTitle()
        {
            return Driver.Title;
        }

        // create 2 metods: check that I open site, check title

    public void ClickRegisterButton()
        {
            Click(RegisterButton);
        }

    public bool RegisterButtonVisible()
        {
            
            return WaitForVisible(RegisterButton).Displayed;
        }

    public string GetRegisterButtonText()
        {
            return GetText(RegisterButton);
        }    
    
}

}

