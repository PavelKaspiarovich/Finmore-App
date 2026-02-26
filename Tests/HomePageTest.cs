using FinmoreApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FinmoreApp.Tests
{
    [TestFixture]

    public class HomePageTest : BaseTest
    {

        private void OpenHomePageMethods() // why this method is in HomePageTests but not in HomePage.cs??
        {
          HomePage.OpenHomePage();   

        }

        [Test]
        public void CheckTitleAndURL(){
            OpenHomePageMethods();

            Assert.Multiple(()=>
            {
                Assert.That(HomePage.GetHomePageUrl(),Does.Contain("https://finmore.netlify.app/"), 
                "URL is incorrect"
                );
                Assert.That(HomePage.GetHomePageTitle(),Does.Contain("Повнофункціональний фінансовий менеджер"),
                "Title is incorrect");
            });            
 
        }

        [Test]
        public void RegisterButtonIsDisplayed()
        {
             OpenHomePageMethods();           
             Assert.Multiple(() =>
            {
                Assert.That(HomePage.RegisterButtonVisible(),
                    Is.True, "Register button is not visible");
 
                Assert.That(HomePage.GetRegisterButtonText(),
                    Is.EqualTo("Register"),                   
                    "Register button text is incorrect");
            });

        }


        [Test]
        public void RegisterPageIsDisplayedIfClickRegisterButton()
        {
            OpenHomePageMethods();
            HomePage.ClickRegisterButton();
            var registrationPage = new RegistrationPage(Driver);
            Assert.That(
                registrationPage.IsRegisterFormVisible(),Is.True,
                "Registration form is absent"
            );        
           
        }

   }
}