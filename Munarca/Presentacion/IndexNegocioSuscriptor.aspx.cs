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
        private void CargarComment()
        {
            csUtilidades util = new csUtilidades();
            int cod = int.Parse(util.desencriptar(Request.Params["show"]));
            lgComentario = new LogicaComentario();
            dtListComentario.DataSource = lgComentario.DataComentario(cod);
            dtListComentario.DataBind();
        }
        private void CargarComment2()
        {
            csUtilidades util = new csUtilidades();
            usuario = (csUsuario)Session["Usuario"];
            int cod = int.Parse(util.desencriptar(Request.Params["show"]));
            lgComentario = new LogicaComentario();
            dtListComentario2.DataSource = lgComentario.DataComentario(cod, usuario.id_usuario);
            dtListComentario2.DataBind();
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
                            string calificacion = lgCalificacion.PromedioCalificacion(negocio.id_negocio).ToString();
                            CargarGaleria(codNegocio);
                            lbNombreNeg.Text = negocio.nombre;
                            //Rating1.CurrentRating = int.Parse(calificacion);
                            //dtListComentario.DataSource = lgComentario.DataComentario(codNegocio);
                            //dtListComentario.DataBind();
                            lgVisita.CrearVisita(codNegocio);
                            foto_Negocio.ImageUrl = negocio.foto_negocio;
                            CargarComment();
                            hdLat.Value = negocio.latitud;
                            hdLong.Value = negocio.longitud;
                            lbRating.Text = calificacion;
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
                if (lgCalificacion.ValidacionCalificacion(usuario.id_usuario))
                {
                    lgCalificacion.CrearCalificacion(calificacion);
                    lbCalificacion.Text = "Tu Calificacion es: " + Rating1.CurrentRating.ToString();
                }
                else
                {
                    lgCalificacion.ModificarCalificacion(calificacion);
                    lbCalificacion.Text = "Tu Calificacion es: " + Rating1.CurrentRating.ToString();
                }
                
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
                CargarComment();
                txtComment.Text = "";
            }
            catch (Exception ex)
            {

                txtComment.Text = ex.Message;
            }

        }

        protected void btnCommen_Click(object sender, EventArgs e)
        {
            try
            {
                btnMisComm.CssClass = "btn btn-default";
                btnCommen.CssClass = "btn btn-danger";
                btnModificarCmm.Visible = false;
                btnComment.Visible = true;
                txtComment.Enabled = true;
                dtListComentario2.Visible = false;
                dtListComentario.Visible = true;
                ltMsnComment.Text = "";
                txtComment.Text = "";
            }
            catch (Exception ex)
            {

                ltMsnComment.Text = @"<div class='alert alert-danger alert-dismissable'>
                                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                  <strong>Error!</strong> " + ex.Message + "</div>";
            }

        }

        protected void btnMisComm_Click(object sender, EventArgs e)
        {
            try
            {
                btnMisComm.CssClass = "btn btn-danger";
                btnCommen.CssClass = "btn btn-default";
                btnModificarCmm.Visible = false;
                btnComment.Visible = false;
                txtComment.Enabled = false;
                dtListComentario2.Visible = true;
                dtListComentario.Visible = false;
                CargarComment2();
                ltMsnComment.Text = "";
                txtComment.Text = "";
            }
            catch (Exception ex)
            {

                ltMsnComment.Text = @"<div class='alert alert-danger alert-dismissable'>
                                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                  <strong>Error!</strong> " + ex.Message + "</div>";
            }

        }

        protected void btnModCmm_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                DataListItem item = (DataListItem)btn.NamingContainer;
                Label lb = (Label)item.FindControl("lbid_comentario");
                Literal lb2 = (Literal)item.FindControl("ltComentario");
                btnModificarCmm.Visible = true;
                txtComment.Text = lb2.Text;
                ViewState["codComment"]=lb.Text;
                txtComment.Enabled = true;

            }
            catch (Exception ex)
            {

                ltMsnComment.Text = @"<div class='alert alert-danger alert-dismissable'>
                                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                  <strong>Error!</strong> " + ex.Message + "</div>";
            }
        }

        protected void btnELiCmm_Click(object sender, EventArgs e)
        {
            try
            {
                txtComment.Text = "";
                btnModificarCmm.Visible = false;
                lgComentario = new LogicaComentario();
                LinkButton btn = (LinkButton)sender;
                DataListItem item = (DataListItem)btn.NamingContainer;
                Label lb = (Label)item.FindControl("lbid_comentario");
                ////csComentario comentario = new csComentario(int.Parse(lb.Text), txtComment.Text, "", "", 0, 0);
                if (lgComentario.EliminarComentario(int.Parse(lb.Text)))
                {
                    ltMsnComment.Text = @"<div class='alert alert-danger alert-dismissable'>
                                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                  <strong>Informacion! </strong> " + "Comentario eliminado" + "</div>";
                    CargarComment2();
                    CargarComment();
                    
                }
                else
                {
                    ltMsnComment.Text = @"<div class='alert alert-danger alert-dismissable'>
                                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                  <strong>Error!</strong> " + "No se elimino el Comentario" + "</div>";
                }

            }
            catch (Exception ex)
            {

                ltMsnComment.Text = @"<div class='alert alert-danger alert-dismissable'>
                                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                  <strong>Error!</strong> " + ex.Message + "</div>";
            }
        }

        protected void btnModificarCmm_Click(object sender, EventArgs e)
        {
            try
            {
                btnModificarCmm.Visible = false;
                lgComentario = new LogicaComentario();
                csComentario comentario = new csComentario(int.Parse(ViewState["codComment"].ToString()), txtComment.Text, "", "", 0, 0);
                if (lgComentario.ModificarComentario(comentario))
                {
                    ltMsnComment.Text = @"<div class='alert alert-danger alert-dismissable'>
                                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                  <strong>Informacion! </strong> " + "Comentario Modificado" + "</div>";
                    CargarComment2();
                    CargarComment();
                    txtComment.Text = "";

                }
                else
                {
                    ltMsnComment.Text = @"<div class='alert alert-danger alert-dismissable'>
                                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                  <strong>Error!</strong> " + "No se modificado el Comentario" + "</div>";
                    txtComment.Text = "";
                }

            }
            catch (Exception ex)
            {
                txtComment.Text = "";
                ltMsnComment.Text = @"<div class='alert alert-danger alert-dismissable'>
                                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                  <strong>Error!</strong> " + ex.Message + "</div>";
            }
        }
    }
}