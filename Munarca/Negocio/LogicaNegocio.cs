using System;
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
                //nombreProc,Conexion

                cmd = new SqlCommand("crearRegistro", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomNegoc", negocio.nombre);
                cmd.Parameters.AddWithValue("@descrip", negocio.descripcion);
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
        public DataTable listarNegocio(int cod )
        {
            DataTable listar = new DataTable();
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("select * from  negocio where fk_id_propietario = @cod and estado=1", cnn);
                //cmd.CommandText = "select * from  negocio";
                //cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@cod",cod);
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
                cmd= new SqlCommand("select * from  negocio where  id_negocio =@codNegocio ",cnn);
                cmd.Parameters.AddWithValue("@codNegocio",codNegocio);
                read=cmd.ExecuteReader();
                if(read.Read()){
                int cod=int.Parse(read["id_negocio"].ToString());
                string nombre=read["nombre"].ToString();
                string descrip=read["descripcion"].ToString();
                int telefono=int.Parse(read["telefono"].ToString());
                int codUsuario=int.Parse(read["fk_id_propietario"].ToString());
                int codCategoria=int.Parse(read["fk_id_categoria"].ToString());
                negocio=new csNegocio(cod,nombre,descrip,telefono,codUsuario,codCategoria);
                return negocio;
                }
                return negocio = null;
                
            }
            catch (Exception)
            {
                return negocio=null;
                throw;
            }
            
        }
        public Boolean eliminarNeocio(int cod) 
        {
            SqlConnection cnn = Conexion.AbrirCnn();
            bool respuesta = false;
            try
            {
                cmd = new SqlCommand("update negocio set estado=0 where id_negocio=@cod",cnn);
                cmd.Parameters.AddWithValue("@cod", cod);
                cmd.ExecuteNonQuery();
                Conexion.CerrarCnn(cnn);
                respuesta = true;
            }
            catch (SqlException ex)
            {
                
                rta=ex.ToString();
            }
            return respuesta;
        }


    }
}
