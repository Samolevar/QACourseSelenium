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
            Assert.That(text, Is.EqualTo("Вместе с google часто ищут").After(500));
        }

        [Test]
        public void InitialTest()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void NoLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }

        [Test]
        public void ShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("All");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void MinLengthLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Alle");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InvalidLoginWithIncorrectCharacters()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Allen&Twist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void LoginWithNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Allen2020");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InvalidLoginWithSpace()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Allen 2020");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void NumbersLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("20202020");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void LongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("aaaaaaaaaaaaaaaaaaaaaaaaa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void MaxLengthLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("aaaaaaaaaaaaaaaaaaaaaaaa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void NoEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void MinLengthEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a@m.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ShortEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a@m.r");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void InvalidEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("amfguyd.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void LongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("jutdttfvkvkuyfkuyckgvkjhbkhglu@yd.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }

        [Test]
        public void MaxLengthEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("utdttfvkvkuyfkuyckgvkjhbkhglu@yd.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void Female()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void Male()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void NoGender()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void DifferentPasswords()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алёна Крутикова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("AllenTwist");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("alenakrutikova2@gmail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("12345679");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }
    }
}
