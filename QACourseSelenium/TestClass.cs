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
            Assert.That(text, Is.EqualTo("Вместе с google часто ищут").After(500));
        }

        [Test]
        public void InitialTest()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyass");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("kekkek.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid email address.");
        }

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilya");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("kek@kek.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }

        [Test]
        public void Test3()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ily");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("kek@kek.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.");
        }

        [Test]
        public void Test4()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyasilyasilyasilyasilya");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("kek@kek.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }

        [Test]
        public void Test5()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyasilyasilyasilyasilyas");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("kek@kek.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.");
        }

        [Test]
        public void TestUnequalPasswords()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyas");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("kek@kek.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("12345678");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Passwords must match");
        }

        [Test]
        public void TestSpecSymbolInLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyas#");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("kek@kek.com");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("12345678");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Invalid input.");
        }

        [Test]
        public void Test5SymbolsInEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyass");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("k@k.u");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.\r\nInvalid email address.");
        }


        [Test]
        public void Test36SymbolsInEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyass");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("qwertqwertqwertqwertqwert@qwertyu.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 6 and 35 characters long.");

        }

        [Test]
        public void TestWithoutLogin()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("kek@kek.ru");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual(result, "Field must be between 4 and 24 characters long.\r\nInvalid input.");
        }

        [Test]
        public void Test35SymbolsInEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyas");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("qwertqwertqwertqwertqwert@ke.om");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }

        [Test]
        public void Test6SymbolsInEmail()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyas2");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("q@k.om");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }

        [Test]
        public void Test6SymbolsInEmail7()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Алеев Ильяс");
            driver.FindElement(By.ClassName("text-plain")).SendKeys("ilyas2");

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[1].Click();


            driver.FindElement(By.ClassName("text-email")).SendKeys("q@k.om");
            driver.FindElement(By.ClassName("text-password")).SendKeys("123456789");
            driver.FindElement(By.Id("confirm")).SendKeys("123456789");

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            checkBox.Click();
            checkBox.Submit();

            var result = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.AreEqual(result, "Спасибо за регистрацию!");
        }
    }
}

