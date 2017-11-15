using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class BuscarUsuarioaspx : System.Web.UI.Page
    {
        #region Metodos
        private void filter()
        {
            LogicaUsuario lgUsu = new LogicaUsuario();
            GvUsuario.DataSource = lgUsu.BuscarUsu(txtBuscador.Text);
            DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogicaUsuario lgUsu = new LogicaUsuario();
            GvUsuario.DataSource = lgUsu.BuscarUsu();
            DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            filter();
        }

       

        protected void GvUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cod = Int32.Parse(GvUsuario.DataKeys[e.RowIndex].Value.ToString());
            LogicaUsuario lgUsuario = new LogicaUsuario();
            if (lgUsuario.EliminarUsu(cod))
            {
                lbMensaje.Text = "Eliminado!!!";
                LogicaUsuario lgUsu = new LogicaUsuario();
                GvUsuario.DataSource = lgUsu.BuscarUsu();
                DataBind();


            }
            else {
                lbMensaje.Text = "NO Eliminado!!!";
            }
        }

        protected void GvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod = int.Parse(GvUsuario.SelectedDataKey.Values[0].ToString());
            //lbMensaje.Text = cod.ToString();
            Response.Redirect("PerfilUsuarioAdminn.aspx?perfil="+cod);

        }
    }
}