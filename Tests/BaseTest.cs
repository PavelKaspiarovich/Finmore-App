using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FinmoreApp.Pages;
using OpenQA.Selenium.DevTools.V142.Network;

namespace FinmoreApp.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver{get; private set;} = null!;
        protected HomePage HomePage = null!;
 
        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            HomePage = new HomePage(Driver);
        }
 
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}