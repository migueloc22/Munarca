using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class ConfigAdmin : System.Web.UI.Page
    {
        LogicaTipoDocumento lgTpDoc;
        LogicaDepartamento lgDepartamento;
        LogicaCiudad lgCiudad;
        LogicaUsuario lgUsuario;
        csUsuario usuario;
        public void cargarTipoDoc()
        {
            lgTpDoc = new LogicaTipoDocumento();
            dtTpDoc.DataSource = lgTpDoc.DataTableTpDoc();
            dtTpDoc.DataTextField = "tipo_doc";
            dtTpDoc.DataValueField = "id_tipo_doc";
            dtTpDoc.DataBind();
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


        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                usuario = (csUsuario)Session["usuario"];
                imgUser.ImageUrl = usuario.foto;
                txtApe1.Text = usuario.apellido1;
                txtApe2.Text = usuario.apellido2;
                txtCorreo.Text = usuario.correo;
                //txtFechaNac.Text = "1994-07-07";
                txtNombre1.Text = usuario.nombre1;
                txtNombre2.Text = usuario.nombre2;
                txtNumDoc.Text = usuario.telefono;
                cargarDepartamento();
                cargarTipoDoc();
                int cod = int.Parse(dtDepartamento.SelectedValue.ToString());
                cargarCiudad(cod);
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
                    lgUsuario = new LogicaUsuario();
                    imgUser.ImageUrl = "media/img/" + FileUpload1.FileName;
                    lgUsuario.CambiarFoto(FileUpload1.FileName, usuario.id_usuario);
                    Session["usuario"] = lgUsuario.SessioUsuario(usuario.id_usuario);
                    ltImagen.Text = @"<div class='alert alert-danger'>
                    <strong>Exito!</strong> Foto actualizada.
                    </div>";

                }
                catch (Exception ex)
                {
                    ltImagen.Text = ex.Message;
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                ltImagen.Text = "No Cargo La foto";
            }
        }
         protected void btnDatos_Click(object sender, EventArgs e)
        {

            try
            {
                lgUsuario = new LogicaUsuario();
            }
            catch (Exception ex)
            {

                ltDatos.Text = ex.Message; 
            }
        }

        protected void btnGuardarPass_Click(object sender, EventArgs e)
        {

        }

        protected void dtDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod = int.Parse(dtDepartamento.SelectedValue.ToString());
            cargarCiudad(cod);
        }
    }

    }
