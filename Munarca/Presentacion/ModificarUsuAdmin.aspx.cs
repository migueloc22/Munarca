using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class ModificarUsuAdmin : System.Web.UI.Page
    {
        LogicaUsuario lgUsuario;
        csUsuario usuario;
        csUtilidades util;

        
        #region metodos
        private void cargarTipoUsu()
        {
            LogicaTipoUsuario lgUsu = new LogicaTipoUsuario();
            dlTipoUsuario.DataSource = lgUsu.DtTipoUsu();
            dlTipoUsuario.DataTextField = "tipo";
            dlTipoUsuario.DataValueField = "id_tipo_usuario";
            dlTipoUsuario.DataBind();
            
        }

        private void cargarTipoDoc()
        {
            LogicaTipoDocumento lgTipDoc = new LogicaTipoDocumento();
            dlTipoDoc.DataSource = lgTipDoc.DataTableTpDoc();
            dlTipoDoc.DataTextField = "tipo_doc";
            dlTipoDoc.DataValueField = "id_tipo_doc";
            dlTipoDoc.DataBind();

        }

        private void cargarCiudad() {
            LogicaCiudad lgCiu = new LogicaCiudad();
            int cod = int.Parse(dlDpto.SelectedValue.ToString());
            dlCiudad.DataSource = lgCiu.DataTableCiudad(cod);
            dlCiudad.DataTextField = "ciudad";
            dlCiudad.DataValueField = "id_ciudad";
            dlCiudad.DataBind();
        }
        private void cargarDepto() {
            LogicaDepartamento lgDpto = new LogicaDepartamento();
            dlDpto.DataSource = lgDpto.DataTableDpto();
            dlDpto.DataTextField = "departamento";
            dlDpto.DataValueField = "id_departamento";
            dlDpto.DataBind();            
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
            //mmsg.Bcc.Add("migueloc22@gmail.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = "<h1>Bienvenido a Munarca </h1></br>Nos alegra de que hayas decidido probar Munarca.</br> Aquí tienes tu <p style='color:grey, size:16px'>contraseña: </p> <p style='color:red'>"+ pass + "</p> Para cambiarla ingresa a configuración";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

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
            try
            {
                if (!IsPostBack)
                {
                    cargarDepto();
                    cargarCiudad();
                    cargarTipoUsu();
                    cargarTipoDoc();
                }
            }
            catch (Exception ex)
            {

                ltMensaje.Text = @"<div class='alert alert-danger alert-dismissable'>
                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                  <strong>Error!</strong> "+ex.Message+"</div>";
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string pass1, pass2;
                util = new csUtilidades();
                lgUsuario = new LogicaUsuario();
                pass1 = util.CrearPassword(10);
                pass2 = util.Encriptar(pass1);
                usuario = new csUsuario(0,txtNom1.Text,txtNom2.Text,txtApe1.Text,txtApe2.Text,txtCorreo.Text,"",txtDir.Text,txtFechaNac.Text,txtTelefono.Text,int.Parse(txtNumDoc.Text),int.Parse(dlTipoDoc.SelectedValue.ToString()),int.Parse(dlCiudad.SelectedValue.ToString()),pass2);
                if (lgUsuario.CrearUsuario(usuario, dlTipoUsuario.SelectedValue))
                {
                    ltMensaje.Text = @"<div class='alert alert-danger alert-dismissable'>
                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                  <strong>Error!</strong>Usuario Agregado</div>";
                    EnviarCorreo(pass2, txtCorreo.Text);
                }
                else {
                    ltMensaje.Text = @"<div class='alert alert-danger alert-dismissable'>
                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                  <strong>Error!</strong>El Usuario no fue agregado</div>";
                }

            }
            catch (Exception ex)
            {
                
               ltMensaje.Text = @"<div class='alert alert-danger alert-dismissable'>
                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                  <strong>Error!</strong> "+ex.Message+"</div>";
            }
        }
    }
}