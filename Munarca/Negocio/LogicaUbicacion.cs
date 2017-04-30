using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BaseDatos;

namespace Negocio
{
    public class LogicaUbicacion:csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        public Boolean CrearUbicacion(csUbicacion ubicacion)
        {
            bool retorno=false;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("insert into ubicacion(laptitud,longitud,ubicacion,fk_id_negocio) values(@laptitud,@longitud,@ubicacion,@fk_id_negocio)", cnn);
                cmd.Parameters.AddWithValue("@laptitud",ubicacion.laptitup);
                cmd.Parameters.AddWithValue("@longitud",ubicacion.longitup);
                cmd.Parameters.AddWithValue("@ubicacion",ubicacion.ubicacion);
                cmd.Parameters.AddWithValue("@fk_id_negocio",ubicacion.fk_id_negocio);
                cmd.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {

                rta=ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return retorno;
        }
    }
}
