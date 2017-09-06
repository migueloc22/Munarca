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
                LogicaPath lgPath = new LogicaPath();
                negocio = (csNegocio)Session["Negocio"];
                Repeater1.DataSource = lgPath.DataTbPath(negocio.id_negocio); ;
                Repeater1.DataBind();
                lbNombre.Text = negocio.nombre;
                lbDescrip.Text = negocio.descripcion;
                lbTelefono.Text = negocio.telefono.ToString();
                lbUbicacion.Text = negocio.ubicacion;
            }
            else
            {
                Response.Redirect("IndexPropietario.aspx");
            }
        }
    }
}