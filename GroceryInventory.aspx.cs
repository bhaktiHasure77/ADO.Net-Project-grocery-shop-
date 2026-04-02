using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GroceryInventory : System.Web.UI.Page
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

            }catch(Exception ex)
            {
                lblInv.Text = ex.Message;
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
        txtPName.Enabled = true;
        txtProdPrice.Enabled = true;
        txtQnty.Enabled = true;
    }
    #endregion

    //Method to disable fields
    #region
    public void Disable()
    {
        txtPName.Enabled = false;
        txtProdPrice.Enabled = false;
        txtQnty.Enabled = false;
    }
    #endregion
    //fetch method For fetching ProductID's
    #region
    public void Fetch()
    {
       
        con = new SqlConnection();
        con = Connection.GetConnection();
        cmd = new SqlCommand("Select prodId From Product", con);
        rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
            ProductIDdrop.Items.Add(rdr["prodId"].ToString());
        }
        rdr.Close();
    }
    #endregion
    //Display method for Displaying bydefaultly 1st product Details
    #region
    public void Display()
    {
        ProductIDdrop.Items.Clear();
        
        con = new SqlConnection();
        con = Connection.GetConnection();
        
        cmd = new SqlCommand("Select * From Product Where prodId=1",con);
        rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
          //  ProductIDdrop.Items.Add(rdr["prodId"].ToString());
            txtPName.Text = rdr["prodName"].ToString();
            txtProdPrice.Text = rdr["price"].ToString();
            txtQnty.Text = rdr["qnty"].ToString();
        }
    }
    #endregion
    //Clear method clearing fields
    #region
    public void Clear()
    {
        txtPName.Text = " ";
        txtProdPrice.Text = " ";
        txtQnty.Text = " ";
        lblInv.Text = " ";
    }
    #endregion

    //DropDown List 
    #region
    protected void ProductIDdrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand();
            con = new SqlConnection();
            con = Connection.GetConnection();
            cmd.Connection = con;
            int prodId = Convert.ToInt32(ProductIDdrop.SelectedValue);

            cmd.CommandText = string.Format("Select * from Product where prodId=@id");
            cmd.Parameters.AddWithValue("@id", prodId);

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                txtPName.Text = rdr["prodName"].ToString();
                txtProdPrice.Text = rdr["price"].ToString();
                txtQnty.Text = rdr["qnty"].ToString();
            }
            lblInv.Text = " ";

        }
        catch (Exception ex)
        {
            lblInv.Text = ex.Message;
        }
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
            lblInv.Text = ex.Message;
        }
    }
    #endregion

    //Save button  for inserting new data inside Inventory
    #region
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand();
            con = new SqlConnection();
            con = Connection.GetConnection();
            cmd.Connection = con;
            string name = txtPName.Text;
            int price = Convert.ToInt32(txtProdPrice.Text);
            int qty= Convert.ToInt32(txtQnty.Text);
            if (name != " " )
            {

                if (price > 0 && qty > 0)
                {
                    cmd.CommandText = String.Format("Insert Into Product(prodName,price,qnty) values (@name,@price,@qty)");
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        lblInv.Text = "Product Details Added SuccessFully!!";
                    }
                    else
                    {
                        lblInv.Text = "Error While Adding!";
                    }

                }
                else
                {
                    lblInv.Text = "Price or Quantity inserterd is negative or zero !!";
                }

                Display();
                Fetch();
                Disable();
            }
            else
            {
                lblInv.Text = "Invalid Details!!<br/>Product Name shouldn't be blank!!";
            }
        }
        catch(Exception ex)
        {
            lblInv.Text = ex.Message;
        }
    }
    #endregion

    //Edit Button to enable fields to edit products
    #region
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Enabled();


        }
        catch(Exception ex)
        {
            lblInv.Text = ex.Message;
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
            int id = Convert.ToInt32(ProductIDdrop.SelectedValue);
            string name = txtPName.Text;
            int price = Convert.ToInt32(txtProdPrice.Text);
            int qty = Convert.ToInt32(txtQnty.Text);
            //Checking if price And qnty are negative or zero if not then update Product details
            if (price > 0 && qty > 0)
            {
                cmd.CommandText = String.Format("Update Product set prodName=@name,price=@price,qnty=@qty Where prodId=@id");
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@id", id);
                //return no of rows afftected 
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    lblInv.Text = "Product Details Updated SuccessFully!!";
                }
                else
                {
                    lblInv.Text = "Error While Updating!";
                }
            }
            else
            {
                lblInv.Text = "Price or Quantity inserterd is negative or zero !!";
            }
            
            Display();
            Fetch();
            Disable();
        }
        catch (Exception ex)
        {
            lblInv.Text = ex.Message;
        }

    }
    #endregion

    //Removing Product Based On Its product ID
    #region
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand();
            con = new SqlConnection();
            con = Connection.GetConnection();
            cmd.Connection = con;
            int id = Convert.ToInt32(ProductIDdrop.SelectedValue);
            
          
                cmd.CommandText = String.Format("Delete from Product Where prodId=@id");
                
                cmd.Parameters.AddWithValue("@id", id);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    lblInv.Text = "Product Details Removed SuccessFully!!";
                }
                else
                {
                    lblInv.Text = "Error While Removing!";
                }
            
          
            Display();
            Fetch();
            Disable();
        
        }catch(Exception ex)
        {
            lblInv.Text = ex.Message;
        }
    }
    #endregion

}