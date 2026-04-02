using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerDetails : System.Web.UI.Page
{
    
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rdr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                cmd = new SqlCommand();
                con = new SqlConnection();
                con = Connection.GetConnection();
                cmd.Connection = con;
              
                Display();
                Fetch();
                Disable();
                lblCust.Text = " ";
                //btnSave_Click.Enabled = false;
                //btnUpdate_Click.Enabled = false;

            }
            catch (Exception ex)
            {
                lblCust.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

    }

    //method to enable fields Enabled()
    #region
    public void Enabled()
    {
        txtCustName.Enabled = true;
        txtAddress.Enabled = true;
        txtMob.Enabled = true;
       
    }
    #endregion


    //fetch method For fetching Customers's ID
    #region
    public void Fetch()
    {
      
        con = new SqlConnection();
        con = Connection.GetConnection();
       
        cmd = new SqlCommand("Select custId From Customer ORDER BY custId", con);
        rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            CustIdDrop.Items.Add(rdr["custId"].ToString());
        }
        rdr.Close();
    }
    #endregion

    //Display method for Displaying bydefaultly 1st Customer Details
    #region
    public void Display()
    {
        CustIdDrop.Items.Clear();
        cmd = new SqlCommand();
        con = new SqlConnection();
        con = Connection.GetConnection();
        cmd.Connection = con;

        cmd = new SqlCommand("Select * From Customer Where custId=1", con);
        rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {

            txtMob.Text = rdr["mobileNo"].ToString();
            txtCustName.Text = rdr["custName"].ToString();
            txtAddress.Text = rdr["custAddress"].ToString();
        }
    }
    #endregion
    //Method to disable fields
    #region
    public void Disable()
    {
        txtCustName.Enabled = false;
        txtAddress.Enabled = false;
        txtMob.Enabled = false;
    }
    #endregion
    //Clear method clearing fields
    #region
    public void Clear()
    {
        txtAddress.Text = " ";
        txtCustName.Text = " ";
        txtMob.Text = " ";
        lblCust.Text = " ";
    }
    #endregion
    //Add Button clears fields and enables fields to add New Data
    #region
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
            Enabled();
            
        }
        catch (Exception ex)
        {
            lblCust.Text = ex.Message;
        }

    }
    #endregion
    //DropDown List 
    #region
    protected void CustIdDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand();
            con = new SqlConnection();
            con = Connection.GetConnection();
            cmd.Connection = con;
            int custId = Convert.ToInt32(CustIdDrop.SelectedValue);

            cmd.CommandText = string.Format("Select * from Customer where custId=@id");
            cmd.Parameters.AddWithValue("@id", custId);

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                txtCustName.Text = rdr["custName"].ToString();
                txtMob.Text = rdr["mobileNo"].ToString();
                txtAddress.Text = rdr["custAddress"].ToString();
            }
            lblCust.Text = " ";


        }
        catch (Exception ex)
        {
            lblCust.Text = ex.Message;
        }
    }
    #endregion
    //Save button  for inserting new customer inside Customer table
    #region
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand();
            con = new SqlConnection();
            con = Connection.GetConnection();
            cmd.Connection = con;
            string name = txtCustName.Text;
            string address = txtAddress.Text;
            string no = txtMob.Text;
            if (name!= " " && address!= " " && no!=" ")
            {
                cmd.CommandText = "Insert Into Customer(custName,custAddress,mobileNo) Values(@name,@address,@no)";


                // Add parameters
                cmd.Parameters.AddWithValue("@name", txtCustName.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@no", txtMob.Text);

                cmd.CommandType = CommandType.Text;

                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    lblCust.Text = "Customer Added Successfully!!";
                }
                else
                {
                    lblCust.Text = "ERROR";
                }

                // Clear fields
                Display();
                Fetch();
                Disable();
            }
            else
            {
                lblCust.Text = "Invalid Details!!<br/>Name, Mobile Number or Address should not be Blank!!";
            }
        }

        catch (Exception ex)
        {
           lblCust.Text= ex.Message;
        }
    }
    #endregion
    //Updating existing Product details
    #region
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //Connection
            cmd = new SqlCommand();
            con = new SqlConnection();
            con = Connection.GetConnection();
            cmd.Connection = con;
            //Reading inputs 
            int id = Convert.ToInt32(CustIdDrop.SelectedValue);
            string name = txtCustName.Text;
            string no = txtMob.Text;
            string address = txtAddress.Text;
            //Validating
            if (name != " " && no != " " && address != " ") { 
            //updating customer details 
            cmd.CommandText = String.Format("Update Customer set custName=@name,custAddress=@address,mobileNo=@no Where custId=@id");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@no", no);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@id", id);
            //return no of rows afftected 
            int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    lblCust.Text = "Customer Details Updated SuccessFully!!";

                    Display();
                    Fetch();
                    Disable();
                }
            else
            {
                lblCust.Text = "Error While Updating!";
            }

            }
            else
            {
                lblCust.Text = "Invalid Details!!<br/>Name, Mobile Number or Address should not be Blank!!";
            }
            
        }
        catch (Exception ex)
        {
            lblCust.Text = ex.Message;
        }
    }

    #endregion


    //Edit Button to enable fields to edit Customers
    #region
    protected void btnEdit_Click(object sender, EventArgs e)
    {

        try
        {
            Enabled();
           
        }
        catch (Exception ex)
        {
            lblCust.Text = ex.Message;

        }
    }
    #endregion
}