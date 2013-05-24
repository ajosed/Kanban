using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Kanban_board_project.html
{
    public partial class usuarioXboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Kanban"].ConnectionString;
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string query = "insert into [Kanbanboard].[dbo].[USUARIOSxBOARD] ([IDUSUARIO],[IDBOARD],[ROLE]) values(@IDUSUARIO,@IDBOARD,@ROLE)";
                 SqlCommand cmd = new SqlCommand(query, conexion);

                 string query3 = "select IDUSUARIO from [Kanbanboard].[dbo].[USUARIOS] where correo like '" + this.txtnombre.Text + "' or usuariolike '" + this.txtnombre.Text + "'";
                SqlCommand cmd3 = new SqlCommand(query3, conexion);
                int idusuario = (int)cmd3.ExecuteScalar();

                cmd.Parameters.AddWithValue("@IDUSUARIO", idusuario);
                cmd.Parameters.AddWithValue("@IDBOARD", Session["boardid"]);
                cmd.Parameters.AddWithValue("@ROLE", 1);
                cmd.ExecuteNonQuery();
                conexion.Close();
                this.txtnombre.Text =" ";
                this.ListView1.DataBind();
            }
            catch (Exception ex)
            {
                
                MessageBoxShow(this,"usuario no registrado.");
            }
        }

        private void MessageBoxShow(Page page, string message)
        {
            Literal ltr = new Literal();
            ltr.Text = @"<script type='text/javascript'> alert('" + message + "') </script>";
            page.Controls.Add(ltr);
        }
    }
}