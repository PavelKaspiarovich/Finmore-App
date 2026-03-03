using FinmoreApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FinmoreApp.Tests
{
    [TestFixture]

    public class HomePageTest : BaseTest
    {

        [Test]
        public void CheckTitleAndURL(){
            

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
                     
             Assert.Multiple(() =>
            {
                Assert.That(HomePage.RegisterButtonVisible(),
                    Is.True, "Register button is not visible");
 
                Assert.That(HomePage.GetRegisterButtonText(),
                    Is.EqualTo("Зареєструватися"),                   
                    "Register button text is incorrect");
            });

        }


        [Test]
        public void RegisterPageIsDisplayedIfClickRegisterButton()
        {
         
            HomePage.ClickRegisterButton();
            var registrationPage = new RegistrationPage(Driver);
            Assert.That(
                registrationPage.IsRegisterFormVisible(),Is.True,
                "Registration form is absent"
              
            
            );        
           
        }

   }
}