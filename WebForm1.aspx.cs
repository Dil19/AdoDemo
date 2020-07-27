using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Odbc;

namespace AdoDemo001
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            /* SqlConnection con = new SqlConnection(CS);
             try
             {
                 SqlCommand cmd = new SqlCommand("Select * from tblProduct", con);
                 con.Open();
                 SqlDataReader rdr = cmd.ExecuteReader();
                 GridView1.DataSource = rdr;
                 GridView1.DataBind();
             }
             catch
             {

             }
             finally
             {
                 con.Close();
             }*/


            /*using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblProduc", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();

                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "Select Count(ProductId) from tblProduc";
                cmd2.Connection = con;
                con.Open();
                int TotalRows = (int)cmd2.ExecuteScalar();
                Response.Write("total rows = " + TotalRows.ToString() + "<br/>");

                cmd2.CommandText = "Insert into tblProduc values('4', 'calculator', '100', '230'), ('5', 'todelete', '100', '230')";
                int TotalRowsInserted = cmd2.ExecuteNonQuery();
                Response.Write("total rows inserted = " + TotalRowsInserted.ToString() + "<br/>");


                cmd2.CommandText = "delete from tblProduc where ProductId in(4,5)";
                int TotalRowsDeleted = cmd2.ExecuteNonQuery();
                Response.Write("total rows deleted = " + TotalRowsDeleted.ToString() + "<br/>");
            }*/


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblProduc where Name like @ProductName", con);

                /*string Command = "Select * from tblProduc where Name like @Name";

                SqlCommand cmd = new SqlCommand(Command, con);*/
                cmd.Parameters.AddWithValue("@ProductName", TextBox1.Text + "%");
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();

                Response.Write("passed");


            }
        }
    }
}