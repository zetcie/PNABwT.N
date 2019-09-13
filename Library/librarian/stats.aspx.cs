using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Library.librarian
{
    public partial class stats : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        string x = "";
        string d = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

           /* if (Session["librarian"] == null)
            {
                Response.Redirect("login.aspx");
            }*/
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            if (startdate.Text == "" && stopdate.Text == "")
            {
                x = "1900-01-01";
                d = DateTime.Now.ToString("yyyy-MM-dd");

                DataTable dt1 = new DataTable();
                dt1.Clear();
                dt1.Columns.Add("books_title");
                dt1.Columns.Add("books_author_name");
                dt1.Columns.Add("books_isbn");
                dt1.Columns.Add("books_issues_no");

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select b.books_title, b.books_author_name, i.books_isbn, count(i.books_isbn) as ile from issue_books AS i join books AS b on i.books_isbn=b.books_isbn where i.books_issue_date BETWEEN '" + x + "' AND '" + d + "' group by i.books_isbn, b.books_title, b.books_author_name";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow dr1 = dt1.NewRow();
                    dr1["books_title"] = dr["books_title"].ToString();
                    dr1["books_author_name"] = dr["books_author_name"].ToString();
                    dr1["books_isbn"] = dr["books_isbn"].ToString();
                    dr1["books_issues_no"] = dr["ile"].ToString();

                    dt1.Rows.Add(dr1);
                }
                d1.DataSource = dt1;
                d1.DataBind();
            }
            else
            {
                x = startdate.Text;
                d = stopdate.Text;

                DataTable dt1 = new DataTable();
                dt1.Clear();
                dt1.Columns.Add("books_title");
                dt1.Columns.Add("books_author_name");
                dt1.Columns.Add("books_isbn");
                dt1.Columns.Add("books_issues_no");

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select b.books_title, b.books_author_name, i.books_isbn, count(i.books_isbn) as ile from issue_books AS i join books AS b on i.books_isbn=b.books_isbn where i.books_issue_date BETWEEN '" + x + "' AND '" + d + "' group by i.books_isbn, b.books_title, b.books_author_name";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow dr1 = dt1.NewRow();
                    dr1["books_title"] = dr["books_title"].ToString();
                    dr1["books_author_name"] = dr["books_author_name"].ToString();
                    dr1["books_isbn"] = dr["books_isbn"].ToString();
                    dr1["books_issues_no"] = dr["ile"].ToString();

                    dt1.Rows.Add(dr1);
                }
                d1.DataSource = dt1;
                d1.DataBind();
            }
        }
    }
}