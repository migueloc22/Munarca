using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos;
using System.Data.SqlClient;

namespace Negocio
{
    public class LogicaCalificacion:csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        public Boolean CrearCalificacion(csCalificacion calificacion)
        {
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand(@"insert into calificacion(calificacion,fecha,hora,fk_id_negocio,fk_id_usuario) 
                                     values(@calificacion,@fecha,@hora,@fk_id_negocio,@fk_id_usuario)", cnn);
                cmd.Parameters.AddWithValue("@calificacion",calificacion.calificaion);
                cmd.Parameters.AddWithValue("@fecha",calificacion.fecha);
                cmd.Parameters.AddWithValue("@hora",calificacion.hora);
                cmd.Parameters.AddWithValue("@fk_id_negocio",calificacion.fk_id_Negocio);
                cmd.Parameters.AddWithValue("@fk_id_usuario",calificacion.fk_id_usuario);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                retorno = true;
            }
            catch (Exception ex)
            {
                
                rta=ex.ToString();
            }
            return retorno;
        }
        public double PromedioCalificacion(int codNegocio)
        {
            double retorno =0;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select CONVERT(decimal(18,2),AVG(calificacion.calificacion)) as Promedio from calificacion where fk_id_negocio=@fk_id_negocio;", cnn);
                cmd.Parameters.AddWithValue("@fk_id_negocio", codNegocio);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    retorno = double.Parse( read["Promedio"].ToString());
                }
                Conexion.CerrarCnn(cnn);
            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            return retorno;
        }
    }
}
