using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class CalificacionSuscriptor : System.Web.UI.Page
    {
        csCalificacion calificacion;
        LogicaCalificacion lgCalificacion;
        csNegocio negocio;
        csUsuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lgCalificacion = new LogicaCalificacion();
                negocio = (csNegocio)Session["SessionNegocio"];
                lbPorcentaje.Text =  lgCalificacion.PromedioCalificacion(negocio.id_negocio).ToString();
            }
        }

        protected void btnCalificar_Click(object sender, EventArgs e)
        {
            usuario = (csUsuario)Session["Usuario"];
            negocio = (csNegocio)Session["SessionNegocio"];
            lgCalificacion = new LogicaCalificacion();
            
            try
            {
                DateTime tiempo = DateTime.Now;
                String fecha = tiempo.Date.ToString("yyyy-MM-dd");
                String hora = "14:07:07";
                calificacion = new csCalificacion(0, int.Parse(Rating1.CurrentRating.ToString()), fecha, hora, negocio.id_negocio, usuario.id_usuario);
                lgCalificacion.CrearCalificacion(calificacion);
                lbCalificacion.Text = Rating1.CurrentRating.ToString();
                lbPorcentaje.Text = lgCalificacion.PromedioCalificacion(negocio.id_negocio).ToString(); ;
            }
            catch (Exception ex)
            {
                
                lbCalificacion.Text=ex.ToString();
            }

            
        }
    }
}