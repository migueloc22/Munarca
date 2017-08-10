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
    public class LogicaCiudad : csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;

        
         public DataTable DataTableCiudad(){
             DataTable tabla = new DataTable();
             cnn = Conexion.AbrirCnn();
             try
             {
                  cmd = new SqlCommand("Select * from ciudad", cnn);
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
         public DataTable DataTableCiudad(int codDepartemento)
         {
             DataTable tabla = new DataTable();
             cnn = Conexion.AbrirCnn();
             try
             {
                 cmd = new SqlCommand("Select * from ciudad where fk_id_departemento=@fk_id_departemento", cnn);
                 cmd.Parameters.AddWithValue("@fk_id_departemento", codDepartemento);
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
