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
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
        }

        [OneTimeTearDown]
        public void TearDown()  => driver.Quit();

        [TestCase("grisha",1, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName ="Корректный вариант")]
        [TestCase("", 1, "test@test.ru", "123456", "123456", "errors", "Field must be between 4 and 24 characters long.\r\nInvalid input.",
            TestName = "Пустой логин")]
        [TestCase("ggg", 1, "test@test.ru", "123456", "123456", "errors", "Field must be between 4 and 24 characters long.",
            TestName = "Слишком короткий логин в 3 символа")]
        [TestCase("gggg", 1, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Минимально возможный логин в 4 символа")]
        [TestCase("ggggg", 1, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Логин в 5 символов")]
        [TestCase("1234", 1, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Логин из чисел")]
        [TestCase("абвг", 1, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Логин из символ кирилици")]
        [TestCase("абв!г.", 1, "test@test.ru", "123456", "123456", "errors", "Invalid input.",
            TestName = "Логин с недопустимым символом")]
        [TestCase("ggggggggggggggggggggggg", 1, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Логин пред максимальной длины, 23")]
        [TestCase("gggggggggggggggggggggggg", 1, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Логин максимальной длины 24")]
        [TestCase("ggggggggggggggggggggggggg", 1, "test@test.ru", "123456", "123456", "errors", "Field must be between 4 and 24 characters long.",
            TestName = "Слишком длинный логин, 25 символов")]
        [TestCase("grisha", 0, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Регистрация без ввода пола")]
        [TestCase("grisha", 1, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Регистрация с мужским полом")]
        [TestCase("grisha", 2, "test@test.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Регистрация с женским полом")]
        [TestCase("grisha", 2, "", "123456", "123456", "errors", "Field must be between 6 and 35 characters long.\r\nInvalid email address.",
            TestName = "Регистрация с пустым emailom")]
        [TestCase("grisha", 2, "t@s.r", "123456", "123456", "errors", "Field must be between 6 and 35 characters long.\r\nInvalid email address.",
            TestName = "Регистрация с слишком коротким emailom 5 символов")]
        [TestCase("grisha", 2, "t@t.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Регистрация с минималньо возможным emailom 6 символов")]
        [TestCase("grisha", 2, "tt@t.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Регистрация emailom длиной 7 символов")]
        [TestCase("grisha", 2, "t!<t@s.r", "123456", "123456", "errors", "Invalid email address.",
            TestName = "Регистрация с emailom с недопустимыми символами")]
        [TestCase("grisha", 2, "абв@s.r", "123456", "123456", "errors", "Invalid email address.",
            TestName = "Регистрация с emailom с кирилицей")]
        [TestCase("grisha", 2, "ttttttttttttttttttttttttttttt@t.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Регистрация emailom длиной 34 символов")]
        [TestCase("grisha", 2, "tttttttttttttttttttttttttttttt@t.ru", "123456", "123456", "flashes", "Спасибо за регистрацию!",
            TestName = "Регистрация emailom длиной 35 символов")]
        [TestCase("grisha", 2, "ttttttttttttttttttttttttttttttt@s.ru", "123456", "123456", "errors", "Field must be between 6 and 35 characters long.",
            TestName = "Регистрация с слишком длинным emailom 36 символов")]
        [TestCase("grisha", 1, "test@test.ru", "", "", "errors", "This field is required.",
            TestName = "Регитсрация без пароля")]
        [TestCase("grisha", 1, "test@test.ru", "123", "123", "flashes", "Спасибо за регистрацию!",
            TestName = "Регитсрация с корректным паролем из цифр")]
        [TestCase("grisha", 1, "test@test.ru", "фис", "фис", "flashes", "Спасибо за регистрацию!",
            TestName = "Регитсрация с корректным паролем из символов кирилицы")]
        [TestCase("grisha", 1, "test@test.ru", "abc", "abc", "flashes", "Спасибо за регистрацию!",
            TestName = "Регитсрация с корректным паролем из символов латиницы")]
        [TestCase("grisha", 1, "test@test.ru", ".!>", ".!>", "flashes", "Спасибо за регистрацию!",
            TestName = "Регитсрация с корректным паролем из спец символов")]
        [TestCase("grisha", 1, "test@test.ru", "12", "ab", "errors", "Passwords must match",
            TestName = "Регитсрация с разными паролями")]
        [TestCase("grisha", 1, "test@test.ru", "12", "12", "flashes", "Спасибо за регистрацию!",false,
            TestName = "Регитсрация без выбора чекбокса")]
        [TestCase("grisha", 1, "test@test.ru", "12", "12", "flashes", "Спасибо за регистрацию!",true,
            TestName = "Регитсрация с выбором чекбокса")]

        public void InitialTest(string login,int dropItemIndex,string email, string password, string repeatPassword,
            string resultClass,string expectedResult, bool isCheckBoxChoosed=true)
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");
            driver.FindElement(By.ClassName("student")).SendKeys("Воронин Григорий");
            driver.FindElement(By.ClassName("text-plain")).SendKeys(login);

            var select = new SelectElement(driver.FindElement(By.ClassName("selected")));
            select.Options[dropItemIndex].Click();

            driver.FindElement(By.ClassName("text-email")).SendKeys(email);
            driver.FindElement(By.ClassName("text-password")).SendKeys(password);
            driver.FindElement(By.Id("confirm")).SendKeys(repeatPassword);

            var checkBox = driver.FindElement(By.ClassName("button-checkbox"));
            if (isCheckBoxChoosed)
                checkBox.Click();

            checkBox.Submit();

            var result = driver.FindElement(By.ClassName(resultClass)).Text;
            Assert.AreEqual(expectedResult, result);
        }
    }
}
