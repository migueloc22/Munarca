using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csEstadoServicio
    {
        public int id_est_servicio { get; set; }
        public int fk_id_tipo_servicio { get; set; }
        public int fk_id_servicio { get; set; }
        public csEstadoServicio(int id_est_servicio, int fk_id_tipo_servicio,int fk_id_servicio)
        {
            this.id_est_servicio = id_est_servicio;
            this.fk_id_servicio = fk_id_servicio;
            this.fk_id_tipo_servicio = fk_id_tipo_servicio;
        }
    }
}
