using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillingReport : System.Web.UI.Page
{
   
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rdr;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            try
            {
                con = Connection.GetConnection();
                cmd = new SqlCommand("Select * From Billing", con);
                rdr = cmd.ExecuteReader();

                dt.Load(rdr);
                rdr.Close();
                gridBilling.DataSource = dt;
                gridBilling.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }
    }
}