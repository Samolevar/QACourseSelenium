// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System;
using System.Threading;
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
        private string baseURL;
        private string StudentName;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            baseURL = "https://qa-course.kontur.host/training/ekb/form";
            StudentName = "Сергей Елчанинов";
        }

        void TestUrl()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        void EnterStudent()
        {
            driver.FindElement(By.ClassName("student")).SendKeys(StudentName);
        }

        void EnterLogin(string Login)
        {
            driver.FindElement(By.ClassName("text-plain")).SendKeys(Login);
        }

        void ChooseGender(int Index)
        {
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[Index].Click();  //Index: 0-Default, 1 - Male, 2 - Female
        }

        void EnterMail(string Mail)
        {
            driver.FindElement(By.ClassName("text-email")).SendKeys(Mail);
        }

        void EnterPass(string Pass)
        {
            driver.FindElement(By.ClassName("text-password")).SendKeys(Pass);
        }

        void EnterPassConfirm(string PassConfirm)
        {
            driver.FindElement(By.Id("confirm")).SendKeys(PassConfirm);
        }

        void CheckAgree()
        {
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
        }

        void ClickRegister()
        {
            var Submit = driver.FindElement(By.CssSelector("input[type=submit]"));
            Submit.Click();
        }
        
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        
        [Test]
        public void ValidRusLoginAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Сергей123");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ValidEngLoginAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ValidMinLengthLoginAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Serg");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ValidMaxLengthLoginAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("SergiPavlovichElchaninov");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InvalidLessThanMinLengthLoginNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("S3r");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void InvalidMoreThanMaxLengthLoginNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Serrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr123");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void InvalidSpecialSymbolsLoginNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Ser#123");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]  //Баг или ошибка требований (Логин, ограничения - 4 - 24 символа, только буквы и цифры)
        public void InvalidUnderscoreSymbolInLoginNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Serg___123");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void UsingSpacebarInLoginNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei Elchaninov");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void EmptyLoginNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }

        [Test]
        public void NotChosenGenderAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(0);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ValidMinLengthMailAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(1);
            EnterMail("1@1.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ValidMaxLengthMailAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(1);
            EnterMail("SergeiPavlovichElchaninov@Gmail.com");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InvalidLessThanMinLengthMailNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(1);
            EnterMail("1@1.u");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void InvalidMoreThanMaxLengthMailNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(1);
            EnterMail("hedghedghedghedghedghedghedghedghedg@.mail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void InvalidNotMailNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(1);
            EnterMail("hedg.mail.ru");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void EmptyMailNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(1);
            EnterMail("");
            EnterPass("123456");
            EnterPassConfirm("123456");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void PasswordMissmatchNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("123");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void EmptyPasswordConfirmNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei123");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("123456");
            EnterPassConfirm("");
            CheckAgree();
            ClickRegister();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void RegisterByEnterKeyAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei100500");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("1");
            EnterPassConfirm("1");
            CheckAgree();

            var Submit = driver.FindElement(By.CssSelector("input[type=submit]"));
            Submit.SendKeys(Keys.Enter);

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmptyPassNotAllowed()
        {
            TestUrl();
            EnterStudent();
            EnterLogin("Sergei100501");
            ChooseGender(1);
            EnterMail("testmail@testmail.ru");
            EnterPass("");
            EnterPassConfirm("");
            CheckAgree();
            ClickRegister();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement Password = driver.FindElement(By.ClassName("text-password"));
            String ValidationMessage = Password.GetAttribute("validationMessage");
            Assert.AreEqual("Заполните это поле.", ValidationMessage);
        }

    }
}
