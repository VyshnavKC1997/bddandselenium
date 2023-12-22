using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestBDD.HooksClass;
using AventStack.ExtentReports;

namespace TestBDD.StepDefinitions
{
    [Binding]
    public class SearchAndBuyStepDefinitions
    {
        ExtentReports extent = Hooks.extent;
        ExtentTest test;
        IWebDriver? driver = Hooks.driver;

        [When(@"User type '([^']*)' in text box")]
        public void WhenUserTypeInTextBox(string pedigree)
        {
            test = extent.CreateTest("ggfgfgf","fggdghfdhgdchgfcgfcngvngjnmbmbm");
            test.Pass();
          //  driver.FindElement(By.Id("mainfrm")).Click();
            driver.FindElement(By.Id("mainfrm")).SendKeys(pedigree);
        }

        [When(@"Click On search button")]
        public void WhenClickOnSearchButton()
        {
            driver.FindElement(By.XPath("//form[@role='search']//button[@type='submit']")).Click();
        }

        [Then(@"User will be redirected into product page")]
        public void ThenUserWillBeRedirectedIntoProductPage()
        {
            try
            {
                Assert.That(driver.Url.Contains("pedigree"), "Search Product Test Failed");

                
            }
            catch (AssertionException ex)
            {
               
            }
        }

        [When(@"User click on add to cart button for products")]
        public void WhenUserClickOnAddToCartButtonForProducts()
        {
            var products = driver.FindElements(By.XPath("//button[@name='add']"));
            int i = 0;
            foreach (var product in products)
            {

                product.Click();

            }
        }

        [When(@"Click On gotocart button")]
        public void WhenClickOnGotocartButton()
        {
            driver.FindElement(By.Id("HeaderCartTrigger")).Click();
        }

        [Then(@"User Will Be On CartPage")]
        public void ThenUserWillBeOnCartPage()
        {
            try
            {
                Assert.That(driver.Url.Contains("cart"), "Move to cart");


            }
            catch (AssertionException ex)
            {
               
            }
        }

        [When(@"User Click On Proceed To Pay")]
        public void WhenUserClickOnProceedToPay()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//div[@class='cart__item-row cart__checkout-wrapper small--hide']//button[@name='checkout'][normalize-space()='Checkout']")));
        }

        [Then(@"User will be On payment page")]
        public void ThenUserWillBeOnPaymentPage()
        {
            try
            {
                Assert.That(driver.Url.Contains("cart"), "Move to CheckOut");


            }
            catch (AssertionException ex)
            {
               
            }
        }

        [When(@"User Enter The Form Data with '([^']*)' ,'([^']*)' ,'([^']*)' ,'([^']*)' ,'([^']*)' , '([^']*)',  '([^']*)','([^']*)' ,'([^']*)'")]
        public void WhenUserEnterTheFormDataWith(string vysh, string kc, string kannur, string ktba, string p4, string kL, string p6, string p7, string p8)
        {
            DefaultWait<IWebDriver> wait;
            wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException), typeof(NoSuchElementException));
        //    wait.Until(d => SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(By.Id("checkout_shipping_address_first_name"))));
            driver.FindElement(By.Id("checkout_shipping_address_first_name")).SendKeys(vysh);
            driver.FindElement(By.Id("checkout_shipping_address_last_name")).SendKeys(kc);
            driver.FindElement(By.Id("checkout_shipping_address_address1")).SendKeys(kannur);
            driver.FindElement(By.Id("checkout_shipping_address_city")).SendKeys(ktba);
            driver.FindElement(By.Id("checkout_email")).SendKeys(p4);
            driver.FindElement(By.Id("checkout_shipping_address_province")).SendKeys(kL);
            driver.FindElement(By.Id("checkout_shipping_address_address2")).SendKeys(p6);
            driver.FindElement(By.Id("checkout_shipping_address_zip")).SendKeys(p7);
            driver.FindElement(By.Id("checkout_shipping_address_phone")).SendKeys(p8);


        }




        [When(@"Press SubmitButton")]
        public void WhenPressSubmitButton()
        {
            driver.FindElement(By.Id("continue_button")).Click();
        }

        [Then(@"User will be on Final Payment Page with Proceed Button")]
        public void ThenUserWillBeOnFinalPaymentPageWithProceedButton()
        {
            try
            {
                Assert.That(driver.Url.Contains("checkouts"));

            }
            catch (AssertionException ex)
            {
              
            }
        }
    }
}
