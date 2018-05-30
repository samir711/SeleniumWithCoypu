using Coypu;
using Coypu.Matchers;
using NUnit.Framework;
using static MyCoypuTest.Core.DriverFactory.BrowserSessionConfig;
using static MyCoypuTest.Page.LoginPage.Login;
using static MyCoypuTest.Page.UserFormPage.UserForm;
using static MyCoypuTest.Util.TestPage;
using Shows = Coypu.NUnit.Matchers.Shows;


namespace MyCoypuTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Test_FillUserForm()
        {
            BrowserLogin("/demosite/Login.html", "admin", "password", "Login");
            FillUserForm();
            TestPopUp();
        }

        [Test]
        public void Test_DialogBox()
        {
            BrowserLogin("/demosite/Login.html", "admin", "password", "Login");
            PageBrowser.ClickButton("Generate");

            //JavaScript Alert Box
            PageBrowser.AcceptModalDialog();
            var dialogMessage = PageBrowser.HasDialog("You pressed OK!");
            Assert.That(dialogMessage, "The message displayed is not the one we are expecting");
        }

        [Test]
        public void Test_MouseHover()
        {
            BrowserLogin("/demosite/Login.html", "admin", "password", "Login");
            PageBrowser.FindId("Automation Tools").Hover();
            PageBrowser.FindId("Selenium").Hover();
            PageBrowser.FindId("Selenium RC").Hover().Click();
            Assert.That(PageBrowser.HasContent("Selenium RC", Options.Substring));

        }

        [Test]
        public void Test_MenubarMenu()
        {
            BrowserLogin("/demosite/Login.html", "admin", "password", "Login");
            PageBrowser.FindId("Automation Tools").Hover();
            Assert.That(PageBrowser, Shows.Css("ul > li > a > span", $"Selenium"));
            Assert.That(PageBrowser, Shows.Css("ul > li > a > span", $"BDD"));
        }

        [Test]
        public void Test_WaitMechanism()
        {
            BrowserLogin("/demosite/Login.html", "admin", "password", "Login");

        }


    }
}
