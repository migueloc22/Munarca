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
                reader=command.ExecuteReader();
                if (reader.Read())
                {
                    Salida = true;
                }
                Conexion.CerrarCnn(cnn);
               
            }
            catch (Exception ex)
            {
               
                codigo = ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return Salida;
        
        }
        public bool CrearTipoUser(int codUser, int tipoUser)
        {
            bool Salida = false;
            try
            {
                codigo = "OkValidar";
                cnn = Conexion.AbrirCnn();
                command = new SqlCommand("insert into estado_usuario(fk_id_usuario,fk_id_tipo_usuario ) values(@fk_id_usuario,@fk_id_tipo_usuario)", cnn);
                command.Parameters.AddWithValue("@fk_id_usuario", codUser);
                command.Parameters.AddWithValue("@fk_id_tipo_usuario", tipoUser);
                 
                 if (command.ExecuteNonQuery()>0)
                {
                    Salida = true;
                }             


            }
            catch (Exception ex)
            {

                codigo = ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return Salida;

        }
    }
}
