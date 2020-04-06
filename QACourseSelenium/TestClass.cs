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

        /* [Test]
         public void ChromeDriverTest()
         {
             driver.Navigate().GoToUrl("http://www.google.com");
             driver.FindElement(By.ClassName("gLFyf")).SendKeys("google");
             Thread.Sleep(500);
             driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
             var text = driver.FindElement(By.ClassName("e2BEnf")).Text;
             Assert.That(text, Is.EqualTo("Вместе с google часто ищут").After(500));
         }*/

        [Test]
        public void InitialTest()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");


            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void WrongMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmailmail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void NotMuchPassword()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("12345");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void ShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUB");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain"))
                .SendKeys("YUBobov111111111111111111111111111111111111111111111111111");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void ShortMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("l@m.m");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result1 = driver.FindElement(By.ClassName("errors")).Text;
            // var result2 = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result1);
            // Assert.AreEqual("Invalid email address.", result2);
        }

        [Test]
        public void EmptyMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            //driver.FindElement(By.ClassName("text-email")).SendKeys("l@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result1 = driver.FindElement(By.ClassName("errors")).Text;
            // var result2 = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result1);
            // Assert.AreEqual("Invalid email address.", result2);
        }

        [Test]
        public void LongMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("llllllllllllllllllllllllllllllllllllllll@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }

        [Test]
        public void SymbolLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov%^$@");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void NumberLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("1234");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmptyCheckbox()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            //checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmptySelect()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmptyLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            //driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov111111111111111111111111111111111111111111111111111");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }
        [Test]
        public void ForSymbolLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBo");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        [Test]
        public void TwentyForSymbolLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBoyyyyyyyyyyyyyyyyyyyy");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("testmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        [Test]
        public void TridchatDvaMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            //Находим поля, забиваем в них значения
            driver.FindElement(By.ClassName("student")).SendKeys("Бобов Юра");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("YUBobov");
            //Элемент с селектами
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("llllllllllllllllllllllll@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            //Находим один элемент, для него выполнить сабмит
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            //Результат
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
    }
}
