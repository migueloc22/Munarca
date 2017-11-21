using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class ModificarNegocioAdmin : System.Web.UI.Page
    {
        List<csUbicacion> listarUbicacion;
        csUbicacion Ubicacion;
        csUsuario Usuario;
        csPath path;
        LogicaPath lgPath;
        csUbicacion ubicacion;
        LogicaUbicacion lgUbicacion;
        csNegocio negocio;
        LogicaNegocio lgNegocio;
        LogicaEstadoNegocio lgEstaNegocio;
        csEstadoNegocio estNegocio;
        #region Metodos
        private void cargarDatos()
        {
            if (Request.Params["negocio"] != null)
            {
                lgNegocio = new LogicaNegocio();
                negocio = lgNegocio.SessionNegocio(int.Parse(Request.Params["negocio"]));
                txtDescdrip.Text = negocio.descripcion;
                txtNombre.Text = negocio.nombre;
                hdCodNegocio.Value = negocio.id_negocio.ToString();
                //hdImag.Value = negocio.foto_negocio;
                txtTelefono.Text = negocio.telefono.ToString();
                lgEstaNegocio = new LogicaEstadoNegocio();
                List<csEstadoNegocio> lista = new List<csEstadoNegocio>();
                hpRegresar1.NavigateUrl = "PerfilUsuarioAdminn.aspx?perfil="+Request.Params["perfil"];
                hpRegresar2.NavigateUrl = "PerfilUsuarioAdminn.aspx?perfil=" + Request.Params["perfil"];
                lista = lgEstaNegocio.listEstadoNegocio(negocio.id_negocio);
                for (int i = 0; i < chekListCategoria.Items.Count; i++)
                {
                    foreach (csEstadoNegocio estNeg in lista)
                    {
                        if (chekListCategoria.Items[i].Value == estNeg.fk_id_categoria.ToString())
                        {
                            chekListCategoria.Items[i].Selected = true;
                        }
                    }


                }
            }
            else
            {
                Response.Redirect("NegocioPropietario.aspx");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                LogicaCategoria lgCategoria;
                lgCategoria = new LogicaCategoria();
                chekListCategoria.DataSource = lgCategoria.Listar();
                chekListCategoria.DataTextField = "categoria";
                chekListCategoria.DataValueField = "id_categoria";
                chekListCategoria.DataBind();

                cargarDatos();



            }

        }

        protected void btnModificarNegocio_Click(object sender, EventArgs e)
        {
            try
            {
                //lgNegocio=new LogicaNegocio();
                //negocio = new csNegocio(int.Parse(lbId_negocio.Text), txtNombre.Text, txtDesccrip.Text, txtTelefono.Text, 0, int.Parse(dpCategoria.SelectedValue.ToString()), txtLon.Text, txtUbicacion.Text, txtLat.Text);
                //if (lgNegocio.ModificarNegocio(negocio))
                //{
                //    Button2_ModalPopupExtender.Show();
                //}
                //else { }
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (chekListCategoria.SelectedIndex == -1)
            {
                args.IsValid = false;
            }
            //for (int i = 0; i < (chekListCategoria.Items.Count-1); i++)
            //{
            //    chekListCategoria.Items(i).sel
            //}
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {


                    LogicaNegocio lgNegocio = new LogicaNegocio();
                    lgPath = new LogicaPath();
                    csUsuario usuario = (csUsuario)Session["Usuario"];
                    int codNegoc = int.Parse(Request.Params["negocio"]);
                    lgEstaNegocio = new LogicaEstadoNegocio();
                    if ((uploadFile1.PostedFile != null) && (uploadFile1.PostedFile.ContentLength > 0))
                    {
                        string fn = System.IO.Path.GetFileName(uploadFile1.PostedFile.FileName);
                        string SaveLocation = Server.MapPath("media/img") + "/" + fn;
                        csNegocio negocio = new csNegocio(int.Parse(hdCodNegocio.Value), txtNombre.Text, txtDescdrip.Text, txtTelefono.Text, usuario.id_usuario, uploadFile1.FileName, hdLonft.Value, txtUbicacion.Text, hdLatFt.Value);

                        if (lgNegocio.ModificarNegocio(negocio))
                        {
                            foreach (ListItem item in chekListCategoria.Items)
                            {
                                if (item.Selected)
                                {
                                    if (lgEstaNegocio.validarEstadNegocio(int.Parse(item.Value.ToString()), codNegoc) == false)
                                    {
                                        estNegocio = new csEstadoNegocio(0, int.Parse(item.Value.ToString()), codNegoc);
                                        lgEstaNegocio.CrearEstadoNegocio(estNegocio);
                                    }

                                }
                                if (item.Selected == false)
                                {
                                    if (lgEstaNegocio.validarEstadNegocio(int.Parse(item.Value.ToString()), codNegoc))
                                    {

                                        lgEstaNegocio.EliminarEstadoNegocio(int.Parse(item.Value.ToString()));
                                    }
                                }

                            }
                            uploadFile1.PostedFile.SaveAs(SaveLocation);
                            Button2_ModalPopupExtender.Show();
                        }
                        else
                        {
                            ltRepuesta.Text = @"<div class='alert alert-danger'>
                             <strong>Danger!</strong> no guardor el registro.
                             </div>";
                        }
                    }
                    else
                    {
                        //string fn = System.IO.Path.GetFileName(uploadFile1.PostedFile.FileName);
                        //string SaveLocation = Server.MapPath("media/img") + "/" + fn;
                        csNegocio negocio = new csNegocio(int.Parse(hdCodNegocio.Value), txtNombre.Text, txtDescdrip.Text, txtTelefono.Text, usuario.id_usuario, "", hdLonft.Value, txtUbicacion.Text, hdLatFt.Value);

                        if (lgNegocio.ModificarNegocio2(negocio))
                        {
                            foreach (ListItem item in chekListCategoria.Items)
                            {
                                if (item.Selected)
                                {
                                    if (lgEstaNegocio.validarEstadNegocio(int.Parse(item.Value.ToString()), codNegoc) == false)
                                    {
                                        estNegocio = new csEstadoNegocio(0, int.Parse(item.Value.ToString()), codNegoc);
                                        lgEstaNegocio.CrearEstadoNegocio(estNegocio);
                                    }

                                }
                                if (item.Selected == false)
                                {
                                    if (lgEstaNegocio.validarEstadNegocio(int.Parse(item.Value.ToString()), codNegoc))
                                    {

                                        lgEstaNegocio.EliminarEstadoNegocio(int.Parse(item.Value.ToString()));
                                    }
                                }

                            }
                            //uploadFile1.PostedFile.SaveAs(SaveLocation);
                            Button2_ModalPopupExtender.Show();
                        }
                        else
                        {
                            ltRepuesta.Text = @"<div class='alert alert-danger'>
                             <strong>Danger!</strong> no guardor el registro.
                             </div>";
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                ltRepuesta.Text = @"<div class='alert alert-danger alert-dismissable'>
<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
<strong>Error! </strong> " + ex.Message + "</div>";
            }

        }
    }
}