using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PracticaCSharpTSCI.Util;

namespace PracticaCSharpTSCI
{

    class Coleccion<T>
    {
        private T[] arreglo = new T[100];

        public T[] Arreglo
        {
            get { return arreglo; }
            set { arreglo = value; }
        }
        public T this[int i]
        {
            get
            {                
                return arreglo[i];
            }
            set
            {
                arreglo[i] = value;
            }
        }
    }


    class Estudiante
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {

            string msg = "hola, como están";
            int np = msg.NumeroDePalabras();
            Console.WriteLine("NP = {0}", np);

            Coleccion<int> numerosColeccion = new Coleccion<int>();
            
            numerosColeccion[0] = 10;
            numerosColeccion[1] = 30;
            numerosColeccion[2] = 6;

            Coleccion<Estudiante> estudiantesColeccion = new Coleccion<Estudiante>();
            
            estudiantesColeccion[0] = new Estudiante() { 
                Nombre = "Luis",
                Apellidos = "Montané"
            };
            

            int[] numeros = {13,14,55,10,4,2};
            /*
            Console.Write("[ ");
            for (int i = 0; i < numeros.Length; i++ )
            {
                if (numeros[i] % 2 == 0)
                {
                    Console.Write(numeros[i] + " ");
                }
            }
            Console.WriteLine(" ]");*/

            
            int npares = numeros.Count(x => x % 2 == 0);
            
            List<int> pares = numeros.Where(x => x % 2 == 0).ToList<int>();
            foreach(int elemento in pares){
                Console.Write(elemento + ",");
            }

           
            //string sql = "select * from usuarios where user = '{0}' and password = '{1}' and x = {2}";
            //string sql_instance = String.Format(sql, "luis", "123", 10);

        }
    }
}
