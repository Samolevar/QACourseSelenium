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
           // driver.Quit();
        }

 
        [Test]
        public void Form_ShouldAcceptValidData()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Maksim Shum");
            driver.FindElement(By.Id("username")).SendKeys("Maksim");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("mmm@mm.ru");
            driver.FindElement(By.Id("password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm")).SendKeys("12345");
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
            driver.FindElement(By.Id("student")).SendKeys("Budnikov Kirill");
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
 
            var error = driver.FindElement(By.ClassName("Ошибка")).Text;
            Assert.That(error == "Field must be between 4 and 24 characters long.");
        }
        
        [Test]
        public void Form_ShouldnotAcceptValidpass()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Maksim Shum");
            driver.FindElement(By.Id("username")).SendKeys("Maksim");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("mmm@mm.ru");
            driver.FindElement(By.Id("password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm")).SendKeys("123457");
            var acceptTos = driver.FindElement(By.Name("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.Id("password")).Text;
            Assert.That(error == "Passwords must match");
        }
        
        [Test]
        public void Form_ShouldnotAcceptValidemail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Maksim Shum");
            driver.FindElement(By.Id("username")).SendKeys("Maksim");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Мужской");
            driver.FindElement(By.Id("email")).SendKeys("@.ru");
            driver.FindElement(By.Id("password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm")).SendKeys("12345");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
           
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();
 
            var error = driver.FindElement(By.Id("email")).Text;
            Assert.That(error.Contains("Field must be between 6 and 35 characters long."));
        }

    }
}
