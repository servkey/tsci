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


    
    //Virtualización/sobre-escritura de métodos
     class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public virtual void Imprimir()
        {
            Console.WriteLine("Invocando método base");
        }
    }

    class Estudiante: Persona
    {
        public String Matricula { get; set; }

        public override void Imprimir()
        {
            Console.WriteLine("Invocando método concreto de estudiante");
        }
    }

    class Trabajador : Persona
    {
        public String NumeroDePersonal { get; set; }

        public override void Imprimir()
        {
            
            Console.WriteLine("Invocando método concreto de trabajador");
        }
    }

    sealed class Bibliotecario : Trabajador
    {
        public override void Imprimir()
        {
            Console.WriteLine("En método bibliotecario...");
        }
    }

    public class A
    {
        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Persona p1 = new Estudiante();
            object o = new object();

            Estudiante etmp = o as Estudiante;

            Estudiante e3 = new Estudiante();

            if (e3 is Persona)
            {
                Console.WriteLine("E3 es un Persona - Prueba");
            }

            if (etmp == null)
            {
            }
            if (p1 is Estudiante)
            {
                Estudiante e1 = (Estudiante)p1;
                Console.WriteLine("P1 es un estudiante - Cast exitoso");
            }
            if (o is Estudiante)
            {
                Estudiante e2 = (Estudiante)o;
                Console.WriteLine("o es un estudiante - Cast no realizado");
            }
            else
            {
                Console.WriteLine("o no es un estudiante - Cast no realizado");
            }
            return;
            A a1 = new A();
            A a2 = a1;

            a1.Nombre = "X";
            a2.Nombre = "Y";

            Console.WriteLine("a1 [nombre] = {0}", a1.Nombre);
            Console.WriteLine("a2 [nombre] = {0}", a2.Nombre);
            
            
            List<Persona> personas = new List<Persona>();
     
            personas.Add(new Estudiante { 
                 Nombre = "Juan",
                 Apellidos = "Pérez", 
                 Matricula = "S1701930"
            });

            personas.Add(new Trabajador
            {
                Nombre = "Rodrigo",
                Apellidos = "López",
                NumeroDePersonal = "345789"

            });
            foreach (Persona p in personas)
            {
                p.Imprimir();
            }
            return;

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
