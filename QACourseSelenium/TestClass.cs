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

        private IWebElement login;
        private SelectElement gender;
        private IWebElement email;
        private IWebElement pass;
        private IWebElement passConfirm;
        private IWebElement acceptTerms;

        private IWebElement FindEl(string elementId) => driver.FindElement(By.Id(elementId));
        private void AssertSuccessReg()
        {
            Assert.AreEqual(
                "Спасибо за регистрацию!", 
                driver.FindElement(By.ClassName("flashes")).Text);
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void SetUpSite()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/training/ekb/form");

            FindEl("student")
                .SendKeys("Даниил Мартыненко");
            login = FindEl("username");
            gender = new SelectElement(driver.FindElement(By.Id("sex")));
            email = FindEl("email");
            pass = FindEl("password");
            passConfirm = FindEl("confirm");
            acceptTerms = FindEl("accept_tos");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void LoginContainsOnlyWords()
        {
            login.SendKeys("deniil");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void LoginContainsOnlyDigits()
        {
            login.SendKeys("12345678");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void LoginContainsRusSymbols()
        {
            login.SendKeys("Даниил");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void LoginLengthIsCorrect
            ([Values("dddd", "dddddddddddddddddddddddd")] string loginStr)
        {
            login.SendKeys(loginStr);
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void LoginLengthIsNotCorrect
            ([Values("ddd", "ddddddddddddddddddddddddd")] string loginStr)
        {
            login.SendKeys(loginStr);
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.", result);
        }

        [Test]
        public void LoginContainsSpecialSymbols()
        {
            login.SendKeys("@d##%^$1");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid input.", result);
        }

        [Test]
        public void LoginIsEmpty()
        {

            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 4 and 24 characters long.\r\nInvalid input.", result);
        }

        [Test]
        public void GenderChoiceFromList
            ([Values(0, 1, 2)] int genderSelectorIndex)
        {
            login.SendKeys("deniil108");
            gender.Options[genderSelectorIndex].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void GenderIsNotChosen()
        {
            login.SendKeys("deniil108");

            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }


        [Test]
        public void EmailHasNotDot()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmailcom");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void EmailHasNotEmailSymbol()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys("deniil108gmail.com");
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Invalid email address.", result);
        }

        [Test]
        public void EmailLengthIsCorrect
            ([Values("d@d.ru", "ddddddddddddddddddddddddd@gmail.com")] string emailStr)
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys(emailStr);
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void EmailLengthIsNotCorrect
        ([Values("d@d.d", "dddddddddddddddddddddddddddddddd@d.d")]
            string emailStr)
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys(emailStr);
            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void EmailIsEmpty()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();

            pass.SendKeys("abc12345678");
            passConfirm.SendKeys("abc12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Field must be between 6 and 35 characters long.\r\nInvalid email address.", result);
        }

        [Test]
        public void PasswordContainsOnlyLetters()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("abcdefgh");
            passConfirm.SendKeys("abcdefgh");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void PasswordContainsOnlyDigits()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("12345678");
            passConfirm.SendKeys("12345678");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void PasswordContainsRusSymbols()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("хочукушатьabcd");
            passConfirm.SendKeys("хочукушатьabcd");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void PasswordContainsUTF16()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("喔☯☲◘Ǖᕾabcd");
            passConfirm.SendKeys("喔☯☲◘Ǖᕾabcd");
            acceptTerms.Click();
            acceptTerms.Submit();

            AssertSuccessReg();
        }

        [Test]
        public void PasswordIsNotEqualToConfirmation()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("12345678");
            passConfirm.SendKeys("abcdefgh");
            acceptTerms.Click();
            acceptTerms.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("Passwords must match", result);
        }

        [Test]
        public void PasswordAndConfirmationAreEmpty()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");


            acceptTerms.Click();
            acceptTerms.Submit();

            var result = driver.FindElement(By.ClassName("errors")).Text;
            Assert.AreEqual("This field is required.", result);
        }

        [Test]
        public void TermsCheckBoxIsEmpty()
        {
            login.SendKeys("deniil108");
            gender.Options[1].Click();
            email.SendKeys("deniil108@gmail.com");
            pass.SendKeys("12345678");
            passConfirm.SendKeys("12345678");

            acceptTerms.Submit();

            AssertSuccessReg();
        }
    }
}