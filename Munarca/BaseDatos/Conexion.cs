using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    public class Conexion
    {
       
      
        public static SqlConnection AbrirCnn(){
            //Conexion  de Viviana
            SqlConnection conexion = new SqlConnection("server=DESKTOP-BU4GL9O ; database=MunarcaDB ; integrated security = true");
            //Conexion de Miguel
            //SqlConnection conexion = new SqlConnection(@"server=DESKTOP-157HBSM\SQLEXPRESS; database=MunarcaDB ; integrated security = true");
            try
            {          
                    conexion.Open();
                    return conexion;
                    
            }

            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
            
        }

        public static void CerrarCnn(SqlConnection cnn)
        {
            try
            {
                cnn.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
    }
}
