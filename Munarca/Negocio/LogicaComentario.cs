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
    public class LogicaComentario : csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        
        public void CrearComentario(csComentario comentario) {
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("[crearComentario]", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //@fk_id_negocio, @id_usuario, @comentario
                cmd.Parameters.AddWithValue("@fk_id_negocio",comentario.fk_id_negocio);                
                cmd.Parameters.AddWithValue("@id_usuario",comentario.fk_id_usuario);                
                cmd.Parameters.AddWithValue("@comentario",comentario.comentario);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
            }
            catch (Exception ex)
            {
                
                rta=ex.ToString();
            }
        }
        public bool ModificarComentario(csComentario comentario)
        {
            cnn = Conexion.AbrirCnn();
            bool retorno = false;
            try
            {
                cmd = new SqlCommand("update comentario set comentario=@comentario where id_comentario=@id_comentario",cnn);
                cmd.Parameters.AddWithValue("@id_comentario",comentario.id_comentario);
                cmd.Parameters.AddWithValue("@comentario",comentario.comentario);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    retorno = true;
                }
                Conexion.CerrarCnn(cnn);

            }
            catch (Exception ex )
            {

                rta = ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return retorno;
        }
        public Boolean EliminarComentario(int codCommentario)
        {
            cnn = Conexion.AbrirCnn();
            bool retorno = false;
            try
            {
                cmd = new SqlCommand("delete comentario where id_comentario=@id_comentario", cnn);
                cmd.Parameters.AddWithValue("@id_comentario", codCommentario);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return retorno;
        }
        public DataTable DataComentario(int codNegocio) {
            DataTable tabla = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select  CONCAT('media/img/',usuario.foto) as avatar,comentario.comentario as comentario,CONCAT(usuario.nombre_1,' ',usuario.apellido_1) as nombre,fecha ,hora  from  comentario inner join usuario on comentario.id_usuario=usuario.id_usuario where fk_id_negocio=@codNegocio order by fecha desc , hora desc", cnn);
                cmd.Parameters.AddWithValue("@codNegocio", codNegocio);
                read = cmd.ExecuteReader();
                tabla.Load(read);
                Conexion.CerrarCnn(cnn);
                
            }
            catch (Exception ex)
            {
                
                rta=ex.ToString();
            }
            return tabla;
        
        }
        public DataTable DataComentario(int codNegocio,int codUsuario)
        {
            DataTable tabla = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select id_comentario, CONCAT('media/img/',usuario.foto) as avatar,comentario.comentario as comentario,CONCAT(usuario.nombre_1,' ',usuario.apellido_1) as nombre,fecha ,hora from  comentario inner join usuario on comentario.id_usuario=usuario.id_usuario where fk_id_negocio=@codNegocio and comentario.id_usuario=@codUsuario order by fecha desc , hora desc", cnn);
                cmd.Parameters.AddWithValue("@codNegocio", codNegocio);
                cmd.Parameters.AddWithValue("@codUsuario", codUsuario);
                read = cmd.ExecuteReader();
                tabla.Load(read);
                Conexion.CerrarCnn(cnn);

            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            return tabla;

        }
        
         
        
    }
}
