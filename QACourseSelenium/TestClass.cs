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
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("khudya");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldAcceptSexMale()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("khudya");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldAcceptWithoutSex()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("khudya");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }


        [Test]
        public void Form_ShouldAcceptLoginCyrilic()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("рррррр");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldNotAcceptEmptyLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.\r\nInvalid input.");
        }
        [Test]
        public void Form_ShouldNotAcceptShortLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.");
        }
        [Test]
        public void Form_ShouldAcceptLoginLenghtOfLeftBoundary()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldAcceptLoginLenghtOfRightBoundary()
    {
        driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
        driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
        driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhhhhhhhhhhhhhhhhhhhhh");

        var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
        select.Options[2].Click();

        driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
        driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
        driver.FindElement(By.Id("confirm")).SendKeys("123456");

        var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
        checkBox.Click();
        checkBox.Submit();

        var result = driver.FindElement(By.ClassName("flashes")).Text;
        Assert.AreEqual(result, "Спасибо за регистрацию!");
    }
        [Test]
        public void Form_ShouldNotAcceptLongLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhhhhhhhhhhhhhhhhhhhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.");
        }
        [Test]
        public void Form_ShouldNotAcceptLoginWithSpecSimvol()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh!h");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid input.");
        }
        [Test]
        public void Form_ShouldAcceptLoginWithNamberAndLetters()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh88");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldAcceptLoginWithOnlyNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("8888888");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldNotAcceptLoginWithSpaceAtTheEnd()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("8888888 ");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid input.");
        }


        [Test]
        public void Form_ShouldAcceptValidnEmailn()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldNotAcceptCyrilicEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("рус@р.ру");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid email address.");
        }
        [Test]
        public void Form_ShouldNotAcceptEmailWithDomainPathLenght1()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmailmail.r");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid email address.");
        }
        [Test]
        public void Form_ShouldNotAcceptEmailWithoutSignDog()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmailmail.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid email address.");
        }
        [Test]
        public void Form_ShouldNotAcceptEmailWithoutSignPoint()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mailru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid email address.");
        }
        [Test]
        public void Form_ShouldNotAcceptEmailWithSpaceAfter()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("textmail@mail.ru ");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid email address.");
        }
        [Test]
        public void Form_ShouldNotAcceptEmptyEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.\r\nInvalid email address.");
        }
        [Test]
        public void Form_ShouldNotAcceptEmailPointbeforeSignSobaka()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("f.!@iru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid email address.");
        }
        [Test]
        public void Form_ShouldNotAcceptEmailWithTwoSignDog()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("f@!@i.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid email address.");
        }
        [Test]
        public void Form_ShouldNotAcceptShortEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("f@i.r");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.\r\nInvalid email address.");
        }
        [Test]
        public void Form_ShouldAcceptEmailLenghtOfLeftBoundary()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("f@i.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldAcceptEmailLenthOfRightBoundary()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ffffffffffffffffffffffffff@mail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldNotAcceptLongEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("fffffffffffffffffffffffffff@mail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.");
        }

        [Test]
        public void Form_ShouldAcceptPasswordsCyrilic()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ffffffffffffff@mail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("яблоко");
            driver.FindElement(By.Id("confirm")).SendKeys("яблоко");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldNotAcceptNotMatchPasswords()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ffffffffffffff@mail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Passwords must match");
        }
        [Test]
        public void Form_ShouldNotAcceptPasswordConsistingOfSpace()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ffffffffffffff@mail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys(" ");
            driver.FindElement(By.Id("confirm")).SendKeys(" ");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "This field is required.");
        }
        [Test]
        public void Form_ShouldAcceptPasswordsWithSpecSign()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ffffffffffffff@mail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("+");
            driver.FindElement(By.Id("confirm")).SendKeys("+");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldAcceptMatchPasswords()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ffffffffffffff@mail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm")).SendKeys("12345");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
        [Test]
        public void Form_ShouldNotAcceptEmptyConfirmPasswords()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ffffffffffffff@mail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm")).SendKeys("");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Passwords must match");
        }


        [Test]
        public void Form_ShouldAcceptNotSelectedCheckBox()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Яна Худякова");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("hhhhh");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ffffffffffffff@mail.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("12345");
            driver.FindElement(By.Id("confirm")).SendKeys("12345");
            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();
            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
    }
}