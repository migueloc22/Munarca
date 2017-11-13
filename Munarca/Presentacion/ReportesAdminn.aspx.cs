using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.IO;
using System.Drawing;

namespace Presentacion
{
    public partial class ReportesAdminn : System.Web.UI.Page
    {

        #region Metodos
        private void CargarCAlificaion()
        {
            try
            {
                gvCalificaion.Visible = true;
                gvVisita.Visible = false;
                LogicaCalificacion lgCalificaion;
                lgCalificaion = new LogicaCalificacion();
                gvCalificaion.DataSource = lgCalificaion.ReportesCAlificacion();
                gvCalificaion.DataBind();
            }
            catch (Exception ex)
            {

                ltMsn.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error! </strong> " + ex.Message + "</div>";
            }

        }
        private void CargarVisita()
        {
            try
            {
                gvCalificaion.Visible = false;
                gvVisita.Visible = true;
                LogicaVisita lgCalificaion;
                lgCalificaion = new LogicaVisita();
                gvVisita.DataSource = lgCalificaion.ReportesVisita();
                gvVisita.DataBind();
            }
            catch (Exception ex)
            {

                ltMsn.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error! </strong> " + ex.Message + "</div>";
            }

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCAlificaion();
            }

        }

        protected void btnVisita_Click(object sender, EventArgs e)
        {
            CargarVisita();
        }

        protected void btnCalificacion_Click(object sender, EventArgs e)
        {
            CargarCAlificaion();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
            Response.ClearContent();
			Response.AddHeader("content-disposition", "attachment; filename=gvtoexcel.xls");
			Response.ContentType = "application/excel";
			System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvCalificaion.RenderControl(htw);
			Response.Write(sw.ToString());
            Response.End();
            }
            catch (Exception ex)
            {

                ltMsn.Text = @"<div class='alert alert-danger alert-dismissable'>
                <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                <strong>Error! </strong> " + ex.Message + "</div>";
            }

        }
    }
}