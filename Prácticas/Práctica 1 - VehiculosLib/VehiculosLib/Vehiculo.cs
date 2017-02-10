using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehiculosLib
{
    public class Vehiculo
    {
        //Versión simplificada
        public String Modelo { get; set; }
        public String Marca { get; set; }
        public String Codigo { get; set; }
        
        //Relación
        public List<Venta> Ventas { get; set; }

        public Vehiculo()
        {
            Ventas = new List<Venta>();
        }
        /*
        //Atributos
        private String modelo;
        private String marca;
        private String codigo;

        //Versión extendida
        public String Modelo
        {
            set
            {                  
                modelo = value;
            }
            get { 
                return modelo; 
            }
        }*/
        /*
        public String GetModelo()
        {            
            return modelo;
        }

        public String GetMarca()
        {
            return marca;
        }

        public String GetCodigo()
        {
            return codigo;
        }

        public void SetModelo(String modelo)
        {
            this.modelo = modelo;        
        }

        public void SetMarca(String marca)
        {
            this.marca = marca;
        }

        public void SetCodigo(String codigo)
        {
            this.codigo = codigo;
        }*/
    }
}
