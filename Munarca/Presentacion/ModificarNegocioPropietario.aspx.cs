using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class ModificarNegocioPropietario : System.Web.UI.Page
    {
        List<csUbicacion> listarUbicacion;
        csUbicacion Ubicacion;
        csUsuario Usuario;
        csPath path;
        LogicaPath lgPath;
        csUbicacion ubicacion;
        LogicaUbicacion lgUbicacion;
        csNegocio negocio;
        #region Metodos
        private void cargarDatos()
        {
            if (Request.Params["negocio"]!=null)
            {
                
            }
            else
            {
                Response.Redirect("NegocioPropietario.aspx");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["SessionNegocio"] != null)
            {

                if (!IsPostBack)
                {
                    LogicaCategoria lgCategoria;
                    lgCategoria = new LogicaCategoria();
                    dpCategoria.DataSource = lgCategoria.Listar();
                    dpCategoria.DataTextField = "categoria";
                    dpCategoria.DataValueField = "id_categoria";
                    dpCategoria.DataBind();
                    negocio = (csNegocio)Application["SessionNegocio"];
                    ViewState["codNegocio"] = negocio.id_negocio;
                    txtDescdrip.Text = negocio.descripcion;
                    hdLatFt.Value = negocio.latitud;
                    hdLonft.Value = negocio.longitud;
                    txtNombre.Text = negocio.nombre;
                    txtTelefono.Text = negocio.telefono.ToString();
                    txtUbicacion.Text = negocio.ubicacion;
                    dpCategoria.SelectedValue = negocio.fk_id_categoria.ToString();
                    txtDir.Text = negocio.direccion;


                }
            }
            else
            {
                Response.Redirect("NegocioPropietario.aspx");
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            LogicaNegocio lgNegocio = new LogicaNegocio();
            lgPath = new LogicaPath();
            csUsuario usuario = (csUsuario)Session["Usuario"];



            if ((uploadFile1.PostedFile != null) && (uploadFile1.PostedFile.ContentLength > 0))
            {
                try
                {
                    
                    string fn = System.IO.Path.GetFileName(uploadFile1.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("media/img") + "/" + fn;
                    csNegocio negocio = new csNegocio(int.Parse(ViewState["codNegocio"].ToString()), txtNombre.Text, txtDescdrip.Text, txtTelefono.Text, usuario.id_usuario, int.Parse(dpCategoria.SelectedValue.ToString()), txtDir.Text, uploadFile1.FileName, hdLonft.Value, txtUbicacion.Text, hdLatFt.Value);
                    
                    if(lgNegocio.ModificarNegocio(negocio))                     
                    {
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
                catch (Exception ex)
                {
                    ltRepuesta.Text = @"<div class='alert alert-danger'>
                    <strong>Advertencia</strong> " + ex.Message + "</div>";

                }

            }
            else
            {
                ltRepuesta.Text = @"<div class='alert alert-danger'>
                    <strong>Danger!</strong> No cargo la Foto.
                    </div>";
            }   
        }
    }
}