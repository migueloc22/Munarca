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
    public class LogicaUsuario : csRespuesta
    {
        SqlCommand command;
        SqlDataReader reader;
        SqlConnection cnn;
        csUsuario csUsuario;
        //Metodo de recueperar da tos de usuario con dadtable
        public DataTable DataUser() {
            DataTable table=new DataTable();
            //bamos  llamar la conexion como la conexion es estactica no se nesecita distanciar;
            cnn = Conexion.AbrirCnn();
            try
            {
                //colocamos primero  la consulta y luego la conecion
                command = new SqlCommand("select * from usuario",cnn);
                //recuperarmos los datos con reader 
                reader = command.ExecuteReader();
                //los datos recuperados se va guardar en datablae que creamos
                table.Load(reader);

            }
            catch (Exception ex)
            {
                
                throw;
            }
            return table;
        }
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
                    string telefono = reader["telefono"].ToString();
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

        public Boolean CrearUsuario(csUsuario usuario,string opcion) {
        Boolean retorno = false;
        cnn = Conexion.AbrirCnn();
        try
        {
            command = new SqlCommand("[CrearUsuario]", cnn);
            command.CommandType = CommandType.StoredProcedure;
            //@fk_id_negocio, @id_usuario, @comentario
            command.Parameters.AddWithValue("@nombre1", usuario.nombre1);
            command.Parameters.AddWithValue("@nombre_2", usuario.nombre2);
            command.Parameters.AddWithValue("@apellido_1", usuario.apellido1);
            command.Parameters.AddWithValue("@apellido_2", usuario.apellido2);
            command.Parameters.AddWithValue("@fk_id_tipo_doc", usuario.fk_id_tipo_doc);
            command.Parameters.AddWithValue("@contraseña", usuario.contraseña);
            command.Parameters.AddWithValue("@num_documento", usuario.num_documento);
            command.Parameters.AddWithValue("@fk_id_ciudad", usuario.fk_id_ciudad);
            command.Parameters.AddWithValue("@direccion", usuario.direccion);
            command.Parameters.AddWithValue("@correo", usuario.correo);
            command.Parameters.AddWithValue("@foto", usuario.foto);
            command.Parameters.AddWithValue("@telefono", usuario.telefono);            
            command.Parameters.AddWithValue("@fecha_nacimiento", usuario.fecha_nacimiento);
            command.Parameters.AddWithValue("@opcion",opcion);
            command.ExecuteNonQuery();
            Conexion.CerrarCnn(cnn);
            retorno = true;
        }
        catch (Exception ex)
        {

            rta = ex.ToString();
        }


        return retorno;
        }

        

    }
}
