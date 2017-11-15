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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["perfil"]!=null)
            {
                lgUsuario = new LogicaUsuario();
                usuario = lgUsuario.SessioUsuario(int.Parse(Request.Params["perfil"]));
                Label1.Text = usuario.nombre1+" "+usuario.apellido1;
                Image1.ImageUrl = usuario.foto;
                lbNombres.Text = usuario.nombre1 + " " + usuario.apellido1;
                lbApellido1.Text = usuario.apellido1;
                lbApellido2.Text = usuario.apellido2;
                lbFecNac.Text = usuario.fecha_nacimiento;
                lbTpDoc.Text = "cc";
                lbNumDoc.Text = usuario.num_documento.ToString();
                lbEdad.Text = "24" + " " + "Años";
                lbDir.Text = usuario.direccion;
                lbTel.Text = usuario.telefono;
                lbTel.Text = usuario.correo;

                hLinkModificar.NavigateUrl = "ModificarUsuarioAdminn.aspx?perfil=" + Request.Params["perfil"];
            }
            else
            {
                Response.Redirect("BuscarUsuarioaspx.aspx");
            }
            
        }
    }
}