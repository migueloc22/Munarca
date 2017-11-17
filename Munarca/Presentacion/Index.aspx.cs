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
        csUtilidades util;
        #region Metodos


        //metodo para cargar datos a la lista
        private void cargarTipoUsu()
        {
            LogicaTipoUsuario lgUsu = new LogicaTipoUsuario();
            drListUsu.DataSource = lgUsu.DtTipoUsu();
            drListUsu.DataTextField = "tipo";
            drListUsu.DataValueField = "id_tipo_usuario";
            drListUsu.DataBind();


        }
        private void cargarTpDoc()
        {
            LogicaTipoDocumento lgTpDoc = new LogicaTipoDocumento();
            dlTipoUsuario.DataSource = lgTpDoc.DataTableTpDoc();
            dlTipoUsuario.DataTextField = "tipo_doc";
            dlTipoUsuario.DataValueField = "id_tipo_doc";
            dlTipoUsuario.DataBind();
        }
        private void cargarTpUsu()
        {
            LogicaTipoUsuario lgUsu = new LogicaTipoUsuario();
            dlTipoDoc.DataSource = lgUsu.DataTableTipoUsu();
            dlTipoDoc.DataTextField = "tipo";
            dlTipoDoc.DataValueField = "id_tipo_usuario";
            dlTipoDoc.DataBind();


        }
        private void cargarCiudad()
        {
            LogicaCiudad lgCiu = new LogicaCiudad();
            int cod = int.Parse(dlDpto.SelectedValue.ToString());
            dlCiudad.DataSource = lgCiu.DataTableCiudad(cod);
            dlCiudad.DataTextField = "ciudad";
            dlCiudad.DataValueField = "id_ciudad";
            dlCiudad.DataBind();
        }
        private void cargarDepartamento()
        {
            LogicaDepartamento lgDpto = new LogicaDepartamento();
            dlDpto.DataSource = lgDpto.DataTableDpto();
            dlDpto.DataTextField = "departamento";
            dlDpto.DataValueField = "id_departamento";
            dlDpto.DataBind();
        }
        private void limpiarRegistro()
        {
            txtNom1.Text = "";
            txtNom2.Text = "";
            txtApe1.Text = ""; txtApe2.Text = "";
            txtCorreo.Text = "";
            txtDir.Text = "";
            txtFechaNac.Text = "";
            txtTelefono.Text = "";
            txtNumDoc.Text = "";
            lbRepuesta.Text = "";
            cargarTipoUsu();
            cargarTpUsu();
            cargarDepartamento();
            cargarCiudad();
            cargarTpDoc();


        }
        public void EnviarCorreo(string pass, string correo)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(correo);

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Munarca_Contraseña";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("munarca1@gmail.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = "Hola nuevo Usuario su contraseña es :(" + pass + ") Podra cambia contraseña y la foto de perfil en configuraciones";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("munarca1@gmail.com");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("munarca1@gmail.com", "munarca123");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail




            cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";
            cliente.Port = 587;
            cliente.EnableSsl = true;


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                Response.Write(ex.ToString());
            }
        }
        #endregion
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
                    try
                    {
                        cargarTpUsu();
                        cargarTpDoc();
                        cargarTipoUsu();
                        cargarDepartamento();
                        cargarCiudad();
                        Session.Clear();
                    }
                    catch (Exception ex)
                    {
                        
                        lbValidacionUser.Text=ex.Message;
                    }
                    
                }
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
                util = new csUtilidades();
                LogicaUsuario lgusuario = new LogicaUsuario();
                //if (lgusuario.validarCorreo(txtCorreo.Text))
                //{
                    String pass = util.CrearPassword(10);
                    String pass2 = util.Encriptar(pass);
                    csUsuario user = new csUsuario(0, txtNom1.Text, txtNom2.Text, txtApe1.Text, txtApe2.Text, txtCorreo.Text, "user.png", txtDir.Text, "1997/01/15", txtTelefono.Text, int.Parse(txtNumDoc.Text), int.Parse(dlTipoDoc.SelectedValue.ToString()), int.Parse(dlCiudad.SelectedValue.ToString()), pass2);
                    Boolean resultado = lgusuario.CrearUsuario(user, dlTipoUsuario.SelectedValue.ToString());
                    if (resultado)
                    {
                        EnviarCorreo(pass, txtCorreo.Text);
                        limpiarRegistro();
                        Button1_ModalPopupExtender.Show();
                    }
                    else
                    {
                        ltMensaje.Text = @"<div class='alert alert-danger'>
                                <strong>No se registro La usuario</strong> Su contraseña sera enviada a su correo electronio.
                            </div>";
                    }
                //}
                //else
                //{
                //    HyperLink3_ModalPopupExtender.Show();
                //    lbRepuesta.Text = "Correo ya existe";
                //}
                

            }
            catch (Exception ex)
            {

                ex.ToString();
            }

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                util = new csUtilidades();
                LgUsuario = new LogicaUsuario();
                Usuario = LgUsuario.Login(util.Encriptar(txtPass.Text), txtEMail.Text);
                if (Usuario != null)
                {
                    if (estadoUser.Validar(Usuario.id_usuario, int.Parse(drListUsu.SelectedValue.ToString())))
                    {
                        Session["Usuario"] = Usuario;
                        switch (drListUsu.SelectedValue.ToString())
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
                        lbValidacionUser.Text = "Tipo de usuario invalido";
                    }
                }
                else
                {
                    lbValidacionUser.Text = "Usuario o contraseña incorrecto";
                }
            }
            catch (Exception ex)
            {

                lbValidacionUser.Text = (ex.Message);
            }

        }

    }
}