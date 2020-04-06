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
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            // Адрес
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/izh/form");
            driver.Navigate().Refresh();
            // Имя студента ставим своё
            driver.FindElement(By.Id("student")).SendKeys("Budnikov Kirill");
        }
        
        [Test]
        public void Form_ShouldAcceptValidData()
        {
            // Логин 4-24 символа
            driver.FindElement(By.Id("username")).SendKeys("budnikov");
            // Поле выбора пола
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
            // Электронная почта 6-35 символов, обязательная собачка @
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            // Пароль без ограничений, подтверждение должно совпадать
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            // Чекбокс "принять условия"
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
            
            //Нажимаем по кнопке "Зарегистрироваться"
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            // Проверяем что текст соответствует 
            var text = driver.FindElement(By.ClassName("flashes")).Text;
            Assert.That(text == "Спасибо за регистрацию!");
        }
        
        [Test]
        public void Form_ShouldNotAcceptShortLogin()
        {
            driver.FindElement(By.Id("username")).SendKeys("bud");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("123");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
            
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Field must be between 4 and 24 characters long.", "Не валидируется короткий логин");
            
        }
        
        [Test]
        public void Form_ShouldNotAcceptWhenPasswordIsNotConfirmed()
        {
            driver.FindElement(By.Id("username")).SendKeys("buda");
            var sex = driver.FindElement(By.Id("sex"));
            var selectSex = new SelectElement(sex);
            selectSex.SelectByText("Male");
            driver.FindElement(By.Id("email")).SendKeys("a@a.ru");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("confirm")).SendKeys("122");
            var acceptTos = driver.FindElement(By.Id("accept_tos"));
            acceptTos.Click();
            
            driver.FindElement(By.CssSelector("input[value=Register]")).Click();

            var error = driver.FindElement(By.ClassName("errors")).Text;
            Assert.That(error == "Passwords must match", "Не валидируется подтверждение пароля");
            
        }
    }
}
