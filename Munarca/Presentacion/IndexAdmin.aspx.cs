using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class IndexAdmin : System.Web.UI.Page
    {
        LogicaUsuario lgUser;
        #region Metodos
        private void cargarDAtosUser() { 
            ///creamos el objeto logica usuario 
            lgUser = new LogicaUsuario();
            //bamos acaragr los datos en el gridviewesoooooooo con dataSource
            gvUsuarios.DataSource = lgUser.DataUser();
            //OJO precuerde eso para toda su vida  para mostrar los datos Se necesita el databing sin eso no muestra nada
            gvUsuarios.DataBind();
            //listo ejecute
           //si ya
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //por  ultimo para que muestr losdaots debe llmar el metodo
        cargarDAtosUser();
            


        }
    }
}