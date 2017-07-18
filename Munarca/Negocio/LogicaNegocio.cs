using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BaseDatos;
using System.Data;

namespace Negocio
{
    public class LogicaNegocio : csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        public string CrearNegocio(csNegocio negocio)
        {
            cnn = Conexion.AbrirCnn();
            try
            {
                //nombreProc,Conexion
                
                cmd = new SqlCommand("crearRegistro", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomNegoc", negocio.nombre);
                cmd.Parameters.AddWithValue("@descrip", negocio.descripcion);
                cmd.Parameters.AddWithValue("@telef", negocio.telefono.ToString());
                cmd.Parameters.AddWithValue("@codUser", negocio.fk_id_usuario);
                cmd.Parameters.AddWithValue("@codCateg", negocio.fk_id_categoria);
                SqlParameter paramaterCod = new SqlParameter();
                paramaterCod.ParameterName = "@cod";
                paramaterCod.SqlDbType= SqlDbType.Int;
                paramaterCod.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramaterCod);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                string cod = cmd.Parameters["@cod"].Value.ToString();
                return cod;


            }
            catch (Exception ex)
            {

                codigo = ex.ToString();
                return null;
            }
            

        }
    }
}
