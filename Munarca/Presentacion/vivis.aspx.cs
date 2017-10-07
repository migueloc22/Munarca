using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Net.Mail;
using System.Net;

namespace Presentacion
{
    public partial class vivis : System.Web.UI.Page
    {
        private string emisor;
        private string receptor;
        private string asunto;
        private string mensajazo;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void EnviarCorreo()
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add("macifuentes09@misena.edu.co");

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Asunto del correo";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("migueloc22@gmail.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = "Texto del contenio del mensaje de correo";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("migueloc22@gmail.com");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("migueloc22@gmail.com", "mac1120375190");

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
        protected void Button1_Click(object sender, EventArgs e)
        {

            csUtilidades util = new csUtilidades();
            //int lng=int.Parse(TextBox1.Text);
            //Label1.Text = util.CrearPassword(lng);
            //emisor = "migueloc22@gmail.com";
            //receptor = "migueloc22@gmail.com";
            //asunto = "nuevo password";
            String pass = util.CrearPassword(10);
            String pass2 = util.Encriptar(pass);
            //mensajazo = "su Contraseña Es " + pass2;
            ////La cadena "servidor" es el servidor de correo que enviará tu mensaje
            //string servidor = "smtp.gmail.com";
            //// Crea el mensaje estableciendo quién lo manda y quién lo recibe
            //MailMessage mensaje = new MailMessage(emisor.ToString(),receptor.ToString(),asunto.ToString(),mensajazo.ToString());
            ////Envía el mensaje.
            //SmtpClient cliente = new SmtpClient(servidor);
            ////Añade credenciales si el servidor lo requiere.
            //cliente.Credentials = CredentialCache.DefaultNetworkCredentials;
            //cliente.Send(mensaje);
            EnviarCorreo();
        }
    }
}