using System;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MyCoypuTest.Core.DriverFactory
{
    internal class CustomeFireFoxDriver : SeleniumWebDriver
    {
        public CustomeFireFoxDriver() : base(FireFoxDriverWithOptions(), Browser.Firefox)
        {

        }

        public static FirefoxDriver FireFoxDriverWithOptions()
        {
            var fp = new FirefoxProfile();
            fp.SetPreference("plugins.default.state", 2);
            fp.SetPreference("plugin.state.npctrl", 2);
            fp.SetPreference("browser.startup.homepage", "about:blank");
            fp.SetPreference("startup.homepage_welcome_url", "about:blank");
            fp.SetPreference("startup.homepage_welcome_url.additional", "about:blank");
            fp.SetPreference("security.sandbox.content.level", 4);
            fp.SetPreference("devtools.selfxss.count", 100);
            var strPath = GetBrowserPath("FIREFOX.EXE").Remove(0, 1);
            strPath = strPath.Remove(strPath.Length - 1, 1);

            var op = new FirefoxOptions() { BrowserExecutableLocation = strPath, Profile = fp };
            try
            {
                return new FirefoxDriver(op);
            }
            catch (Exception e)
            {
                throw new Exception($"FireFoxDriver failed to load with message: {e.Message}");
            }

        }
        private static string GetBrowserPath(string strBrowser)
        {
            string strPath = null;
            //on 64bit the browsers are in a different location
            var browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet") ??
                              Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

            if (browserKeys != null)
            {
                var browserNames = browserKeys.GetSubKeyNames();

                foreach (var browser in browserNames)
                {
                    if (!browser.Contains(strBrowser)) continue;
                    var browserKey = browserKeys.OpenSubKey(browser);
                    var browserKeyPath = browserKey?.OpenSubKey(@"shell\open\command");
                    if (browserKeyPath != null) strPath = (string)browserKeyPath.GetValue(null);
                    break;
                }
            }
            return strPath;
        }

    }
}