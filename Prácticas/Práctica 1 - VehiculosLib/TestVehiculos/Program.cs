using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehiculosLib;
namespace TestVehiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Auto fiesta = new Auto
            {
                Codigo = "COD2910",
                Marca = "Ford",
                Modelo = "Fiesta"                
            };

            Camioneta x = new Camioneta
            {
                Codigo = "COD2310",
                Marca = "Toyota",
                Modelo = "X"
            };

            Venta v1 = new Venta();
            //v1.Monto = 210035;
            Vehiculo[] vv = new Vehiculo[1];
            vv[0] = fiesta;

           v1.registrar(vv, "Juan", "López", "Pérez", 210035);
              
        }
    }
}
