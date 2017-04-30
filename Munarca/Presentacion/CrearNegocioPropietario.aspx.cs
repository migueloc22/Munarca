using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.IO;

namespace Presentacion
{


    public partial class CrearNegocioPropietario : System.Web.UI.Page
    {
        List<csUbicacion> listarUbicacion;
        csUbicacion Ubicacion;
        csUsuario Usuario;
        csPath path;
        LogicaPath lgPath;
        csUbicacion ubicacion;
        LogicaUbicacion lgUbicacion;
        #region metodos
        private List<csUbicacion> ObtenerNuevaLista()
        {
            List<csUbicacion> lista = new List<csUbicacion>();
            //csUbicacion csUbicacion = new csUbicacion(0, "ewqe", "sada", 0, "daadsw ");
            //lista.Add(csUbicacion);
            return lista;
        }

        private List<csUbicacion> ObtnerLista()
        {
            if (Session["lista"] == null)
            {
                return this.ObtenerNuevaLista();

            }
            else
            {
                return (List<csUbicacion>)Session["Lista"];
            }
        }
        private List<csUbicacion> GuardarLista(csUbicacion Ubicacion)
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
       
        #endregion


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

        protected void btnAgregarUbicacion_Click(object sender, EventArgs e)
        {
            Ubicacion = new csUbicacion(0, txtLat.Text, txtLon.Text, 0, txtUbicacion.Text);

            this.GuardarLista(Ubicacion);
            gvUbicacion.DataSource = this.ObtnerLista();
            gvUbicacion.DataBind();
        }

        protected void btnAgregarNegocio_Click(object sender, EventArgs e)
        {

            LogicaNegocio lgNegocio = new LogicaNegocio();
            lgPath = new LogicaPath();
            csNegocio negocio = new csNegocio(0, txtNombre.Text, txtDesccrip.Text, int.Parse(txtTelefono.Text), 1, int.Parse(dpCategoria.SelectedValue.ToString()));
            int codNegoc=int.Parse(lgNegocio.CrearNegocio(negocio));
            if (codNegoc>0) 
            {
                HttpFileCollection file = Request.Files;
                for (int i = 0; i <= file.Count - 1; i++)
                {
                    
                    HttpPostedFile postefile = file[i];
                    String[] nombres = new String[file.Count - 1];
                    if (postefile.ContentLength>0)
                    {
                        postefile.SaveAs(Server.MapPath(@"media\img\") + Path.GetFileName(postefile.FileName));
                        path = new csPath(0, postefile.FileName, codNegoc);
                        lgPath.CrearPath(path);
                    }
                }
                listarUbicacion=(List<csUbicacion>)Session["Lista"];
                foreach (csUbicacion item in listarUbicacion)
                {
                    ubicacion = new csUbicacion(0, item.laptitup, item.longitup, codNegoc, item.ubicacion);
                    lgUbicacion = new LogicaUbicacion();
                    lgUbicacion.CrearUbicacion(ubicacion);
                }
                
            }
            else
            {

            }
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