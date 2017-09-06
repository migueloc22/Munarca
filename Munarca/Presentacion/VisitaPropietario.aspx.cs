using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;

namespace Presentacion
{
    public partial class VisitaPropietario : System.Web.UI.Page
    {
        csNegocio negocio;
        #region metodos
        public String datosGrafica() {
            negocio = (csNegocio)Session["Negocio"];
            LogicaVisita lgVisita = new LogicaVisita();
            DataTable datos = lgVisita.LineaTeiempoVisita(negocio.id_negocio);

            string strDatos;
            strDatos = "[";
           
            foreach (DataRow dr in datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "" + dr[0] + "" + "," +
                dr[1].ToString().Replace(",", ".");
                strDatos = strDatos + "],";

            }
            strDatos = strDatos + "]";
            return strDatos;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Negocio"] != null)
            {
                LogicaPath lgPath = new LogicaPath();
                negocio = (csNegocio)Session["Negocio"];
                Repeater1.DataSource = lgPath.DataTbPath(negocio.id_negocio); ;
                Repeater1.DataBind();
                lbNombre.Text = negocio.nombre;
                lbDescrip.Text = negocio.descripcion;
                lbTelefono.Text = negocio.telefono.ToString();
                lbUbicacion.Text = negocio.ubicacion;
            }
            else
            {
                Response.Redirect("IndexPropietario.aspx");
            }
        }
       
    }
}