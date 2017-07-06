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
        public int id_Ubicaion { get; set; }
        public string laptitup { get; set; }
        public string longitup { get; set; }
        public int fk_id_negocio { get; set; }
        #endregion
        public csUbicacion(int id_Ubicaion, string laptitup, string longitup, int fk_id_negocio)
        {
            this.fk_id_negocio = fk_id_negocio;
            this.id_Ubicaion = id_Ubicaion;
            this.laptitup = laptitup;
            this.longitup = longitup;
        }
    }
}
