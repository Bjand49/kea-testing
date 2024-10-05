using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void flow()
        {
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            driver.Url = "http://localhost:5500";
            //Sign up
            driver.FindElement(By.CssSelector("#optSignup a")).Click();

            //Add user details and sign up
            driver.FindElement(By.CssSelector("#txtEmail")).SendKeys("test@kea.dk");
            driver.FindElement(By.CssSelector("#txtPassword")).SendKeys("pepe");
            driver.FindElement(By.CssSelector("#txtRepeatPassword")).SendKeys("pepe");
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(driver =>
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            }); 
            driver.SwitchTo().Alert().Dismiss();

            //go to login, and log in (the signup didnt work with the server)
            driver.FindElement(By.CssSelector("a[href='login.html']")).Click();
            driver.FindElement(By.CssSelector("#txtEmail")).SendKeys("a@a.com");
            driver.FindElement(By.CssSelector("#txtPassword")).SendKeys("pepe");
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            //Find the right elements and add them to the cart

            //Shirt
            var articles = driver.FindElements(By.CssSelector("body >main > section > article"));
            foreach (var article in articles)
            {
                var header = article.FindElement(By.CssSelector("header h2"));
                if (header.Text.Trim() == "Mens Casual Premium Slim Fit T-Shirts")
                {
                    article.FindElement(By.CssSelector(".cart button")).Click();
                    break;
                }
            }

            //SSD
            foreach (var article in articles)
            {
                var header = article.FindElement(By.CssSelector("header h2"));
                if (header.Text.Trim() == "SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s")
                {
                    new Actions(driver)
                        .ScrollToElement(article)
                        .Perform();
                    var number = article.FindElement(By.CssSelector(".cart input[type='number']"));
                    number.Click();
                    number.SendKeys(Keys.Up);
                    article.FindElement(By.CssSelector(".cart button")).Click();
                    break;
                }

            }
            //checkout cart
            driver.FindElement(By.CssSelector("#optCart a")).Click();
            driver.FindElement(By.CssSelector("#cart form input[type='submit']")).Click();

            //enter address
            driver.FindElement(By.CssSelector("#txtDeliveryAddress")).SendKeys("Guldbergsgade 29N");
            driver.FindElement(By.CssSelector("#txtDeliveryPostalCode")).SendKeys("2200");
            driver.FindElement(By.CssSelector("#txtDeliveryCity")).SendKeys("Copenhagen");
            driver.FindElement(By.CssSelector("#chkRepeat")).Click();
            driver.FindElement(By.CssSelector("#txtCreditCardName")).SendKeys("Pernille L. Hansen");
            var dateInput= driver.FindElement(By.CssSelector("#txtExpiryDate"));
            dateInput.SendKeys("d");
            dateInput.SendKeys(Keys.Tab);
            dateInput.SendKeys("2027");
            driver.FindElement(By.CssSelector(".submit input[value='Place Purchase'")).Click();
            driver.FindElement(By.CssSelector("#txtCVV")).SendKeys("666");
            driver.FindElement(By.CssSelector("#checkout form div.submit input[type='submit']")).Click();

            //checkout cart
            driver.FindElement(By.CssSelector("#optCart a")).Click();
            Assert.Equal("The cart is empty. Please add some products to the cart.", driver.FindElement(By.CssSelector("#alert p")).Text);


        }
    }
}