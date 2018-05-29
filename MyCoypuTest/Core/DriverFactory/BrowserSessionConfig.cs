using Coypu;
using static MyCoypuTest.Core.DriverFactory.BrowserSetUp;
using static MyCoypuTest.Util.TestPage;

namespace MyCoypuTest.Core.DriverFactory
{
    public class BrowserSessionConfig
    {
        public static void SetBrowserSession(string url, string browser)
        {
            TestBrowserSetUp(browser);
            var sessionConfiguration = new SessionConfiguration
            {
                AppHost = url,
                Browser = BrowserString
            };

            PageBrowser = new BrowserSession(sessionConfiguration, WebDriver);
            PageBrowser.MaximiseWindow();
        }



        //var sessionConfiguration = new SessionConfiguration
        //{
        //    AppHost = "at.dayforce.com",
        //    Port = 1111,
        //    SSL = false,
        //    Driver = typeof(SeleniumWebDriver),
        //    Timeout = TimeSpan.FromSeconds(30),
        //    Browser = Browser.Firefox
        //};
        //var browser = new BrowserSession(sessionConfiguration);
        //browser.MaximiseWindow();


    }
}
