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
    public class LogicaCategoria :csRespuesta
    {
        SqlCommand comman;
        SqlDataReader read;
        DataTable tabla;
        public DataTable Listar() {

            tabla = new DataTable();
            SqlConnection cnn=Conexion.AbrirCnn();
            try
            {
                comman = new SqlCommand("select * from categoria", cnn);
                read = comman.ExecuteReader();
                tabla.Load(read);
                return tabla;
            }
            catch (Exception ex)
            {

                rta = ex.ToString();
                return tabla;
            }
            finally { Conexion.CerrarCnn(cnn); }
            
        }
    }
}
