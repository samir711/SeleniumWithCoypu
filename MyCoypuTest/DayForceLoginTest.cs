using System;
using Coypu;
using Coypu.Drivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace MyCoypuTest
{
    [TestFixture]
    public class DayForceLoginTest
    {


        [Test]
        public void LoginTest()
        {
            var sessionConfiguration = new SessionConfiguration
            {
                Browser = Browser.InternetExplorer,
                AppHost = "at.dayforce.com"
            };

            var browser = new BrowserSession(sessionConfiguration);
            browser.Visit("/root/mydayforce/MyDayforce.aspx");
            browser.FillIn("txtCompanyName").With("at855plat6");
            browser.FillIn("txtUserName").With("cadmin");
            browser.FillIn("txtUserPass").With("1");
            browser.ClickButton("Login");

        }
    }
}
