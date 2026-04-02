using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Billing : System.Web.UI.Page
{

   
    SqlConnection con ;
    SqlCommand cmd;
    SqlDataReader rdr;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {      
        if (!Page.IsPostBack)
        {
            // Hide bill table initially
            bill.Visible = false;
            try
            {
                con = new SqlConnection();
                con = Connection.GetConnection();
                cmd = new SqlCommand();
                // Load customer names into dropdown
                cmd.CommandText = "Select CustName from Customer";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CustDrop.Items.Add(rdr[0].ToString());
                }
                rdr.Close();

                // Load product names into dropdown
                cmd.CommandText = "Select ProdName from Product";

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ProdDrop.Items.Add(rdr[0].ToString());
                }
               
            }
            catch (Exception ex)
            {
                // Display error
                lblBillRes.Text = ex.Message;
            }
            finally
            {
                rdr.Close();
                con.Close();
            }
        }
    }
    // Get Customer ID using customer name
    #region
    public int CustId(string name)
    {
        cmd.CommandText = "Select custId from Customer where custName=@custName";
        cmd.Parameters.AddWithValue("@custName", name);

        rdr = cmd.ExecuteReader();

        int custId = 0;

        while (rdr.Read())
        {
            custId = Convert.ToInt32(rdr["custId"]);
        }

        rdr.Close();
        return custId;
    }
    #endregion

    // Update product quantity after sale
    #region
    public void UpdateQnty(int qnty, int id)
    {
        
        cmd.CommandText = "Update Product set qnty=qnty-@qnty where prodId=@id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@qnty", qnty);

        cmd.ExecuteNonQuery();

        // Clear parameters to avoid reuse issues
        cmd.Parameters.Clear();
    }
    #endregion

    // Clear all UI fields
    #region
    public void Clear()
    {
        try
        {
            txtQty.Text = " ";
            lblTotal.Text = " ";
            lblBillNo.Text = " ";
            lblCustName.Text = " ";
            lblPricepp.Text = " ";
            lblProdName.Text = " ";
            lblBillRes.Text = " ";
            lblQty.Text = " ";
        }
        catch (Exception ex)
        {
            lblBillRes.Text = ex.Message;
        }
    }
    #endregion




    // Clear fields when product changes
    #region
    protected void CustDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        bill.Visible = false;
        Clear();

    }

    // Clear fields when customer changes
    protected void ProdDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        bill.Visible = false;
        Clear();
    }
    #endregion
    // Bill Generation Event
    #region
    protected void btnGenerateBill_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input
            string custName = CustDrop.SelectedValue.ToString();
            string prodName = ProdDrop.SelectedValue.ToString();
            int qnty = Convert.ToInt32(txtQty.Text);
            //datbase connection 
            cmd = new SqlCommand();
            con = new SqlConnection();
            con = Connection.GetConnection();
            cmd.Connection = con;

            // Validate quantity
            if (qnty > 0)
            {
                // Check available stock
                cmd.CommandText = "Select qnty From Product where prodName=@name";
                cmd.Parameters.AddWithValue("@name", prodName);

                rdr = cmd.ExecuteReader();

                int qty = 0;

                while (rdr.Read())
                {
                    qty = Convert.ToInt32(rdr["qnty"]);
                }

                rdr.Close();
                cmd.Parameters.Clear();

                // If stock is sufficient
                #region
                if (qty >= qnty)
                {
                    // Fetch price and product ID
                    cmd.CommandText = "Select price,prodId from Product where prodName=@name";
                    cmd.Parameters.AddWithValue("@name", prodName);

                    rdr = cmd.ExecuteReader();

                    int totalPrice = 0;
                    int price = 0;
                    int prodId = 0;

                    while (rdr.Read())
                    {
                        prodId = Convert.ToInt32(rdr["prodId"]);
                        price = Convert.ToInt32(rdr["price"]);
                        totalPrice = price * qnty;
                    }

                    rdr.Close();
                    cmd.Parameters.Clear();

                    // Update product stock
                    UpdateQnty(qnty, prodId);

                    // Get customer ID
                    int custId = CustId(custName);

                    // Insert bill into database
                    cmd.CommandText = "Insert Into Billing(custId,prodId,qty,totalBill) Values(@custid,@prodid,@qnty,@tBill)";
                    cmd.Parameters.AddWithValue("@custid", custId);
                    cmd.Parameters.AddWithValue("@prodid", prodId);
                    cmd.Parameters.AddWithValue("@qnty", qnty);
                    cmd.Parameters.AddWithValue("@tBill", totalPrice);

                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        // Fetch bill details
                        cmd = new SqlCommand("Select * From Billing", con);
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            lblBillNo.Text = rdr["billNo"].ToString();                          
                            lblQty.Text = rdr["qty"].ToString();
                            lblTotal.Text = rdr["totalBill"].ToString();
                        }

                        // Display bill details
                        lblCustName.Text = custName;
                        lblProdName.Text = prodName;
                        lblPricepp.Text = price.ToString();

                        // Show bill table
                        bill.Visible = true;
                    }
                    else
                    {
                        lblBillRes.Text = "Error While Generating Bill!!";
                    }
                    #endregion
                }
                else
                {
                    // Not enough stock
                    lblBillRes.Text = "Invalid Quantity!!<br/>Available Stock is " + qty;
                }
            }
            else
            {
                // Invalid quantity
                lblBillRes.Text = "Invalid Quantity ";
            }

            // Clear input fields
            txtQty.Text = " ";

        }
        catch (Exception ex)
        {
            lblBillRes.Text ="Invalid Quantity!! "+ex.Message;
        }
    }
    #endregion
}