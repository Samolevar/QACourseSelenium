// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QACourseSelenium
{
    [TestFixture]
    public class RegisterTests
    {
        private IWebDriver driver;


        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        private void navigateToSite()
        {
            //driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form"); //без багов 
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final"); //с багами
        }

        private void enterValidName()
        {
            driver.FindElement(By.ClassName("student")).SendKeys("Грибанов Сергей");
        }

        private void enterValidNickname()
        {
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Ronne");
        }

        private void selectMaleSex()
        {
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
        }

        private void enterValidEmail()
        {
            var email = "mr.ronne@yandex.ru";
            Assert.GreaterOrEqual(email.Length, 6);
            Assert.LessOrEqual(email.Length, 35);
            Assert.IsTrue(email.Contains("@"));
            driver.FindElement(By.ClassName("text-email")).SendKeys(email);
        }

        private void enterEqualsValidPasswords()
        {
            driver.FindElement(By.ClassName("text-password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm")).SendKeys("12345");
        }

        private void clickOnCheckboxAndSubmit()
        {
            //driver.FindElement(By.ClassName("/html/body/form/p/input")).Click();
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
        }

        [Test]
        public void AllValid()
        {
            navigateToSite();
            enterValidName();
            enterValidNickname();
            selectMaleSex();
            enterValidEmail();
            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void FailsWithTooShortValidLogin()
        {
            navigateToSite();
            enterValidName();

            var login = "R";
            Assert.Less(login.Length, 4);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(login);

            selectMaleSex();
            enterValidEmail();
            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void MinLengthValidLogin()
        {
            navigateToSite();
            enterValidName();

            var login = "Ronn";
            Assert.AreEqual(4, login.Length);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(login);

            selectMaleSex();
            enterValidEmail();
            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void MaxLengthValidLogin()
        {
            navigateToSite();
            enterValidName();

            var login = "Ronne6789012345678901234";
            Assert.AreEqual(24, login.Length);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(login);

            selectMaleSex();
            enterValidEmail();
            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void FailsWithTooLongValidLogin()
        {
            navigateToSite();
            enterValidName();

            var login = "Ronne67890123456789012345";
            Assert.Greater(login.Length, 24);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(login);

            selectMaleSex();
            enterValidEmail();
            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void FailsWithWithForbiddenCharactersInvalidLogin()
        {
            navigateToSite();
            enterValidName();

            var login = "Mr.Ronne";
            Assert.GreaterOrEqual(login.Length, 4);
            Assert.LessOrEqual(login.Length, 24);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(login);

            selectMaleSex();
            enterValidEmail();
            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void FailsWithOnlyForbiddenCharactersInvalidLogin()
        {
            navigateToSite();
            enterValidName();

            var login = "%$@.!:";
            Assert.GreaterOrEqual(login.Length, 4);
            Assert.LessOrEqual(login.Length, 24);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(login);

            selectMaleSex();
            enterValidEmail();
            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void FailsWithTooShortValidEmail()
        {
            navigateToSite();
            enterValidName();
            enterValidNickname();
            selectMaleSex();

            var email = "x@x.x";
            Assert.Less(email.Length, 6);
            Assert.IsTrue(email.Contains("@"));
            driver.FindElement(By.ClassName("text-email")).SendKeys(email);

            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            var expectedSubstring = "Field must be between 6 and 35 characters long";
            Assert.IsTrue(result.Contains(expectedSubstring), $"Expected to contains: \"{expectedSubstring}\", but was: \"{result}\"");
        }

        [Test]
        public void MinLengthValidEmail()
        {
            navigateToSite();
            enterValidName();
            enterValidNickname();
            selectMaleSex();

            var email = "x@x.xx";
            Assert.AreEqual(6, email.Length);
            Assert.IsTrue(email.Contains("@"));
            driver.FindElement(By.ClassName("text-email")).SendKeys(email);

            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void WithMaxLengthValidEmail()
        {
            navigateToSite();
            enterValidName();
            enterValidNickname();
            selectMaleSex();

            //var email = "x1234567890@x1234567890.x1234567890";
            var email = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx@x.xx";
            Assert.AreEqual(35, email.Length);
            Assert.IsTrue(email.Contains("@"));
            driver.FindElement(By.ClassName("text-email")).SendKeys(email);

            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void FailsWithTooLongValidEmail()
        {
            navigateToSite();
            enterValidName();
            enterValidNickname();
            selectMaleSex();

            var email = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx@xx.xx";
            Assert.Greater(email.Length, 35);
            Assert.IsTrue(email.Contains("@"));
            driver.FindElement(By.ClassName("text-email")).SendKeys(email);

            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            var expectedSubstring = "Field must be between 6 and 35 characters long";
            Assert.IsTrue(result.Contains(expectedSubstring), $"Expected to contains: \"{expectedSubstring}\", but was: \"{result}\"");
        }

        [Test]
        public void FailsWithNoAtSignsInvalidEmail()
        {
            navigateToSite();
            enterValidName();
            enterValidNickname();
            selectMaleSex();

            var email = "xxxxxxxx";
            Assert.GreaterOrEqual(email.Length, 6);
            Assert.LessOrEqual(email.Length, 35);
            Assert.IsFalse(email.Contains("@"));
            driver.FindElement(By.ClassName("text-email")).SendKeys(email);

            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            var expectedSubstring = "Invalid email address";
            Assert.IsTrue(result.Contains(expectedSubstring), $"Expected to contains: \"{expectedSubstring}\", but was: \"{result}\"");
        }

        [Test]
        public void FailsWithFewAtSignsInvalidEmail()
        {
            navigateToSite();
            enterValidName();
            enterValidNickname();
            selectMaleSex();

            var email = "xxx@xx@xx.xx";
            Assert.GreaterOrEqual(email.Length, 6);
            Assert.LessOrEqual(email.Length, 35);
            Assert.IsTrue(email.Contains("@"));
            driver.FindElement(By.ClassName("text-email")).SendKeys(email);

            enterEqualsValidPasswords();
            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            var expectedSubstring = "Invalid email address";
            Assert.IsTrue(result.Contains(expectedSubstring), $"Expected to contains: \"{expectedSubstring}\", but was: \"{result}\"");
        }

        [Test]
        public void FailsWithDifferentPasswords()
        {
            navigateToSite();
            enterValidName();
            enterValidNickname();
            selectMaleSex();
            enterValidEmail();

            driver.FindElement(By.ClassName("text-password")).SendKeys("onePass");
            driver.FindElement(By.Id("confirm")).SendKeys("twoPass");

            clickOnCheckboxAndSubmit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            var expectedSubstring = "Passwords must match";
            Assert.IsTrue(result.Contains(expectedSubstring), $"Expected to contains: \"{expectedSubstring}\", but was: \"{result}\"");
        }
    }
}