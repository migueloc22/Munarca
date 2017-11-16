using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csEstadoNegocio
    {
        public int id_est_negocio { get; set; }
        public int fk_id_categoria { get; set; }
        public int fk_id_negocio { get; set; }
        public csEstadoNegocio(int id_est_negocio, int fk_id_categoria, int fk_id_negocio)
        {
            this.id_est_negocio = id_est_negocio;
            this.fk_id_negocio = fk_id_negocio;
            this.fk_id_categoria = fk_id_categoria;
        }
    }
}
