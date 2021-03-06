﻿using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Presentacion
{
    public partial class IndexSuscriptor : System.Web.UI.Page
    {
        csNegocio negocio;
        LogicaNegocio lgNegocio;
        csUtilidades util;
        #region Metodos
        private void CargarGrid()
        {
            LogicaServicio lgServicio = new LogicaServicio();
            dtServicio.DataSource = lgServicio.ListarSErvicio();
            dtServicio.DataBind();
        }
        private void FilterGrid1()
        {
            LogicaServicio lgServicio = new LogicaServicio();
            string filter = "";
            filter = "where nombre_servicio LIKE '" + txtBuscar.Text + "%'  order by  valor " + rdListOrdenar.SelectedValue.ToString();
            //dtServicio.DataSource = lgServicio.FiltroSErvicio(txtMin.Text, txtMax.Text, rdListOrdenar.SelectedValue.ToString());
            dtServicio.DataSource = lgServicio.FiltroSErvicio(filter);
            dtServicio.DataBind();
        }
       
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
                Session["SessionNegocio"] = null;
            }
        }

        protected void btnFiltrol_Click(object sender, EventArgs e)
        {
            FilterGrid1();
        }

        

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            CargarGrid();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            util = new csUtilidades();
            ImageButton btn = (ImageButton)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            Label lb = (Label)item.FindControl("lbIdServicio");
            Response.Redirect("IndexNegocioSuscriptor.aspx?show=" + util.Encriptar(lb.Text));
        }

        protected void btnNomNegocio_Click(object sender, EventArgs e)
        {
            try
            {
                util = new csUtilidades();
                LinkButton btn = (LinkButton)sender;
                DataListItem item = (DataListItem)btn.NamingContainer;
                Label lb = (Label)item.FindControl("lbIdServicio");
                Response.Redirect("IndexNegocioSuscriptor.aspx?show=" + util.Encriptar(lb.Text));
            }
            catch (Exception)
            {

                throw;
            }

        }

        //protected void gvServicio_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lgNegocio = new LogicaNegocio();
        //    int codNegocio =int.Parse(gvServicio.SelectedDataKey.Values[0].ToString());
        //    negocio = lgNegocio.SessionNegocio(codNegocio);
        //    Session["SessionNegocio"] = negocio;
        //    Response.Redirect("IndexNegocioSuscriptor.aspx");
        //}
    }
}