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
    public class LogicaTipoUsuario : csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        public DataTable DataTableTipoUsu(){
             DataTable tabla = new DataTable();

             cnn = Conexion.AbrirCnn();
             try
             {
                 cmd = new SqlCommand("Select * from tipo_usuario where id_tipo_usuario!=3", cnn);
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

