﻿using System;
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
    }



    }

