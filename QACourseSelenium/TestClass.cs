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
            //driver.Quit();
        }
        
        [Test]
        public void Form_ShouldAcceptValidData()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Martiushev Denis");
            driver.FindElement(By.Id("username")).SendKeys("martiushev");
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
            Assert.That(text == "Спасибо за регистрацию!");
        }
       
        [Test]
        public void Form_ShouldNotAcceptShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Martiushev Denis");
            driver.FindElement(By.Id("username")).SendKeys("mar");
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
            Assert.That(error == "Field must be between 4 and 24 characters long.");
        }
        
        [Test]
        public void Form_ShouldNotAcceptLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Martiushev Denis");
            driver.FindElement(By.Id("username")).SendKeys("mmmmmmmmmmmmmmmmmmmmmmmmm");
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
            Assert.That(error == "Field cannot be longer than 24 characters.");
        }

        [Test]
        public void Form_ShouldNotAcceptInvalidLogin()
                 {
                     driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
                     driver.FindElement(By.Id("student")).SendKeys("Martiushev Denis");
                     driver.FindElement(By.Id("username")).SendKeys("mmmm&$");
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
                     Assert.That(error == "Invalid input.");
                 }
        [Test]
        public void Form_ShouldNotAcceptLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Martiushev Denis");
            driver.FindElement(By.Id("username")).SendKeys("mmmm");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("mmmmmmmmmmmmmmmmmmmmmmmmmm@yandex.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
         
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
         
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Field must be between 6 and 35 characters long.");
        }
        
        [Test]
        public void Form_ShouldNotAcceptInvalidEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Martiushev Denis");
            driver.FindElement(By.Id("username")).SendKeys("mmmm");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("mmmmmr");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
         
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
         
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Invalid email address.");
        }
        [Test]
        public void Form_PasswordsShouldMatch()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Martiushev Denis");
            driver.FindElement(By.Id("username")).SendKeys("mmmm");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("a@a.mu");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("12");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
         
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
         
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Passwords must match");
        }
       
        [Test]
        public void Form_ShouldAcceptLogin24Symbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Martiushev Denis");
            driver.FindElement(By.Id("username")).SendKeys("mmmmmmmmmmmmmmmmmmmmmmmm");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("a@a.mu");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
         
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
         
            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!");
        }
    }
}
