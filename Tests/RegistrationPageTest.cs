using WebDriverManager.Services.Impl;
using FinmoreApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V142.FedCm;


namespace FinmoreApp.Tests
{

    public class RegistrationPageTest : BaseTest
    {

  
    [Test]

        public void UserIsSuccessfullyRegistered()
        {
            
            var registrationPage = new RegistrationPage(Driver);
            var email = TestDataGenerator.RandomEmail();
            var fullName = TestDataGenerator.RandomName();
            var password = TestDataGenerator.password;
            
            HomePage.ClickRegisterButton();
             Assert.That(registrationPage.IsRegisterFormVisible(),Is.True);

              registrationPage.RegisterUser(
                fullName,
                email,
                password,
                password,
                "USD"                
                ); 

            // Assert.That(registrationPage.IsRegisterFormVisible(),Is.False);
                Assert.That(
                Driver.Url,
                Does.Not.Contain("register"),
                "User was not redirected after registration"
                );
         
                       
                        
        }               


    }


}