using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
//   {
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        String text = (Guid.NewGuid().ToString()).Substring(0, 5);
//        Response.Cookies["Captcha"]["value"] = text;
//        imagecaptcha.ImageUrl = "Captcha.aspx";
//    }
    
    
//    string hashBox = GetMD5(TextBox3.Text);
//        try
//        {
//            Guid newGUID = Guid.NewGuid();
           
//            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
//            conn.Open();
//            string insertQuery = "insert into UserData (Id, UserName, Email, Password) values (@Id, @Uname, @email, @password)";
//            SqlCommand com = new SqlCommand(insertQuery, conn);
//            com.Parameters.AddWithValue("@Id", newGUID.ToString());
//            com.Parameters.AddWithValue("@Uname", TextBoxUN.Text);
//            com.Parameters.AddWithValue("@email", TextBox2.Text);
//            com.Parameters.AddWithValue("@password", hashBox);
//            com.ExecuteNonQuery();
//            Response.Redirect("Manager.aspx");
//            Response.Write("Registration  is Successful");
//            conn.Close();
            
//        }
//        catch(Exception ex)
//        {
//            Response.Write("Error:" + ex.ToString());
//        }
//}

//{
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        String text = (Guid.NewGuid().ToString()).Substring(0, 5);
//        Response.Cookies["Captcha"]["value"] = text;
//        imagecaptcha.ImageUrl = "Captcha.aspx";
//    }
//    protected void Button1_Click(object sender, EventArgs e)
//    {
//        if (IsPostBack)
//        {
//            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
//            conn.Open();
//            string checkuser = "select count(*) from UserData where UserName='" + TextBoxUserN.Text + "'";
//            SqlCommand com = new SqlCommand(checkuser, conn);
//            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
//            conn.Close();
//            if (temp == 1)
//            {
//                conn.Open();
//                string checkPasswordQuery = "Select password from UserData where UserName='" + TextBoxUserN.Text + "'";
//                SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
//                string password = passComm.ExecuteScalar().ToString().Replace(" ", "");
//                if (password == GetMD5(TextBoxPW.Text))
//                {
//                    Session["New"] = TextBoxUserN.Text;
//                    Response.Write("Password is correct");
                    
//                }
//                else
//                {
//                    Response.Write("Incorret Password");
//                }
//            }
//            conn.Close();
//        }
//        if (txtcaptcha.Text.ToString() == Request.Cookies["Captcha"]["value"])
//        {
//            Response.Redirect("User.aspx");
//        }
//    }

//    protected void LBcaptcha_Click(object sender, EventArgs e)
//    {
//        Response.Cookies["Captcha"]["value"] = (Guid.NewGuid().ToString()).Substring(0, 5);
//        imagecaptcha.ImageUrl = "Captcha.aspx";
//    }

//    public string GetMD5(string text)
//    {
//        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
//        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
//        byte[] result = md5.Hash;
//        StringBuilder str = new StringBuilder();
//        for (int i = 1; i < result.Length; i++)
//        {
//            str.Append(result[i].ToString("x2"));
//        }
//        return str.ToString();

//    }
//}