using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class loginAdmin : System.Web.UI.Page
    {
        LogicaUsuario lgusuario = new LogicaUsuario();
        LogicaEstadoUsuario lgesUsu = new LogicaEstadoUsuario();
        csUsuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            usuario = lgusuario.Login(txtPass.Text, txtCorreo.Text);
            if (usuario != null)
            {
                Session ["Usuario"] = usuario;
                Response.Redirect("IndexAdmin.aspx");
                
            }
            else
            {
                lbValidar.Text = "El usuario no existe";
            }
        }

       
    }
}