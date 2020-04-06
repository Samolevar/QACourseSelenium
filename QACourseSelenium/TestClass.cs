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
        private const string Expected = "Field must be between 4 and 24 characters long.\r\nInvalid input.";
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
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "ivanovaS");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }

    //Здесь проверяю поле "Логин"

        [Test]
        public void ItShouldShowErrorIfLoginContains3Symbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iia");
            
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Field must be between 4 and 24 characters long.", actual: result);
        }

        [Test]
        public void ItShouldBeOKIfLoginContains4LatinSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }

        [Test]
        public void ItShouldBeOKIfLoginContains24LatinSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiiiiiiiiiiiiiiiiiiiiiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfLoginContains25Symbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiiiiiiiiiiiiiiiiiiiiiiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Field must be between 4 and 24 characters long.", actual: result);
        }

        [Test]
        public void ItShouldBeOKIfLoginContainsNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "3434222389");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }
        
        [Test]
        public void ItShouldBeOKIfLoginContainsCyrillic()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "ОаНшВФЫ");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfLoginContainsSpecialCharacters()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: ",-.;:/&()#+=%{}[]<>@$*'~");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid input.", actual: result);
        }
    
        [Test]
        public void ItShouldShowErrorIfLoginContainsNonPrintableCharacters()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "^р ^t^I^m");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid input.", actual: result);
        }
                                            
        [Test]
        public void ItShouldShowErrorIfLoginAreNull()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }
        
    //Здесь проверяю поле "Адрес электронной почты"  
    
        [Test]
        public void ItShouldShowErrorIfMailFormatContainsNoZeroAndFirstDomainNames()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }
        
        [Test]
        public void ItShouldShowErrorIfMailFormatContainsNoCommersialAt()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "testtest");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }
        
        [Test]
        public void ItShouldShowErrorIfMailFormatNotValidInLocalPart()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "John..Doe@example.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }

        [Test]
        public void ItShouldBeOKIfMailLocalPartIsInQuotationMarks()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "\"John..Doe\"@example.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }
        
        [Test]
        public void ItShouldBeOKIfMailContains6Symbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "t@t.gg");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }
        
        [Test]
        public void ItShouldBeOKIfMailContains35Symbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "ttttt0000111234567891923456743@t.gg");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfMailContains36Symbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "ttttt0000111234567891923456743a@t.gg");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Field must be between 6 and 35 characters long.", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfMailAreNull()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }
               
    //Здесь проверяю поле "Пароль"  
         
        [Test]
        public void ItShouldShowErrorIfPasswordNotConfirmed()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "oooooo");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Passwords must match", actual: result);
        }

    }
}
    