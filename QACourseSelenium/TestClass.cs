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
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!",result);
        }

        [Test]
        public void EmptyLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);

        }

       /* [Test]
        public void LoginWithRoundParenthesis()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD()");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void LoginWithSquareParenthesis()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD[]");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void LoginWithDots()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD.");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

       [Test]
        public void LoginWithPercentage()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD%");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }*/

       [Test]
        public void LoginLessThanFourSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Tag");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginGreaterThanTwentyFourSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Tag4567890123456789012345");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginEqualFourSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void LoginEqualTwentyFourSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD56789012345678901234");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void LoginWithRusLetters()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ТагД");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void LoginWithNumbers()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("56789012345678901234");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void LoginWithSpace()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("Bor Bor");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void LoginWithSpecialSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("()[]!?%&@\\\"/:;#`~№$*-_=+");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void NoGender()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[0].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void MaleGender()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void FemaleGender()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragn@testmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmptyEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void EmailWithoutDog()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragntestmail.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void EmailWithoutDotInDomain()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("ragntest@ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void EmailLessThanSixSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a@a.a");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void ValidEmailGreaterThanThirtyFiveSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a234567890123456789012345678901@a.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.", result);
        }

        [Test]
        public void ValidEmailEqualToThirtyFiveSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456789012345678901234567890@a.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ValidEmailEqualToSixSymbols()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a@a.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmailWithoutDomain()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("abcdef@");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void EmailWithoutName()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("@abcd.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void ValidEmailWithMoreThanONeDotsInDomain()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456767890@a.b.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void EmailWithMoreThanOneDog()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a@a@a@abcd.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void EmailWithSpecialSymbolsInDomain()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@ab!cd.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void ValidEmailWithSpecialSymbolsInName()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a2345!6767890@b.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void ConfirmPasswordIsCorrect()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456767890@a.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("correct");
            driver.FindElement(By.Id("confirm")).SendKeys("correct");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void DifferentPasswordInConfirmPassword()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@abcd.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("passt");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void EmptyConfirmPassword()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@abcd.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void OneSymbolPassword()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("aa@abcd.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("p");
            driver.FindElement(By.Id("confirm")).SendKeys("p");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void WithCheckbox()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456767890@b.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        [Test]
        public void WithoutCheckbox()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456767890@b.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }


        [Test]
        public void OnlyPasswordErrorLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.XPath( "/ html / body / form / dl / dd[2] / ul")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);

        }

        [Test]
        public void OnlyPasswordErrorMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);

        }

        [Test]
        public void OnlyPasswordErrorConfirm()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[5]/ul")).Text;
            Assert.AreEqual("Passwords must match", result);

        }

        [Test]
        public void OnlyNecesseryFields()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456767890@b.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual("Спасибо за регистрацию!", result);
        }

        //Дальше тесты проверяют реакцию формы при заполненности различных полей.
        //Всего полей 5, что дает 32 варианта (Заполнено - не заполнено). Метод пар оставил 8. Два варианта были уже проверены выше.

        [Test]
        public void OnlyPassLoginGenderCheckboxErrorMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagDm");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);

        }

        [Test]
        public void OnlyPassLoginGenderCheckboxErrorConfirm()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagDm");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[1].Click();

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[5]/ul")).Text;
            Assert.AreEqual("Passwords must match", result);

        }

        [Test]
        public void OnlyMailConfirmErrorLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456767890@b.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/ html / body / form / dl / dd[2] / ul")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);

        }

        [Test]
        public void OnlyGenderConfirmErrorLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();


            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/ html / body / form / dl / dd[2] / ul")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }

        [Test]
        public void OnlyGenderConfirmErrorMail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();


            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");
            driver.FindElement(By.Id("confirm")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[4]/ul")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void OnlyLoginMailErrorConfirm()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("TagD");

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456767890@b.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[5]/ul")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void OnleGenderMailCheckboxErrorLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456767890@b.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/ html / body / form / dl / dd[2] / ul")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }

        [Test]
        public void OnleGenderMailCheckboxErrorConfirm()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Таганцов Дмитрий");

            var select = new SelectElement(driver.FindElement((By.ClassName("selected"))));
            select.Options[2].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys("a23456767890@b.ru");

            driver.FindElement(By.ClassName("text-password")).SendKeys("pass");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.XPath("/html/body/form/dl/dd[5]/ul")).Text;
            Assert.AreEqual("Passwords must match", result);
        }
    }
}
