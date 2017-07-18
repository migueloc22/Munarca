using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Negocio;

namespace Presentacion
{
    public partial class Index : System.Web.UI.Page
    {
        LogicaUsuario LgUsuario = new LogicaUsuario();
        LogicaEstadoUsuario estadoUser = new LogicaEstadoUsuario();
        csUsuario Usuario;
        protected void Page_Load(object sender, EventArgs e)
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
                
                Session.Clear();
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
    }
}