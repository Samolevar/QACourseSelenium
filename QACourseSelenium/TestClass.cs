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
        private string baseURL;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            baseURL = "https://qa-course.kontur.host/training/ekb/form";
            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Login_From_4_To_24_Characters_Rus()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Login_From_4_To_24_Characters_Eng()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Login_4_Characters()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Serg");
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
        public void Login_24_Characters()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("SergiPavlovichElchaninov");
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
        public void Login_Less_Than_4_Characters()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Login_More_Than_24_Characters()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Login_Not_Allowed_Symbols()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Login_With_Space()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei Elchaninov");
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
        public void Login_Empty()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Gender_Null()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei123");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[0].Click();

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
        public void Valid_Mail_Length_6_Characters()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("1@1.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void Valid_Mail_Length_35_Characters()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("SergeiPavlovichElchaninov@Gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void Invalid_Mail_Less_Than_6_Characters()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Invalid_Mail_More_Than_35_Characters()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Сергей Елчанинов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sergei1");
            var select = new SelectElement(driver.FindElement(By.ClassName("Selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("hedghedghedghedghedghedghedghedghedg@.mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void Not_Mail()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Mail_Empty()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Pass_Not_Match()
        {
            driver.Navigate().GoToUrl(baseURL);
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
        public void Pass_Confirm_Empty()
        {
            driver.Navigate().GoToUrl(baseURL);
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
