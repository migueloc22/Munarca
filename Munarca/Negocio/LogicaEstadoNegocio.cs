using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaEstadoNegocio
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        DataTable tabla;
        public void CrearEstadoServicio() { }
        public void ModificarEstadoServicio() { }
        public void TableEstadoServicio() { }
        public void EliminarEstadoServicio() { }
    }
}
