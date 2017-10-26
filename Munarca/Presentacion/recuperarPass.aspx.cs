using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{

    public partial class recuperarPass : System.Web.UI.Page
    {

        LogicaUsuario lgUsuario;
     
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            //csUtilidades util = new csUtilidades();
            //lgUsuario = new LogicaUsuario();
            //String pass = util.CrearPassword(10);
            //String pass2 = util.Encriptar(pass);
            //if (lgUsuario.RecuperracionPass(txtCorreo.Text, pass2))
            //{
            //    EnviarCorreo(pass, txtCorreo.Text);
            //    lbRespuesta.Text = "Contaseña actulizada se renvio a su correo";
            //    txtCorreo.Text = "";

            //}
            //else
            //{
            //    lbRespuesta.Text = "No actualizo la contraseña...";
            //}
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            csUtilidades util = new csUtilidades();
            lgUsuario = new LogicaUsuario();
            String pass = util.CrearPassword(10);
            String pass2 = util.Encriptar(pass);
            if (lgUsuario.RecuperracionPass(txtCorreo.Text, pass2))
            {
                //EnviarCorreo(pass, txtCorreo.Text);
                lbRespuesta.Text = "Contaseña actulizada se renvio a su correo";
                txtCorreo.Text = "";

            }
            else
            {
                lbRespuesta.Text = "No actualizo la contraseña...";
            }
        }

        protected void btnEnviar_Click1(object sender, EventArgs e)
        {
            csUtilidades util = new csUtilidades();
            lgUsuario = new LogicaUsuario();
            String pass = util.CrearPassword(10);
            String pass2 = util.Encriptar(pass);
            if (lgUsuario.RecuperracionPass(txtCorreo.Text, pass2))
            {
                EnviarCorreo(pass, txtCorreo.Text);
                lbRespuesta.Text = "Contaseña actulizada se renvio a su correo";
                txtCorreo.Text = "";

            }
            else
            {
                lbRespuesta.Text = "No actualizo la contraseña...";
            }
        }
        #region Metodos
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
            mmsg.Body = "Hola  Usuario su contraseña es :(" + pass + ") Podra cambia contraseña en configuarciones";
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
        
    }
}