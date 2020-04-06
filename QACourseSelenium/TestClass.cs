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
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("krasnogorov");
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
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("krg");
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
        public void Form_ShouldAcceptShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("kras");
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
        public void Form_ShouldAcceptLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("lKxBAfAmOOsoduvEUFDLJ6n6");
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
        public void Form_ShouldNotAcceptLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("lKxBAfAmOOsoduvEUFDLJ6n61");
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
        public void Form_ShouldNotAcceptShortEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("krasnogorov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
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
        public void Form_ShouldNotAcceptLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("krasnogorov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("ArKNgOBUw4nJcpn44LrWOFgjCBdNmk0@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Field must be between 6 and 35 characters long.");
        }
        
        [Test]
        public void Form_ShouldAcceptLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("krasnogorov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("ArKNgOBUw4nJcpn44LrWOFgjCBdNmk@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!");
        }
        
        [Test]
        public void Form_ShouldNotAcceptWithoutAcceptTos()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("krasnogorov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("ArKNgOBUw4nJcpn44LrWOFgjCBdNmk@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
                //var acceptTos = driver.FindElement(By.Id("accept_tos"));
            //acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!");
        }
        
        [Test]
        public void Form_ShouldNotAcceptEmailWithoutAt()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("krasnogorov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
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
        public void Form_ShouldNotAcceptWithoutMatchPassword()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("krasnogorov");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("321");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Passwords must match");
        }
        
        [Test]
        public void Form_ShouldNotAcceptLoginWithSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Krasnogorov Vladimir");
            driver.FindElement(By.Id("username")).SendKeys("kr@$g");
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

    }
}
