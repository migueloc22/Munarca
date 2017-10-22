using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class IndexNegocioSuscriptor : System.Web.UI.Page
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
        private void CargarGrid(csNegocio negocio)
        {
            //lgServicio = new LogicaServicio();
            //gvServicio.DataSource = lgServicio.ListarSErvicio(negocio.id_negocio);
            //gvServicio.DataBind();
        }
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
                    //int codUser = int.Parse(Request.Params["show"].ToString());
                    if (Request.Params["show"].Length > 0)
                    {
                        csUtilidades util = new csUtilidades();
                        lgNegocio = new LogicaNegocio();
                        lgCalificacion = new LogicaCalificacion();
                        lgVisita = new LogicaVisita();
                       
                        int codNegocio = int.Parse(util.desencriptar(Request.Params["show"]));
                        negocio = new csNegocio();
                        negocio = lgNegocio.SessionNegocio(codNegocio);
                        if (negocio != null)
                        {
                            CargarGaleria(codNegocio);
                            lbNombreNeg.Text = negocio.nombre;
                            Rating1.CurrentRating = 3;
                            //dtListComentario.DataSource = lgComentario.DataComentario(codNegocio);
                            //dtListComentario.DataBind();
                            lgVisita.CrearVisita(codNegocio);
                            CargarComment(codNegocio);
                            hdLat.Value = negocio.latitud;
                            hdLong.Value = negocio.longitud;
                            lbRating.Text = lgCalificacion.PromedioCalificacion(negocio.id_negocio).ToString();
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
                        Response.Redirect("IndexSuscriptor.aspx");
                    }

                }
                else
                {
                    Response.Redirect("IndexSuscriptor.aspx");
                }
            }
            catch (Exception ex)
            {
                pnContenido.Visible = false;
                ltError.Text = ex.Message;
            }

        }

        protected void btnCalificacion_Click(object sender, EventArgs e)
        {
            usuario = (csUsuario)Session["Usuario"];
            negocio = (csNegocio)Application["negocio"];
            lgCalificacion = new LogicaCalificacion();

            try
            {
                DateTime tiempo = DateTime.Now;
                String fecha = tiempo.Date.ToString("yyyy-MM-dd");
                String hora = "14:07:07";
                calificacion = new csCalificacion(0, int.Parse(Rating1.CurrentRating.ToString()), fecha, hora, negocio.id_negocio, usuario.id_usuario);
                lgCalificacion.CrearCalificacion(calificacion);
                lbCalificacion.Text = "Tu Calificacion es: " + Rating1.CurrentRating.ToString();
            }
            catch (Exception ex)
            {

                lbCalificacion.Text = ex.ToString();
            }
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            try
            {
                lgComentario = new LogicaComentario();
                usuario = (csUsuario)Session["Usuario"];
                negocio = (csNegocio)Application["negocio"];
                csComentario comentario = new csComentario(0, txtComment.Text, "", "", usuario.id_usuario, negocio.id_negocio);
                lgComentario.CrearComentario(comentario);
                CargarComment(negocio.id_negocio);
                txtComment.Text = "";
            }
            catch (Exception ex)
            {

                txtComment.Text = ex.Message;
            }

        }
    }
}