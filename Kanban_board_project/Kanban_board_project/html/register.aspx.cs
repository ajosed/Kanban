using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kanban_board_project;

namespace Kanban_board_project.html
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
                Response.Redirect("Dashboard.aspx");

            if (Application["LblErrorMessage"] != null)
            {
                this.LblErrorMessage.Text = Application["LblErrorMessage"].ToString();
                Application["LblErrorMessage"] = null;
            }

            if (Application["LblEmail"] != null)
            {
                this.LblEmail.Text = Application["LblEmail"].ToString();
                Application["LblEmail"] = null;
            }

            if (Application["LblUser"] != null)
            {
                this.LblUser.Text = Application["LblUser"].ToString();
                Application["LblUser"] = null;
            }

            if (Application["LblImage"] != null)
            {
                this.LblImage.Text = Application["LblImage"].ToString();
                Application["LblImage"] = null;
            }

            if (Application["Name"] != null)
            {
                this.name.Value = Application["Name"].ToString();
                Application["Name"] = null;
            }

            if (Application["Email"] != null)
            {
                this.email.Value = Application["Email"].ToString();
                Application["Email"] = null;
            }

            if (Application["User"] != null)
            {
                this.user.Value = Application["User"].ToString();
                Application["User"] = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (code.Value.CompareTo(Session["CaptchaImageText"].ToString()) != 0)
            {
                Application["LblImage"] = " Código incorrecto";
                Application["Name"] = string.Format("{0}", Request.Form["name"]);
                Application["Email"] = string.Format("{0}", Request.Form["email"]);
                Application["User"] = string.Format("{0}", Request.Form["user"]);
                Response.Redirect("register.aspx");
                return;
            }

            management mg = new management();

            string userText = string.Format("{0}", Request.Form["user"]);
            string passText = string.Format("{0}", Request.Form["pass"]);
            string emailText = string.Format("{0}", Request.Form["email"]);

            Int32 Validation = mg.emailIsValid(emailText);

            if (Validation != 0)
            {
                Application["Name"] = string.Format("{0}", Request.Form["name"]);
                Application["Email"] = string.Format("{0}", Request.Form["email"]);
                Application["User"] = string.Format("{0}", Request.Form["user"]);

                if (Validation == 1)
                    Application["LblEmail"] = " Sintaxis de correo errónea";

                if (Validation == 2)
                    Application["LblEmail"] = " Dominio no encontrado";

                if (Validation == 3)
                    Application["LblEmail"] = " Correo Electrónico no disponible";

                Response.Redirect("register.aspx");
                return;
            }

            if (mg.correoRegistrado(emailText))
            {
                Application["LblEmail"] = " Este correo ya esta en uso";
                Application["Name"] = string.Format("{0}", Request.Form["name"]);
                Application["Email"] = string.Format("{0}", Request.Form["email"]);
                Application["User"] = string.Format("{0}", Request.Form["user"]);
                Response.Redirect("register.aspx");
                return;
            }

            if (mg.yaExisteUser(userText))
            {
                Application["LblUser"] = " Username no disponible";
                Application["Name"] = string.Format("{0}", Request.Form["name"]);
                Application["Email"] = string.Format("{0}", Request.Form["email"]);
                Application["User"] = string.Format("{0}", Request.Form["user"]);
                Response.Redirect("register.aspx");
                return;
            }
            else
            {
                string nameText = string.Format("{0}", Request.Form["name"]);
                string profText = DropDownList1.SelectedValue;
                try
                {
                    mg.insertingRecord(nameText, profText, emailText, userText, passText);
                    mg.sendActivationMessage(emailText, nameText, "jj.cob@unitec.edu", "ramirezcruz2013");
                    Response.Redirect("Dashboard.aspx");
                }
                catch(Exception)
                {
                    Application["LblUser"] = " Username no disponible";
                    Application["Name"] = string.Format("{0}", Request.Form["name"]);
                    Application["Email"] = string.Format("{0}", Request.Form["email"]);
                    Application["User"] = string.Format("{0}", Request.Form["user"]);
                }
            }
        }
    }
}