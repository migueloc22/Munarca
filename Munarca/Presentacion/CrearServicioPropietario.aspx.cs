using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.IO;


namespace Presentacion
{
    public partial class CrearServicioPropietario : System.Web.UI.Page
    {
        LogicaServicio lgServicio;
        csUtilidades util;
        csServicio servicio;
        csNegocio negocio;
        LogicaTipoServicio lgTpServicios;
        #region Metodos
        //private void CargarList()
        //{
        //    lgTpServicios = new LogicaTipoServicio();
        //    dpListServicios.DataSource = lgTpServicios.dtTpServicio();
        //    dpListServicios.DataTextField = "tipo_servicio";
        //    dpListServicios.DataValueField = "id_tipo_servicio";
        //    dpListServicios.DataBind();
        
        //}
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["show"] == null)
            {
                Response.Redirect("IndexPropietario.aspx");
            }
            else {
                bntRegresar.NavigateUrl = "IndexNegocioPropietario.aspx?show=" + Request.Params["show"];
                bntRegresar2.NavigateUrl = "IndexNegocioPropietario.aspx?show=" + Request.Params["show"];
                
                //CargarList();
            }
            
        }

        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                util = new csUtilidades();
                int codnegocio = int.Parse(util.desencriptar(Request.Params["show"]));
                lgServicio = new LogicaServicio();
                DateTime time = DateTime.Now;
                string fecha = time.Date.ToString("yyyy-MM-dd");
                //string hora = time.TimeOfDay.ToString("HH:mm");
                string hora = "14:05:12";
                HttpFileCollection file = Request.Files;
                for (int i = 0; i <= file.Count - 1; i++)
                {

                    HttpPostedFile postefile = file[i];
                    String[] nombres = new String[file.Count - 1];
                    if (postefile.ContentLength > 0)
                    {

                        postefile.SaveAs(Server.MapPath(@"media\img\") + Path.GetFileName(postefile.FileName));
                        servicio = new csServicio(0, txtNombre.Text, txtDescripcion.Text, postefile.FileName.ToString(), fecha, hora, int.Parse(txtValor.Text), codnegocio);
                        if (lgServicio.CrearServicio(servicio))
                        {
                            Button2_ModalPopupExtender.Show();
                        }
                        else
                        {
                            ltError.Text = @"<div class='alert alert-danger'>
                          <strong>Error!</strong> " + "Servicio no creado" + ".</div>";
                        }

                    }
                }
            
            }
            catch (Exception ex)
            {

                ltError.Text = @"<div class='alert alert-danger'>
                          <strong>Error!</strong> " + ex.Message + ".</div>";
            }
           
            
            
        }
    }
}