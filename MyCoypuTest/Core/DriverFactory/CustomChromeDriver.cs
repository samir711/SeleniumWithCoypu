using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace MyCoypuTest.Core.DriverFactory
{
    public class CustomChromeDriver : SeleniumWebDriver
    {


        public CustomChromeDriver() : base(ChormeDriverWithOptions(), Browser.Chrome)
        {
        }
        public static ChromeDriver ChormeDriverWithOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("always-authorize-plugins");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.AddArgument("enable-npapi");
            options.AddArguments("chrome.switches", "--disable-extensions");
            options.AddArgument("disable-infobars");
            options.AddArgument("enable-automation");
            options.AddArgument("start-maximized");
            options.AddArgument("--enable-memory-info");
            options.AddArguments("--enable-precise-memory-info");
            options.AddArgument("--js-flags=--expose-gc");
            options.AddArgument("disable-extensions-file-access-check");
            options.AddArgument("disable-extensions-http-throttling");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            return new ChromeDriver(options);


        }




    }
}
