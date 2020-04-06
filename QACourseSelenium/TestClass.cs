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

        /*[Test]
        public void ChromeDriverTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.FindElement(By.ClassName("gLFyf")).SendKeys("google");
            Thread.Sleep(500);
            driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
            var text = driver.FindElement(By.ClassName("e2BEnf")).Text;
            Assert.That(text, Is.EqualTo("Вместе с google часто ищут").After(500));*/
        [Test]
        public void Form_ShouldAcceptValidData()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Chigvinceva Vlada");
            driver.FindElement(By.Id("username")).SendKeys("vlada");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!");
        }

        [Test]
        public void Form_ShouldNotAcceptShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Chigvinceva Vlada");
            driver.FindElement(By.Id("username")).SendKeys("chi");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Field must be between 4 and 24 characters long.");
        }

        [Test]
        public void Form_ShouldNotAcceptLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Chigvinceva Vlada");
            driver.FindElement(By.Id("username")).SendKeys("chigvincevavladarenatovna"); //25
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Field must be between 4 and 24 characters long.");
        }

        [Test]
        public void Form_ShouldNotAcceptShortEmail() //cosyak
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Chigvinceva Vlada");
            driver.FindElement(By.Id("username")).SendKeys("chigvinceva");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error.Contains("Field must be between 6 and 35 characters long."),"не валидируется короткий адрес");
        }

        [Test]
        public void Form_ShouldNotAcceptLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Chigvinceva Vlada");
            driver.FindElement(By.Id("username")).SendKeys("chigvinceva");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error.Contains("Field must be between 6 and 35 characters long."), "So long adress");
            
        }

        [Test]
        public void Form_ShouldNotAcceptEmailWithoutDog()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Chigvinceva Vlada");
            driver.FindElement(By.Id("username")).SendKeys("chigvinceva");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("aaa.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Invalid email address.");
        }

        [Test]
        public void Form_ShouldNotAcceptInvailedLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Chigvinceva Vlada");
            driver.FindElement(By.Id("username")).SendKeys("chigvinceva@");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Invalid input.");
        }

        [Test]
        public void Form_ShouldNotAcceptNotSamePass()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Chigvinceva Vlada");
            driver.FindElement(By.Id("username")).SendKeys("chigvinceva");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("125");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error.Contains("Passwords must match"));
        }
        
    }
}
