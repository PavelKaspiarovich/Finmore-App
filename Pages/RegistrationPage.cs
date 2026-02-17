using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V142.Browser;
using OpenQA.Selenium.Support.UI;

namespace FinmoreApp.Pages
{
    
    public class RegistrationPage : BasePage
    {

        public readonly By NameInput = By.CssSelector("[data-testid='register-name-input']");
        public readonly By EmailInput = By.CssSelector("[data-testid='register-email-input']");
        public readonly By PasswordInput = By.CssSelector("[data-testid='register-password-input']");
        public readonly By ConfirmPasswordInput = By.CssSelector("[data-testid='register-confirm-password-input']");
        public readonly By CurrencySelect = By.CssSelector("[data-testid='register-currency-select']");
        public readonly By SubmitButton = By.CssSelector("[data-testid='register-submit-button']");



        private readonly By RegisterButton = By.CssSelector("[data-testid='register-submit-button']"); // Register button From HomePage

    
        public RegistrationPage(IWebDriver driver) : base(driver){}

        public void OpenRegistrationPage()
        {
            Driver.Navigate().GoToUrl("https://finmore.netlify.app/");
            Click(RegisterButton);
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

        public void EnterConfirmPassword(string confirmPpassword)
        {
            Type(ConfirmPasswordInput, confirmPpassword);        
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


