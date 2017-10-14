using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class UsusarioAdminn : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null && Session["TipoUsuario"] != null)
            {
                //hhjh
                csUsuario user = (csUsuario)Session["Usuario"];
                imgUer.ImageUrl = user.foto;
                imgUser2.ImageUrl = user.foto;
                lbEmail.Text = user.correo;
                lbNombre2.Text = user.nombre1 + " " + user.apellido1;
                lbNombre.Text = user.nombre1;
                switch (Session["TipoUsuario"].ToString())
                {
                    case "2":
                        Response.Redirect("IndexSuscriptor.aspx"); 
                        break;
                    case "1":
                        Response.Redirect("IndexPropietario.aspx"); 
                        break;
                    default:
                        
                        break;
                }
            }
        }
        protected void btnCerrarSession_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }
    }
}