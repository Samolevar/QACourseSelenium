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
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frolov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
            driver.FindElement(By.Id("email")).SendKeys("aa@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!");
        }
        
        [Test]
        public void Form_ShouldAcceptLoginSpecialSymbol()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("fro$lov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
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
        public void Form_ShouldNotAcceptShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("fro");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
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
        public void Form_ShouldNotAcceptLoginDigits()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("1111");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
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
        public void Form_ShouldAcceptLoginMinNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frol");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
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
        public void Form_ShouldAcceptLoginMaxNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frrrrrrrrrrrrrrrrrrrrrrr");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
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
        public void Form_ShouldAcceptLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frrrrrrrrrrrrrrrrrrrrrrrr");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
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
        public void Form_ShouldAcceptSexFemale()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frolov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Female");
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
        public void Form_ShouldAcceptEmailMinNumbersName()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frolov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
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
        public void Form_ShouldAcceptEmailMaxNumbersName()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frolov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
            driver.FindElement(By.Id("email")).SendKeys("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!");
        }
        
        [Test]
        public void Form_ShouldAcceptEmailNotValid()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frolov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
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
        public void Form_ShouldAcceptEmailShortName()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frolov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
            driver.FindElement(By.Id("email")).SendKeys("@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error.Contains("Field must be between 6 and 35 characters long."));
        }
        
        [Test]
        public void Form_ShouldAcceptEmailLongName()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frolov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
            driver.FindElement(By.Id("email")).SendKeys("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Field must be between 6 and 35 characters long.");
        }
        
        [Test]
        public void Form_ShouldAcceptConfirmPassword()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.FindElement(By.Id("student")).SendKeys("Frolov Aleksey");
            driver.FindElement(By.Id("username")).SendKeys("frolov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("1234");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
         
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
         
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Passwords must match");
         
        }
                 
              
    }
}
