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
        private const string URL = "https://qa-course.kontur.host/training/ekb/form";

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
        public void InitialTest()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void AllErrorsInvalidInput()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("1234567");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);

        }




        [Test]
        public void SuccessfulRegistrationIfLoginIsСyrillic()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("АннаГ");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }


        [Test]
        public void SuccessfulRegistrationIfLoginHasNumbers()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("12345");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void SuccessfulRegistrationIfLoginHas4Symbol()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("Anna");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void SuccessfulRegistrationIfLoginHas24Symbol()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("mailmailmailmailmailmail");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void ShowErrorIfLoginIsNull()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);

        }

        [Test]
        public void ShowErrorIfLoginHas25Symbol()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("mailmailmailmailmailmailm");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);

        }

        [Test]
        public void ShowErrorIfLoginHas3Symbol()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("ann");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void ShowErrorIfLoginHasSpecialSymbols()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("<>^&*");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void SuccessfulRegistrationIfMailHasNumbers()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("12345@1234.mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void SuccessfulRegistrationIfMailHas6Symbols()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("m@a.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void SuccessfulRegistrationIfMailHas35Symbol()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("lmailmailmailmailmailmail@mail.mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }

        [Test]
        public void ShowErrorWhenMailIsСyrillic()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("почта@почта.рф");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);

        }

        [Test]
        public void ShowErrorWhenMailHasNumbersInTheFirstDomain()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("12345@1234.123");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);

        }

        [Test]
        public void ShowErrorWhenMailIsNull()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);

        }
        [Test]
        public void ShowErrorWhenMailHas36Symbol()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ilmailmailmailmailmailmail@mail.mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);

        }
        [Test]
        public void ShowErrorWhenMailHas5Symbols()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("m@m.c");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);

        }

        [Test]
        public void ShowErrorWhenMailIsNotCommercialAt()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mailmail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);

        }
        [Test]
        public void ShowErrorWhenMailHasSpecialSymbols()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail<>^&*@mail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);

        }

        [Test]
        public void ShowErrorWhenMailIsNotLocalPart()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("@mail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);

        }

        [Test]
        public void ShowErrorWhenMailFirstDomainIsNull()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);

        }

        [Test]
        public void ShowErrorWhenMailFirstDomainIsNullButThereIsAPoint()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);

        }

        [Test]
        public void SuccessfulRegistrationIfMailFirstDomainIsСyrillic()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.рф");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);

        }
        //По практике это не валидный ввод, так как "в домене «.рф» все имена второго уровня пишутся исключительно кириллицей." цитата с вики: https://ru.wikipedia.org/wiki/.рф. Тоесть это баг. 

        [Test]
        public void SuccessfulRegistrationIfMailFirstDomainHas1Symbols()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.r");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);

        }



        [Test]
        public void ShowErrorWhenPasswordMisMatch()
        {

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Id("student")).SendKeys("Анна Григоровская");
            driver.FindElement(By.Id("username")).SendKeys("AnnaG");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("mail@mail.com");

            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("1234567");

            var chekBox = driver.FindElement(By.Id("accept_tos"));
            chekBox.Click();
            chekBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }






    }
}