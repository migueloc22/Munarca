using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class ConfigSuscriptor : System.Web.UI.Page
    {
        LogicaTipoDocumento lgTpDoc;
        LogicaDepartamento lgDepartamento;
        LogicaCiudad lgCiudad;
        LogicaUsuario lgUsuario;
        csUsuario usuario;
        csUtilidades util;
        LogicaTipoUsuario lgTpUser;
        LogicaEstadoUsuario lgEstUser;
        #region Metodos

        public void cargarTipoDoc()
        {
            lgTpDoc = new LogicaTipoDocumento();
            dtTpDoc.DataSource = lgTpDoc.DataTableTpDoc();
            dtTpDoc.DataTextField = "tipo_doc";
            dtTpDoc.DataValueField = "id_tipo_doc";
            dtTpDoc.DataBind();
        }
        public void cargarTipoUser()
        {
            lgTpUser = new LogicaTipoUsuario();
            dpTipoUser.DataSource = lgTpUser.DataTableTipoUsu();
            dpTipoUser.DataTextField = "tipo";
            dpTipoUser.DataValueField = "id_tipo_usuario";
            dpTipoUser.DataBind();
            dpTipoUser2.DataSource = lgTpUser.DtTipoUsu();
            dpTipoUser2.DataTextField = "tipo";
            dpTipoUser2.DataValueField = "id_tipo_usuario";
            dpTipoUser2.DataBind();
        }

        public void cargarDepartamento(int id)
        {
            lgDepartamento = new LogicaDepartamento();
            dtDepartamento.DataSource = lgDepartamento.DataTableDpto(id);
            dtDepartamento.DataTextField = "departamento";
            dtDepartamento.DataValueField = "id_departamento";
            dtDepartamento.DataBind();
        }
        public void cargarDepartamento()
        {
            lgDepartamento = new LogicaDepartamento();
            dtDepartamento.DataSource = lgDepartamento.DataTableDpto();
            dtDepartamento.DataTextField = "departamento";
            dtDepartamento.DataValueField = "id_departamento";
            dtDepartamento.DataBind();
        }
        public void cargarCiudad(int cod)
        {
            lgCiudad = new LogicaCiudad();
            dtCiudad.DataSource = lgCiudad.DataTableCiudad(cod);
            dtCiudad.DataTextField = "ciudad";
            dtCiudad.DataValueField = "id_ciudad";
            dtCiudad.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    usuario = (csUsuario)Session["usuario"];
                    imgUser.ImageUrl = usuario.foto;
                    txtApe1.Text = usuario.apellido1;
                    txtApe2.Text = usuario.apellido2;
                    txtCorreo.Text = usuario.correo;
                    txtFechaNac.Text = usuario.fecha_nacimiento;
                    txtNombre1.Text = usuario.nombre1;
                    txtNombre2.Text = usuario.nombre2;
                    txtNumDoc.Text = usuario.num_documento.ToString();
                    txtTelefono.Text = usuario.telefono;
                    txtDir.Text = usuario.direccion;
                    cargarDepartamento();
                    cargarTipoDoc();
                    int cod = int.Parse(dtDepartamento.SelectedValue.ToString());
                    cargarCiudad(cod);
                    cargarTipoUser();
                }
            }
            catch (Exception ex)
            {

                ltDatos.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error!</strong> " + ex.Message + "</div>";
            }



        }

        protected void txtGuadarImg_Click(object sender, EventArgs e)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string SaveLocation = Server.MapPath("media\\img") + "\\" + fn;
                try
                {
                    FileUpload1.PostedFile.SaveAs(SaveLocation);

                    usuario = (csUsuario)Session["usuario"];

                    imgUser.ImageUrl = "media/img/" + FileUpload1.FileName;
                    lgUsuario = new LogicaUsuario();
                    lgUsuario.CambiarFoto(FileUpload1.FileName, usuario.id_usuario);
                    Session["usuario"] = lgUsuario.SessioUsuario(usuario.id_usuario);
                    ltImagen.Text = @"<div class='alert alert-info alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>¡Información!</strong>Foto actulizada</div>";

                }
                catch (Exception ex)
                {
                    ltImagen.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error!</strong> " + ex.Message + "</div>";
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                ltImagen.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error!</strong> No Cargo La Foto</div>";
            }
        }

        protected void btnDatos_Click(object sender, EventArgs e)
        {

            try
            {
                lgUsuario = new LogicaUsuario();
                //if (txtFechaNac.Rows>0||txtFechaNac.Text==null)
                //{
                usuario = (csUsuario)Session["Usuario"];

                if (lgUsuario.validarCorreo(txtCorreo.Text) || txtCorreo.Text == usuario.correo)
                {
                    usuario = new csUsuario(usuario.id_usuario, txtNombre1.Text, txtNombre2.Text, txtApe1.Text, txtApe2.Text, txtCorreo.Text, "", txtDir.Text, txtFechaNac.Text, txtTelefono.Text, int.Parse(txtNumDoc.Text), int.Parse(dtTpDoc.SelectedValue.ToString()), int.Parse(dtCiudad.SelectedValue.ToString()), "");
                    if (lgUsuario.ActulizarDatos(usuario))
                    {
                        lgUsuario = new LogicaUsuario();
                        ltDatos.Text = @"<div class='alert alert-info alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>¡Información!</strong> Datos Actualizados</div>";
                        Session["Usuario"] = lgUsuario.SessioUsuario(usuario.id_usuario);
                    }
                    else
                    {
                        ltDatos.Text = @"<div class='alert alert-danger alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>Error!</strong>Datos No Actualizados</div>";
                    }
                }
                else
                {
                    ltDatos.Text = @"<div class='alert alert-danger alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>Error!</strong>Correo ya existe</div>";
                }


                //}
            }
            catch (Exception ex)
            {

                ltDatos.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error!</strong> " + ex.Message + "</div>";
            }
        }

        protected void btnGuardarPass_Click(object sender, EventArgs e)
        {
            try
            {
                lgUsuario = new LogicaUsuario();
                //if (txtFechaNac.Rows>0||txtFechaNac.Text==null)
                //{
                usuario = (csUsuario)Session["Usuario"];
                util = new csUtilidades();
                if (lgUsuario.CambiarPass(util.Encriptar(txtPass1.Text), usuario.id_usuario))
                {
                    lgUsuario = new LogicaUsuario();
                    ltMsnPass.Text = @"<div class='alert alert-info alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>¡Información!</strong> Contraseña actualizada.</div>";
                    Session["Usuario"] = lgUsuario.SessioUsuario(usuario.id_usuario);
                }
                else
                {
                    ltMsnPass.Text = @"<div class='alert alert-danger alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>Error!</strong>Contraseña no actualizada.</div>";
                }


                //}
            }
            catch (Exception ex)
            {

                ltMsnPass.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error!</strong> " + ex.Message + "</div>";
            }
        }

        protected void dtDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int cod = int.Parse(dtDepartamento.SelectedValue.ToString());
                cargarCiudad(cod);
            }
            catch (Exception ex)
            {

                ltDatos.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error!</strong> " + ex.Message + "</div>";
            }

        }

        protected void btnCmbiarUser_Click(object sender, EventArgs e)
        {
            try
            {
                lgEstUser = new LogicaEstadoUsuario();
                usuario = (csUsuario)Session["Usuario"];
                if ((lgEstUser.Validar(usuario.id_usuario, int.Parse(dpTipoUser.SelectedValue))))
                {
                    switch (dpTipoUser.SelectedValue)
                    {
                        case "1":
                            Session["TipoUsuario"] = "1";
                            Response.Redirect("IndexPropietario.aspx");
                            break;
                        case "2":
                            Session["TipoUsuario"] = "2";
                            Response.Redirect("IndexSuscriptor.aspx");
                            break;
                        case "3":
                            Session["TipoUsuario"] = "3";
                            Response.Redirect("indexAdminn.aspx");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    
                    
                        ltMsntpUserAgregar.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>!Error! </strong> Ya tiene tipo de usuario agregado con su usuario</div>";
                    
                }

            }
            catch (Exception ex)
            {

                ltMsntpUserAgregar.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error! </strong> " + ex.Message + "</div>";
            }
        }

        protected void btnUsuraio_Click(object sender, EventArgs e)
        {
            try
            {
                lgEstUser = new LogicaEstadoUsuario();
                usuario = (csUsuario)Session["Usuario"];
                if ((lgEstUser.Validar(usuario.id_usuario, int.Parse(dpTipoUser.SelectedValue))))
                {
                    ltMsntpUserAgregar.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>¡Error! </strong> Ya tiene tipo de usuario agregado.</div>";
                }
                else
                {
                    if (lgEstUser.CrearTipoUser(usuario.id_usuario, int.Parse(dpTipoUser.SelectedValue)))
                    {
                        ltMsntpUserAgregar.Text = @"<div class='alert alert-info alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>¡Información! </strong> Tipo de Usuario agregado</div>";
                    }
                    else
                    {
                        ltMsntpUserAgregar.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error! </strong> Ya tiene tipo de usuario agregado con su usuario</div>";
                    }
                }

            }
            catch (Exception ex)
            {

                ltMsntpUserAgregar.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error! </strong> " + ex.Message + "</div>";
            }
        }
    }
}