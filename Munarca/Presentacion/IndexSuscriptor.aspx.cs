using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Presentacion
{
    public partial class IndexSuscriptor : System.Web.UI.Page 
    {
        csNegocio negocio;
        LogicaNegocio lgNegocio;
        private void CargarGrid()
        {
            LogicaServicio lgServicio = new LogicaServicio();
            gvServicio.DataSource = lgServicio.ListarSErvicio();
            gvServicio.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
                Session["SessionNegocio"] = null;
            }
        }

        protected void gvServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lgNegocio = new LogicaNegocio();
            int codNegocio =int.Parse(gvServicio.SelectedDataKey.Values[0].ToString());
            negocio = lgNegocio.SessionNegocio(codNegocio);
            Session["SessionNegocio"] = negocio;
            Response.Redirect("IndexNegocioSuscriptor.aspx");
        }
    }
}