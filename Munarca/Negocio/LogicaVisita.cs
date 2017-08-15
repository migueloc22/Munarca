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
        public DataTable LineaTeiempoVisita()
        {
            DataTable data = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select count(CONVERT (date, tiempo)),CONVERT (date, tiempo),nombre from Visita inner join negocio on Visita.fk_id_negocio=negocio.id_negocio group by CONVERT (date, tiempo),nombre", cnn);
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
