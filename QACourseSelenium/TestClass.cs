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
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void TestLogin1() //логин меньше 4 символов 
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sof");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void TestLogin2() //логин больше 24 символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofasofasofasofasofasofasofa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void TestLogin3() //логин с цифрами и буквами
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa4");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void TestLogin4() // логин только символы
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("%%%%%");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void TestLogin5() // логин только цифры
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("44444");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void TestLogin6() // пустое поле логин
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }

        [Test]
        public void TestLogin7() // логин с символами
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa%");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void TestGender1() // пустое поле "пол"
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void TestEmail1() // email меньше 6 символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("b@m.r");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void TestEmail2() // email больше 35 символов
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaabodrovaaaa@bodrovaaaa.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }

        [Test]
        public void TestEmail3() // email без символа "@"
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaagmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void TestPassword1() // поля "пароль" и "подтверждение пароля" не совпадают
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("1234567");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void TestPassword2() // пустое поле "подтверждение пароля"
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void TestAccept1() // без согласия на условия
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Софья Бодрова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("sofa");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("bbodrovaaaa@gmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        
    }
}

