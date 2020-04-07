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

        public void InitialTest() //Верное заполнение всей формы
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
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

        public void PasswordsDoesnotMatch() //Пароли не совпадают
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

        public void MailBiggerThanThirtyFiveSymbols() //Длина почты больше 30 символов
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

        public void LoginLessThanFourSymbols() //Длина логина меньше четырёх символов
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
        public void LoginBiggerThanTwentyFourSymbols() //Длина логина больше 24 символов
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
        public void SpecialSymbolsInLogin() //Спец символы в составе логина
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

        public void MailShorterThanSixSymbols() //Длина почты короче шести символов
        {
        driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
        driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
        driver.FindElement(By.ClassName("text-plain")).SendKeys("SerovArt");

        var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
        select.Options[1].Click();

        driver.FindElement(By.ClassName("text-email")).SendKeys("D@d.r");

        driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
        driver.FindElement(By.Id("confirm")).SendKeys("123456");

         var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
         checkBox.Click();
         checkBox.Submit();

        var result = driver.FindElement(By.ClassName("errors")).Text;
        Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]

        public void EmptyMail() //Поле почты пустое
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("SerovArt");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result1 = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result1);
        }

        [Test]

        public void NumberLogin() //Цифры в логине
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("1234");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmptyLogin() //Поле логина пустое
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }

        [Test]
        public void WrongMail() //Неверный формат почты
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Серов");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("SerovArt");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmailmail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }
    }
}
