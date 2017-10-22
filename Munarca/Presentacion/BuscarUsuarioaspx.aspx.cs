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
    }
}