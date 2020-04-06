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

        //[Test]
        //public void ChromeDriverTest()
        //{
        //    driver.Navigate().GoToUrl("http://www.google.com");
        //    driver.FindElement(By.ClassName("gLFyf")).SendKeys("google");
        //    Thread.Sleep(500);
        //    driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
        //    var text = driver.FindElement(By.ClassName("e2BEnf")).Text;
        //    Assert.That(text, Is.EqualTo("Вместе с google часто ищут").After(500));
        //}

        [Test]
        public void FormShouldAcceptValidData()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
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
        public void FormShouldNotAcceptShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("sun");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Female");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Field must be between 4 and 24 characters long.");
        }

        [Test]
        public void FormShouldNotAcceptDifferentPasswords()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("1234");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Passwords must match");
        }

        [Test]
        public void FormShouldNotAcceptLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("1234567890123456789012345");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Female");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("1234");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Field must be between 4 and 24 characters long.");
        }

        [Test]
        public void FormShouldNotAcceptShortEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Female");
            driver.FindElement(By.Id("email")).SendKeys("a@.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Field must be between 6 and 35 characters long.\r\nInvalid email address.");
        }

        [Test]
        public void FormShouldNotAcceptLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("123456789012345678901234567890123@.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Field must be between 6 and 35 characters long.\r\nInvalid email address.");
        }

        [Test]
        public void FormShouldNotAcceptLoginWithSpecialSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova$");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Invalid input.");
        }

        [Test]
        public void FormShouldNotAcceptWithoutApprovment()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var text = driver.FindElement(By.ClassName("flashes")).Text;

            Assert.That(text == "Спасибо за регистрацию!");
        }

        [Test]
        public void FormShouldNotAcceptEmptyLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Field must be between 4 and 24 characters long.\r\nInvalid input.");
        }

        [Test]
        public void FormShouldNotAcceptEmptySex()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
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
        public void FormShouldNotAcceptEmptyEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Field must be between 6 and 35 characters long.\r\nInvalid email address.");
        }

        [Test]
        public void FormShouldNotAcceptShortEmailWithoutSymbol()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("aa.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Field must be between 6 and 35 characters long.\r\nInvalid email address.");
        }

        [Test]
        public void FormShouldNotAcceptEmailWithoutSymbol()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("aa1.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Invalid email address.");
        }

        [Test]
        public void FormShouldNotAcceptEmailWithoutDomen()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("aa1123");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Invalid email address.");
        }

        [Test]
        public void FormShouldAcceptLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("123456789012345678901234567890@1.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var text = driver.FindElement(By.ClassName("flashes")).Text;

            Assert.That(text == "Спасибо за регистрацию!");
        }

        [Test]
        public void FormShouldAcceptShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("sunt");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
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
        public void FormShouldAcceptLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("123456789012345678901234");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
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
        public void FormShouldAcceptLoginWithDigitAndLetters()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("123as");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
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
        public void FormShouldAcceptMale()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("123as");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
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
        public void FormShouldNotAcceptWrongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/final");
            driver.FindElement(By.Id("student")).SendKeys("Suntsova Anna");
            driver.FindElement(By.Id("username")).SendKeys("suntsova");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Женский");
            driver.FindElement(By.Id("email")).SendKeys("qq@q.q");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();

            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var errorText = driver.FindElement(By.ClassName("errors")).Text;

            Assert.That(errorText == "Invalid email address.");
        }

    }
}
