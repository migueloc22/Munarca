using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos;
using System.Data.SqlClient;

namespace Negocio
{
    public class LogicaUsuario : csRespuesta
    {
        SqlCommand command;
        SqlDataReader reader;
        SqlConnection cnn;
        csUsuario csUsuario;

        public csUsuario Login(string contraseña, string correo)
        {
            cnn = Conexion.AbrirCnn();
            try
            {
                codigo = "OkLogin";
                rta = "401";
                command = new SqlCommand("Select * from usuario where contraseña=@pass and correo=@correo", cnn);
                command.Parameters.AddWithValue("@pass", contraseña);
                command.Parameters.AddWithValue("@correo", correo);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int id_usuario = int.Parse(reader["id_usuario"].ToString());
                    string nombre1=reader["nombre_1"].ToString();
                    string nombre2 = reader["nombre_2"].ToString();
                    string apellido1 = reader["apellido_1"].ToString();
                    string apellido2= reader["apellido_2"].ToString();                    
                    string foto=reader["foto"].ToString() ;
                    string direccion= reader["direccion"].ToString();
                    string fecha_nacimiento=reader["fecha_nacimiento"].ToString() ;
                    int telefono=int.Parse(reader["telefono"].ToString()) ;
                    int num_documento=int.Parse(reader["num_documento"].ToString());
                    int fk_id_tipo_doc=int.Parse(reader["fk_id_tipo_doc"].ToString());
                    int fk_id_ciudad = int.Parse(reader["fk_id_ciudad"].ToString());
                    csUsuario = new csUsuario(  id_usuario, nombre1, nombre2 , apellido1 , apellido2 ,   correo,  foto ,  direccion ,  fecha_nacimiento ,  telefono , num_documento, fk_id_tipo_doc , fk_id_ciudad, contraseña ) ;
                    Conexion.CerrarCnn(cnn);
                    return csUsuario;
                    
                }
                else
                {
                    codigo = "nop";
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
