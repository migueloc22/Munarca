using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csPath
    {
        #region Propiedades
        public int id_path { get; set; }
        public int fk_id_negocio { get; set; }
        public string path { get; set; }
        #endregion
        public csPath(int id_path, string path, int fk_id_negocio)
        {
            this.fk_id_negocio = fk_id_negocio;
            this.id_path = id_path;
            this.path = path;
        }
    }
}
