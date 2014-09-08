using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class FiguraGeometrica
    {
        public int Id { get; set; }

        public FiguraGeometrica(int id)
        {
            Id = id;
        }

        public virtual void CalculaArea(){
            Console.WriteLine("Calculando Area Figura Geometrica");
        }
    }

    class Cuadrado : FiguraGeometrica
    {
        public int Lado { get; set; }

        public Cuadrado(int lado, int id) : base(id)
        {
            Lado = lado;
        }
        public override void CalculaArea()
        {
            base.CalculaArea();
            Console.WriteLine("Calculando Area Cuadrado");
        }
    }

    class Triangulo : FiguraGeometrica
    {
        public int Altura { get; set; }
        public int Base { get; set; }

        public Triangulo(int altura, int basea, int id): base (id)
        {
            Altura = altura;
            Base = basea;
        }
        public override void CalculaArea()
        {
            Console.WriteLine("Calculando Area Triangulo");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<FiguraGeometrica> figuras = new List<FiguraGeometrica>();
            Cuadrado c1 = new Cuadrado(10, 1);
            Cuadrado c2 = new Cuadrado(12, 2);
            Triangulo t1 = new Triangulo(12,13,3);
            Triangulo t2 = new Triangulo(13, 15, 4);
            figuras.Add(c1);
            figuras.Add(c2);
            figuras.Add(t1);
            figuras.Add(t2);

            foreach (FiguraGeometrica f in figuras)
            {
                f.CalculaArea();
            }
        
        }
    }
}
