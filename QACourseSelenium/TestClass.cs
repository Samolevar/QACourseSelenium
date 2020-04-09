// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
        //Успешная регистрация
        public void InitialTest()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tarelkin");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "123@ya.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");


        }

        [Test]
        //короткий логин
        public void ShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tar");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "123@ya.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var login_short = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(login_short, "Field must be between 4 and 24 characters long.");
            
        }

        [Test]
        //длинный логин
        public void LongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tar111111111111111111111111111111111111111111111111111");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "123@ya.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            //Длинный логин
            var login_long = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(login_long, "Field must be between 4 and 24 characters long.");

        }

        [Test]
        //логин со спецсимволом
        public void SymbolLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tar@1111");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "123@ya.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var symbol_login = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(symbol_login, "Invalid input.");

        }

        [Test]
        //короткий e-mail
        public void ShortEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tarelkin");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "1@y.r");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var short_email = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(short_email, "Field must be between 6 and 35 characters long.\r\nInvalid email address.");

        }

        [Test]
        //длинный e-mail
        public void EmailFormat()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tarelkin");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "112312312312232323232323232323232323232323232323232323232323233123123@ya.r");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var long_email = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(long_email, "Field must be between 6 and 35 characters long.\r\nInvalid email address.");

        }

        [Test]
        //e-mail без символа @
        public void InvalidEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tarelkin");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "11222.ya.r");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var invalid_email = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(invalid_email, "Invalid email address.");

        }

        [Test]
        //e-mail с русскими буквами
        public void EmailWithRuSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tarelkin");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "11222абв@ya.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var invalid_email = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(invalid_email, "Invalid email address.");

        }

        [Test]
        //e-mail со спецсимволом
        public void EmailWithSymbol()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tarelkin");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "11!222@ya.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreNotEqual(result, "Спасибо за регистрацию!");

        }

        [Test]
        //подтверждение пароля
        public void PassRight()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tarelkin");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "11223@ya.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123");
            driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var PassRight = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(PassRight, "Passwords must match");

        }

        [Test]
        //тест чекбокса
        public void CheckboxTest()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Дмитрий Кошкаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "tarelkin");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "123@ya.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "123456");
            //driver.FindElement(By.ClassName("button-checkbox")).Click();

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            //checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreNotEqual(result, "Спасибо за регистрацию!");


        }
    }
}
