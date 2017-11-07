using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Device.Location;
using Subgurim.Controles;
namespace Presentacion
{
    public partial class geoNegocioSuscriptor : System.Web.UI.Page
    {
        LogicaNegocio lgNEgocio;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            //string databaseFile = Server.MapPath("~/App_Data/GeoIP/GeoLiteCity.dat");
            //LookupService service = new LookupService(databaseFile);
            //Location location = service.getLocation(Request.UserHostAddress);

            
            if (!IsPostBack)
            {
            //    LogicaUbicacion lgNEgocio = new LogicaUbicacion();
            //    List<csUbicacion> listUbicacion = lgNEgocio.ListarUbicacion(4.69982544, -74.0550546);
            //    dtUbicaion.DataSource = listUbicacion.OrderBy(v => v.distancia);
            //    dtUbicaion.DataBind();
                //if (location!=null)
                //{
                //    hdLatFt.Value = location.latitude.ToString();
                //    hdLonft.Value = location.longitude.ToString();
                //}
                
            }
            //rpUbicacion.ItemCommand += rpUbicacion_ItemCommand;

        }

        void rpUbicacion_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lgNEgocio = new LogicaNegocio();
            csNegocio negocio;
            if (e.CommandName == "btnUbicacion")
            {
                //String id_negocio = ((LinkButton)e.CommandSource).CommandArgument;
                //negocio= lgNEgocio.SessionNegocio(int.Parse( id_negocio));
                //txtLan2.Text=negocio.latitud;
                //txtlon2.Text=negocio.longitud;
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
                //lgNEgocio = new LogicaNegocio();
                //List<csNegocio> listUbicacion = lgNEgocio.listarUbicacion(double.Parse(txtLat.Text.ToString()), double.Parse(txtLon.Text.ToString()));
                ////List<csUbicacion> listUbicacion = lgNEgocio.ListarUbicacion(4.69982544, -74.0550546);
                //rpUbicacion.DataSource = listUbicacion.OrderBy(v => v.distancia);
                //rpUbicacion.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            try
            {
                lgNEgocio = new LogicaNegocio();
                double latptitup = double.Parse(hdLatFt.Value);
                double longitup = double.Parse(hdLonft.Value);
                List<csNegocio> listaUbicaion = lgNEgocio.listarUbicacion(latptitup, longitup);
                dtNegosios.DataSource = listaUbicaion.OrderBy(v => v.distancia);
                dtNegosios.DataBind();
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }

        protected void btnNombre_Click(object sender, EventArgs e)
        {

        }

        protected void imgNegocio_Click(object sender, ImageClickEventArgs e)
        {

        }


    }
}