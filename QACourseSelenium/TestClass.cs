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
        public void InitialTest1() //Полностью валидное заполнение
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Serega12");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        [Test]
        public void InitialTest2() //Валидный логин на кириллице
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Сергей");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InitialTest3() //Валидный логин 4 символа
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Sere");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InitialTest4()  //Валидный логин  24 символа
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("zxczsdgsdfasdfaefddzfass");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InitialTest5() //невалидный логин менее 4 символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Ser");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void InitialTest6() //Невалидный логин более 24 символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("zxczsdgsdfasdfaefddzfasss");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void InitialTest7()  //Невалидный логин с использованием знака препинания
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd!");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void InitialTest8() //Невалидный логин с использованием спец символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Serega#rdd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void InitialTest9() //Тест на отсутствие пола 
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd"); 
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();                          
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InitialTest10()// Валидная почта с цифрами
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd12@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InitialTest11()// Валидная почта 6 символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("d@m.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InitialTest12()// Валидная почта 35 символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("asdasdasfdasdsadasdaeregard@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        [Test]
        public void InitialTest13()//Невалидная почта с отстутствием @
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();                       
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregarddmail.ru"); 
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void InitialTest14() //Невалидная почта с отсутствием локальной части
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void InitialTest15() //Невалидная почта с отсутствием доменной части
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void InitialTest16() //Невалидная почта менее 6 символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("a@m.r");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void InitialTest17() //Невалидная почта более 35 символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("asdasdasfdasdsadasdaeregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }

        [Test]
        public void InitialTest18()  //Тест на отсутствие согласия с условиями
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd");
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();                         
            driver.FindElement(By.ClassName("text-email")).SendKeys("Serega_rdd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Name("confirm")).SendKeys("123456789");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void InitialTest19() //Несовпадение пароля
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("Student")).SendKeys("Сергей Толузаров");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Seregardd"); 
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            driver.FindElement(By.ClassName("text-email")).SendKeys("Seregardd@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("1");
            driver.FindElement(By.Name("confirm")).SendKeys("2");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }
    }
}