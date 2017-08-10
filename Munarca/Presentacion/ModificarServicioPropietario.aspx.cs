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
    public partial class ModificarServicioPropietario : System.Web.UI.Page
    {
        csServicio servicio;
        LogicaServicio lgServicio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                servicio = (csServicio)Application["SessionServicio"];
                txtNombre.Text = servicio.nombre;
                txtDescripcion.Text = servicio.descripcion;
                txtValor.Text = servicio.valor.ToString();
                lbImagen.Text = servicio.imagen;
                ViewState["codServicio"] = servicio.id_servicio;
            }
            
        }

        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lgServicio = new LogicaServicio();
            HttpFileCollection file = Request.Files;
            for (int i = 0; i <= file.Count - 1; i++)
            {

                HttpPostedFile postefile = file[i];
                String[] nombres = new String[file.Count - 1];
                if (postefile.ContentLength > 0)
                {

                    postefile.SaveAs(Server.MapPath(@"media\img\") + Path.GetFileName(postefile.FileName));
                    servicio = new csServicio(int.Parse(ViewState["codServicio"].ToString()), txtNombre.Text, txtDescripcion.Text, postefile.FileName.ToString(), null, null, int.Parse(txtValor.Text), 0);
                    if (lgServicio.ModificarServicio2(servicio))
                    {
                        Button2_ModalPopupExtender.Show();
                    }

                }
                else
                {


                    servicio = new csServicio(int.Parse(ViewState["codServicio"].ToString()), txtNombre.Text, txtDescripcion.Text, lbImagen.Text, null, null, int.Parse(txtValor.Text), 0);
                    if (lgServicio.ModificarServicio2(servicio))
                    {
                        Button2_ModalPopupExtender.Show();
                    }

                }
            }
        }
    }
}