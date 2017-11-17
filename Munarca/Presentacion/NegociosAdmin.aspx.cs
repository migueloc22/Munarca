using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class NegociosAdmin : System.Web.UI.Page
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
            btnModificar.Visible = false;
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
            hdCodCategoria.Value=cod.ToString();
            GridViewRow row = gvCategorias.SelectedRow;
            string codigo = row.Cells[1].Text;
            btnModificar.Visible = true;
            txtNomCategoria.Text = codigo.ToString();

        }

        protected void gvCategorias_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            txtNomCategoria.Text = "hola";
        }

        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            txtNomCategoria.Text = "hola";
        }

        protected void gvCategorias_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            LogicaCategoria lgCategoria = new LogicaCategoria();
            int cod = Int32.Parse(gvCategorias.DataKeys[e.RowIndex].Value.ToString());
            if (lgCategoria.EliminarCategoria(cod.ToString()))
            {
                lbMensaje.Text = "Categoria Eliminada";
                filter();
            }
            else {
                lbMensaje.Text = "No se pudo eliminar la categoria";
            }


        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            LogicaCategoria lgCategoria = new LogicaCategoria();
            csCategoria categoria = new csCategoria(int.Parse(hdCodCategoria.Value),txtNomCategoria.Text);
            if (lgCategoria.ModificarCategoria(categoria))
            {
                lbMensaje.Text = "Categoria modificada";
                btnModificar.Visible = false;
                filter();
            }
            else {
                lbMensaje.Text = "No se pudo modificar la categoria";
            }
		 
	
            
        }
        }
    }
