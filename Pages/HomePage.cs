using FinmoreApp.Pages;
using OpenQA.Selenium;

namespace FinmoreApp.HomePage{

public class HomePage : BasePage
{
    private readonly By RegisterButton = By.CssSelector("[data-testid='register-submit-button']");

    public HomePage(IWebDriver driver) : base(driver)  // инициализировали конструктор
    {} 

    public void OpenHomePage()   
        {
            Driver.Navigate().GoToUrl("https://finmore.netlify.app/");
        }

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

