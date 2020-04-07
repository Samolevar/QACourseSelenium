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
    public class TestClass
    {
        private IWebDriver driver;
        private string validUrl;
        private string myName;
        private string validLogin;
        private string validEmail;
        private string validPassword;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            validUrl = "https://qa-course.kontur.host/training/ekb/form";
            validLogin = "KOTI4";
            myName = "Lubozhev Konstantin";
            validEmail = "lubozhevk@gmail.ru";
            validPassword = "qwerty";
        }

        private void ChooseGender(int index)
        {
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[index].Click();
        }

        private void ChooseGender()
        {
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
        }

        private void EnterStudentName() => driver.FindElement(By.ClassName("student")).SendKeys(myName);
        private void EnterStudentName(string name) => driver.FindElement(By.ClassName("student")).SendKeys(name);


        private void EnterLogin() => driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);
        private void EnterLogin(string login) => driver.FindElement(By.ClassName("text-plain")).SendKeys(login);


        private void EnterEmail() => driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
        private void EnterEmail(string email) => driver.FindElement(By.ClassName("text-email")).SendKeys(email);


        private void EnterPasswordAndConfPassword()
        {
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);
        }

        private void EnterPasswordAndConfPassword(string password)
        {
            driver.FindElement(By.ClassName("text-password")).SendKeys(password);
            driver.FindElement(By.Id("confirm")).SendKeys(password);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        //[Test]
        //public void ChromeDriverTest()
        //{
        //    driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
        //    driver.FindElement(By.ClassName("gLFyf")).SendKeys("google");
        //    Thread.Sleep(500);
        //    driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
        //    var text = driver.FindElement(By.ClassName("e2BEnf")).Text;
        //    Assert.That(text, Is.EqualTo("Главные новости").After(500));
        //}


        [Test]
        public void InitialTest()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }














        //Login
        [Test]
        public void LoginWith4Charecters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin("KOTI");
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void LoginWithMoreThen4AndLessThen24Charecters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin("kotich");
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void LoginWith24Charecters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin("kkkkkkkkkkkkkkkkkkkkkkkk");
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void LoginWithRussianLayout()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin("котич");
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmptyLogin()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin("");
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result1 = driver.FindElement(By.XPath("/html/body/form/dl/dd[2]/ul/li[1]")).Text;
            var result2 = driver.FindElement(By.XPath("/html/body/form/dl/dd[2]/ul/li[2]")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result1);
            Assert.AreEqual("Invalid input.", result2);
        }

        [Test]
        public void LoginWithLessThen4characters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin("KOT");
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginWithMoreThen24characters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin("KOTI4isTheBestAnaInWholeOverwatchComunity");
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginWithSpecialSymbols()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin("$KOTI4%");
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }


        [Test]
        public void LoginWithSpaces()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin("KOT I4");
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }





        //Email
        [Test]
        public void CorrectEmail()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail("lubozhevk@gmail.com");
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }



        [Test]
        public void EmailWith6Charecters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail("k@l.ru");
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void EmailWithMoreThen6AndLessThen35Charecters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail("kavo@mail.ru");
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void EmailWith35Charecters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail("kkkkkkkkkkkkkkkkkkkkkkkkkkk@mail.ru");
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void EmailWithMoreThen35Charecters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail("kkkkkkkkkkkkkkkkkkkkkkkkkkkavo@mail.ru");
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);

        }

        [Test]
        public void EmailWithLessThen6Charecters()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail("k@l.r");
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result1 = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul/li[1]")).Text;
            var result2 = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul/li[2]")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result1);
            Assert.AreEqual("Invalid email address.", result2);

        }


        [Test]
        public void EmptyEmail()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail("");
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result1 = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul/li[1]")).Text;
            var result2 = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul/li[2]")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result1);
            Assert.AreEqual("Invalid email address.", result2);

        }


        [Test]
        public void EmailWithoutDogSymbol()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail("kavomail.ru");
            EnterPasswordAndConfPassword();


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul/li[1]")).Text;
            Assert.AreEqual("Invalid email address.", result);

        }



        //Password
        [Test]
        public void PasswordNotMatch()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail();
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwer");


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);

        }


        [Test]
        public void EmptyPassword()
        {
            driver.Navigate().GoToUrl(validUrl);
            EnterStudentName();
            EnterLogin();
            ChooseGender();
            EnterEmail();
            EnterPasswordAndConfPassword("");


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("This field is required.", result);

        }

    }
}