using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSelenium.SeleniumDriver
{
    internal class DriverFactory
    {
       
            public static IWebDriver CreateWebDriver(string browserType)
            {
                IWebDriver driver;

                switch (browserType)
                {
                    case "chrome":
                        driver = CreateChromeDriver();
                        break;
                    case "edge":
                        driver = CreateEdgeDriver();
                        break;
                    default:
                        throw new ArgumentException("Invalid browser type specified");
                }

                return driver;
            }

            private static IWebDriver CreateChromeDriver()
            {
                // Set up Chrome options if needed
                ChromeOptions options = new ChromeOptions();
                // Add any desired options

                return new ChromeDriver(options);
            }


            private static IWebDriver CreateEdgeDriver()
            {
                // Set up Edge options if needed
                EdgeOptions options = new EdgeOptions();
                // Add any desired options

                return new EdgeDriver(options);
            }

         
        }

    
}
