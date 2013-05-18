﻿using System;
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
    public partial class Configuration : System.Web.UI.Page
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
                //string query = "SELECT *  FROM [Kanbanboard].[dbo].[COLUMNA]where IDBOARD=" + Session["boardid"];
                string query = "SELECT *  FROM [Kanbanboard].[dbo].[COLUMNA]where IDBOARD=1";
                //string query2 = "SELECT [NOMBRE] FROM [Kanbanboard].[dbo].[BOARDS] where IDBOARD=" + Session["boardid"];
                string query2 = "SELECT [NOMBRE] FROM [Kanbanboard].[dbo].[BOARDS] where IDBOARD=1";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlCommand cmd2 = new SqlCommand(query2, conexion);
                string boardname = cmd2.ExecuteScalar().ToString();
                this.Panel1.Title = boardname;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                ad.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Ext.Net.Panel p = new Ext.Net.Panel();
                    p.Title = row["NOMBRE"].ToString();
                    p.BodyPadding = 20;
                    p.Flex = 1;
                    p.AutoScroll = true;
                    p.TitleAlign = Ext.Net.TitleAlign.Center;
                    this.Panel1.Items.Add(p);
                    p.Add(new Ext.Net.Button(""){Listeners ={Click ={Handler="p.Text=\"holis\";"}}});
                                id.Add(p);
                            }
                this.Panel1.DataBind();
                configcontrols();
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

        public void configcontrols()
        {

            /*System.Web.UI.WebControls.Button boton = new System.Web.UI.WebControls.Button();
            boton.Text = "Hola mundo";
            boton.Click += holamundo;
            */
            Ext.Net.Button p = new Ext.Net.Button("hola")
            {
                Listeners =
                {
                    Click =
                    {
                        Handler="p.Text=\"holis\";"
                    }
                }
            };
            this.Panel1.Items.Add(p);
            
        }

        private void holamundo(object sender, EventArgs e)
        {

            MessageBoxShow(this, "hola mundo");
        }
    }
}