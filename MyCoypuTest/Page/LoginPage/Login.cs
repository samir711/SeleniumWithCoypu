using System;
using Coypu;
using static MyCoypuTest.Core.DriverFactory.BrowserSessionConfig;
using static MyCoypuTest.Util.TestPage;

namespace MyCoypuTest.Page.LoginPage
{
    public class Login
    {
        public static void BrowserLogin(string url, string username, string password, string loginButton, string browser = "chrome")
        {
            SetBrowserSession("executeautomation.com", browser);
            PageBrowser.Visit(url);
            PageBrowser.FillIn("UserName").With(username);
            PageBrowser.FillIn("Password").With(password);
            PageBrowser.ClickButton(loginButton, new Options()
            {
                WaitBeforeClick = TimeSpan.FromMilliseconds(2000),

            });

        }
    }
}
