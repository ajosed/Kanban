using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Ext.Net;

namespace Kanban_board_project.html
{
    public partial class drawKanban : System.Web.UI.Page
    {
        List<Ext.Net.Panel> id = new List<Ext.Net.Panel>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Panel1.MinHeight = 600;
            try
            {


                string connectionString = ConfigurationManager.ConnectionStrings["Kanban"].ConnectionString;
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string query = "SELECT *  FROM [Kanbanboard].[dbo].[COLUMNA]where IDBOARD=" + Session["boardid"];
                //string query = "SELECT *  FROM [Kanbanboard].[dbo].[COLUMNA]where IDBOARD=2 order by POSICION";
                string query2 = "SELECT [NOMBRE] FROM [Kanbanboard].[dbo].[BOARDS] where IDBOARD=" + Session["boardid"];
                //string query2 = "SELECT [NOMBRE] FROM [Kanbanboard].[dbo].[BOARDS] where IDBOARD=2";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlCommand cmd2 = new SqlCommand(query2, conexion);
                string boardname = cmd2.ExecuteScalar().ToString();
                this.Panel1.Title = boardname;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                ad.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Literal ltr = new Literal();
                    //ltr.Text = "<ext:Panel ID=\"Panel" + (int)row["POSICION"] + "\"runat=\"server\" Title=\"archive\" BodyPadding=\"20\" Flex=\"1\" AutoScroll=\"True\" TitleAlign=\"Center\"></ext:Panel>";
                    Ext.Net.Panel p = new Ext.Net.Panel();
                    p.Title = row["NOMBRE"].ToString();
                    p.BodyPadding = 20;
                    p.Flex = 1;
                    p.AutoScroll = true;
                    p.Cls = "draggable";
                    p.TitleAlign = Ext.Net.TitleAlign.Center;
                    id.Add(p);
                    Ext.Net.Container p1 = new Ext.Net.Container();
                    p1.Flex = 1;
                    p1.Cls = "dropable";
                    p1.Layout = Ext.Net.LayoutType.Fit.ToString();
                    p1.Add(p);

                    this.Panel1.Items.Add(p1);

                }

                this.Panel1.DataBind();
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBoxShow(this, ex.StackTrace);
            }

        }

        private void MessageBoxShow(Page page, string message)
        {
            Literal ltr = new Literal();
            ltr.Text = @"<script type='text/javascript'> alert('" + message + "') </script>";
            page.Controls.Add(ltr);
        }
        public void add()
        {
            id[0].Add(new Ext.Net.Button("Hola"));
            id[1].Add(new Ext.Net.Button("Hola"));
            id[2].Add(new Ext.Net.Button("Hola"));
            id[2].Add(new Ext.Net.Button("Hola"));
        }

        void updatepositions()
        {
                string connectionString = ConfigurationManager.ConnectionStrings["Kanban"].ConnectionString;
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                string query = "SELECT *  FROM [Kanbanboard].[dbo].[COLUMNA]where IDBOARD=" + Session["boardid"];
                //string query = "SELECT *  FROM [Kanbanboard].[dbo].[COLUMNA]where IDBOARD=2 order by POSICION";
                string query2 = "delete [Kanbanboard].[dbo].[COLUMNA] where IDBOARD=" + Session["boardid"];
                //string query2 = "delete [Kanbanboard].[dbo].[COLUMNA] where IDBOARD=2 ";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlCommand cmd2 = new SqlCommand(query2, conexion);
                cmd2.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                ad.Fill(dt);
                int x=0;
                foreach (DataRow row in dt.Rows)
                {
                    foreach (Container region in Panel1.Items)
                    {
                        Ext.Net.Panel pan = (Ext.Net.Panel)region.Items[0];
                        row[buscar(dt,pan.Title)] = x;
                        x++;
                    }
                }
                SqlBulkCopy bc = new SqlBulkCopy(conexion);
                bc.DestinationTableName = "[Kanbanboard].[dbo].[COLUMNA]";
                DataRow[] row1 = new DataRow[dt.Rows.Count];
                x = 0;
                foreach (DataRow row in dt.Rows)
                {
                    row1[x] = row;
                    x++;
                }

                bc.WriteToServer(row1);

                conexion.Close();
        }
        public int buscar(DataTable dt, string s)
        {
            int x = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["NOMBRE"].Equals(s))
                {
                    return x;
                }
                else
                {
                    x++;
                }
            }
            return -1;
        }
    }
}