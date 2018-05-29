using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoypuTest.Util;
using static MyCoypuTest.Util.TestPage;

namespace MyCoypuTest.Page.UserFormPage
{
    public class UserForm
    {
        public static void FillUserForm()
        {
            //Drop Down Select
            PageBrowser.Select("Mr.").From("TitleId");
            //Text Box
            PageBrowser.FillIn("Initial").With("KK");
            PageBrowser.FillIn("FirstName").With("admin");
            PageBrowser.FillIn("MiddleName").With("adminMiddle");
            //Radio Button
            PageBrowser.Choose("female");
            //Check Box
            PageBrowser.Check("hindi");
            //Button Click
            PageBrowser.ClickButton("Save");

        }

        public static void TestPopUp()
        {
            PageBrowser.ClickLink("HtmlPopup");
            var popup = PageBrowser.FindWindow("Popup Window");
            popup.Select("Mr.").From("TitleId");
            popup.FillIn("Initial").With("KK");
            //Close
            popup.ExecuteScript("self.close();");

            //Fall back to parent window
            PageBrowser.FindWindow("Execute Automation");
            //Initial
            PageBrowser.FillIn("Initial").With("KK");
            // First Name
            PageBrowser.FillIn("FirstName").With("admin");


        }
    }
}
