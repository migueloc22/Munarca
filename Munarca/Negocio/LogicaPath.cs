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
    public class LogicaPath : csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        public Boolean CrearPath(csPath path)
        {
            cnn = Conexion.AbrirCnn();
            Boolean retorno = false;
            try
            {
                cmd = new SqlCommand("INSERT INTO path (path,fk_id_negocio) VALUES (@path,@idNegocio)", cnn);
                cmd.Parameters.AddWithValue("@path", path.path);
                cmd.Parameters.AddWithValue("@idNegocio", path.fk_id_negocio);
                cmd.ExecuteNonQuery();
                retorno = true;
                Conexion.CerrarCnn(cnn);
            }
            catch (Exception ex)
            {
                Conexion.CerrarCnn(cnn);
                rta = ex.ToString();
            }
            return retorno;

        }
        public Boolean EliminarPath(int idpath)
        {
            cnn = Conexion.AbrirCnn();
            Boolean retorno = false;
            try
            {
                cmd = new SqlCommand("delete from path where id_path= @idpath", cnn);
                cmd.Parameters.AddWithValue("@idpath", idpath);
                cmd.ExecuteNonQuery();
                retorno = true;
                Conexion.CerrarCnn(cnn);
            }
            catch (Exception ex)
            {
                Conexion.CerrarCnn(cnn);
                rta = ex.ToString();
            }
            return retorno;

        }
        public List<csPath> ListarPath(int codNegocio)
        {
            List<csPath> lista = new List<csPath>();
            cnn = Conexion.AbrirCnn();
            csPath path;
            try
            {
                cmd = new SqlCommand("select * from path where fk_id_negocio=@fk_id_negocio", cnn);
                cmd.Parameters.AddWithValue("@fk_id_negocio", codNegocio);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int id_path = int.Parse(read["id_path"].ToString());
                    String pathS = read["path"].ToString();
                    int fk_id_negocio = int.Parse(read["fk_id_negocio"].ToString());
                    path = new csPath(id_path, pathS, fk_id_negocio);
                    lista.Add(path);
                }
            }
            catch (Exception ex)
            {

                rta = ex.ToString(); ;
            }
            return lista;
        }
        public DataTable DataTbPath(int codNegocio)
        {
            DataTable lista = new DataTable();
            cnn = Conexion.AbrirCnn();
            
            try
            {
                cmd = new SqlCommand("select CONCAT('/media/img/',path) as media , id_path from path where fk_id_negocio=@fk_id_negocio", cnn);
                cmd.Parameters.AddWithValue("@fk_id_negocio", codNegocio);
                read = cmd.ExecuteReader();            
                lista.Load(read);
                
            }
            catch (Exception ex)
            {

                rta = ex.ToString(); ;
            }
            return lista;
        }
    }
}
