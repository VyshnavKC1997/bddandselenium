using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Serilog;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TestBDD.DriverCreation;

namespace TestBDD.HooksClass
{
    [Binding]
    public sealed class Hooks
    {
        static Dictionary<string, string> properties;
        public static IWebDriver? driver;
        static public ExtentReports extent;
        static ExtentSparkReporter sparkReporter;
       

        [BeforeFeature]
        public static void LogFileCreation()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/SearchFeature_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currdir + "/ExtentReport/extent-report"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            extent.AttachReporter(sparkReporter);

            properties = new Dictionary<string, string>();
            string fileName = currdir + "/Configuration/config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
            driver = DriverFactory.CreateWebDriver(properties["browser"].ToLower());
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
           

            

            

          
        }

        [AfterFeature]
        public static void CleanUp()
        {
            Log.CloseAndFlush();
            extent.Flush();
            driver?.Quit();
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            driver?.Navigate().GoToUrl(properties["baseUrl"]);
        }


    }
}