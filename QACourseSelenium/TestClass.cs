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
        public void MinLengthLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smgl");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
     
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        
        [Test]
        public void MaxLengthLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvnsmglvnsmglvnsmglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        
        [Test]
        public void LoginWithNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn10");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        
        [Test]
        public void MaleSelected()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        
        [Test]
        public void FemaleSelected()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
        
        [Test]
        public void TooShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smg");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        } 
        
        [Test]
        public void TooLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvnsmglvnsmglvnsmglvns");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        } 
        
        [Test]
        public void LoginWithInvalidCharacters()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn,");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        } 
        
        [Test]
        public void EmptyLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\nInvalid input.", result);
        } 
        
        [Test]
        public void TooShortEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("d@d.d");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\nInvalid email address.", result);
        } 
        
        [Test]
        public void MinLengthEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("1@m.ru");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        } 
        
        [Test]
        public void MaxLengthEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("smglvnsmglvnsmglvnsmglvnsmg@mail.ru");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        } 
        
        [Test]
        public void EmptyEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\nInvalid email address.", result);
        } 
        
        [Test]
        public void TooLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("1234567891234567891234567891@mail.ru");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }
        
        [Test]
        public void InvalidEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("123456789");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void PasswordDoesNotMatchConfirmation()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Galeeva Polina");
            
            driver.FindElement(By.ClassName("text-plain")).SendKeys("smglvn");
            
            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();
            
            driver.FindElement(By.ClassName("text-email")).SendKeys("test_mail@mail.com");
            
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();
            
            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }
    }
}
