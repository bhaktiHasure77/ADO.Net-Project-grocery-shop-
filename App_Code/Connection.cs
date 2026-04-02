using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;


public class Connection
{
   
    public Connection()
    {
       
    }
    public static SqlConnection GetConnection()
    {
        try
        {
            string strCon = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            return con;
        }catch(Exception ex)
        {
           throw new Exception(ex.Message);
        }
    }
}