using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Kanban_board_project;

namespace Kanban_board_project.html
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
                Response.Redirect("Dashboard.aspx");

            if (Application["LblUser"] != null)
            {
                this.LblUser.Text = Application["LblUser"].ToString();
                Application["LblUser"] = null;
            }

            if (Application["TxtUser"] != null)
            {
                user.Value = Application["TxtUser"].ToString();
                Application["TxtUser"] = null;
            }

            if (Application["LblPass"] != null)
            {
                this.LblPass.Text = Application["LblPass"].ToString();
                Application["LblPass"] = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userText = string.Format("{0}", Request.Form["user"]);
            string passText = string.Format("{0}", Request.Form["pass"]);

            Kanban_board_project.management mm = new management();
            management mg = new management();

            if (mg.yaExiste(userText, passText))
            {
                Session["user"] = userText;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                if (!mg.yaExisteUser(userText))
                    Application["LblUser"] = " Usuario no existe";
                else
                {
                    Application["TxtUser"] = userText;
                    Application["LblPass"] = " Contraseña Incorrecta";
                }

                Response.Redirect("main.aspx");
            }
        }
    }
}