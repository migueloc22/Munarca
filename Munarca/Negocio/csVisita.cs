using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csVisita
    {
        #region Propiedades
        public int id_Visita { get; set; }
        public string tiempo { get; set; }
        public int fk_id_negocio { get; set; }
        #endregion
        public csVisita( int id_Visita , string tiempo,int fk_id_negocio ) {
            this.fk_id_negocio = fk_id_negocio;
            this.id_Visita = id_Visita;
            this.tiempo = tiempo;
        }

    }
}
