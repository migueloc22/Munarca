using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csServicio
    {
        #region Propiedades
        public int id_servicio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int valor { get; set; }
        public int fk_id_negocio { get; set; }
        public int fk_id_tpServicios { get; set; }

        #endregion
        public csServicio(int id_servicio, string nombre, string descripcion, string imagen, string fecha, string hora, int valor, int fk_id_negocio, int fk_id_tpServicios) 
        {
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.fk_id_negocio = fk_id_negocio;
            this.hora = hora;
            this.id_servicio = id_servicio;
            this.imagen = imagen;
            this.nombre = nombre;
            this.valor = valor;
            this.fk_id_tpServicios = fk_id_tpServicios;
        }

    }
}
