using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class UsuarioAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            csUsuario usuario;
            usuario = (csUsuario)Session["Usuario"];
            if (usuario != null)
            {
                lbNombre.Text = usuario.nombre1;
            }
            else
            {
                Response.Redirect("LoginAdmin.aspx");
            }
        }
    }
}