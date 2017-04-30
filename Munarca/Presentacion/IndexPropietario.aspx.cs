using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class IndexPropietario : System.Web.UI.Page
    {
        LogicaNegocio lgNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            csUsuario user = (csUsuario)Session["Usuario"];
            if (!IsPostBack)
            {
                lgNegocio = new LogicaNegocio();
                dtlisNegocio.DataSource = lgNegocio.listarNegocio(user.id_usuario);
                dtlisNegocio.DataBind();
                Session["Negocio"] = null;
            }


        }

        protected void btnIrGeocio_Click(object sender, EventArgs e)
        {
            try
            {
                //string cod = dtlisNegocio.ID ;
                LinkButton btn = (LinkButton)sender;
                DataListItem item = (DataListItem)btn.NamingContainer;
                Label lb = (Label)item.FindControl("Label2");
                lgNegocio = new LogicaNegocio();
                csNegocio negocio=lgNegocio.SessionNegocio(int.Parse(lb.Text));
                Session["Negocio"] = negocio;
                Response.Redirect("IndexServicioPropietario.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }






    }
}