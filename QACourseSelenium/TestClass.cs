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
        private const string URL = "https://qa-course.kontur.host/training/final";

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
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "ivanovaS");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test1234@test1234.com");

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
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iia");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
        public void RegistrationIsSuccessfullIfLoginContains4LatinSymbols()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
        public void RegistrationIsSuccessfullIfLoginContains24LatinSymbols()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiiiiiiiiiiiiiiiiiiiiiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiiiiiiiiiiiiiiiiiiiiiiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
        public void RegistrationIsSuccessfullIfLoginContainsNumbers()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "3434222389");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
        public void RegistrationIsSuccessfullIfLoginContainsCyrillic()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "ОаНшВФЫ");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: ",-.;:/&()#+=%{}[]<>@$*'~");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "^р ^t^I^m");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
        public void ItShouldShowErrorIfLoginIsNull()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
        public void ItShouldShowErrorIfMailDomainPartContainsNoDotCom()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
        public void ItShouldShowErrorIfMailTLDContains1Symbol()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.c");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfMailTLDContainsNumbers()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.111");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }
        
        [Test]
        public void ItShouldShowErrorIfMailSecondDomainNameIsNull()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfMailContainsNoLocalPart()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }
        
        [Test]
        public void ItShouldShowErrorIfMailFormatContainsNoCommersialAt()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "testtest.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfMailContainsNCommersialAt()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfMailContainsSpecialCharactersInUnquotedLocalPart()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: ",-.;:/&()#+=%{}[]<>$*'~@ex.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }

        [Test]
        public void RegistrationIsSuccessfullIfMailContainsSpecialCharactersInQuotedLocalPart()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "\",-.;:/&()#+=%{}[]<>$*'~\"@ex.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfMailIsCyrillic()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "ывфй@ру.рф");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Invalid email address.", actual: result);
        }

        [Test]
        public void ItShouldShowErrorIfMailContains5Symbols()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "1@t.g");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void RegistrationIsSuccessfullIfMailContains6Symbols()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
        public void RegistrationIsSuccessfullIfMailContains35Symbols()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
        public void ItShouldShowErrorIfMailIsNull()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

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
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "123456");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(expected: "Passwords must match", actual: result);
        }

    //Здесь проверяю поле "Пол"
        
        [Test]
        public void RegistrationIsSuccessfullIfGenderIsNull()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }

    //Здесь проверяю выбор чекбокса "Я согласен с условиями"

        [Test]
        public void RegistrationIsSuccessfullIfCheckboxIsNotSubmitted()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.ClassName("student")).SendKeys(text: "Иванова Светлана");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(text: "iiii");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(text: "test@test.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys(text: "1234");
            driver.FindElement(By.Id("confirm")).SendKeys(text: "1234");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(expected: "Спасибо за регистрацию!", actual: result);
        }
        
    }
}
    