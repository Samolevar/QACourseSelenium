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
        public void ValidFormShouldBeSuccessfullyRegistered()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("loginForMashaS");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("mashatest@test.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!" );

        }

        [Test]
        public void LoginCanContainsNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("login");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("mashatest@test.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");

        }

        [Test]
        public void LoginShouldBeLongerThenFour()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("log");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("mashatest@test.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[2]/ul/li")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.");

        }

        [Test]
        public void LoginShouldBeLessThenTwentyFive()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("0123456789012345678901234");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("mashatest@test.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[2]/ul/li")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.");

        }

        [Test]
        public void LoginShouldBeContainsOnlyLettersAndNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("!212121&&&**@");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("mashatest@test.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[2]/ul/li")).Text;
            Assert.AreEqual(result, "Invalid input.");
        }

        [Test]
        public void EmailShouldBeLongerThenSix()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("login");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("1@ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul/li[1]")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.");
        }

        [Test]
        public void EmailShouldBeLessThenThirtyFive()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("login");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("masha999999999999999999999999sochendlinnimemailomvot@takim");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul/li[1]")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.");
        }

        [Test]
        public void EmailShouldBeContainsAT()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("login");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("12346fds78901.245");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul/li")).Text;
            Assert.AreEqual(result, "Invalid email address.");
        }

        [Test]
        public void PasswordShouldBeTheSame()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("login");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("12346fds78901.245");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty123");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[5]/ul/li")).Text;
            Assert.AreEqual(result, "Passwords must match");
        }


        [Test]
        public void PasswordShouldBeInForm()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Masha Smorodina");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("text-plain")).SendKeys("login");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("12346fds78901.245");
            driver.FindElement(By.ClassName("text-password")).SendKeys("qwerty");
            driver.FindElement(By.Id("confirm")).SendKeys("qwerty123");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[5]/ul/li")).Text;
            Assert.AreEqual(result, "Passwords must match");
        }
    }
}
