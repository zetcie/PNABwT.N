using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Library.student
{
    public partial class my_issued_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        string penalty = "0";
        double noofdays = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (Session["student"] == null)
            {
                Response.Redirect("student_login.aspx");
            }

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from penalty";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                penalty = dr2["penalty"].ToString();
            }


            DataTable dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("student_index");
            dt1.Columns.Add("books_isbn");
            dt1.Columns.Add("books_issue_date");
            dt1.Columns.Add("books_aprox_return_date");
            dt1.Columns.Add("student_username");
            dt1.Columns.Add("is_books_return");
            dt1.Columns.Add("books_returned_date");
            dt1.Columns.Add("lateday");
            dt1.Columns.Add("penalty");

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books where student_username='"+ Session["student"].ToString()+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                DataRow dr1 = dt1.NewRow();
                dr1["student_index"] = dr["student_index"].ToString();
                dr1["books_isbn"] = dr["books_isbn"].ToString();
                dr1["books_issue_date"] = dr["books_issue_date"].ToString();
                dr1["books_aprox_return_date"] = dr["books_aprox_return_date"].ToString();
                dr1["student_username"] = dr["student_username"].ToString();
                dr1["is_books_return"] = dr["is_books_return"].ToString();
                dr1["books_returned_date"] = dr["books_returned_date"].ToString();

                DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                DateTime d2 = Convert.ToDateTime(dr["books_aprox_return_date"].ToString());

                if (d1 > d2)
                {
                    TimeSpan t = d1 - d2;
                    noofdays = t.TotalDays;
                    dr1["lateday"] = noofdays.ToString();
                }
                else
                {
                    dr1["lateday"] = "0";
                }
                dr1["penalty"] = Convert.ToString(Convert.ToDouble(noofdays) * Convert.ToDouble(penalty));

                dt1.Rows.Add(dr1);
            }
            d1.DataSource = dt1;
            d1.DataBind();
        }
    }
}