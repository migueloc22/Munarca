using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class csUsuario
    {
        #region Propiedades
        public int id_usuario { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string contraseña { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string correo { get; set; }
        public string foto { get; set; }
        public string direccion { get; set; }
        public string fecha_nacimiento { get; set; }
        public string telefono { get; set; }
        public int num_documento { get; set; }
        public int fk_id_tipo_doc { get; set; }
        public int fk_id_ciudad { get; set; }
        public int codUser { get; set; }
        #endregion
        public csUsuario(int id_usuario, string nombre1, string nombre2, string apellido1, string apellido2, string correo, string foto, string direccion, string fecha_nacimiento, string telefono, int num_documento, int fk_id_tipo_doc, int fk_id_ciudad, string contraseña) 
         {
             this.apellido1 = apellido1;
             this.apellido2 = apellido2;
             this.correo = correo;
             this.direccion = direccion;
             this.fecha_nacimiento = fecha_nacimiento;
             this.fk_id_ciudad = fk_id_ciudad;
             this.fk_id_tipo_doc = fk_id_tipo_doc;
             this.foto = foto;
             this.id_usuario = id_usuario;
             this.nombre1 = nombre1;
             this.nombre2 = nombre2;
             this.num_documento = num_documento;
             this.telefono = telefono;
             this.contraseña = contraseña;
         }
        public csUsuario(int id_usuario, string nombre1, string nombre2, string apellido1, string apellido2, string correo, string foto, string direccion, string fecha_nacimiento, string telefono, int num_documento, int fk_id_tipo_doc, int fk_id_ciudad, string contraseña ,int CodUer)
        {
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.correo = correo;
            this.direccion = direccion;
            this.fecha_nacimiento = fecha_nacimiento;
            this.fk_id_ciudad = fk_id_ciudad;
            this.fk_id_tipo_doc = fk_id_tipo_doc;
            this.foto = foto;
            this.id_usuario = id_usuario;
            this.nombre1 = nombre1;
            this.nombre2 = nombre2;
            this.num_documento = num_documento;
            this.telefono = telefono;
            this.contraseña = contraseña;
            this.codUser = codUser;
        }
    }
}
