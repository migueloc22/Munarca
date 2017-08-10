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
    public partial class CrearServicioPropietario : System.Web.UI.Page
    {
        LogicaServicio lgServicio;
        csServicio servicio;
        csNegocio negocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            negocio = (csNegocio)Session["Negocio"];
            lgServicio = new LogicaServicio();            
            DateTime time= DateTime.Now;
            string fecha = time.Date.ToString("yyyy-MM-dd");
            //string hora = time.TimeOfDay.ToString("HH:mm");
            string hora = "14:05:12";
            HttpFileCollection file = Request.Files;
            for (int i = 0; i <= file.Count - 1; i++)
            {

                HttpPostedFile postefile = file[i];
                String[] nombres = new String[file.Count - 1];
                if (postefile.ContentLength > 0)
                {
                    
                    postefile.SaveAs(Server.MapPath(@"media\img\") + Path.GetFileName(postefile.FileName));
                    servicio = new csServicio(0, txtNombre.Text, txtDescripcion.Text, postefile.FileName.ToString(), fecha, hora, int.Parse(txtValor.Text), negocio.id_negocio);
                    if (lgServicio.CrearServicio(servicio))
                    {
                        Button2_ModalPopupExtender.Show();
                    }
                    
                }
            }
            
            
            
        }
    }
}