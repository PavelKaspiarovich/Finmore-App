using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V142.Browser;
using OpenQA.Selenium.Support.UI;

namespace FinmoreApp.Pages
{
    
    public class RegistrationPage : BasePage
    {

        private readonly By NameInput = By.CssSelector("[data-testid='register-name-input']");
        private readonly By EmailInput = By.CssSelector("[data-testid='register-email-input']");
        private readonly By PasswordInput = By.CssSelector("[data-testid='register-password-input']");
        private readonly By ConfirmPasswordInput = By.CssSelector("[data-testid='register-confirm-password-input']");
        private readonly By CurrencySelect = By.CssSelector("[data-testid='register-currency-select']");
        private readonly By SubmitButton = By.CssSelector("[data-testid='register-submit-button']");
        private readonly By RegisterForm = By.CssSelector("[data-testid='register-page']");




        // private readonly By RegisterButton = By.CssSelector("[data-testid='switch-to-register-button']"); // Register button From HomePage

    
        public RegistrationPage(IWebDriver driver) : base(driver){}


        public bool IsRegisterFormVisible()
        {
            return WaitForVisible(RegisterForm).Displayed;
        }
     
        public void EnterFullName(string fullName)
        {
            Type(NameInput, fullName);
        }

        public void EnterEmail(string email)
        {
            Type( EmailInput, email);
        }

        public void EnterPassword(string password)
        {
            Type(PasswordInput, password);        
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            Type(ConfirmPasswordInput, confirmPassword);        
        }

        public void SelectCurrency(string currencyValue)
        {
            var selectElement = new SelectElement(WaitForVisible(CurrencySelect));
            selectElement.SelectByValue(currencyValue);
        }

        public void ClickSubmitButton()
        {
            Click(SubmitButton);
        }

    }
   
}


