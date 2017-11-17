using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class IndexNegocioPropietario : System.Web.UI.Page
    {
        csNegocio negocio;
        csCalificacion calificacion;
        LogicaServicio lgServicio;
        LogicaVisita lgVisita;
        LogicaComentario lgComentario;
        LogicaNegocio lgNegocio;
        LogicaPath lgPaht;
        LogicaCalificacion lgCalificacion;
        csUsuario usuario;
        #region metodos

        private void CargarGrid()
        {
            csUtilidades util = new csUtilidades();
            int codNegocio = int.Parse(util.desencriptar(Request.Params["show"]));
            lgServicio = new LogicaServicio();
            gvServicio.DataSource = lgServicio.ListarSErvicio(codNegocio);
            gvServicio.DataBind();
        }
        protected string obtenerDatos()
        {
            string strDatos="";
            try
            {
                csUtilidades util = new csUtilidades();

                DataTable datos = new DataTable();
                LogicaVisita lgVisita = new LogicaVisita();
                datos = lgVisita.LineaTeiempoVisita(int.Parse(util.desencriptar(Request.Params["show"])));
                ////string strDatos = "[['Negocio', 'Visita'],";
                //datos.Columns.Add(new DataColumn("año", typeof(string)));
                //datos.Columns.Add(new DataColumn("java", typeof(string)));
                //datos.Columns.Add(new DataColumn("c#", typeof(string)));
                //datos.Columns.Add(new DataColumn("phyton", typeof(string)));
                //datos.Columns.Add(new DataColumn("javascript", typeof(string)));
                //datos.Rows.Add(new Object[] {"new Date(2015,5,6)",15,2.8,5.7,3.6});
                //datos.Rows.Add(new Object[] { "new Date(2016,1,2)", 21, 4.4, 5.4, 3.9});
                //datos.Rows.Add(new Object[] { "new Date(2017,4,6)", 14.6, 3.5, 3.6, 3.0});
                
                strDatos = "[";

                //foreach (DataRow dr in datos.Rows)
                //{
                //    strDatos = strDatos + "[";
                //    strDatos = strDatos + "" + dr[0] + "" + "," + 
                //    dr[1].ToString().Replace(",",".")+","+
                //    dr[2].ToString().Replace(",",".")+","+
                //    dr[3].ToString().Replace(",",".")+","+
                //    dr[4].ToString().Replace(",",".");
                //    strDatos = strDatos + "],";
                //}
                foreach (DataRow dr in datos.Rows)
                {
                    strDatos = strDatos + "[";
                    strDatos = strDatos + "" + dr[0] + "" + "," +
                    dr[1].ToString().Replace(",", ".");
                    strDatos = strDatos + "],";
                }
                strDatos = strDatos + "]";
                
            }
            catch (Exception ex)
            {

                ltError.Text = ex.Message;
            }
            return strDatos;

        }
        //private void CargarChart()
        //{
        //    csUtilidades util = new csUtilidades();
        //    lgVisita = new LogicaVisita();
        //    int codNegocio = int.Parse(util.desencriptar(Request.Params["show"]));
        //    Chart1.DataSource = lgVisita.LineaTeiempoVisita(codNegocio);
        //    //Chart1.Series["Series1"].Points.DataBindXY("numero", "Tiempo");
        //    Chart1.Series["Series1"].XValueMember = "numero";
        //    Chart1.Series["Series1"].YValueMembers = "Tiempo";
        //    Chart1.DataBind();
        //}
        private void CargarGaleria(int cod)
        {
            lgPaht = new LogicaPath();
            rpGaleria.DataSource = lgPaht.DataTbPath(cod);
            rpGaleria.DataBind();
        }
        private void CargarComment(int cod)
        {
            lgComentario = new LogicaComentario();
            dtListComentario.DataSource = lgComentario.DataComentario(cod);
            dtListComentario.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Params["show"] != null)
                {

                    btnAgregarSv.NavigateUrl = "CrearServicioPropietario.aspx?show=" + Request.Params["show"].ToString();
                    //int codUser = int.Parse(Request.Params["show"].ToString());
                    if (Request.Params["show"].Length > 0)
                    {
                        csUtilidades util = new csUtilidades();
                        lgNegocio = new LogicaNegocio();
                        lgCalificacion = new LogicaCalificacion();
                        ////lgVisita = new LogicaVisita();
                        int codNegocio = int.Parse(util.desencriptar(Request.Params["show"]));
                        linkMulmedia.NavigateUrl = "AlbumNegocioPropietario.aspx?show=" + Request.Params["show"].ToString();
                        negocio = new csNegocio();
                        negocio = lgNegocio.SessionNegocio(codNegocio);
                        if (negocio != null)
                        {
                            int calificacion = int.Parse(lgCalificacion.PromedioCalificacion(negocio.id_negocio).ToString());
                            CargarGaleria(codNegocio);
                            lbNombreNeg.Text = negocio.nombre;
                            Rating1.CurrentRating =calificacion;
                            CargarGrid();
                            //CargarChart();
                            CargarComment(codNegocio);
                            foto_Negocio.ImageUrl = negocio.foto_negocio;
                            hdLat.Value = negocio.latitud;
                            hdLong.Value = negocio.longitud;
                            lbRating.Text = calificacion.ToString();
                            lbDescripcion.Text = negocio.descripcion;
                            Application["negocio"] = negocio;
                        }
                        else
                        {

                            pnContenido.Visible = false;
                            ltError.Text = "hola";
                        }


                    }
                    else
                    {
                        Response.Redirect("IndexPropietario.aspx");
                    }

                }
                else
                {
                    Response.Redirect("IndexPropietario.aspx");
                }
            }
            catch (Exception ex)
            {
                pnContenido.Visible = false;
                ltError.Text = ex.Message;
            }
        }
        protected void gvServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int codServicio = int.Parse(gvServicio.SelectedDataKey.Values[0].ToString());
                //lgServicio = new LogicaServicio();
                //Application["SessionServicio"] = lgServicio.SessionServicio(codServicio);
                Response.Redirect("ModificarServicioPropietario.aspx?show=" + Request.Params["show"]+"&service="+codServicio);
            }
            catch (Exception ex)
            {
                
                ltError.Text=ex.Message;
            }
            
        }

        protected void gvServicio_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codServicio = int.Parse(gvServicio.DataKeys[e.RowIndex].Value.ToString());
            ViewState["codServicio"] = codServicio;            
            btnNodal_ModalPopupExtender.Show();

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            csUtilidades util = new csUtilidades();
            lgServicio = new LogicaServicio();
            int codServicio = int.Parse(ViewState["codServicio"].ToString());
            if (lgServicio.EliminarServicio(codServicio))
            {
                CargarGrid();
            }
        }
    }
}