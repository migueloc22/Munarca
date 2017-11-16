using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csTipoServicio
    {

        public int id_tipo_servicio { get; set; }
        public string tipo_servicio { get; set; }
        public csTipoServicio(int id_tipo_servicio,string tipo_servicio)
        {
            this.id_tipo_servicio = id_tipo_servicio;
            this.tipo_servicio = tipo_servicio;

        }
    }
}
