using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos;
using System.Data.SqlClient;
using System.Data;

namespace Negocio
{
    public class LogicaCalificacion : csRespuesta
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
                cmd.Parameters.AddWithValue("@calificacion", calificacion.calificaion);
                cmd.Parameters.AddWithValue("@fecha", calificacion.fecha);
                cmd.Parameters.AddWithValue("@hora", calificacion.hora);
                cmd.Parameters.AddWithValue("@fk_id_negocio", calificacion.fk_id_Negocio);
                cmd.Parameters.AddWithValue("@fk_id_usuario", calificacion.fk_id_usuario);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                retorno = true;
            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            return retorno;
        }
        public Boolean ModificarCalificacion(csCalificacion calificacion)
        {
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand(@"update calificacion set calificacion=@calificacion where fk_id_usuario=@fk_id_usuario)", cnn);
                cmd.Parameters.AddWithValue("@calificacion", calificacion.calificaion);
                cmd.Parameters.AddWithValue("@fk_id_usuario", calificacion.fk_id_usuario);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                retorno = true;
            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            return retorno;
        }
        public double PromedioCalificacion(int codNegocio)
        {
            double retorno = 0;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select CONVERT(decimal(18,2),AVG(calificacion.calificacion)) as Promedio from calificacion where fk_id_negocio=@fk_id_negocio;", cnn);
                cmd.Parameters.AddWithValue("@fk_id_negocio", codNegocio);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    retorno = double.Parse(read["Promedio"].ToString());
                }
                Conexion.CerrarCnn(cnn);
            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            return retorno;
        }
        public bool ValidacionCalificacion(int codNegocio)
        {
            bool retorno = true;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select count(*) Promedio from calificacion where fk_id_usuario=@fk_id_negocio;", cnn);
                cmd.Parameters.AddWithValue("@fk_id_negocio", codNegocio);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    retorno = false;
                }
                Conexion.CerrarCnn(cnn);
            }
            catch (Exception ex)
            {

                rta = ex.Message;
            }
            return retorno;
        }
        public DataTable ReportesCAlificacion()
        {
            DataTable table = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select   negocio.nombre , CONVERT(decimal(18,2),AVG(calificacion.calificacion))  as Promedio ,count(id_calificacion)  as N_Calificaiones from calificacion inner join negocio on calificacion.fk_id_negocio=negocio.id_negocio group by negocio.nombre", cnn);
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
    }
}
