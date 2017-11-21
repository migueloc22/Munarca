using BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaEstadoNegocio :csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        DataTable tabla;
        public void CrearEstadoNegocio(csEstadoNegocio estNegocio) {
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("INSERT INTO estado_negocio (fk_id_categoria,fk_id_negocio) VALUES(@fk_id_categoria,@fk_id_negocio)", cnn);
                cmd.Parameters.AddWithValue("fk_id_categoria", estNegocio.fk_id_categoria);
                cmd.Parameters.AddWithValue("fk_id_negocio", estNegocio.fk_id_negocio);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                rta = ex.Message;
            }
            finally { Conexion.CerrarCnn(cnn); }
        }
        public void ModificarEstadoNegocio() { }
        public List<csEstadoNegocio> listEstadoNegocio(int cod)
        {
            List<csEstadoNegocio> lista = new List<csEstadoNegocio>();
            cnn = Conexion.AbrirCnn();
            csEstadoNegocio EstCategoria;
            int id_est_negocio = 0;
            int fk_id_categoria = 0;
            int fk_id_negocio = 0;
            try
            {
                cmd = new SqlCommand("select * from estado_negocio where fk_id_negocio=@fk_id_negocio", cnn);
                cmd.Parameters.AddWithValue("@fk_id_negocio", cod);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    id_est_negocio = int.Parse(read["id_est_negocio"].ToString());
                    fk_id_categoria = int.Parse(read["fk_id_categoria"].ToString());
                    fk_id_negocio = int.Parse(read["fk_id_negocio"].ToString());
                    EstCategoria = new csEstadoNegocio(id_est_negocio, fk_id_categoria, fk_id_negocio);
                    lista.Add(EstCategoria);
                }
            }
            catch (Exception ex)
            {

                rta = ex.Message;
            }
            finally { Conexion.CerrarCnn(cnn); }
            return lista;
        
        }
        public bool validarEstadNegocio(int fk_id_categoria, int fk_id_negocio)
        {
            bool retorno = false;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("Select * from estado_negocio where fk_id_categoria=@fk_id_categoria and fk_id_negocio=@fk_id_negocio", cnn);
                cmd.Parameters.AddWithValue("@fk_id_categoria", fk_id_categoria);
                cmd.Parameters.AddWithValue("@fk_id_negocio", fk_id_negocio);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    retorno = true;
                }

            }
            catch (Exception ex)
            {

                rta = ex.ToString();
            }
            Conexion.CerrarCnn(cnn);
            return retorno;
        }
        public void EliminarEstadoNegocio(int fk_id_categoria)
        {

            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("delete from estado_negocio where fk_id_categoria=@fk_id_categoria", cnn);
               cmd.Parameters.AddWithValue("@fk_id_categoria",fk_id_categoria);
                //cmd.Parameters.AddWithValue("fk_id_negocio", estNegocio.fk_id_negocio);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                rta = ex.Message;
            }
            finally { Conexion.CerrarCnn(cnn); }
        
        }

    }
}
