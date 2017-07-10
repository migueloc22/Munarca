using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class UsuarioSuscriptor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null && Session["TipoUsuario"] != null)
            {
                switch (Session["TipoUsuario"].ToString())
                {
                    case "1":
                        break;
                    case "2":
                        Response.Redirect("IndexPropietario.aspx"); ;
                        break;
                    default:
                        break;
                }
            }
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Response.Redirect("Index.aspx");
        //}
    }
}