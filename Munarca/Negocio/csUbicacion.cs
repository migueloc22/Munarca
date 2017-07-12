using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csUbicacion
    {
        #region Propiedades
        public int id_Ubicacion { get; set; }
        public string laptitup { get; set; }
        public string longitup { get; set; }
        public string ubicacion { get; set; }
        public int fk_id_negocio { get; set; }
        #endregion
        public csUbicacion(int id_Ubicacion, string laptitup, string longitup, int fk_id_negocio, string ubicacion)
        {
            this.fk_id_negocio = fk_id_negocio;
            this.id_Ubicacion = id_Ubicacion;
            this.laptitup = laptitup;
            this.longitup = longitup;
            this.ubicacion = ubicacion;
        }
    }
}
