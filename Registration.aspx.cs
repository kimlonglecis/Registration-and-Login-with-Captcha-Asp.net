using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            //Check if username is taken.  Not working
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            //conn.Open();
            //String checkUser = "Select count(*) from Userdata where Username='" + TextBo + "'";
            //SqlCommand com = new SqlCommand(checkUser, conn);
            //int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            //if (temp == 1)
            //{
            //    Response.Write("User already exists, please try a different username");
            //}
            //conn.Close();
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Guid newGUID = Guid.NewGuid();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
        conn.Open();
        string insertQuery = "insert into Userdata (Id, Username, Email, Password, Country) values (@id, @username, @email, @password, @country)";
        
        //Check if username is taken.  Not working
        //SqlCommand cmd = new SqlCommand();
        //cmd.CommandText = "select * from Userdata where Username=@uname";
        //cmd.Parameters.AddWithValue("@uname", TextBoxuserName.Text);
        //cmd.Connection = conn;
        //SqlDataReader rd = cmd.ExecuteReader();
        //if(rd.HasRows)
        //{
        //    Label1.Visible = true;
        //    Label1.Text = "username already avaiable";
        //    Label1.ForeColor = System.Drawing.Color.Red;
        //}
        //else
        //{
        //    Label1.Visible = true;
        //    Label1.Text = "username not already avaiable";
        //    Label1.ForeColor = System.Drawing.Color.Green; 
        //}
        
        SqlCommand com = new SqlCommand(insertQuery, conn);
        com.Parameters.AddWithValue("@id", newGUID.ToString());
        com.Parameters.AddWithValue("@username", Encrypt(TextBoxuserName.Text));
        com.Parameters.AddWithValue("@email", TextBoxeMail.Text);
        com.Parameters.AddWithValue("@password", Encrypt(TextBoxpassword.Text));
        com.Parameters.AddWithValue("@country", DropDownListcountry.SelectedValue.ToString());

        com.ExecuteNonQuery();
        Response.Redirect("table.aspx");

        conn.Close();
         
    

    }
    protected void TextBoxuserName_TextChanged(object sender, EventArgs e)
    {

    }


    //Encrypt Function
    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }


    //Decrypt Function
    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
}