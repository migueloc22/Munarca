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
    public class LogicaCategoria : csRespuesta
    {
        SqlConnection cnn;
        SqlCommand comman;
        SqlDataReader read;
        DataTable tabla;


        public DataTable Listar()
        {

            tabla = new DataTable();
            SqlConnection cnn = Conexion.AbrirCnn();
            try
            {
                comman = new SqlCommand("select * from categoria order by id_categoria  ,  categoria", cnn);
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
        // metodo para crear categoria
        public bool crearCategoria(string categoria)
        {
            
            cnn = Conexion.AbrirCnn();
            bool retorno=false;
            try
            {
                comman = new SqlCommand(@"insert into categoria(categoria) values(@categoria)", cnn);
                comman.Parameters.AddWithValue("@categoria", categoria);
                int ejecu= comman.ExecuteNonQuery();
                if (ejecu > 0)
                {
                    retorno = true;
                }
                Conexion.CerrarCnn(cnn);
                
            }
            catch (Exception ex)
            {
                rta = ex.ToString();
            }

            return retorno;
                 
            
        }
//metodo para eliminar categoria




    }
}
