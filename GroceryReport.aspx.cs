using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GroceryReport : System.Web.UI.Page
{

    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rdr;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            try
            {
                con = new SqlConnection();
                con = Connection.GetConnection();
               
                cmd = new SqlCommand("Select * From Billing", con);
                rdr = cmd.ExecuteReader();

                dt.Load(rdr);
                rdr.Close();
                gridGrocery.DataSource = dt;
                gridGrocery.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }
    }
}