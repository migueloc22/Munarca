using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Negocio;
using System.IO;

namespace Presentacion
{
    public partial class Index : System.Web.UI.Page
    {
        LogicaUsuario LgUsuario = new LogicaUsuario();
        LogicaEstadoUsuario estadoUser = new LogicaEstadoUsuario();
        csUsuario Usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null && Session["TipoUsuario"] != null)
                {
                    switch (Session["TipoUsuario"].ToString())
                    {
                        case "1":
                            Response.Redirect("IndexSuscriptor.aspx");
                            break;
                        case "2":
                            Response.Redirect("IndexPropietario.aspx"); ;
                            break;
                        default:
                            break;
                    }


                }
                else
                {
                    LogicaTipoDocumento lgTpDoc = new LogicaTipoDocumento();
                    dlTipoDoc.DataSource = lgTpDoc.DataTableTpDoc();
                    dlTipoDoc.DataTextField = "tipo_doc";
                    dlTipoDoc.DataValueField = "id_tipo_doc";
                    dlTipoDoc.DataBind();
                    Session.Clear();
                    //recuperarar id
                    //int.Parse(dlTipoDoc.SelectedValue.ToString())



                    LogicaDepartamento lgDpto = new LogicaDepartamento();
                    dlDpto.DataSource = lgDpto.DataTableDpto();
                    dlDpto.DataTextField = "departamento";
                    dlDpto.DataValueField = "id_departamento";
                    dlDpto.DataBind();
                    Session.Clear();

                    LogicaTipoUsuario lgTipoUsu = new LogicaTipoUsuario();
                    dlTipoUsuario.DataSource = lgTipoUsu.DataTableTipoUsu();
                    dlTipoUsuario.DataTextField = "tipo";
                    dlTipoUsuario.DataValueField = "id_tipo_usuario";
                    dlTipoUsuario.DataBind();
                    Session.Clear();
                    LogicaCiudad lgCiu = new LogicaCiudad();
                    int cod = int.Parse(dlDpto.SelectedValue.ToString());
                    dlCiudad.DataSource = lgCiu.DataTableCiudad(cod);
                    dlCiudad.DataTextField = "ciudad";
                    dlCiudad.DataValueField = "id_ciudad";
                    dlCiudad.DataBind();
                }
            }


        }
        protected void btnAtivador1_Click(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                ViewState["opciones"] = "1";
                btnAtivador1.CssClass = "btn btn-danger btn-lg ";
                btnAtivador2.CssClass = "btn btn-link btn-lg ";
                btnAtivador1.ForeColor = Color.White;
                btnAtivador2.ForeColor = Color.Gray;

            }


        }

        protected void btnAtivador2_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ViewState["opciones"] = "2";
                btnAtivador1.CssClass = "btn btn-link btn-lg ";
                btnAtivador2.CssClass = "btn btn-danger btn-lg ";
                btnAtivador2.ForeColor = Color.White;
                btnAtivador1.ForeColor = Color.Gray;

            }


        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string Opcion;
            Usuario = LgUsuario.Login(txtPass.Text, txtEMail.Text);
            if (Usuario != null)
            {
                Session["Usuario"] = Usuario;
                if (ViewState["opciones"] == null)
                {
                    Opcion = "1";
                }
                else
                {
                    Opcion = ViewState["opciones"].ToString();
                }

                switch (Opcion)
                {
                    case "1":
                        Session["TipoUsuario"] = "1";
                        Response.Redirect("IndexSuscriptor.aspx");
                        break;
                    case "2":
                        ViewState["opciones"] = "2";
                        btnAtivador1.CssClass = "btn btn-link btn-lg ";
                        btnAtivador2.CssClass = "btn btn-danger btn-lg ";
                        btnAtivador2.ForeColor = Color.White;
                        btnAtivador1.ForeColor = Color.Gray;
                        Session["TipoUsuario"] = "2";
                        Response.Redirect("IndexPropietario.aspx");
                        break;
                    default:
                        btnEntrar.Text = "1";
                        break;

                }
            }
            else
            {
                Response.Write("el usuario no exite");
            }


        }



        protected void dlDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogicaCiudad lgCiu = new LogicaCiudad();
            int cod = int.Parse(dlDpto.SelectedValue.ToString());
            dlCiudad.DataSource = lgCiu.DataTableCiudad(cod);
            dlCiudad.DataTextField = "ciudad";
            dlCiudad.DataValueField = "id_ciudad";
            dlCiudad.DataBind();
            HyperLink3_ModalPopupExtender.Show();

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                LogicaUsuario lgusuario = new LogicaUsuario();
                HttpFileCollection file = Request.Files;
                for (int i = 0; i <= file.Count - 1; i++)
                {

                    HttpPostedFile postefile = file[i];
                    String[] nombres = new String[file.Count - 1];
                    if (postefile.ContentLength > 0)
                    {

                        postefile.SaveAs(Server.MapPath(@"media\img\") + Path.GetFileName(postefile.FileName));
                        csUsuario user = new csUsuario(0, txtNom1.Text, txtNom2.Text, txtApe1.Text, txtApe2.Text, txtCorreo.Text, postefile.FileName.ToString(), txtDir.Text, txtFechaNac.Text, int.Parse(txtTelefono.Text), int.Parse(txtNumDoc.Text), int.Parse(dlTipoDoc.SelectedValue.ToString()), int.Parse(dlCiudad.SelectedValue.ToString()), txtContraseña.Text);

                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }

        }
    }
}