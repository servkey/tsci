using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Delegados
{
    
    class Program
    {
        public Program()
        {
            Thread hilo1 = new Thread(Probar);
            hilo1.Start();
        }
        public void Probar()
        {
            int index = 0;
            while (true)
            {
                Thread.Sleep(5000);
                Console.WriteLine("Saludando {0}", index++);
            }
        }

        public class Delegado
        {
            public static int Sumar(int x, int y)
            {
                return x + y;
            }
            public delegate int SumarDelegado(int x, int y);

        }

        public static void TestDelegado(Delegado.SumarDelegado metodo){
            Console.WriteLine("Probando delegado desde método");
            metodo(103,4948);
        }

        public static int Restar(int x, int y)
        {
            return x - y;
        }
        static void Main(string[] args)
        {
            //1.- Usuo del delegado
            Delegado.SumarDelegado metodoSumar = Delegado.Sumar;
            int resultado = metodoSumar(10, 12);

            TestDelegado(Program.Restar);

        }
    }
}
