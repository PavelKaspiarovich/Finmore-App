

using WebDriverManager.Services.Impl;
using Bogus;

namespace FinmoreApp.Tests
{
    public class TestDataGenerator : BaseTest 
    {
        public static string RandomEmail()
        {
            return $"User_{Guid.NewGuid().ToString().Substring(0,6)}@gmail.com";
        }

        public static string RandomName()
        {
            return new Bogus.Faker("en").Name.FullName();
        }

        public const string password = "Test1234!";

    }

}