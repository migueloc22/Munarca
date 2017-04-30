using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        LogicaNegocio lgNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            csUsuario user = (csUsuario)Session["Usuario"];
            if (!IsPostBack)
            {
                lgNegocio = new LogicaNegocio();
                gvNegocio.DataSource = lgNegocio.listarNegocio(user.id_usuario);
                gvNegocio.DataBind();
                lgNegocio = new LogicaNegocio();
                //GridView1.DataSource = lgNegocio.listarNegocio(user.id_usuario);
                //GridView1.DataBind();
                Session["Negocio"] = null;
            }
        }
        //protected void gvNegocio_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
        //    try
        //    {

        //        int cod = int.Parse(gvNegocio.SelectedDataKey.Values[0].ToString());
        //        Response.Write(cod);
        //    }
        //    catch (Exception ex)
        //    {

        //        Response.Write(ex.ToString());
        //    }

        //}

        protected void gvNegocio_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

            btnModal_ModalPopupExtender.Show();
        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int cod = int.Parse(GridView1.SelectedDataKey.Values[0].ToString());
        //    Response.Write(cod);
        //}

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}