using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class ModificarNegocioPropietario : System.Web.UI.Page
    {
        csNegocio negocio;
        LogicaNegocio lgNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["SessionNegocio"] != null)
            {

                if (!IsPostBack)
                {
                    LogicaCategoria lgCategoria;
                    lgCategoria = new LogicaCategoria();
                    dpCategoria.DataSource = lgCategoria.Listar();
                    dpCategoria.DataTextField = "categoria";
                    dpCategoria.DataValueField = "id_categoria";
                    dpCategoria.DataBind();
                    negocio= (csNegocio)Application["SessionNegocio"];
                    txtDesccrip.Text = negocio.descripcion;
                    txtLat.Text = negocio.latitud;
                    txtLon.Text = negocio.longitud;
                    txtNombre.Text = negocio.nombre;
                    txtTelefono.Text = negocio.telefono.ToString();
                    txtUbicacion.Text = negocio.ubicacion;
                    lbId_negocio.Text = negocio.id_negocio.ToString();
                    dpCategoria.SelectedValue = negocio.fk_id_categoria.ToString();


                }
            }
            else
            {
                Response.Redirect("NegocioPropietario.aspx");
            }
        }

        protected void btnModificarNegocio_Click(object sender, EventArgs e)
        {
            try
            {
                lgNegocio=new LogicaNegocio();
                negocio = new csNegocio(int.Parse(lbId_negocio.Text), txtNombre.Text, txtDesccrip.Text, txtTelefono.Text, 0, int.Parse(dpCategoria.SelectedValue.ToString()), txtLon.Text, txtUbicacion.Text, txtLat.Text);
                if (lgNegocio.ModificarNegocio(negocio))
                {
                    Button2_ModalPopupExtender.Show();
                }
                else { }
            }
            catch (Exception ex)
            {
                
                Response.Write(ex.ToString());
            }
        }
    }
}