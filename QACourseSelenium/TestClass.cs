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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("KOTI");


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("kotich");


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("kkkkkkkkkkkkkkkkkkkkkkkk");


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("котич");


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("");


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("KOT");


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("KOTI4isTheBestAnaInWholeOverwatchComunity");


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("$KOTI4%");


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("KOT I4");


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("lubozhevk@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("k@l.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("kavo@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("kkkkkkkkkkkkkkkkkkkkkkkkkkk@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("kkkkkkkkkkkkkkkkkkkkkkkkkkkavo@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("k@l.r");
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("");
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("kavomail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(validPassword);
            driver.FindElement(By.Id("confirm")).SendKeys(validPassword);


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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
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
            driver.FindElement(By.ClassName("student")).SendKeys(myName);
            driver.FindElement(By.ClassName("text-plain")).SendKeys(validLogin);


            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(validEmail);
            driver.FindElement(By.ClassName("text-password")).SendKeys("");
            driver.FindElement(By.Id("confirm")).SendKeys("");


            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("This field is required.", result);

        }

    }
}