using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kanban_board_project.html
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sacar el id y redireccionar hacia el kanban board  y mandamos en session el id del board
            Session["boardid"] = this.GridView1.Rows[this.GridView1.SelectedIndex].Cells[1].Text;
            int x = int.Parse(this.GridView1.Rows[this.GridView1.SelectedIndex].Cells[1].Text);
            Response.Redirect("~/html/drawKanban.aspx");
            // MessageBoxShow(this, this.GridView1.SelectedIndex.ToString());
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("btndelete"))
            {
                MessageBoxShow(this, "Borrado!!!" + this.GridView1.Rows[1].Cells[1].Text);
            }
        }
        private void MessageBoxShow(Page page, string message)
        {
            Literal ltr = new Literal();
            ltr.Text = @"<script type='text/javascript'> alert('" + message + "') </script>";
            page.Controls.Add(ltr);
        }

        protected void Button1_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {

            Response.Redirect("~/html/Crearboard.aspx");
        }
    }
}