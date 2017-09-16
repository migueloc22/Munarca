 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class AlbumNegocioPropietario : System.Web.UI.Page
    {
        LogicaPath lgNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Negocio"] != null)
            {
                LogicaPath lgPath = new LogicaPath();
                csNegocio negocio = (csNegocio)Session["Negocio"];
                lgNegocio = new LogicaPath();
                dlPath.DataSource = lgNegocio.DataTbPath(negocio.id_negocio);
                dlPath.DataBind();
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