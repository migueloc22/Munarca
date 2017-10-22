using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csCategoria
    {
        public int idCategoria{ get; set; }
        public string categoria { get; set; }
       public csCategoria(int idCategoria, string categoria){
           this.idCategoria = idCategoria;
           this.categoria = categoria;

}
        
    }

}
