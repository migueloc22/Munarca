﻿using System;
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
        public bool EliminarCategoria(string idCategoria) {
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {

                comman = new SqlCommand("delete from categoria where id_categoria=@codCategoria", cnn);
                comman.Parameters.AddWithValue("@codCategoria", idCategoria);
                comman.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                retorno = true; 
            }
            catch (Exception)
            {
                
                throw;
            }
            return retorno;
        }
//metodo para modificar categoria
        public bool ModificarCategoria(csCategoria categoria) {
            Boolean retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                comman = new SqlCommand("update categoria set  categoria=@Categoria where id_categoria=@codCategoria ", cnn);
                comman.Parameters.AddWithValue("@codCategoria",categoria.idCategoria);
                comman.Parameters.AddWithValue("@Categoria",categoria.categoria);
                comman.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                retorno = true;            
            }
            catch (Exception)
            {
                
                throw;
            }
            return retorno;
        }
        public List<csCategoria> listCategoria(int cod)
        {
            List<csCategoria> lista = new List<csCategoria>();
            cnn = Conexion.AbrirCnn();
            csCategoria categoria;
            int id_categoria = 0;
            string categ = "";
            try
            {
                comman = new SqlCommand("select * from categoria id_categoria=@id_categoria", cnn);
                comman.Parameters.AddWithValue("id_categoria", cod);
                read = comman.ExecuteReader();
                while (read.Read())
                {
                    id_categoria = int.Parse(read["id_categoria"].ToString());
                    categ = read["id_categoria"].ToString();
                    categoria = new csCategoria(id_categoria,categ);
                    lista.Add(categoria);
                }
            }
            catch (Exception ex)
            {

                rta = ex.Message;
            }
            finally { Conexion.CerrarCnn(cnn); }
            return lista;
        
        }

        

    }
}
