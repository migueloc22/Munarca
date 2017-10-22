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
    public class LogicaVisita:csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        public void CrearVisita(int codNegocio)
        {
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("[CrearVisita]", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //@fk_id_negocio, @id_usuario, @comentario
                cmd.Parameters.AddWithValue("@idNegocio", codNegocio);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
        }
        public DataTable DataVisita()
        {
            DataTable data = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select  nombre as Negocio,count(id_negocio) as Visita  from Visita inner join negocio on Visita.fk_id_negocio=negocio.id_negocio group by nombre", cnn);
                read = cmd.ExecuteReader();
                data.Load(read);


            }
            catch (SqlException ex)
            {

                rta = ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return data;
        }
        public DataTable LineaTeiempoVisita(int idNegocio)
        {
            DataTable data = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select concat ('new Date(',YEAR(convert(datetime, tiempo, 105)),',',MONTH(convert(datetime, tiempo, 105)),',',DAY(convert(datetime, tiempo, 105)),')') as Tiempo, count(tiempo) as numero from Visita where fk_id_negocio=@id_negocio group by tiempo", cnn);
                cmd.Parameters.AddWithValue("@id_negocio", idNegocio);
                read = cmd.ExecuteReader();
                data.Load(read);


            }
            catch (SqlException ex)
            {

                rta = ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return data;
        }

        public DataTable DataVisita(int idNegocio )
        {
            DataTable data = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select  nombre as Negocio,count(id_negocio) as Visita  from Visita inner join negocio on Visita.fk_id_negocio=negocio.id_negocio where negocio.fk_id_propietario=@id_negocio group by nombre", cnn);
                cmd.Parameters.AddWithValue("@id_negocio", idNegocio);
                read = cmd.ExecuteReader();
                data.Load(read);


            }
            catch (SqlException ex)
            {

                rta = ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return data;
        }
    }
}
