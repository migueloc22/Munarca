using BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaEstadoNegocio :csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        DataTable tabla;
        public void CrearEstadoNegocio(csEstadoNegocio estNegocio) {
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("INSERT INTO estado_negocio (fk_id_categoria,fk_id_negocio) VALUES(@fk_id_categoria,@fk_id_negocio)", cnn);
                cmd.Parameters.AddWithValue("fk_id_categoria", estNegocio.fk_id_categoria);
                cmd.Parameters.AddWithValue("fk_id_negocio", estNegocio.fk_id_negocio);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                rta = ex.Message;
            }
            finally { Conexion.CerrarCnn(cnn); }
        }
        public void ModificarEstadoNegocio() { }
        public void TableEstadoNegocio() { }
        public void EliminarEstadoNegocio() { }
    }
}
