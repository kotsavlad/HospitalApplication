using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OkButton_Click(object sender, EventArgs e)
        {
            var isValidUser = false;
            var userName = UserTextBox.Text.Trim();
            var userPassword = PasswordTextBox.Text.Trim();
            foreach (var user in DataProvider.Users)
            {
                if(user.Key == userName && user.Value == userPassword)
                {
                    isValidUser = true;
                    break;
                }
            }
            if (isValidUser)
                Response.Redirect("MainPage.aspx");
            else
                Response.Write(@"<script>alert('Invalid username or password!\Try again')</script>");
        }
    }
}