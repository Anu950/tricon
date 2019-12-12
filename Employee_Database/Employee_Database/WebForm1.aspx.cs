using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//namespace Employee_Database
//{
//    public partial class WebForm1 : System.Web.UI.Page
//    {
//        [3:59 PM]
//        Srinidhi A

//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Configuration;



namespace Employee_Database
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_data();
            }
        }


        public void load_data()
        {
            SqlConnection con = new SqlConnection(@"Data Source=TRICONNODEWS042\SQLEXPRESS;Initial Catalog=Northwind;User ID=sa;Password=Sep@2016");


            SqlCommand cmd = new SqlCommand("select * from Anuradha", con);
            SqlDataAdapter sdl = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            sdl.Fill(ds1);




            DropDownList1.DataSource = ds1;

            DropDownList1.DataValueField = "ID";
            DropDownList1.DataValueField = "Name";

            DropDownList1.DataBind();
        }


        protected void abc(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=TRICONNODEWS042\SQLEXPRESS;Initial Catalog=Northwind;User ID=sa;Password=Sep@2016");

            string query = "select * from Anuradha where Name = '"+ DropDownList1.SelectedItem.Value+"'";


            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        public enum Type
        {
            Store=1,
            Text=2
        }
        public DataSet Test(string command, SqlParameter[] sqlParams,Type type)
        {
            var connStr = ConfigurationManager.AppSettings["conn"];
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(command, con);
                if (type == Type.Store)
                    cmd.CommandType = CommandType.StoredProcedure;
                else if (type == Type.Text)
                    cmd.CommandType = CommandType.Text;
                if (sqlParams != null && sqlParams.Length > 0)
                {
                    foreach(var item in sqlParams)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                return ds;
            }
        }
        protected DataSet Meth(String q)
        {
            var connStr = ConfigurationManager.AppSettings["conn"];
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                return ds;
            }

        }
        public void on_Add(object sender, EventArgs e)
        {
            try
            {
                string insert = "insert into Anuradha (Name,Id,Address,Salary) values ('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "'," + TextBox4.Text + ")";
                DataSet dd = Meth(insert);
                GridView1.DataSource = dd;
                GridView1.DataBind();
            }
            catch(Exception ex)
            {

            }


        }

    }
}










