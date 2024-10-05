using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace E2ETest
{
    public class WebTest : IDisposable
    {
        private IWebDriver _driver;
        public WebTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        [Fact]
        public void Buttons()
        {
            _driver.Url = "https://formy-project.herokuapp.com/buttons";
            var dropdown = _driver.FindElement(By.CssSelector("#btnGroupDrop1"));
            dropdown.Click();
            _driver.FindElement(By.CssSelector(".dropdown-menu.show"));

        }

        [Fact]
        public void Checkbox()
        {
            _driver.Url = "https://formy-project.herokuapp.com/checkbox";
            var check = _driver.FindElement(By.CssSelector("#checkbox-1"));
            check.Click();
            _driver.FindElement(By.CssSelector("#checkbox-1:checked"));
        }
        [Fact]
        public void Datepicker()
        {
            _driver.Url = "https://formy-project.herokuapp.com/datepicker";
            var check = _driver.FindElement(By.CssSelector("#datepicker"));
            check.Click();
            var todayblock = _driver.FindElement(By.CssSelector(".datepicker-days td.today"));
            var datevalue = long.Parse(todayblock.GetAttribute("data-date"));
            todayblock.Click();
            DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds(datevalue).ToLocalTime().DateTime;
            check = _driver.FindElement(By.CssSelector("#datepicker"));
            Assert.Equal(dateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture), check.GetAttribute("value"));
        }
        [Fact]
        public void DragDrop()
        {
            _driver.Url = "https://formy-project.herokuapp.com/dragdrop";
            var img = _driver.FindElement(By.CssSelector("#image"));
            var box = _driver.FindElement(By.CssSelector("#box"));
            Actions action = new Actions(_driver);
            action.DragAndDrop(img, box).Perform();
            _driver.FindElement(By.CssSelector("#box.ui-state-highlight"));
        }

        [Fact]
        public void Disabled()
        {
            _driver.Url = "https://formy-project.herokuapp.com/enabled";
            var check = _driver.FindElement(By.CssSelector("#disabledInput"));
            Assert.Equal(check.GetAttribute("disabled"), "true");

        }

        [Fact]
        public void FileUpload()
        {
            _driver.Url = "https://formy-project.herokuapp.com/fileupload";
            var fileInput = _driver.FindElement(By.CssSelector("input[type='file']"));
            var file = Path.Combine(AppContext.BaseDirectory, "test.txt");
            fileInput.SendKeys(file);
            var fileName = _driver.FindElement(By.CssSelector("#file-upload-field"));
            Assert.Equal("test.txt", fileName.GetAttribute("value"));
            var reset = _driver.FindElement(By.CssSelector(".btn-reset"));
            reset.Click();
            fileName = _driver.FindElement(By.CssSelector("#file-upload-field"));
            Assert.Equal("", fileName.GetAttribute("value"));
        }

        [Fact]
        public void Modal()
        {
            _driver.Url = "https://formy-project.herokuapp.com/modal";
            var btn = _driver.FindElement(By.CssSelector("#modal-button"));
            btn.Click();
            var modalShown = _driver.FindElement(By.CssSelector("#exampleModal.fade.show"));
            modalShown.Click();
            var modal = _driver.FindElement(By.CssSelector("#exampleModal.fade"));
        }

        [Fact]
        public void Scroll()
        {
            _driver.Url = "https://formy-project.herokuapp.com/scroll";
            var input = _driver.FindElement(By.CssSelector("#name"));
            new Actions(_driver)
                .ScrollToElement(input)
                .Perform();
        }
        [Fact]
        public void RadioButton()
        {
            _driver.Url = "https://formy-project.herokuapp.com/radiobutton";
            var check = _driver.FindElement(By.CssSelector("#radio-button-1"));
            check.Click();
            _driver.FindElement(By.CssSelector("#radio-button-1:checked"));
            var check2 = _driver.FindElement(By.CssSelector("body > div > div:nth-child(6) > input"));
            check2.Click();
            _driver.FindElement(By.CssSelector("body > div > div:nth-child(6) > input:checked"));


        }

        [Fact]
        public void Alert()
        {
            _driver.Url = "https://formy-project.herokuapp.com/switch-window";
            var check = _driver.FindElement(By.CssSelector("#alert-button"));
            check.Click();
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();
        }
        public void Dispose()
        {
            _driver.Dispose();
        }

    }
}