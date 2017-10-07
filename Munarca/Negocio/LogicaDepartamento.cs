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
    public class LogicaDepartamento : csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;

         public DataTable DataTableDpto(){
             DataTable tabla = new DataTable();

             cnn = Conexion.AbrirCnn();
             try
             {
                  cmd = new SqlCommand("Select * from departamento", cnn);
                  read = cmd.ExecuteReader();
                  tabla.Load(read);
             }
             catch (Exception ex)
             {
                 rta = ex.ToString();   
                 
             }
             Conexion.CerrarCnn(cnn);
             return tabla;
         }
         public DataTable DataTableDpto(int id_departamento)
         {
             DataTable tabla = new DataTable();

             cnn = Conexion.AbrirCnn();
             try
             {
                 cmd = new SqlCommand("Select * from departamento where id_departamento=@id_departamento", cnn);
                 cmd.Parameters.AddWithValue("@id_departamento", id_departamento);
                 read = cmd.ExecuteReader();
                 tabla.Load(read);
             }
             catch (Exception ex)
             {
                 rta = ex.ToString();

             }
             Conexion.CerrarCnn(cnn);
             return tabla;
         }
    }



    }

