using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GMaps;
using Subgurim.Controles;

namespace Presentacion
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //GMap1.setCenter(new GLatLng(40.7127837, -74.00594130000002), 5);

            //GMap1.mapType = GMapType.GTypes.Hybrid;
            //GMap1.addMapType(GMapType.GTypes.Physical);
            //GMap1.addControl(new GControl(GControl.preBuilt.MapTypeControl));
            //GMap1.enableRotation = true;
            GMap1.setCenter(new GLatLng(41, 3), 3);

            GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));

            GMarker m1 = new GMarker(new GLatLng(41, 3));

            MarkerManager mManager = new MarkerManager();
            mManager.Add(m1, 2);

            List<GMarker> mks = new List<GMarker>();
            List<GInfoWindow> iws = new List<GInfoWindow>();

            Random r = new Random();
            GMarker mkr;
            for (int i = 0; i < 5; i++)
            {
                double ir1 = r.Next(40) / 10.0 - 2.0;
                double ir2 = r.Next(40) / 10.0 - 2.0;

                mkr = new GMarker(m1.point + new GLatLng(ir1, ir2));
                mks.Add(mkr);

                GMap1.Add(new GListener(mkr.ID, GListener.Event.click, "function(){alert('" + i + "');}"));
            }

            for (int i = 0; i < 5; i++)
            {
                double ir1 = r.Next(40) / 20.0 - 1;
                double ir2 = r.Next(40) / 20.0 - 1;

                mkr = new GMarker(m1.point + new GLatLng(ir1, ir2));
                GInfoWindow window = new GInfoWindow(mkr, i.ToString());
                iws.Add(window);
            }

            mManager.Add(mks, 5, 6);
            mManager.Add(iws, 7, 8);

            GMap1.markerManager = mManager;
        }

        protected string GMap1_Click(object s, GAjaxServerEventArgs e)
        {
            return default(string);
        }
    }
}