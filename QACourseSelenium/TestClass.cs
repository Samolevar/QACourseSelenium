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
        public void Form_ShouldAcceptValidData()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("budnikov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!", "Не принимаются валидные значения, логин буквы");
        }
       
        [Test]
        public void Form_ShouldNotAcceptShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("bud");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Field must be between 4 and 24 characters long.", "Не валидируется короткий логин");
        }
        
        [Test]
        public void FormShouldNotAcceptLoginSpecSymbol()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("qw!d");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Invalid input.", "Не валидируется логин со спец символами");
            
        }
        [Test]
        public void FormShouldNotAcceptEmailWithoutDog()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("qwyd");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("ajkhha.u");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Invalid email address.", "Не валидируется е-мэйл без собачки");
            
        }
        [Test]
        public void FormShouldNotAcceptEmailWithoutDot()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("qwyd");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("ajk@hhau");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Invalid email address.", "Не валидируется е-мэйл без точки");
            
        }
        [Test]
        public void FormShouldNotAcceptLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("qwyd");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("ajkhhdffvfvgbbfgbsfgbsjkhkjhkjhjkhkhkjhkjhkhhkhjkhkhkhkhkhkhkhkjhjkhkhk@hk.au");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Field must be between 6 and 35 characters long.", "Не валидируется длинный е-мэйл");
            
        }
        [Test]
        public void FormShouldNotAcceptPasswordNonConfirm()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("qwyd");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("khkhkhkhkjhjkhkhk@hk.au");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("1234");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Passwords must match", "Не совпадает пароль");
            
        }
        [Test]
        public void FormShouldNotAcceptEmailSpecSymbol()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("qwyd");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("k#$@r.u");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Invalid email address.", "Не валидируется е-мэйл со спец символами");
            
        }
        [Test]
        public void Form_ShouldAcceptValidDataCifri()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("12345");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!", "Не принимаются валидные значения, логин цифры");
        }
        [Test]
        public void Form_ShouldAcceptValidDataCifriiBukvi()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Shevnina Polina");
            driver.FindElement(By.Id("username")).SendKeys("123etwwt45");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!", "Не принимаются валидные значения, логин цифры и буквы");
        }
        
    }
}
