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
        LogicaNegocio lgNegocio;
        #region metodos
        private void CargarGrid(csNegocio negocio)
        {
            //lgServicio = new LogicaServicio();
            //gvServicio.DataSource = lgServicio.ListarSErvicio(negocio.id_negocio);
            //gvServicio.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Params["show"] != null)
                {
                    //int codUser = int.Parse(Request.Params["show"].ToString());
                    if (Request.Params["show"].Length > 0)
                    {
                        csUtilidades util = new csUtilidades();
                        lgNegocio = new LogicaNegocio();
                        int codNegocio = int.Parse(util.desencriptar(Request.Params["show"]));
                        negocio = new csNegocio();
                        negocio = lgNegocio.SessionNegocio(codNegocio);
                        if (negocio != null)
                        {                            
                            Application["negocio"] = negocio;
                            ltError.Text = negocio.telefono;
                            
                        }
                        else
                        {
                            
                            pnContenido.Visible = false;
                            ltError.Text = "hola";
                        }


                    }
                    else
                    {
                        Response.Redirect("IndexSuscriptor.aspx");
                    }

                }
                else
                {
                    Response.Redirect("IndexSuscriptor.aspx");
                }
            }
            catch (Exception ex)
            {
                pnContenido.Visible = false;
                ltError.Text = ex.Message;
            }

        }
    }
}