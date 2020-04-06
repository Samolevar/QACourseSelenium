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
            driver.FindElement(By.Id("student")).SendKeys("Startcev Artem");
            driver.FindElement(By.Id("username")).SendKeys("startcev");
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
                     driver.FindElement(By.Id("student")).SendKeys("Startcev Artem");
                     driver.FindElement(By.Id("username")).SendKeys("stлa");
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
                     Assert.That(error.Contains("Field must be between 4 and 24 characters long."));
                 }
        
        [Test]
        public void Form_ShouldNotAcceptLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Startcev Artem");
            driver.FindElement(By.Id("username")).SendKeys("123456789012345678901234567890");
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
        public void Form_ShouldNotIncorrectLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Startcev Artem");
            driver.FindElement(By.Id("username")).SendKeys("aaa#1");
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
        
        //Email
        [Test]
        public void Form_ShouldNotIncorrectEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Startcev Artem");
            driver.FindElement(By.Id("username")).SendKeys("Startcev");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("aaaa.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Invalid email address.");
        }
        
        [Test]
        public void Form_ShouldNotAcceptShortEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Startcev Artem");
            driver.FindElement(By.Id("username")).SendKeys("Startcev");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("a@.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error.Contains("Field must be between 4 and 24 characters long."));
        }
        
        [Test]
        public void Form_ShouldNotAcceptLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Startcev Artem");
            driver.FindElement(By.Id("username")).SendKeys("Startcev");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("1234567890123456789012345678901234567890@.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error.Contains("Field must be between 6 and 35 characters long."));// error1 == "Invalid email address.");
            
           // Assert.That(error1 == "Invalid email address.");
        }
        
        [Test]
        public void Form_ShouldNotSuperIncorrectEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Startcev Artem");
            driver.FindElement(By.Id("username")).SendKeys("Startcev");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("z@z.r");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error.Contains("Field must be between 6 and 35 characters long."));
           // var error0 = driver.FindElements(By.ClassName("errors"))[0].Text;
           // var error1 = driver.FindElements(By.ClassName("errors"))[1].Text;
           // Assert.That(error0 == "Field must be between 6 and 35 characters long.");
           // Assert.That(error1 == "Invalid email address.");
        }
        
        [Test]
        public void Form_PasswordShouldMatch()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Startcev Artem");
            driver.FindElement(By.Id("username")).SendKeys("Startcev");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("aa@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("13");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Passwords must match");
        }
        
        
    }
}
