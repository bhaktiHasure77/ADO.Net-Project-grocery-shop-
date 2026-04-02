using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayRollLib;
/// <summary>
/// This Web Forms page demonstrates the use of Delegates
/// and Callback Methods in a Payroll system.
/// Functionality:
/// 1. Displays employee details before salary increment
/// 2. Uses delegate to process each employee
/// 3. Applies salary increment using callback method
/// 4. Displays updated salary results
/// </summary>

public partial class PayRoll : System.Web.UI.Page
{
    // Array of employees

    EmployeeDel[] emp = new EmployeeDel[]
    {
            new EmployeeDel("Ancy","Martin",7000),
            new EmployeeDel("Jessy","Paniker",7000),
             new EmployeeDel("Jijo","Vargise",9000)

    };
    // Department object 

    Department d = new Department("IP");

    protected void Page_Load(object sender, EventArgs e)
    {



    }

    protected void btnDisplay_Click(object sender, EventArgs e)
    {

        try
        {
            //displaying details before increment
            foreach(var a in emp)
            {
                lblEmp.Text += a.Name + " " + a.LName + " with payroll of " + a.Salary+"<br/>";
            }
            DelegateUsingCallBackMethod m = new DelegateUsingCallBackMethod();
            // Create delegate instance and assign method
            MyDel del = new MyDel(m.UpdatePayRoll);
            // This will call UpdatePayRoll() for each employee
            m.ProcessEmployee(emp,del);
            lblRes.Text += m.res;

        }catch(Exception ex)
        {
            lblRes.Text = ex.Message;
        }
    }
}