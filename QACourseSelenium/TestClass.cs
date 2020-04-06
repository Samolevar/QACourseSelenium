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
        public void ChromeDriverTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.FindElement(By.ClassName("gLFyf")).SendKeys("google");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
            var text = driver.FindElement(By.ClassName("e2BEnf")).Text;
            Assert.That(text, Is.EqualTo("Главные новости").After(500));
        }

        [Test]
        public void InitialTest()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("Yakushevpo");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("test@test.com");
          
            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567890");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        [Test]
        public void WrongLoginTest()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("Yakushev.po");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("test@test.com");

            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567890");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void WrongEmailTest()
        {

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("Yakushevpo");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("testtest.com");
            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567890");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }
        [Test]
        public void PasswordMismatchTest()
        {

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("Yakushevpo");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("test@test.com");
            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }
        [Test]
        public void ShortLoginTest()
        {

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("Y");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("test@test.com");
            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567890");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }
        [Test]
        public void ShortEmailTest()
        {

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("Ykushev");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("t@t.t");
            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567890");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }
        [Test]
        public void TooLongEmailTest()
        {

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("Ykushev");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("1111111111111111111111111111@test.ru");
            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567890");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }
        [Test]
        public void TooLongLoginTest()
        {

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("1111111111111111111111111111111111111111111111111");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("1111111@test.ru");
            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567890");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }
        [Test]
        public void MaxLenthOfLoginTest()
        {

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("111111111111111111111111");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("1111111@test.ru");
            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567890");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        [Test]
        public void MaxLenthOfEmailTest()
        {

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.Name("student")).SendKeys("Якушев Павел");
            driver.FindElement(By.Name("username")).SendKeys("login");
            var select = new SelectElement(driver.FindElement(By.Name("sex")));
            select.Options[1].Click();
            driver.FindElement(By.Name("email")).SendKeys("111111111111111111111111111@test.ru");
            driver.FindElement(By.Name("password")).SendKeys("1234567890");
            driver.FindElement(By.Name("confirm")).SendKeys("1234567890");
            var checkBox = driver.FindElement(By.Name("accept_tos"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }


    }
}