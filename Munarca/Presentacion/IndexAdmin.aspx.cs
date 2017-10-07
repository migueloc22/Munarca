using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class IndexAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            csUsuario usuario;
            usuario = (csUsuario)Session["Usuario"];
            if (usuario != null)
            {
                lbMensaje.Text = usuario.nombre1 + " " + usuario.contraseña;
            }
            else
            {
                Response.Redirect("LoginAdmin.aspx");
            }
        }
    }
}