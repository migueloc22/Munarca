using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class geoNegocioSuscriptor : System.Web.UI.Page
    {
        LogicaNegocio lgNEgocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    LogicaUbicacion lgNEgocio = new LogicaUbicacion();
            //    List<csUbicacion> listUbicacion = lgNEgocio.ListarUbicacion(4.69982544, -74.0550546);
            //    dtUbicaion.DataSource = listUbicacion.OrderBy(v => v.distancia);
            //    dtUbicaion.DataBind();
            //}
            rpUbicacion.ItemCommand += rpUbicacion_ItemCommand;

        }

        void rpUbicacion_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lgNEgocio = new LogicaNegocio();
            csNegocio negocio;
            if (e.CommandName == "btnUbicacion")
            {
                String id_negocio = ((LinkButton)e.CommandSource).CommandArgument;
                negocio= lgNEgocio.SessionNegocio(int.Parse( id_negocio));
                txtLan2.Text=negocio.latitud;
                txtlon2.Text=negocio.longitud;
            }
        }

        protected void btnUbicacion_Click(object sender, EventArgs e)
        {

        }

        protected void lkNegocio_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lgNEgocio = new LogicaNegocio();
                List<csNegocio> listUbicacion = lgNEgocio.listarUbicacion(double.Parse(txtLat.Text.ToString()), double.Parse(txtLon.Text.ToString()));
                //List<csUbicacion> listUbicacion = lgNEgocio.ListarUbicacion(4.69982544, -74.0550546);
                rpUbicacion.DataSource = listUbicacion.OrderBy(v => v.distancia);
                rpUbicacion.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}