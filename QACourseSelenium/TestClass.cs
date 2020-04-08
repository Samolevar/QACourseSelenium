// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System.Collections.Generic;
using System.Security;
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
        private string link = "https://qa-course.kontur.host/training/ekb/form";

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

        
        [Test]
        public void InitTest()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newbieru");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("Flashes")).Text;

            Assert.AreEqual("Спасибо за регистрацию!", result );
        }

        [Test]
        public void LoginMayContainNumbers()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newbie12");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("Flashes")).Text;

            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void FourSymbolsEnoughForLogin()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newb");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("Flashes")).Text;

            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ThreeSymbolsNotEnoughForLogin()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("new");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginLength24SymbolsIsMaximumOk()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("twentyfoursymbolsloginnn");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("Flashes")).Text;

            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void LoginLength25SymbolsIsNotOk()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("twentyfivesymbolslogin123");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void DotNotAllowedInLogin()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("log.in");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void SharpNotAllowedInLogin()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("1234#");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void PercentNotAllowedInLogin()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("petr%");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void EmailShouldContainDogSymbol()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newbieru");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void EmailShouldContainDot()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newbieru");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mailru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void EmailLength36SymbolsIsNotOk()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newbieru");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("thirtysixsymbolsemailisnotok@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }

        [Test]
        public void EmailLength35SymbolsIsOk()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newbieru");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("thirtyfivesymbolsemailisoky@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("Flashes")).Text;

            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmailLengthSixSymbolsIsOk()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newbieru");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("t@m.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("Flashes")).Text;

            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void PasswordRequired()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newbieru");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("thirtyfivesymbolsemail11111@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("");
            driver.FindElement(By.Id("confirm")).SendKeys("notMatch");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("This field is required.", result);
        }

        [Test]
        public void PasswordConfirmationMustMatch()
        {
            driver.Navigate().GoToUrl(link);
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("newbieru");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("t@l.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Passwords must match", result);
        }
        
        [Test]
        public void LoginRequired()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Петр Телицин");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("thirtyfive@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.Id("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;

            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }
    }
}
