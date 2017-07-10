using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class UsuarioPropietario : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null && Session["TipoUsuario"] != null)
            {
                switch (Session["TipoUsuario"].ToString())
                {
                    case "1":
                        Response.Redirect("IndexSuscriptor.aspx");
                        break;
                    case "2":

                        break;
                    default:
                        break;
                }
               
            }

        }

        protected void bntCerrarSession_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }
    }
}