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
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

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


            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblProduc", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();
            }


        }
    }
}