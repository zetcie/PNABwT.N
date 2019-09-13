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
    public partial class add_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (Session["librarian"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string books_image_name;
            string books_pdf_name;
            string path = "";
            string path2 = "";

            if (f1.FileName.ToString() != "")
            {
                books_image_name = Class1.GetRandomPassword(10) + ".jpg";
                f1.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_images/" + books_image_name.ToString());
                path = "books_images/" + books_image_name.ToString();
            }
            if (f2.FileName.ToString() != "")
            {
                books_pdf_name = Class1.GetRandomPassword(10) + ".pdf";
                f2.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_pdf/" + books_pdf_name.ToString());
                path2 = "books_pdf/" + books_pdf_name.ToString();
            }
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books values('"+bookstitle.Text+"','"+path.ToString()+"','" + path2.ToString() + "','" + authorname.Text+"','"+isbn.Text+"','"+qty.Text+"')";
            cmd.ExecuteNonQuery();
            msg.Style.Add("display", "block");
        }
    }
}