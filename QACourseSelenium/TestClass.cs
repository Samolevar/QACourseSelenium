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
        private const string testingURL = "https://qa-course.kontur.host/training/ekb/form";

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
        public void SuccessfulRegistrationIfSexIsMale()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ShowErrorIfPasswordsDoNotMatch()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("12345");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void ShowErrorIfLoginLengthLessThan4()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Art");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void ShowErrorIfLoginLengthMoreThan24()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ArtArtArtArtArtArtArtArtA");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void ShowErrorIfEmailHasNotSignAt()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void ShowErrorIfEmailLengthLessThan6()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("i@r.u");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void ShowErrorIfEmailLengthMoreThan35()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ArteecArteecArteecArteecArteec@we.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }

        [Test]
        public void ShowErrorIfLoginHasSpecialSymbol()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck!");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void ShowErrorIfLoginIsEmpty()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(string.Empty);

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);

        }

        [Test]
        public void SuccessfulRegistrationIfLoginLengthIs6()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteec");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void SuccessfulRegistrationIfLoginLengthIs24()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ArtArtArtArtArtArtArtArt");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void SuccessfulRegistrationIfEmailLengthIs35()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ArteecArteecArteecArteecArtee@we.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void SuccessfulRegistrationIfSexIsFemale()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void SuccessfulRegistrationIfCheckboxIsNotSelected()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void SuccessfulRegistrationIfSexIsEmpty()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck");

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void SuccessfulRegistrationIfLoginHasNumbers()
        {
            driver.Navigate().GoToUrl(testingURL);
            driver.FindElement(By.ClassName("student")).SendKeys("Артемий Гордон");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Arteeck24");

            driver.FindElement(By.ClassName("text-email")).SendKeys("art99999@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            var checkbox = driver.FindElement(By.ClassName("button-checkbox"));
            checkbox.Click();
            checkbox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }
    }
}
