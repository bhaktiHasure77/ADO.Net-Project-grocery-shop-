using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Login Page Of Sam's Grocery Shop system
/// checking the Credentials
/// </summary>
/// 
public partial class Assignment5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblLogin.Text = " ";
    }
    #region
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            //Taking username and password from user to Login to the system
        
            string user = txtUser.Text;
            string pw = txtPW.Text;
            //checking the Credentials if matches the same then take user to home page
            if(user=="admin" && pw== "admin@1234#$!")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {//if credentials doesnt matches 
                lblLogin.Text = "Invalid Credentials!!<br/> Check Username or Password and Try Again.";
            }
        }
        catch(Exception ex)
        {
            //if any exception 
            lblLogin.Text = ex.Message;
        }
    }
    #endregion
}