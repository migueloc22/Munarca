using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace Presentacion
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        csUsuario User;
        protected void Page_Load(object sender, EventArgs e)
        {
            //lbTipoUser.Text = "hola";
            if (Session["Usuario"] != null && Session["TipoUsuario"] != null)
            {
                  //User= (csUsuario)Session["Usuario"];
                  //lbTipoUser.Text = User.nombre1+" "+User.apellido1;
                switch (Session["TipoUsuario"].ToString())
                {
                    case "1":
                        //lbTipoUser.Text = "Propietario";
                        break;
                    case "2":
                        //lbTipoUser.Text = "Suscriptor";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("Index.aspx");
            }
        }
    }
}