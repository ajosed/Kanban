using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Kanban_board_project.html
{
    /// <summary>
    /// Descripción breve de Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Kanban"].ConnectionString;
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string query = "select PICTURE from USUARIOS where IDUSUARIO='"+context.Request.Params["id"]+"'";
                SqlCommand cmd = new SqlCommand(query, conexion);

                Byte[] imagen = (Byte[])cmd.ExecuteScalar();

                context.Response.ContentType = "png";
                context.Response.OutputStream.Write(imagen, 0, imagen.Length);
                conexion.Close();
            }
            catch (Exception ex)
            {
                context.Response.Output.WriteLine(ex.Message);
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}