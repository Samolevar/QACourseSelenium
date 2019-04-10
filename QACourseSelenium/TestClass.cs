// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QACourseSelenium
{
    [TestFixture]
    public class TestClass
    {
        private ChromeDriver chromeDriver;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            chromeDriver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }

        [Test]
        public void ChromeDriverTest()
        {
            chromeDriver.Navigate().GoToUrl("http://www.google.com");
            chromeDriver.FindElement(By.ClassName("gLFyf")).SendKeys("google");
            Thread.Sleep(500);
            chromeDriver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
            var text = chromeDriver.FindElement(By.ClassName("e2BEnf")).Text;
            Assert.That(text, Is.EqualTo("Главные новости").After(500));
        }
    }
}