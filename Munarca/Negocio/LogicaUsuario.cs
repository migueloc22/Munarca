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
                    string foto="media/img/"+reader["foto"].ToString() ;
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
        public Boolean validarCorreo(string correo){
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                command = new SqlCommand("select count(*) usuario where correo like %@correo%",cnn);
                command.Parameters.AddWithValue("@correo", correo);
                command.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            return retorno;
        }
        public  Boolean RecuperracionPass (string correo , string pass){
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                command = new SqlCommand("update usuario set contraseña=@contraseña where correo=@correo", cnn);
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@contraseña", pass);
                int num= command.ExecuteNonQuery();
                if (num!=0)
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
        public Boolean CambiarFoto(string foto, int codUser)
        {
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                command = new SqlCommand("update usuario set foto=@foto where id_usuario=@id_usuario", cnn);
                command.Parameters.AddWithValue("@foto", foto);
                command.Parameters.AddWithValue("@id_usuario", codUser);
                int num = command.ExecuteNonQuery();
                if (num != 0)
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
        public Boolean CambiarPass(string contraseña, int codUser)
        {
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                command = new SqlCommand("update usuario set contraseña=@contraseña where id_usuario=@id_usuario", cnn);
                command.Parameters.AddWithValue("@contraseña", contraseña);
                command.Parameters.AddWithValue("@id_usuario", codUser);
                int num = command.ExecuteNonQuery();
                if (num != 0)
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
        public Boolean ActulizarDatos(csUsuario user)
        {
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                command = new SqlCommand("update usuario set nombre_1=@nombre_1,nombre_2=@nombre_2,apellido_1=@apellido_1,apellido_2=@apellido_2,fk_id_tipo_doc=@fk_id_tipo_doc,num_documento=@num_documento,fk_id_ciudad=@fk_id_ciudad,direccion=@direccion,telefono=@telefono,fecha_nacimiento=@fecha_nacimiento where id_usuario=@id_usuario", cnn);
                command.Parameters.AddWithValue("@nombre_1", user.nombre1);
                command.Parameters.AddWithValue("@nombre_2", user.nombre2);
                command.Parameters.AddWithValue("@apellido_1", user.apellido1);
                command.Parameters.AddWithValue("@apellido_2", user.apellido2);
                command.Parameters.AddWithValue("@fk_id_tipo_doc", user.fk_id_tipo_doc);
                command.Parameters.AddWithValue("@num_documento", user.num_documento);
                command.Parameters.AddWithValue("@fk_id_ciudad", user.fk_id_ciudad);
                command.Parameters.AddWithValue("@direccion", user.direccion);
                command.Parameters.AddWithValue("@telefono", user.telefono);
                command.Parameters.AddWithValue("@fecha_nacimiento", user.fecha_nacimiento);
                command.Parameters.AddWithValue("@id_usuario", user.codUser);

                int num = command.ExecuteNonQuery();
                if (num != 0)
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

        //METODO PARA BUSCAR USUARIOS EN ADMIN
        //executenonquery para eliminar agregar y insertar
        public DataTable BuscarUsu(String buscar) {
            cnn = Conexion.AbrirCnn();
            DataTable ListaUsuario = new DataTable();
            try
            {
                command = new SqlCommand("select * from usuario where nombre_1 like @buscar or apellido_1 like @buscar or num_documento like @buscar", cnn);
                command.Parameters.AddWithValue("@buscar","%"+buscar+"%");
                reader = command.ExecuteReader();
                ListaUsuario.Load(reader);


            }
            catch (Exception)
            {
                
                throw;
            }
            return ListaUsuario;
        }
        public DataTable BuscarUsu()
        {
            cnn = Conexion.AbrirCnn();
            DataTable ListaUsuario = new DataTable();
            try
            {
                command = new SqlCommand("select * from usuario order by nombre_1  ,  apellido_1 ", cnn);
                reader = command.ExecuteReader();
                ListaUsuario.Load(reader);


            }
            catch (Exception)
            {

                throw;
            }
            return ListaUsuario;
        }





        public csUsuario SessioUsuario(int p)
        {
            cnn = Conexion.AbrirCnn();
            try
            {
                codigo = "OkLogin";
                rta = "401";
                command = new SqlCommand("Select * from usuario where  id_usuario=@id_usuario", cnn);
                command.Parameters.AddWithValue("@id_usuario", p);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int id_usuario = int.Parse(reader["id_usuario"].ToString());
                    string nombre1 = reader["nombre_1"].ToString();
                    string nombre2 = reader["nombre_2"].ToString();
                    string apellido1 = reader["apellido_1"].ToString();
                    string apellido2 = reader["apellido_2"].ToString();
                    string foto = "media/img/" + reader["foto"].ToString();
                    string direccion = reader["direccion"].ToString();
                    string fecha_nacimiento = reader["fecha_nacimiento"].ToString();
                    string telefono = reader["telefono"].ToString();
                    string correo = reader["correo"].ToString();
                    string contraseña = reader["contraseña"].ToString();
                    int num_documento = int.Parse(reader["num_documento"].ToString());
                    int fk_id_tipo_doc = int.Parse(reader["fk_id_tipo_doc"].ToString());
                    int fk_id_ciudad = int.Parse(reader["fk_id_ciudad"].ToString());
                    csUsuario = new csUsuario(id_usuario, nombre1, nombre2, apellido1, apellido2, correo, foto, direccion, fecha_nacimiento, telefono, num_documento, fk_id_tipo_doc, fk_id_ciudad, contraseña);
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
