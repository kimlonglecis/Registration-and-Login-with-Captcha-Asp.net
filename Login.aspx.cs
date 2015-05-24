using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            String checkUser = "Select count(*) from Userdata where Username='" + TextBoxloginUserName.Text + "'";
            SqlCommand com = new SqlCommand(checkUser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                string checkPasswordQuery = "Select Password from Userdata where Username='" + TextBoxloginUserName.Text + "'";
                SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
                string password = passComm.ExecuteScalar().ToString().Replace(" ", "");
                if (password == TextBoxloginPassword.Text)
                {
                    Session["New"] = TextBoxloginUserName.Text;
                    Response.Redirect("table.aspx");
                }
                else
                {
                    Response.Write("wrong password");
                }
            }
            else
            {
                Response.Write("wrong username");

            }
            conn.Close();
        }
        else
        {
            //showing label of regular captcha
            Label1.Text = "Please enter corrected capcha";

            //Showing label of im not a robot captcha.  Not working
            //Labelcaptcha.Text = "Please enter corrected capcha";
        }


    }

    protected void RecapchaValidator_ServerValidate(Object sender, ServerValidateEventArgs e)
    {
        e.IsValid = this.recaptcha.IsValid;
    }
}