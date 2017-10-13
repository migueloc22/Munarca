using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class UsuarioSuscriptor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null && Session["TipoUsuario"] != null)
            {
                csUsuario user = (csUsuario)Session["Usuario"];
                imgUer.ImageUrl = user.foto;
                imgUser2.ImageUrl = user.foto;
                lbEmail.Text = user.correo;
                lbNombre2.Text = user.nombre1 + " " + user.apellido1;
                lbNombre.Text = user.nombre1;
                switch (Session["TipoUsuario"].ToString())
                {
                    case "2":
                        break;
                    case "1":
                        Response.Redirect("IndexPropietario.aspx"); ;
                        break;
                    default:
                        Response.Redirect("IndexAdmin.aspx");
                        break;
                }
            }
        }

        protected void btnCerrarSession_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }

        

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Response.Redirect("Index.aspx");
        //}
    }
}