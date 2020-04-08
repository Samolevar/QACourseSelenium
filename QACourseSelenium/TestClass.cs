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
            /*Проверка корректно заполненной формы*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("andy1");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("andrew.67@list.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");



        }
        [Test]
        public void TestOnShortLogin()
        {
            /*Проверка некорректно заполненной формы, при вводе логина менее 4 символов*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("and");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("andrew.67@list.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.");



        }
        [Test]
        public void TestOnLongLogin()
        {
            /*Проверка некорректно заполненной формы, при вводе логина более 24 символов*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("andyandyandyandyandyandy1");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("andrew.67@list.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.");



        }
        [Test]
        public void TestOnInvalidEmail()
        {
            /*Проверка некорректно заполненной формы, при невалидного емейла, в котором отсутствует символ '@'*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("andy1");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("andrew.67list.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid email address.");

        }
        [Test]
        public void TestOnPasswordMismatch()
        {
            /*Проверка некорректно заполненной формы, в которой введены разные строки
             в поля "Пароль" и "Подтверждение пароля" */
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("andy1");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("andrew.67@list.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Passwords must match");

        }
        [Test]
        public void TestOnLackAgreementMark()
        {
            /*Проверка корректно заполненной формы, когда не поставлена галочка в пункте "Я согласен с условиями"*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("andy1");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("andrew.67@list.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            //checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");

        }
        [Test]
        public void TestOnShortEmail()
        {
            /*Проверка некорректно заполненной формы, когда указан слишком короткий емейл менее 6 символов*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("andy1");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("6@l.r");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.\r\nInvalid email address.");

        }
        [Test]
        public void TestOnLongEmail()
        {
            /*Проверка некорректно заполненной формы, при вводе емейла более 35 символов*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("andy1");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("qwertyuiopasdfghjklzxcvbnm@qwertyuiopasdfghjklzxcvbnm.ryewurdfhjfsdhbf");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.");

        }
        [Test]
        public void TestOnLongInvalidEmail()
        {
            /*Проверка некорректно заполненной формы, при вводе емейла более 35 символов и с отсутствием "@"*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("andy1");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("andrew.67list.rufdsfdsfdsfdsdsadsadsaf");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.\r\nInvalid email address.");

        }
        [Test]
        public void TestOnLoginWithWrongCharacters()
        {
            /*Проверка некорректно заполненной формы, при вводе логина с символами,
             отличных от цифр и английских букв*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("and11@@");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("andrew.67@list.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid input.");

        }
        [Test]
        public void FillingStudentNameWithLettersNumbersMathematicalSymbols()
        {
            /*Проверка корректно заполненной формы, при вводе имени с английскими буквами, цифрами и
             математическими символами*/
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Андрей Ермаков1+");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("andyyy");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("andrew.67@list.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");

        }
    }
}
