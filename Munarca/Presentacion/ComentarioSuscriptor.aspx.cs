using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class ComentarioSuscriptor : System.Web.UI.Page
    {
        LogicaComentario lgComentario;
        csNegocio negocio;
        csUsuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
            {
                    lgComentario = new LogicaComentario();
                    usuario = (csUsuario)Session["Usuario"];
                    negocio = (csNegocio)Session["SessionNegocio"];
                    dtComentario.DataSource = lgComentario.DataComentario(negocio.id_negocio);
                    dtComentario.DataBind();
                    ViewState["opcion"] = 1;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            
            
            
            
        }

        protected void btnComentario_Click(object sender, EventArgs e)
        {
            
            lgComentario = new LogicaComentario();
            usuario = (csUsuario)Session["Usuario"];
            negocio = (csNegocio)Session["SessionNegocio"];
                    
            int opcion = int.Parse(ViewState["opcion"].ToString());
            if (opcion==1)
            {
                csComentario comentario = new csComentario(0, txtComentario.Text, "", "", usuario.id_usuario, negocio.id_negocio);    
                lgComentario.CrearComentario(comentario);
                dtComentario.DataSource = lgComentario.DataComentario(negocio.id_negocio);
                dtComentario.DataBind();
                txtComentario.Text = "";
            }
            else
            {
                int idComentario = int.Parse(ViewState["idComentario"].ToString());
                if (idComentario!=0)
                {
                    lbVdComentario.Text = "";
                    csComentario comentario = new csComentario(idComentario, txtComentario.Text, "", "", usuario.id_usuario, negocio.id_negocio);
                    lgComentario.ModificarComentario(comentario);
                    dtComentario.DataSource = lgComentario.DataComentario(negocio.id_negocio);
                    dtComentario.DataBind();
                    txtComentario.Text = "";
                    ViewState["opcion"] = 1;
                    dlComentario.SelectedValue = "1";
                    dtComentarioMod.Visible = false;
                    dtComentario.Visible = true;
                }

                else
                {
                    lbVdComentario.Text = "Seleccione un comentario...";
                }
            }
        }

        protected void dlComentario_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuario = (csUsuario)Session["Usuario"];
            negocio = (csNegocio)Session["SessionNegocio"];
            lgComentario = new LogicaComentario();
            if (dlComentario.SelectedValue.ToString() == "1") 
            {       
                
                dtComentario.DataSource = lgComentario.DataComentario(negocio.id_negocio);
                dtComentario.DataBind();
                ViewState["opcion"] = 1;
                dtComentarioMod.Visible = false;
                dtComentario.Visible = true;
            }
            else
            {
                dtComentarioMod.Visible = true;
                dtComentario.Visible = false;
                dtComentarioMod.DataSource = lgComentario.DataComentario(negocio.id_negocio, usuario.id_usuario);
                dtComentarioMod.DataBind();
                ViewState["opcion"] = 2;
            }
        }

        

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            Label lb = (Label)item.FindControl("lbIdComentario");
            Label lb2 = (Label)item.FindControl("lbComentario");
            txtComentario.Text =  lb2.Text;
            ViewState["idComentario"] = lb.Text;
            
        }

        
    }
}