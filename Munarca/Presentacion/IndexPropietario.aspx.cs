﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;

namespace Presentacion
{
    public partial class IndexPropietario : System.Web.UI.Page
    {
        #region metodos
        protected string obtenerDatos()
        {
            LogicaVisita lgVisita=new LogicaVisita();
            DataTable datos = lgVisita.DataVisita();
            //datos.Columns.Add(new DataColumn("Negocio", typeof(string)));
            //datos.Columns.Add(new DataColumn("Visita", typeof(string)));
            //datos.Rows.Add(new object[] { "work", 11 });
            //datos.Rows.Add(new object[] { "eat", 2 });
            //datos.Rows.Add(new object[] { "comunete", 2 });
            //datos.Rows.Add(new object[] { "slep", 7 });
            //datos.Rows.Add(new object[] { "watch tv", 2 });

            string strDatos = "[['Negocio', 'Visita'],";

            foreach (DataRow dr in datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return strDatos;

        }
        #endregion
        LogicaNegocio lgNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            csUsuario user = (csUsuario)Session["Usuario"];
            if (!IsPostBack)
            {
                lgNegocio = new LogicaNegocio();
                dtlisNegocio.DataSource = lgNegocio.listarNegocio(user.id_usuario);
                dtlisNegocio.DataBind();
                Session["Negocio"] = null;
            }


        }

        protected void btnIrGeocio_Click(object sender, EventArgs e)
        {
            try
            {
                //string cod = dtlisNegocio.ID ;
                LinkButton btn = (LinkButton)sender;
                DataListItem item = (DataListItem)btn.NamingContainer;
                Label lb = (Label)item.FindControl("Label2");
                lgNegocio = new LogicaNegocio();
                csNegocio negocio=lgNegocio.SessionNegocio(int.Parse(lb.Text));
                Session["Negocio"] = negocio;
                Response.Redirect("IndexServicioPropietario.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


         



    }
}