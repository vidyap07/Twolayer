using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Twolayer
{
    public partial class UserProfile : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select Name,Age,Address,Photo from Twolayer where Id='" + Session["userid"] + "'";
            SqlDataReader dr = obj.Fn_Reader(sel);
            while(dr.Read())
            {
                Label1.Text = dr["Name"].ToString();
                Label2.Text = dr["Age"].ToString();
                Label3.Text = dr["Address"].ToString();
                Image1.ImageUrl = dr["Photo"].ToString();
            }

            DataSet ds = obj.Fn_DataSet(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            //DataList using DataTable
            DataTable dt = obj.Fn_DataTable(sel);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
}