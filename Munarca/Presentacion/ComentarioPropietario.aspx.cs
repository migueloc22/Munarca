using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class ComentarioPropietario : System.Web.UI.Page
    {
        csNegocio negocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Negocio"] != null)
            {
                negocio = (csNegocio)Session["Negocio"];
                lbNombre.Text = negocio.nombre;
                lbDescrip.Text = negocio.descripcion;
            }
            else
            {
                Response.Redirect("IndexPropietario.aspx");
            }
        }
    }
}