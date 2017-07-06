using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csCalificacion
    {
        #region Propiedades
        public int id_calificacion { get; set; }
        public int calificaion { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int fk_id_Negocio { get; set; }
        public int fk_id_usuario { get; set; }
        #endregion
        csCalificacion(int id_calificacion, int calificaion, string fecha, string hora, int fk_id_Negocio, int fk_id_usuario) 
        {
            this.calificaion = calificaion;
            this.fecha = fecha;
            this.fk_id_Negocio = fk_id_Negocio;
            this.fk_id_usuario = fk_id_usuario;
            this.hora = hora;
            this.id_calificacion = id_calificacion;

        }
    }
}
