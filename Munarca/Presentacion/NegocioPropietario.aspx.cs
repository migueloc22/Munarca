using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class NegocioPropietario : System.Web.UI.Page
    {
        #region Metodos
        private void CargarTabla()
        {
            csUsuario user = (csUsuario)Session["Usuario"];
            lgNegocio = new LogicaNegocio();
            gvNegocio.DataSource = lgNegocio.listarNegocio(user.id_usuario);
            gvNegocio.DataBind();
        }
        #endregion
        LogicaNegocio lgNegocio;
        csNegocio negocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                CargarTabla();
                Session["Negocio"] = null;
                Application["SessionNegocio"] = null;
                Session["lista"] = null;
            }
        }
        

        protected void gvNegocio_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

            btnModal_ModalPopupExtender.Show();
            try
            {

                int cod = Int32.Parse(gvNegocio.DataKeys[e.RowIndex].Value.ToString());
                ViewState["codEliminar"] = cod;
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }

        protected void gvNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                lgNegocio = new LogicaNegocio();
                int cod = int.Parse(gvNegocio.SelectedDataKey.Values[0].ToString());
                negocio = lgNegocio.SessionNegocio(cod);
                Application["SessionNegocio"] = negocio;
                Response.Redirect("ModificarNegocioPropietario.aspx");
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lgNegocio = new LogicaNegocio();
            int cod = int.Parse(ViewState["codEliminar"].ToString());
            lgNegocio.eliminarNeocio(cod);
            CargarTabla();
        }
    }
}