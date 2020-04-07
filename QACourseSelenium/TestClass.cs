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

        //[Test]
        //public void ChromeDriverTest()
        //{
        //    driver.Navigate().GoToUrl("http://www.google.com");
        //    driver.FindElement(By.ClassName("gLFyf")).SendKeys("google");
        //    Thread.Sleep(500);
        //    driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
        //    var text = driver.FindElement(By.ClassName("e2BEnf")).Text;
        //    Assert.That(text, Is.EqualTo("Вместе с google часто ищут").After(500));
        //}

        [Test]
        public void TestWoman()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text:"Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "hellisunder");
            
            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void TestMan()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "hellisunder");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void TestNoGender()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "hellisunder");

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }


        [Test]
        public void TestNumberLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "hell111");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void TestSymbolLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "$hell$");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }


        [Test]
        public void TestWrongConfirm()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "hellisunder");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("12345");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void TestNoConfirm()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "hellisunder");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            //driver.FindElement(By.Id("confirm")).SendKeys("12345");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }


        [Test]
        public void TestWrongMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "hellisunder");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void TestSmallMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "hellisunder");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a@a");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void TestBigMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "hellisunder");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }

       
        [Test]
        public void TestSmallLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "h");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void TestBigLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Анна Мостовова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "helllllllllllllllllllllll");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }
    }
}
