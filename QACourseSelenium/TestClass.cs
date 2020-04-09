// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

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

        /*
        [Test]
        public void ChromeDriverTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.FindElement(By.ClassName("gLFyf")).SendKeys("google");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
            var text = driver.FindElement(By.ClassName("e2BEnf")).Text;
            Assert.That(text, Is.EqualTo("Вместе с google часто ищут").After(500));
        }
        */

        // https://qa-course.kontur.host/training/ekb/table

        [Test]
        public void InitialTest()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("bagindp");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test121@test121.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("test121@test121.ru");
            driver.FindElement(By.Id("confirm")).SendKeys("test121@test121.ru");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Click();
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void PasswordsDontMatch()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("bagindp");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test121@test121.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("test121@test121.ru");
            driver.FindElement(By.Id("confirm")).SendKeys("test121@test121.rus");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Click();
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }


        [Test]
        public void PasswordTwoIsEmpty()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("bagindp");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test121@test121.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("test121@test121.ru");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void LoginIsTooShort()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("bag");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test121@test121.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("password345");
            driver.FindElement(By.Id("confirm")).SendKeys("password345");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Click();
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginIsTooLong()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("bagdpbagdpbagdpbagdpbagdp");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test121@test121.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("password345");
            driver.FindElement(By.Id("confirm")).SendKeys("password345");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Click();
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }
        [Test]
        public void LoginIsNull()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test121@test121.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("password345");
            driver.FindElement(By.Id("confirm")).SendKeys("password345");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Click();
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }

        [Test]
        public void LoginContainsNotOnlyLettersAndNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("w$wwww");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test121@test121.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("password345");
            driver.FindElement(By.Id("confirm")).SendKeys("password345");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Click();
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void EmailIsTooShort()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("bagindp");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("t@t.r");
            driver.FindElement(By.ClassName("text-password")).SendKeys("password345");
            driver.FindElement(By.Id("confirm")).SendKeys("password345");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Click();
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void EmailIsTooLong()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("bagindp");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("test1test1test1test1test1te@test1.ru"); // 36 символов
            driver.FindElement(By.ClassName("text-password")).SendKeys("password345");
            driver.FindElement(By.Id("confirm")).SendKeys("password345");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Click();
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }
        [Test]
        public void EmailIsNull()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("bagindp");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-password")).SendKeys("password345");
            driver.FindElement(By.Id("confirm")).SendKeys("password345");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Click();
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void EmailDoesNotContainSobaka()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Денис Багин");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("bagindp");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("wasd.wasd");
            driver.FindElement(By.ClassName("text-password")).SendKeys("password345");
            driver.FindElement(By.Id("confirm")).SendKeys("password345");

            var checkBox1 = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox1.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }
    }
}
