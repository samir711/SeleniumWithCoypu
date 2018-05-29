using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coypu;
using Coypu.Drivers;

namespace MyCoypuTest.Core.DriverFactory
{
    public class BrowserSetUp
    {
        public static Browser BrowserString { get; set; }
        public static Driver WebDriver { get; set; }
        public static void TestBrowserSetUp(string browser)
        {
            GetBrowserString(browser);
            CreateWebDriver(browser);
        }

        private static void CreateWebDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "internetexplorer":
                    WebDriver = new CustomIeDriver();
                    break;
                case "chrome":
                    WebDriver = new CustomChromeDriver();
                    break;
                case "firefox":
                    WebDriver = new CustomeFireFoxDriver();
                    break;
                default:
                    Console.WriteLine("No matching browser found");
                    break;
            }
        }

        private static void GetBrowserString(string browser)
        {
            switch (browser.ToLower())
            {
                case "internetexplorer":
                    BrowserString = Browser.InternetExplorer;
                    break;
                case "chrome":
                    BrowserString = Browser.Chrome;
                    break;
                case "firefox":
                    BrowserString = Browser.Firefox;
                    break;
                default:
                    Console.WriteLine("No matching browser found");
                    break;
            }
        }

    }
}
