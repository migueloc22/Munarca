using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class IndexServicioPropietario : System.Web.UI.Page
    {

        csNegocio negocio;
        LogicaServicio lgServicio;
        #region metodos
        private void CargarGrid(csNegocio negocio ) {
            lgServicio = new LogicaServicio();
            gvServicio.DataSource = lgServicio.ListarSErvicio(negocio.id_negocio);
            gvServicio.DataBind();
        }
        #endregion
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
                CargarGrid( negocio ) ;
            }
            else
            {
                Response.Redirect("IndexPropietario.aspx");
            }
        }

        protected void gvServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codServicio = int.Parse(gvServicio.SelectedDataKey.Values[0].ToString());
            lgServicio = new LogicaServicio();
            Application["SessionServicio"] = lgServicio.SessionServicio(codServicio);
            Response.Redirect("ModificarServicioPropietario.aspx");
        }

        protected void gvServicio_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codServicio = int.Parse(gvServicio.DataKeys[e.RowIndex].Value.ToString());
            ViewState["codServicio"] = codServicio;
            btnNodal_ModalPopupExtender.Show();
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lgServicio = new LogicaServicio();
            int codServicio = int.Parse(ViewState["codServicio"].ToString());
            if (lgServicio.EliminarServicio(codServicio))
            {
                negocio = (csNegocio)Session["Negocio"];                
                CargarGrid(negocio);
            }
        }

        
    }
}

