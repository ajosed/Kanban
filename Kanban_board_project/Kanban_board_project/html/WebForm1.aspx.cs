using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kanban_board_project.html
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            management mg = new management();

            if (!mg.yaExiste(this.TextBox1.Text, this.TextBox2.Text))
                Response.Redirect("WebForm1.aspx");
            /*
            CheckingEmailAddress.EmailVerify Verifier = new CheckingEmailAddress.EmailVerify();
            CheckingEmailAddress.ReturnValues WithoutTimeOut = Verifier.VerifyEmail(this.TextBox1.Text, "0");
            CheckingEmailAddress.ReturnValues WithTimeOut = Verifier.VerifyEmailWithTimeout(this.TextBox1.Text, "5", "0");

            String info = "";
            info += WithoutTimeOut.ValidLicenseKey.ToString();
            info += "\n";
            info += WithoutTimeOut.CorrectSyntax.ToString();
            info += "\n";
            info += WithoutTimeOut.GoodEmail.ToString();

            Response.Write(info);
             */
        }
    }
}