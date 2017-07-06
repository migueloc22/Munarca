using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csNegocio
    {
        #region Propiedades
        public int id_negocio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int telefono { get; set; }
        public int fk_id_usuario { get; set; }
        public int fk_id_categoria { get; set; }
        #endregion
        public csNegocio( int id_negocio,string nombre,string descripcion, int telefono,int fk_id_usuario,int fk_id_categoria ) 
        {
            this.descripcion = descripcion;
            this.fk_id_categoria = fk_id_categoria;
            this.fk_id_usuario = fk_id_usuario;
            this.nombre = nombre;
            this.telefono = telefono;
            this.id_negocio = id_negocio;
        }
    }
}
