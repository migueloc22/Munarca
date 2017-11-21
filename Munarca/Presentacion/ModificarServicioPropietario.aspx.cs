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
    public partial class ModificarServicioPropietario : System.Web.UI.Page
    {
        csServicio servicio;
        LogicaServicio lgServicio;
        LogicaTipoServicio lgTpServicios;
        csUtilidades util;
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
            if (!IsPostBack)
            {
                if (Request.Params["show"] == null)
                {
                    Response.Redirect("IndexPropietario.aspx");
                }
                else
                {
                    try
                    {
                        util = new csUtilidades();
                        lgServicio = new LogicaServicio();                        
                        servicio= lgServicio.SessionServicio(int.Parse(Request.Params["service"].ToString()));
                        bntRegresar.NavigateUrl = "IndexNegocioPropietario.aspx?show=" + Request.Params["show"];
                        bntRegresar2.NavigateUrl = "IndexNegocioPropietario.aspx?show=" + Request.Params["show"];
                        //CargarList();
                        txtNombre.Text = servicio.nombre;
                        txtDescripcion.Text = servicio.descripcion;
                        txtValor.Text = servicio.valor.ToString();
                        lbImagen.Text = servicio.imagen;
                        ViewState["codServicio"] = servicio.id_servicio;
                    }
                    catch (Exception ex)
                    {

                        ltError.Text = @"<div class='alert alert-danger'><strong>Error!</strong> " + ex.Message + ".</div>";
                    }

                }


            }

        }





        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                lgServicio = new LogicaServicio();
                HttpFileCollection file = Request.Files;
                util = new csUtilidades();
                for (int i = 0; i <= file.Count - 1; i++)
                {

                    HttpPostedFile postefile = file[i];
                    String[] nombres = new String[file.Count - 1];
                    if (postefile.ContentLength > 0)
                    {
                        int codService = int.Parse(ViewState["codServicio"].ToString());
                        int codNegocio=int.Parse(util.desencriptar(Request.Params["show"].ToString()));
                        postefile.SaveAs(Server.MapPath(@"media\img\") + Path.GetFileName(postefile.FileName));
                        servicio = new csServicio(codService, txtNombre.Text, txtDescripcion.Text, postefile.FileName.ToString(), "", "", int.Parse(txtValor.Text),codNegocio);
                        if (lgServicio.ModificarServicio(servicio))
                        {
                            Button2_ModalPopupExtender.Show();

                        }
                        else
                        {
                            ltError.Text = @"<div class='alert alert-danger'>
                          <strong>Error!</strong> " + "Servicio Modificado" + ".</div>";
                        }

                    }
                    else
                    {


                        int codService = int.Parse(ViewState["codServicio"].ToString());
                        int codNegocio = int.Parse(util.desencriptar(Request.Params["show"].ToString()));
                        servicio = new csServicio(codService, txtNombre.Text, txtDescripcion.Text, "", "", "", int.Parse(txtValor.Text), codNegocio);
                        if (lgServicio.ModificarServicio2(servicio))
                        {
                            Button2_ModalPopupExtender.Show();

                        }
                        else
                        {
                            ltError.Text = @"<div class='alert alert-danger'>
                          <strong>Error!</strong> " + "Servicio Modificado" + ".</div>";
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