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

        public void InitialTest()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Серов Артемий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("SerovArt");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]

        public void PasswordsDoesnotMatch()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("SerovArt");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("1234");
            driver.FindElement(By.Id("confirm")).SendKeys("123");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]

        public void MailBiggerThanThirtyFiveSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("SerovArt");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("Dasdasdasdasasdasdsdasda@rdsadasasdasdasdasddasdasd.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }

        [Test]

        public void LoginLessThanFourSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Ser");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginBiggerThanTwentyFourSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seraaaaaaaaaaaaaaaaaaaaaaaaa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void SpecialSymbolsInLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seraaaaa$aaa#");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test@mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

       [Test]

        public void MailShorterThanSixSymbols()
        {
        driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
        driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
        driver.FindElement(By.ClassName("text-plain")).SendKeys("SerovArt");

        var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
        select.Options[1].Click();

        driver.FindElement(By.ClassName("text-email")).SendKeys("D@d.r");

        driver.FindElement(By.ClassName("text-password")).SendKeys("123");
        driver.FindElement(By.Id("confirm")).SendKeys("123");

         var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
         checkBox.Click();
         checkBox.Submit();

        var result = driver.FindElement(By.ClassName("errors")).Text;
        Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

    }
}
