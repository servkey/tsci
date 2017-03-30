using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace Reflexion
{

    class Delegado
    {
        public static int Restar(int x, int y)
        {
            return x - y;
        }
        
        public static int Multiplicar(int x, int y)
        {
            return x * y;
        }

        public static int Dividir(int x, int y)
        {
            return x / y;
        }
        public static int Sumar(int x, int y)
        {
            return x + y;
        }
        public delegate int OperacionDelegado(int x, int y);
    }

    class DelegadoTest
    {
        public Delegado.OperacionDelegado SeleccionandoDelegado(int opcion)
        {
            Delegado.OperacionDelegado resultado;
            if (opcion == 1)
            {
                resultado = Delegado.Sumar;
            }
            else if (opcion == 2)
            {
                resultado = Delegado.Restar;
            }
            else if (opcion == 3)
            {
                resultado = Delegado.Multiplicar;
            }
            else
            {
                resultado = Delegado.Dividir;
            }
            return resultado;
        }
    }

    class Persona
    {
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public void Caminar(string lugar)
        {
            Console.WriteLine("Caminando...");
        }
    }

    class Estudiante: Persona
    {
        public String Matricula { get; set; }

        public void Estudiar(int num, string materia)
        {
            Console.WriteLine("Estudiando...");
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            //Reflexion
            Estudiante e = new Estudiante();
            Type t = e.GetType();
            
            Console.WriteLine("Nombre completo: {0}", t.FullName);
            Console.WriteLine("Nombre Tipo Base: {0}" , t.BaseType.Name);
            Console.WriteLine("Nombre Tipo Base Base: {0}", t.BaseType.BaseType.Name);

            Console.WriteLine("********Métodos*****");
                
            foreach (MethodInfo m in t.GetMethods()){
                Console.WriteLine("\tNombre de método: {0}", m.Name);
                Console.WriteLine("\tParámetros del método: ");
                
                foreach (ParameterInfo p in m.GetParameters())
                {
                    Console.WriteLine("\t\tParámetro: {0}, Tipo: {1}", p.Name, p.ParameterType.Name); 
                }
            }
            Console.WriteLine("********Propiedades*****");
            
            foreach (PropertyInfo m in t.GetProperties())
            {
                Console.WriteLine("\tNombre de Propiedad: " + m.Name);
            }


            return;
            DelegadoTest dt = new DelegadoTest();
            Delegado.OperacionDelegado del = dt.SeleccionandoDelegado(1);
            int x = del(10, 30);
            Delegado d = new Delegado();
            //d.GetType().
        }
    }
}
