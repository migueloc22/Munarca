using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{


    public partial class CrearNegocioPropietario : System.Web.UI.Page
    {
        List<csUbicacion> listarUbicacion;
        csUbicacion Ubicacion;
        csUsuario Usuario;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!IsPostBack)
            {
                LogicaCategoria lgCategoria;
                lgCategoria = new LogicaCategoria();
                dpCategoria.DataSource = lgCategoria.Listar();
                dpCategoria.DataTextField = "categoria";
                dpCategoria.DataValueField = "id_categoria";
                dpCategoria.DataBind();
                gvUbicacion.DataSource = this.ObtenerNuevaLista();
                gvUbicacion.DataBind();
            }

        }
        private List<csUbicacion> ObtenerNuevaLista()
        {
            List<csUbicacion> lista =new List<csUbicacion>();
            csUbicacion csUbicacion = new csUbicacion(0, "ewqe", "sada", 0, "daadsw ");
            lista.Add(csUbicacion);
            return lista;
        }

        private List<csUbicacion> ObtnerLista()
        {
            if (Session["lista"]==null)
            {
                return this.ObtenerNuevaLista();
                
            }
            else
            {
                return (List<csUbicacion>)Session["Lista"];
            }
        }
        private List<csUbicacion> GuardarLista(csUbicacion Ubicacion )
        {
            if (Session["lista"] == null)
            {
                List<csUbicacion> lista = this.ObtenerNuevaLista();
                lista.Add(Ubicacion);
                Session["Lista"] = lista;

            }
            else
            {
                List<csUbicacion> lista = (List<csUbicacion>)Session["Lista"];
                lista.Add(Ubicacion);
                Session["Lista"] = lista;
            }
            return (List<csUbicacion>)Session["Lista"];
        }
        protected void btnAgregarUbicacion_Click(object sender, EventArgs e)
        {
            Ubicacion = new csUbicacion(0, txtLat.Text, txtLon.Text, 0, txtUbicacion.Text);         
            
            this.GuardarLista(Ubicacion);
            gvUbicacion.DataSource =this.ObtnerLista();
            gvUbicacion.DataBind();
        }

        protected void btnAgregarNegocio_Click(object sender, EventArgs e)
        {

            LogicaNegocio lgNegocio = new LogicaNegocio();
            csNegocio negocio = new csNegocio(0, txtNombre.Text, txtDesccrip.Text, int.Parse(txtTelefono.Text), 1, int.Parse(dpCategoria.SelectedValue.ToString()));
            Response.Write( lgNegocio.CrearNegocio(negocio));
        }

        //protected void btnAgregarNegocio_Click(object sender, EventArgs e)
        //{
        //    lgCategoria = new LogicaCategoria();
        //    dpDownCategoria.DataSource = lgCategoria.Listar();
        //    dpDownCategoria.DataTextField = "categoria";
        //    dpDownCategoria.DataSourceID = "id_categoria";
        //    dpDownCategoria.DataBind();
        //}
    }
}