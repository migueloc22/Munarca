using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BaseDatos;

namespace Negocio
{
    public class LogicaTipoServicio : csRespuesta
    {
        SqlCommand cmd;
        SqlDataReader read;
        public  DataTable dtTpServicio() {
            DataTable table = new DataTable();
            SqlConnection cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select * from tipo_servicio", cnn);
                read = cmd.ExecuteReader();
                table.Load(read);
            }
            catch (Exception ex)
            {

                rta = ex.Message;
            }
            finally { Conexion.CerrarCnn(cnn); }
            return table;
        }
        public void CrearEstadoServicio() { }
        public void ModificarEstadoServicio() { }
        public void TableEstadoServicio() { }
        public void EliminarEstadoServicio() { }
    }
}
