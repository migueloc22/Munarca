using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class AlbumNegocioPropietario : System.Web.UI.Page
    {
        csUtilidades util;
        LogicaPath lgNegocio;
        LogicaPath lgPath;
        #region Metodos
        private void CargarPath()
        {
            lgPath = new LogicaPath();
            util = new csUtilidades();
            lgNegocio = new LogicaPath();
            dlPath.DataSource = lgNegocio.DataTbPath(int.Parse(util.desencriptar(Request.Params["show"])));
            dlPath.DataBind();
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["show"] != null)
            {
                CargarPath();
                HyperLink1.NavigateUrl = "IndexNegocioPropietario.aspx?show=" + Request.Params["show"];
            }
            else
            {
                Response.Redirect("IndexPropietario.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            LogicaNegocio lgNegocio = new LogicaNegocio();
            lgPath = new LogicaPath();
            csUsuario usuario = (csUsuario)Session["Usuario"];


            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                try
                {
                    util=new csUtilidades();
                    string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("media\\img") + "\\" + fn;
                    int codNegoc = int.Parse(util.desencriptar(Request.Params["show"]));
                    csPath path = new csPath(0, FileUpload1.FileName, codNegoc);
                    if (lgPath.CrearPath(path))
                    {
                        FileUpload1.PostedFile.SaveAs(SaveLocation);
                        CargarPath();
                        ltMsnMultimedia.Text = @"<div class='alert alert-info alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>¡Información!</strong> Imagen Agregada</div>";
                    }
                    else
                    {
                        ltMsnMultimedia.Text = @"<div class='alert alert-danger'>
                             <strong>Danger!</strong> no guardor el registro.
                             </div>";
                    }

                }
                catch (Exception ex)
                {
                    ltMsnMultimedia.Text = @"<div class='alert alert-danger'>
                    <strong>Advertencia</strong> " + ex.Message + "</div>";

                }

            }
            else
            {
                ltMsnMultimedia.Text = @"<div class='alert alert-danger'>
                    <strong>Danger!</strong> No cargo la Foto.
                    </div>";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                DataListItem item = (DataListItem)btn.NamingContainer;
                Label lb = (Label)item.FindControl("lbIdPath");
                int codNegoc = int.Parse(util.desencriptar(Request.Params["show"]));
                lgPath = new LogicaPath();
                if (lgPath.EliminarPath(int.Parse(lb.Text)))
                {
                    ltMsnMultimedia.Text = @"<div class='alert alert-info alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>¡Información!</strong>Imagen eliminada</div>";

                    CargarPath();
                }
                else {
                    ltMsnMultimedia.Text = @"<div class='alert alert-danger alert-dismissable'>
                    <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                    <strong>Error! </strong> Imagen no elinada</div>";
                
                }

            }
            catch (Exception ex)
            {

                ltMsnMultimedia.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error! </strong> " + ex.Message + "</div>";
            }
        }

        

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                DataListItem item = (DataListItem)btn.NamingContainer;
                Label lb = (Label)item.FindControl("lbIdPath");
                int codNegoc = int.Parse(util.desencriptar(Request.Params["show"]));
                lgPath = new LogicaPath();
                if (lgPath.EliminarPath(int.Parse(lb.Text)))
                {
                    ltMsnMultimedia.Text = @"<div class='alert alert-info alert-dismissable'>
                        <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                        <strong>¡Información!</strong>Imagen eliminada</div>";

                    CargarPath();
                }
                else
                {
                    ltMsnMultimedia.Text = @"<div class='alert alert-danger alert-dismissable'>
                    <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                    <strong>Error! </strong> Imagen no elinada</div>";

                }

            }
            catch (Exception ex)
            {

                ltMsnMultimedia.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error! </strong> " + ex.Message + "</div>";
            }
        }
    }
}