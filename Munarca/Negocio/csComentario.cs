using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csComentario
    {
        #region Propiedades
        public int id_comentario { get; set; }
        public string comentario { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int fk_id_usuario { get; set; }
        public int fk_id_negocio { get; set; }
        #endregion
        public csComentario(int id_comentario, string comentario, string fecha, string hora, int fk_id_usuario, int fk_id_negocio)
        {

            this.comentario = comentario;
            this.fecha = fecha;
            this.fk_id_negocio = fk_id_negocio;
            this.fk_id_usuario = fk_id_usuario;
            this.hora = hora;
            this.id_comentario = id_comentario;
            
        }

    }
}
