using System;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace MyCoypuTest.Core.DriverFactory
{
    internal class CustomIeDriver : SeleniumWebDriver
    {
        public CustomIeDriver() : base(CustomIeDriverWithOptions(), Browser.InternetExplorer)
        {
        }

        public static InternetExplorerDriver CustomIeDriverWithOptions()
        {
            var ieoptions = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = false,
                EnsureCleanSession = true,
                IgnoreZoomLevel = true,
                InitialBrowserUrl = "about:Tabs",
                EnableNativeEvents = false,
                //  PageLoadStrategy = InternetExplorerPageLoadStrategy.Eager
            };

            return new InternetExplorerDriver(ieoptions);


        }
    }
}