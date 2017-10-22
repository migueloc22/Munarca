using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class GestionCategorias : System.Web.UI.Page
    {
        LogicaCategoria lgcategoria;
        private void filter()
        {
            LogicaCategoria lgCategoria = new LogicaCategoria();
            gvCategorias.DataSource = lgCategoria.Listar();
            //GvUsuario.DataSource = lgUsu.BuscarUsu(txtBuscador.Text);
            gvCategorias.DataBind();
        }   
        

        protected void Page_Load(object sender, EventArgs e)
        {
            filter();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lgcategoria = new LogicaCategoria();
          if (lgcategoria.crearCategoria(txtNomCategoria.Text))
            {
                lbMensaje.Text = "Categoria Agregada";
                
            }
          else
          {
              lbMensaje.Text = "La Categoria no fue agregada";
          }
        }

        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod = int.Parse(gvCategorias.SelectedDataKey.Values[0].ToString());
            txtNomCategoria.Text = cod.ToString();

        }
    }
}