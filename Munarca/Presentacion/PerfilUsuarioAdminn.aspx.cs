using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class PerfilUsuarioAdminn : System.Web.UI.Page
    {
        csUsuario usuario;
        LogicaUsuario lgUsuario;
        LogicaNegocio lgNegocio;
        LogicaEstadoUsuario lgEstUsuario;

        #region  metodos
        private void CargarTabla()
        {

            lgNegocio = new LogicaNegocio();
            gvNegocio.DataSource = lgNegocio.listarNegocio(int.Parse(Request.Params["perfil"]));
            gvNegocio.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lgNegocio = new LogicaNegocio();
            int cod = int.Parse(ViewState["codEliminar"].ToString());
            lgNegocio.eliminarNeocio(cod);
            CargarTabla();
        }

        protected void gvNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string cod = gvNegocio.SelectedDataKey.Values[0].ToString();
                Response.Redirect("ModificarNegocioAdmin.aspx?negocio=" + cod + "&perfil=" + Request.Params["perfil"], false);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

            //Response.Redirect("ModificarNegocioPropietario.aspx");

        }
        protected void gvNegocio_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

            btnModal_ModalPopupExtender.Show();
            try
            {

                int cod = Int32.Parse(gvNegocio.DataKeys[e.RowIndex].Value.ToString());
                ViewState["codEliminar"] = cod;
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }

        #endregion




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Request.Params["perfil"] != null)
                {
                    lgUsuario = new LogicaUsuario();
                    lgEstUsuario = new LogicaEstadoUsuario();
                    usuario = lgUsuario.SessioUsuario(int.Parse(Request.Params["perfil"]));
                    Label1.Text = usuario.nombre1 + " " + usuario.apellido1;
                    Image1.ImageUrl = usuario.foto;
                    lbNombres.Text = usuario.nombre1 + " " + usuario.apellido1;
                    lbApellido1.Text = usuario.apellido1;
                    lbApellido2.Text = usuario.apellido2;
                    lbFecNac.Text = usuario.fecha_nacimiento;
                    lbTpDoc.Text = "cédula de ciudadanía";
                    lbNumDoc.Text = usuario.num_documento.ToString();
                    //lbEdad.Text = "24" + " " + "Años";
                    lbDir.Text = usuario.direccion;
                    lbTel.Text = usuario.telefono;
                    lbCorreo.Text = usuario.correo;
                    if (lgEstUsuario.Validar(usuario.id_usuario,3))
                    {
                        pnNegocio.Visible = true;
                        CargarTabla();

                    }
                    hplinkCreaNegocio.NavigateUrl = "~/CrearNegocioAdmin.aspx?perfil=" + Request.Params["perfil"];

                    hLinkModificar.NavigateUrl = "ModificarUsuarioAdminn.aspx?perfil=" + Request.Params["perfil"];
                }
                else
                {
                    Response.Redirect("BuscarUsuarioaspx.aspx");
                }
            }
        }
    }
}