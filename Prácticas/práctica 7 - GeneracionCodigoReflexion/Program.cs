using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneracionCodigoReflexion
{
    class Persona
    {
        public int Edad { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> p = new List<Persona>();
            p.Add(new Persona { 
                 Edad = 23
            });
            
            p.Add(new Persona
            {
                Edad = 50
            });
            
            p.Add(new Persona
            {
                Edad = 65
            });

            //Linq to Objects
            //1. Origen
            int[] numeros = new int[]{3,45,10,20,53};
            int[] numerosX = new int[] { 3, 45, 10, 20, 53 };

            //2.Consulta
            int[] pares = numeros.Where(i => (i % 2) == 0).ToArray();
            
            //3.Ejecución 
            foreach(int n in pares){
                Console.WriteLine("Par {0}", n);
            }

            //2. Consulta
            int[] paresE = (from n in numeros
                            where (n % 2) == 0
                            select n).ToArray();


            //3.Ejecución 
            foreach (int n in paresE)
            {
                Console.WriteLine("Par {0}", n);
            }


            var resultado = p.Where(i => i.Edad < 60);

            //LINQ TO SQL
            //1. Origen de datos
            TSCIEntities db = new TSCIEntities();

            //2. Definición de la consulta
            var autos = from auto in db.TblAutos
                        where auto.Anio > 2000
                        select auto;


            //3. Ejecución 
            foreach (var auto in autos){
                Console.WriteLine("Marca: {0}, Modelo: {1}", auto.Marca, auto.Modelo);
            }

            foreach (var v in db.TblVentas)
            {
                //v.TblAutos.Marca
                //v.TblClientes.
            }

            foreach (var c in db.TblClientes)
            {
                //c.TblVentas
                //v.TblAutos.Marca
                //v.TblClientes.
            }

            var autosVendidos = from venta in  db.TblVentas
                                join auto in db.TblAutos
                                on venta.IdAuto equals auto.IdAuto
                                where venta.Monto.Equals("473")
                                select auto;

            Console.WriteLine("Autos vendidos con monto mayor igual a 400");
            foreach (var auto in autosVendidos)
            {
                Console.WriteLine("Marca: {0}, Modelo: {1}, Anio: {2}", auto.Marca, auto.Modelo, auto.Anio);
            }


            Operaciones.ActivityModel.Actor actor = new Operaciones.ActivityModel.Actor{ 
                Name = "Jugador", 
                          
            };
            actor.Attributes.Add(new Operaciones.ActivityModel.Util.Variable{
                Name = "nombre",
                Tipo = "System.String"
            });

            actor.Attributes.Add(new Operaciones.ActivityModel.Util.Variable
            {
                Name = "edad",
                Tipo = "System.Double"
            });

            Codigo.Util.GeneracionCodigo g = new Codigo.Util.GeneracionCodigo();
            g.Generar(actor);
            g.Compilar();
        }
    }
}
