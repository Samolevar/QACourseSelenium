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
        public void LoginEng()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei123");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void LoginRus()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Сергей123");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void LoginLessThan4Symbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("S3r");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginMoreThan24Symbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Serrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr123");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginNotAllowedSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Ser!@#$%^&*()");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void LoginFrom4To24Symbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void NoLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }

        [Test]
        public void InvalidMailLessThan6Sym()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("1@1.u");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void NotMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("hedg.mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void MailEmpty()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void MailMoreThan65Sym()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("hedghedghedghedghedghedghedghedghedghedghedghedghedghedghedghedg@.mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void PassNotMatch()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("126");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void PassNullMatch()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

    }
}
