using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using Bogus;

namespace FinmoreApp
{
    [TestFixture]
    public class HomePageTest
    {

        IWebDriver driver = null!;
        Faker faker = null!;


        [SetUp]
        public void SetUp()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            faker = new Faker("uk");
        }
        [Test]
        public void OpenSite()
        {
            driver.Navigate().GoToUrl("https://finmore.netlify.app/");

            Assert.That(
              driver.Url,
              Does.Contain("finmore.netlify.app"),
              "Error"
          );


            Assert.That(driver.Title, Does.Contain("Повнофункціональний фінансовий менеджер"));

        }

        [Test]

        public void CheckRegistration()
        {
            driver.Navigate().GoToUrl("https://finmore.netlify.app/");
            // driver.FindElement(By.CssSelector("[data-testid='switch-to-register-button']")).Click();

            // Assert.Pass("Registration button clicked");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // var button = wait.Until(
            // ExpectedConditions.ElementIsVisible(
            // By.CssSelector("[data-testid='switch-to-register-button']")           
            //     )
            // );

            var button = wait.Until(d =>
                d.FindElement(By.CssSelector("[data-testid='switch-to-register-button']"))
            );
            Assert.Multiple(() =>
            {
                Assert.That(button.Displayed, Is.True);
                Assert.That(button.Text, Does.Contain("Зареєструватися"));
            });

            button.Click();

            Assert.That(
              driver.Url,
              Does.Contain("https://finmore.netlify.app/"),
              "Error"
          );


            Assert.That(driver.Title, Does.Contain("Повнофункціональний фінансовий менеджер"));
        }

        [Test]
        public void CheckRegisterFormIsVisible()
        {
            driver.Navigate().GoToUrl("https://finmore.netlify.app/");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        var button = wait.Until(d =>
                d.FindElement(By.CssSelector("[data-testid='switch-to-register-button']"))
            );
            Assert.Multiple(() =>
            {
                Assert.That(button.Displayed, Is.True);
                Assert.That(button.Text, Does.Contain("Зареєструватися"));
            });

            button.Click();

            var form = wait.Until(d =>
                d.FindElement(By.CssSelector("[data-testid='register-form']"))
            );

            Assert.That(form.Displayed);
        }



        [Test]

        public void CheckRegistrationMandatoryFields()
        {
            driver.Navigate().GoToUrl("https://finmore.netlify.app/%22);");   

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));



            var button = wait.Until(d =>
                d.FindElement(By.CssSelector("[data-testid='switch-to-register-button']"))
            );
            Assert.Multiple(() =>
            {
                Assert.That(button.Displayed, Is.True);
                Assert.That(button.Text, Does.Contain("Зареєструватися"));
            });

            button.Click();


            var nameInput = wait.Until( d=> d.FindElement(By.CssSelector("[data-testid='register-name-input']"))
            );
            string namePlaceholder = nameInput.GetAttribute("placeholder")!;

            var emailInput = wait.Until( d=> d.FindElement(By.CssSelector("[data-testid='register-email-input']"))
            );
            string emailPlaceholder = emailInput.GetAttribute("placeholder")!;

            var passwordInput = wait.Until( d => d.FindElement(By.CssSelector("[data-testid='register-password-input']"))
            );
            string passwordPlaceholder = passwordInput.GetAttribute("placeholder")!;

            var confirmPasswordInput = wait.Until( d => d.FindElement(By.CssSelector("[data-testid='register-confirm-password-input']"))
            );
            string confirmPasswordPlaceholder = confirmPasswordInput.GetAttribute("placeholder")!;

            var currencySelect = wait.Until( d => d.FindElement(By.CssSelector("[data-testid='register-currency-select']"))
            );
            var currencyDropdown = new SelectElement(currencySelect);
            var optionTexts = currencyDropdown.Options
            .Select(o => o.Text)
            .ToList();

            var registerButton = wait.Until(d => d.FindElement(By.CssSelector("[data-testid='register-submit-button']"))
            );


            Assert.Multiple(() =>
            {
               Assert.That(namePlaceholder, Is.EqualTo("Іван Петренко"));
               Assert.That(emailPlaceholder, Is.EqualTo("your@email.com"));
               Assert.That(passwordPlaceholder, Is.EqualTo("Мінімум 6 символів"));
               Assert.That(confirmPasswordPlaceholder, Is.EqualTo("Повторіть пароль"));
               Assert.That(optionTexts, Does.Contain("Гривня (UAH)"));
               Assert.That(optionTexts, Does.Contain("Долар США (USD)"));
               Assert.That(optionTexts, Does.Contain("Євро (EUR)"));
               Assert.That(optionTexts, Does.Contain("Фунт стерлінгів (GBP)"));
               Assert.That(registerButton.Displayed);
               Assert.That(registerButton.Text, Is.EqualTo("Зареєструватися"));
               Assert.That(registerButton.Enabled);
            }                
            );
       
        }


        public string GenerateRandomEmail()
{
    var random = new Random();
    const string chars = "abcdefghijklmnopqrstuvwxyz";
    var username = new string(Enumerable.Repeat(chars, 8)
        .Select(s => s[random.Next(s.Length)]).ToArray());
    return $"{username}@test.com";
}

        [Test]
public void FillRegistrationForm()
{
    driver.Navigate().GoToUrl("https://finmore.netlify.app/");


    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        var button = wait.Until(d =>
                d.FindElement(By.CssSelector("[data-testid='switch-to-register-button']"))
            );
            Assert.Multiple(() =>
            {
                Assert.That(button.Displayed, Is.True);
                Assert.That(button.Text, Does.Contain("Зареєструватися"));
            });

            button.Click();

var randomEmail = GenerateRandomEmail(); 
var fullName = faker.Name.FullName();



 
    driver.FindElement(By.CssSelector("[data-testid='register-name-input']"))  
          .SendKeys(fullName);  
          Console.WriteLine($"User Name: {fullName}");
 
    driver.FindElement(By.CssSelector("[data-testid='register-email-input']"))  // Should user be uniq ?
          .SendKeys(randomEmail);

          Console.WriteLine($"Using email: {randomEmail}");
 
    driver.FindElement(By.CssSelector("[data-testid='register-password-input']"))
          .SendKeys("Password123!");
 
    driver.FindElement(By.CssSelector("[data-testid='register-confirm-password-input']"))
          .SendKeys("Password123!");
 
    driver.FindElement(By.CssSelector("[data-testid='register-currency-select']"))
          .SendKeys("USD");




    var registerButton = wait.Until(d => d.FindElement(By.CssSelector("[data-testid='register-submit-button']"))
            );      
    registerButton.Click();



}






        [TearDown]
        public void TearDown()
        {

            driver.Quit();
        }

    }
}