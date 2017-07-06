using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csEstadoUsuario
    {
        #region Propiedades
        public int id_estadoUsuario { get; set; }
        public int fk_id_usuario { get; set; }
        public int fk_id_tipoUsurio { get; set; }
        #endregion
        public csEstadoUsuario(int id_estadoUsuario, int fk_id_usuario, int fk_id_tipoUsurio) 
        {
            this.fk_id_tipoUsurio = fk_id_tipoUsurio;
            this.fk_id_usuario = fk_id_usuario;
            this.id_estadoUsuario = id_estadoUsuario;
        }
    }
}
