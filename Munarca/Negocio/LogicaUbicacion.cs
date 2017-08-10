using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BaseDatos;

namespace Negocio
{
    public class LogicaUbicacion:csRespuesta
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        public Boolean CrearUbicacion(csUbicacion ubicacion)
        {
            bool retorno=false;
            cnn = Conexion.AbrirCnn();
            try
            {
                cmd = new SqlCommand("insert into ubicacion(laptitud,longitud,ubicacion,fk_id_negocio) values(@laptitud,@longitud,@ubicacion,@fk_id_negocio)", cnn);
                cmd.Parameters.AddWithValue("@laptitud",ubicacion.laptitup);
                cmd.Parameters.AddWithValue("@longitud",ubicacion.longitup);
                cmd.Parameters.AddWithValue("@ubicacion",ubicacion.ubicacion);
                cmd.Parameters.AddWithValue("@fk_id_negocio",ubicacion.fk_id_negocio);
                cmd.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {

                rta=ex.ToString();
            }
            finally { Conexion.CerrarCnn(cnn); }
            return retorno;
        }
        public List<csUbicacion> ListarUbicacion(double lat, double lon)
        {
            csUbicacion csubicacion;
            List<csUbicacion> lista = new List<csUbicacion>();
            cnn = Conexion.AbrirCnn();
            try
            {
                string nombreNegocio;
                string descrcicion;
                double longitup;
                double lapgitup;
                double distancia;
                int idNegocio;
                int idUbicacion;
                string ubicacion;
                //cmd = new SqlCommand("select ubicacion.id_ubicacion,ubicacion.fk_id_negocio,ubicacion.laptitud,ubicacion.longitud,ubicacion.ubicacion,negocio.nombre,negocio.descripcion  from ubicacion inner join negocio on ubicacion.fk_id_negocio=negocio.id_negocio where negocio.estado=1;", cnn);
                cmd = new SqlCommand("select * from ubicacion inner join negocio on ubicacion.fk_id_negocio=negocio.id_negocio where negocio.estado=1;", cnn);

                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    nombreNegocio = read["nombre"].ToString();
                    descrcicion = read["descripcion"].ToString(); ;
                    longitup = double.Parse(read["longitud"].ToString());
                    lapgitup = double.Parse(read["laptitud"].ToString());
                    idNegocio = int.Parse(read["fk_id_negocio"].ToString());
                    idUbicacion = int.Parse(read["id_ubicacion"].ToString());
                    ubicacion = read["ubicacion"].ToString();
                    distancia = Math.Sqrt(Math.Pow((longitup + lon), 2) + Math.Pow((lapgitup + lat), 2));
                    csubicacion = new csUbicacion(idUbicacion, lapgitup.ToString(), longitup.ToString(), idNegocio, distancia, nombreNegocio, descrcicion, ubicacion);
                    lista.Add(csubicacion);
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
