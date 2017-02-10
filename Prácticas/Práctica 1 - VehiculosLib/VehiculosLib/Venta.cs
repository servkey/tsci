using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehiculosLib
{
    public class Venta
    {
        public double Monto { get; set; }
        //Relaciones
        private Comprador comprador;
        private Vehiculo[] vehiculos;

        public bool registrar(Vehiculo[] vehiculos, String nombre, String appPaterno, String appMaterno, double monto)
        {
            bool result = false;
            this.vehiculos = vehiculos;
            //Método 1 para crear una instancia
            /*comprador = new Comprador();
            comprador.Nombre = nombre;
            comprador.ApPaterno = appPaterno;
            comprador.ApMaterno = appMaterno;
            */
            //Método 2 para crear una instancia
            comprador = new Comprador
            {
                Nombre = nombre,
                ApPaterno = appPaterno,
                ApMaterno = appMaterno

            };
            this.Monto = monto;
            foreach (Vehiculo v in vehiculos)
            {
                v.Ventas.Add(this);
            }

            return result;
        }
    }
}
