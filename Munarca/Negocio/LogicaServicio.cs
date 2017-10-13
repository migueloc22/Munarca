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
    public class LogicaServicio : csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        public Boolean CrearServicio(csServicio servico)
        {
            Boolean retorno = false;
            try
            {
                cnn = Conexion.AbrirCnn();
                cmd = new SqlCommand("insert into servicio(nombre_servicio,descripcion,fecha,hora,image,fk_id_negocio,valor) values(@nombre_servicio,@descripcion,@fecha,@hora,@image,@fk_id_negocio,@valor)", cnn);
                cmd.Parameters.AddWithValue("@nombre_servicio", servico.nombre);
                cmd.Parameters.AddWithValue("@descripcion", servico.descripcion);
                cmd.Parameters.AddWithValue("@fecha", servico.fecha);
                cmd.Parameters.AddWithValue("@hora", servico.hora);
                cmd.Parameters.AddWithValue("@image", servico.imagen);
                cmd.Parameters.AddWithValue("@valor", servico.valor);
                cmd.Parameters.AddWithValue("@fk_id_negocio", servico.fk_id_negocio);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                retorno = true;
            }
            catch (SqlException ex)
            {

                throw;
            }
            return retorno;
        }

        public Boolean ModificarServicio(csServicio servico)
        {
            Boolean retorno = false;
            try
            {
                cnn = Conexion.AbrirCnn();
                cmd = new SqlCommand("update servicio set nombre_servicio=@nombre_servicio , descripcion=@descripcion,fecha=@fecha,hora=@hora,image=@image,fk_id_negocio=@fk_id_negocio,valor=@valor", cnn);
                cmd.Parameters.AddWithValue("@nombre_servicio", servico.nombre);
                cmd.Parameters.AddWithValue("@descripcion", servico.descripcion);
                cmd.Parameters.AddWithValue("@fecha", servico.fecha);
                cmd.Parameters.AddWithValue("@hora", servico.hora);
                cmd.Parameters.AddWithValue("@image", servico.imagen);
                cmd.Parameters.AddWithValue("@valor", servico.valor);
                cmd.Parameters.AddWithValue("@fk_id_negocio", servico.fk_id_negocio);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                retorno = true;
            }
            catch (SqlException ex)
            {

                throw;
            }
            return retorno;
        }

        public Boolean ModificarServicio2(csServicio servico)
        {
            Boolean retorno = false;
            try
            {
                cnn = Conexion.AbrirCnn();
                cmd = new SqlCommand("update servicio set nombre_servicio=@nombre_servicio , descripcion=@descripcion,image=@image,valor=@valor where id_servicio =@id_sevicio", cnn);
                cmd.Parameters.AddWithValue("@nombre_servicio", servico.nombre);
                cmd.Parameters.AddWithValue("@descripcion", servico.descripcion);
                cmd.Parameters.AddWithValue("@image", servico.imagen);
                cmd.Parameters.AddWithValue("@valor", servico.valor);
                cmd.Parameters.AddWithValue("@id_sevicio", servico.id_servicio);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                retorno = true;
            }
            catch (SqlException ex)
            {

                rta=ex.ToString();
            }
            return retorno;
        }
        public Boolean EliminarServicio(int codServicio)
        {
            Boolean retorno = false;
            try
            {
                cnn = Conexion.AbrirCnn();
                cmd = new SqlCommand("delete from servicio where id_servicio=@codServicio", cnn);
                cmd.Parameters.AddWithValue("@codServicio", codServicio);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                retorno = true;
            }
            catch (SqlException ex)
            {

                throw;
            }
            return retorno;
        }
        public DataTable ListarSErvicio() {
            DataTable tabla = new DataTable();
            cnn = Conexion.AbrirCnn();
            cmd = new SqlCommand("select top 30 id_servicio,nombre_servicio,fk_id_negocio,descripcion,fecha,hora,valor,CONCAT('/media/img/',image) as imagen from servicio order by fecha desc ,hora desc, nombre_servicio", cnn);
            read = cmd.ExecuteReader();
            tabla.Load(read);
            Conexion.CerrarCnn(cnn);
            return tabla;
        
        
        }
        public DataTable ListarSErvicio(int codNegocio)
        {
            DataTable tabla = new DataTable();
            cnn = Conexion.AbrirCnn();
            cmd = new SqlCommand("select  id_servicio,nombre_servicio,descripcion,fecha,hora,valor,CONCAT('/media/img/',image) as imagen from servicio where fk_id_negocio=@fk_id_negocio order by fecha desc ,hora desc, nombre_servicio", cnn);
            cmd.Parameters.AddWithValue("@fk_id_negocio", codNegocio);
            read = cmd.ExecuteReader();
            tabla.Load(read);
            Conexion.CerrarCnn(cnn);
            return tabla;


        }
        public DataTable ListarRango(string rangoMin, string rangoMax, string ordenar)
        {
            DataTable tabla = new DataTable();
            cnn = Conexion.AbrirCnn();
            cmd = new SqlCommand("select top 30 id_servicio,nombre_servicio,descripcion,fecha,hora,valor,CONCAT('/media/img/',image) as imagen from servicio where valor BETWEEN @rangoMin AND @rangoMax order by  valor "+ordenar+" , nombre_servicio ", cnn);
            cmd.Parameters.AddWithValue("@rangoMin", rangoMin);
            cmd.Parameters.AddWithValue("@rangoMax", rangoMax);
            read = cmd.ExecuteReader();
            tabla.Load(read);
            Conexion.CerrarCnn(cnn);
            return tabla;


        }
        public DataTable ListarRango(string rangoMin, string rangoMax, string nombre_servicio, string ordenar)
        {
           
            DataTable tabla = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select top 30 id_servicio,nombre_servicio,descripcion,fecha,hora,valor,CONCAT('/media/img/',image) as imagen  from servicio where nombre_servicio like @nombre_servicio AND valor BETWEEN @rangoMin and @rangoMax order by  valor " + ordenar + " , nombre_servicio ", cnn);
                cmd.Parameters.AddWithValue("@rangoMin", rangoMin);
                cmd.Parameters.AddWithValue("@rangoMax", rangoMax);
                cmd.Parameters.AddWithValue("@nombre_servicio", "%"+nombre_servicio+"%");
                read = cmd.ExecuteReader();
                tabla.Load(read);
            }
            catch (Exception ex)
            {

                rta = ex.Message;
            }
            
           
            Conexion.CerrarCnn(cnn);
            return tabla;


        }
        public csServicio SessionServicio(int codServio ) 
        {
            int id_servicio;
            string nombre;
            string descripcion;
            string imagen;
            string fecha;
            string hora; 
            int valor;
            int fk_id_negocio;
            csServicio servicio;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select * from servicio where id_servicio=@codServicio", cnn);
                cmd.Parameters.AddWithValue("@codServicio", codServio);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    id_servicio = int.Parse(read["id_servicio"].ToString());
                    nombre = read["nombre_servicio"].ToString();
                    descripcion = read["descripcion"].ToString();
                    imagen = read["image"].ToString();
                    fecha = read["fecha"].ToString();
                    hora = read["hora"].ToString();
                    valor = int.Parse(read["valor"].ToString());
                    fk_id_negocio = int.Parse(read["fk_id_negocio"].ToString());
                    servicio = new csServicio(id_servicio, nombre, descripcion, imagen, fecha, hora, valor, fk_id_negocio);
                    Conexion.CerrarCnn(cnn);
                    return servicio; 
                }
                else
                {
                    servicio = null;
                    return servicio; 
                }
                
            }
            catch (SqlException ex)
            {

                rta = ex.ToString();
                servicio = null;
                return servicio;
            }
           
               
            

            
            
        
        }

    }
}
