﻿using System;
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
        public string direccion { get; set; }
        public string foto_negocio { get; set; }  
        public string longitud { get; set; }
        public string ubicacion { get; set; }
        public string latitud { get; set; }
        public string telefono { get; set; }
        public int fk_id_usuario { get; set; }
        public int fk_id_categoria { get; set; }
        public double distancia { get; set; }
        #endregion
        public csNegocio(int id_negocio, string nombre, string descripcion, string telefono, int fk_id_usuario, int fk_id_categoria,string direccion,string foto_negocio, string longitud, string ubicacion, string latitud) 
        {
            this.descripcion = descripcion;
            this.fk_id_categoria = fk_id_categoria;
            this.fk_id_usuario = fk_id_usuario;
            this.nombre = nombre;
            this.telefono = telefono;
            this.id_negocio = id_negocio;
            this.ubicacion = ubicacion;
            this.latitud = latitud;
            this.longitud = longitud;
            this.direccion = direccion;
            this.foto_negocio = foto_negocio;
        }
        public csNegocio(int id_negocio, string nombre, string descripcion, string telefono, int fk_id_usuario, int fk_id_categoria, string direccion, string foto_negocio, string longitud, string ubicacion, string latitud, double distancia)
        {
            this.descripcion = descripcion;
            this.fk_id_categoria = fk_id_categoria;
            this.fk_id_usuario = fk_id_usuario;
            this.nombre = nombre;
            this.telefono = telefono;
            this.id_negocio = id_negocio;
            this.ubicacion = ubicacion;
            this.latitud = latitud;
            this.longitud = longitud;
            this.distancia = distancia;
            this.direccion = direccion;
            this.foto_negocio = foto_negocio;
        }

        public csNegocio()
        {
            // TODO: Complete member initialization
        }


    }
}
