using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class UsuarioSuscriptor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null && Session["TipoUsuario"] != null)
            {
                csUsuario user = (csUsuario)Session["Usuario"];
                imgUer.ImageUrl = user.foto;
                lbNombre.Text = user.nombre1;
                switch (Session["TipoUsuario"].ToString())
                {
                    case "2":
                        break;
                    case "1":
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