﻿using System;
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
                //nombreProc,Conexion,@longitud,@ubicacion,@latitud

                cmd = new SqlCommand("crearRegistro", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomNegoc", negocio.nombre);
                cmd.Parameters.AddWithValue("@descrip", negocio.descripcion);
                cmd.Parameters.AddWithValue("@longitud", negocio.descripcion);
                cmd.Parameters.AddWithValue("@ubicacion", negocio.descripcion);
                cmd.Parameters.AddWithValue("@latitud", negocio.descripcion);
                cmd.Parameters.AddWithValue("@telef", negocio.telefono.ToString());
                cmd.Parameters.AddWithValue("@codUser", negocio.fk_id_usuario);
                cmd.Parameters.AddWithValue("@codCateg", negocio.fk_id_categoria);
                SqlParameter paramaterCod = new SqlParameter();
                paramaterCod.ParameterName = "@cod";
                paramaterCod.SqlDbType = SqlDbType.Int;
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
        public DataTable listarNegocio()
        {
            DataTable listar = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select * from  negocio where estado=1", cnn);
                //cmd.CommandText = "select * from  negocio";
                //cmd.Connection = cnn;
                read = cmd.ExecuteReader();
                listar.Load(read);
                Conexion.CerrarCnn(cnn);
                return listar;

            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            return listar;
        }
        public DataTable listarNegocio(int cod)
        {
            DataTable listar = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select * from  negocio where fk_id_propietario = @cod and estado=1", cnn);
                //cmd.CommandText = "select * from  negocio";
                //cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@cod", cod);
                read = cmd.ExecuteReader();
                listar.Load(read);
                Conexion.CerrarCnn(cnn);
                return listar;

            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            return listar;
        }
        public csNegocio SessionNegocio(int codNegocio)
        {
            csNegocio negocio;
            cnn = Conexion.AbrirCnn();
            try
            {
                //nombreProc,Conexion,@longitud,@ubicacion,@latitud
                cmd = new SqlCommand("select * from  negocio where  id_negocio =@codNegocio ", cnn);
                cmd.Parameters.AddWithValue("@codNegocio", codNegocio);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    int cod = int.Parse(read["id_negocio"].ToString());
                    string nombre = read["nombre"].ToString();
                    string descrip = read["descripcion"].ToString();
                    string longitud = read["longitud"].ToString();
                    string ubicacion = read["ubicacion"].ToString();
                    string latitud = read["latitud"].ToString();
                    string telefono = read["telefono"].ToString();
                    int codUsuario = int.Parse(read["fk_id_propietario"].ToString());
                    int codCategoria = int.Parse(read["fk_id_categoria"].ToString());
                    negocio = new csNegocio(cod, nombre, descrip, telefono, codUsuario, codCategoria, longitud, ubicacion, latitud);
                    return negocio;
                }
                return negocio = null;

            }
            catch (Exception)
            {
                return negocio = null;
                throw;
            }

        }
        public Boolean eliminarNeocio(int cod)
        {
            SqlConnection cnn = Conexion.AbrirCnn();
            bool respuesta = false;
            try
            {
                cmd = new SqlCommand("update negocio set estado=0 where id_negocio=@cod", cnn);
                cmd.Parameters.AddWithValue("@cod", cod);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                respuesta = true;
            }
            catch (SqlException ex)
            {

                rta = ex.ToString();
            }
            return respuesta;
        }
        public Boolean ModificarNegocio(csNegocio negocio)
        {
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("ModificarNegocio", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //@id_negocio int ,@nombre varchar(30),@ varchar(250),@longitud varchar(35),@ubicacion varchar(35),@latitud varchar(35),@telefono int,@fk_id_categoria int
                cmd.Parameters.AddWithValue("@nombre", negocio.nombre);
                cmd.Parameters.AddWithValue("@descripcion", negocio.descripcion);
                cmd.Parameters.AddWithValue("@longitud", negocio.longitud);
                cmd.Parameters.AddWithValue("@ubicacion", negocio.ubicacion);
                cmd.Parameters.AddWithValue("@latitud", negocio.latitud);
                cmd.Parameters.AddWithValue("@telefono", negocio.telefono);
                cmd.Parameters.AddWithValue("@fk_id_categoria", negocio.fk_id_categoria);
                cmd.Parameters.AddWithValue("@id_negocio", negocio.id_negocio);
                cmd.ExecuteNonQuery();
                retorno = true;

            }
            catch (SqlException ex)
            {

                throw;
            }
            return retorno;

        }
        public List<csNegocio> listarUbicacion(double lat, double lon)
        {

            int id_negocio;
            string nombre;
            string descripcion;
            double longitud;
            string ubicacion;
            double latitud;
            string telefono;
            int fk_id_usuario;
            int fk_id_categoria;
            double distancia;
            csNegocio negocio;
            List<csNegocio> lista = new List<csNegocio>();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select * from negocio where estado=1;", cnn);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    id_negocio = int.Parse(read["id_negocio"].ToString());
                    nombre = read["nombre"].ToString();
                    descripcion = read["descripcion"].ToString();
                    longitud = double.Parse(read["longitud"].ToString());
                    ubicacion = read["ubicacion"].ToString();
                    latitud = double.Parse(read["latitud"].ToString());
                    telefono = read["telefono"].ToString();
                    fk_id_usuario = int.Parse(read["fk_id_propietario"].ToString());
                    fk_id_categoria = int.Parse(read["fk_id_categoria"].ToString());
                    distancia = Math.Sqrt(Math.Pow((longitud + lon), 2) + Math.Pow((latitud + lat), 2));
                    negocio = new csNegocio(id_negocio, nombre, descripcion, telefono, fk_id_usuario, fk_id_categoria, longitud.ToString(), ubicacion, latitud.ToString(), distancia);
                    lista.Add(negocio);
                    
                }
            }
            catch (SqlException ex)
            {

                rta = ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return lista;
        }


    }
}
