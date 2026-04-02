using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerReport : System.Web.UI.Page
{
    Connection connect = new Connection();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rdr;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!Page.IsPostBack)
            {
              
                con = new SqlConnection();
                con = Connection.GetConnection();
                cmd = new SqlCommand("Select * From Customer", con);
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                rdr.Close();
                gridCustomer.DataSource = dt;
                gridCustomer.DataBind();
            }
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}