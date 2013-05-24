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
    public partial class Crearboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

/*
            string connectionString = ConfigurationManager.ConnectionStrings["Kanban"].ConnectionString;
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            string query = "insert into [Kanbanboard].[dbo].[BOARDS] (NOMBRE,FECHAINICIO,COLUMNAS) values(@nombre,@fecha,@columna)";
            string query2 = "select count(*) from [Kanbanboard].[dbo].[BOARDS]";
            string query3 = "select IDUSUARIO from [Kanbanboard].[dbo].[USUARIOS] where USUARIO LIKE '" + Session["user"] + "'";
            string query4 = "insert into [Kanbanboard].[dbo].[USUARIOSxBOARD] ([IDUSUARIO],[IDBOARD],[ROLE]) values(@IDUSUARIO,@IDBOARD,@ROLE)";
            string query6 = "select NOMBRE from [Kanbanboard].[dbo].[BOARDS] where NOMBRE like '" + this.txtnombre.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlCommand cmd2 = new SqlCommand(query2, conexion);
            SqlCommand cmd3 = new SqlCommand(query3, conexion);
            SqlCommand cmd4 = new SqlCommand(query4, conexion);
            SqlCommand cmd6 = new SqlCommand(query6, conexion);
            Object enuso = cmd6.ExecuteScalar();
            if (enuso != null)
            {
                MessageBoxShow(this, "ese board ya existe!");
            }
            else
            {
                cmd.Parameters.AddWithValue("@nombre", this.txtnombre.Text);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year);
                cmd.Parameters.AddWithValue("@columna", 4);
                cmd.ExecuteNonQuery();
                int idboard = (int)cmd2.ExecuteScalar();
                int idusuario = (int)cmd3.ExecuteScalar();

                cmd4.Parameters.AddWithValue("@IDUSUARIO", idusuario);
                cmd4.Parameters.AddWithValue("@IDBOARD", idboard);
                cmd4.Parameters.AddWithValue("@ROLE", 2);
                cmd4.ExecuteNonQuery();

                string[] names = { "Ready", "In Progress", "Testing", "Done" };
                string query5 = "";
                for (int x = 0; x < 4; x++)
                {
                    query5 += "insert into [Kanbanboard].[dbo].[Columna] ([IDBOARD],[POSICION],[NOMBRE],[WHIPLIMITE]) values(" + idboard + "," + x + ",'" + names[x] + "'," + 0 + ")";
                }

                SqlCommand cmd5 = new SqlCommand(query5, conexion);
                cmd5.ExecuteNonQuery();


                conexion.Close();
                
               Context.Response.Redirect("~/html/usuarioXboard.aspx?idb="+idboard);
            }*/
                Session["boardid"]=1;
            }
            catch (Exception ex)
            {
                MessageBoxShow(this,ex.StackTrace);
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