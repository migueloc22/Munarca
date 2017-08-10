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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Negocio"] != null)
            {
                negocio = (csNegocio)Session["Negocio"];
                lbNombre.Text = negocio.nombre;
                lbDescrip.Text = negocio.descripcion;
            }
            else
            {
                Response.Redirect("IndexPropietario.aspx");
            }
        }
        protected string obtenerDatos() {
            DataTable datos = new DataTable();
            datos.Columns.Add(new DataColumn("tareas", typeof(string)));
            datos.Columns.Add(new DataColumn("Hours per Day", typeof(string)));
            datos.Rows.Add(new object[]{"work",11});
            datos.Rows.Add(new object[] { "eat", 2 });
            datos.Rows.Add(new object[] { "comunete", 2 });
            datos.Rows.Add(new object[] { "slep", 7});
            datos.Rows.Add(new object[] { "watch tv", 2 });

            string strDatos = "[['Task', 'Hours per Day'],";

            foreach (DataRow dr in datos.Rows) {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'"+dr[0]+"'"+","+dr[1];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos +"]";
        return strDatos;

        }
    }
}