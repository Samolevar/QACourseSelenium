// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QACourseSelenium
{
    [TestFixture]
    public class TestClass
    {
        private IWebDriver driver;
        private FormChecker formChecker;

        [OneTimeSetUp]
        public void OneTimeSetUp() => driver = new ChromeDriver();

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Z5");
            formChecker = new FormChecker(driver);
        }

        [TearDown]
        public void TearDown() => formChecker.Run();

        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();

        public class FormChecker
        {
            public bool SpecifyLogin = true;
            public bool SpecifyGender = true;
            public bool SpecifyEmail = true;
            public bool SpecifyPassword = true;
            public bool SpecifyConfirmPassword = true;
            public bool MarkСheckBoxAgreement = true;

            public string Login = "dimazh";
            public int Gender = 1;
            public string Email = "testmail@testmail.ru";
            public string Password = "123456";
            public string ConfirmPassword = "123456";
            public string Errors = null;

            private readonly IWebDriver driver;

            public FormChecker(IWebDriver driver) => this.driver = driver;
            public void Run()
            {
                if (SpecifyLogin) driver.FindElement(By.ClassName("text-plain")).SendKeys(Login);
                if (SpecifyGender)
                {
                    var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
                    select.Options[Gender].Click();
                }

                if (SpecifyEmail) driver.FindElement(By.ClassName("text-email")).SendKeys(Email);
                if (SpecifyPassword) driver.FindElement(By.ClassName("text-password")).SendKeys(Password);
                if (SpecifyConfirmPassword) driver.FindElement(By.Id("confirm")).SendKeys(ConfirmPassword);

                var checkBox = driver.FindElement(By.ClassName("button-checkbox"));

                if (MarkСheckBoxAgreement) checkBox.Click();

                checkBox.Submit();
                CheckResults();
            }

            private void CheckResults()
            {
                if (Errors is null)
                {
                    var result = driver.FindElement(By.ClassName("flashes")).Text;
                    Assert.AreEqual(result, "Спасибо за регистрацию!");
                }
                else
                {
                    var result = driver.FindElement(By.ClassName("errors")).Text;
                    Assert.AreEqual(result, Errors);
                }
            }
        }

        [TestCase("dima", TestName = "LoginMinimumPossibleLengthTest")]
        [TestCase("dimazh", TestName = "LoginAverageLengthTest")]
        [TestCase("000000000000000symbols24", TestName = "LoginMaximumLengthTest")]
        [TestCase("123456", TestName = "LoginOnlyFromNumbersTest")]
        [TestCase("1d2i3m4a56", TestName = "LoginWithNumbersAndLettersTest")]
        [TestCase("d@imazh", "Invalid input.", TestName = "LoginWithSpecialCharactersTest")]
        [TestCase("", "Field must be between 4 and 24 characters long.\r\nInvalid input.", false, TestName = "LoginNotFilledInTest")]
        [TestCase("dim", "Field must be between 4 and 24 characters long.", TestName = "LoginLessThanPerhapsTest")]
        [TestCase("0000000000000000symbols25", "Field must be between 4 and 24 characters long.", TestName = "LoginTooLargeLengthTest")]
        public void CheckLogin(string login, string errors = null, bool specifyLogin = true)
        {
            formChecker.Login = login;
            formChecker.SpecifyLogin = specifyLogin;
            formChecker.Errors = errors;
        }

        [TestCase("t@t.ru", TestName = "EmailMinimumPossibleLengthTest")]
        [TestCase("testmail@testmail.ru", TestName = "EmailAverageLengthTest")]
        [TestCase("testmaillllllllsymbol35@testmail.ru", TestName = "EmailMaximumLengthTest")]
        [TestCase("testtest.ru", "Invalid email address.", TestName = "EmailWithoutDogSymbolTest")]
        [TestCase("te@stmail@testmail.ru", "Invalid email address.", TestName = "EmailWithSpecialCharactersTest")]
        [TestCase("", "Field must be between 6 and 35 characters long.\r\nInvalid email address.", false, TestName = "EmailNotFilledInTest")]
        [TestCase("t@t.t", "Field must be between 6 and 35 characters long.\r\nInvalid email address.", TestName = "EmailLessThanPerhapsTest")]
        public void CheckEmail(string email, string errors = null, bool specifyEmail = true)
        {
            formChecker.Email = email;
            formChecker.SpecifyEmail = specifyEmail;
            formChecker.Errors = errors;
        }

        [TestCase("123456", "123456", TestName = "PasswordMadeUpOfNumbersTest")]
        [TestCase("абвгде", "абвгде", TestName = "PasswordOfRussianLettersTest")]
        [TestCase("abcdef", "abcdef", TestName = "PasswordOfEnglishLettersTest")]
        [TestCase("a1b2c3def", "a1b2c3def", TestName = "PasswordOfEnglishLettersAndNumbersTest")]
        [TestCase("abcгбв", "abcгбв", TestName = "PasswordOfEnglishAndRussianLettersTest")]
        [TestCase("aAbBcC", "aAbBcC", TestName = "PasswordContainsUppercaseLettersTest")]
        [TestCase("1@23456", "1@23456", TestName = "PassworWithSpecialCharactersTest")]
        [TestCase("123456", "654321", "Passwords must match", TestName = "PassworDoesNotMatchesConfirmationTest")]
        [TestCase("", "123456", "This field is required.", false, TestName = "PasswordNotFilledInTest")]
        [TestCase("123456", "", "Passwords must match", true, false, TestName = "СonfirmPasswordNotFilledInTest")]
        public void CheckPassword(string password, string confirmPassword, string errors = null, 
            bool specifyPassword = true, bool specifyConfirmPassword = true)
        {
            formChecker.Password = password;
            formChecker.ConfirmPassword = confirmPassword;
            formChecker.SpecifyPassword = specifyPassword;
            formChecker.SpecifyConfirmPassword = specifyConfirmPassword;
            formChecker.Errors = errors;
        }

        [Test]
        public void AgreementNotMarkedTest() => formChecker.MarkСheckBoxAgreement = false;

        [TestCase(0, TestName = "EmptyGenderSelectedTest")]
        [TestCase(1, TestName = "MaleGenderSelectedTest")]
        [TestCase(2, TestName = "FemaleGenderSelectedTest")]
        [TestCase(0, false, TestName = "GenderNotSelectedTest")]
        public void CheckGender(int gender, bool specifyGender = true)
        {
            formChecker.Gender = gender;
            formChecker.SpecifyGender = specifyGender;
        }
    }
}
