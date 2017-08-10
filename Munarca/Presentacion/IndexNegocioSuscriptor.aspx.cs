using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class IndexNegocioSuscriptor : System.Web.UI.Page
    {
        csNegocio negocio;
        LogicaServicio lgServicio;
        #region metodos
        private void CargarGrid(csNegocio negocio)
        {
            lgServicio = new LogicaServicio();
            gvServicio.DataSource = lgServicio.ListarSErvicio(negocio.id_negocio);
            gvServicio.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionNegocio"] != null)
            {

                negocio = (csNegocio)Session["SessionNegocio"];
                lbNombre.Text = negocio.nombre;
                lbDescrip.Text = negocio.descripcion;
                CargarGrid(negocio);
            }
            else
            {
                Response.Redirect("IndexSuscriptor.aspx");
            }
        }
    }
}