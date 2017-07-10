using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BaseDatos;
namespace Negocio
{
    public class LogicaEstadoUsuario : csRespuesta
    {
        SqlCommand command;
        SqlDataReader reader;
        SqlConnection cnn;
        public bool Validar(int codUser,int tipoUser) 
        {
            bool Salida = false;
            try
            {
                codigo = "OkValidar";
                cnn = Conexion.AbrirCnn();
                command = new SqlCommand("select * from estado_usuario where fk_id_usuario=@codUser and fk_id_tipo_usuario=@tipoUser", cnn);
                command.Parameters.AddWithValue("@codUser", codUser);
                command.Parameters.AddWithValue("@tipoUser", tipoUser);
                if (command.ExecuteNonQuery() != 0)
                {
                    Salida = true;
                }
                Conexion.CerrarCnn(cnn);
                return Salida;
            }
            catch (Exception ex)
            {
                return Salida;
                codigo = ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
        
        }
    }
}
