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
    public delegate void SampleDelegate();
    public interface ISampleEvents
    {
        event SampleDelegate SampleEvent;
        void Invoke();
    }
    
    public class SampleClass: ISampleEvents{
        public event SampleDelegate SampleEvent;
        public void Invoke(){
            SampleEvent();
        }
    }

    public class TestClass
    {
        public void Event_1()
        {
            Console.WriteLine("Event_1");
        }

        public void Test()
        {
            SampleClass sc = new SampleClass();
            //sc.SampleEvent += Event_1;
            sc.Invoke();
        }
    }
    public delegate  void Sumar();
    public delegate void Calcular();
    class Operaciones
    {
        public double Result { get; set; }
        public event EventHandler Event;
        public event Calcular delegateCalcular;
        public void Operacion()
        {
            //delegateCalcular = new Calcular(c);
            Console.WriteLine("Alguien Sumó algo");
            Event(this, EventArgs.Empty);
            delegateCalcular();
        }


    }

    class Form
    {
        public int Ancho { get; set; }
        public void Sumar2()
        {
            Console.WriteLine("Sumando desde Program...Delegado 2 ");
            Ancho = 1030;
        }

        public void Sumar()
        {
            Console.WriteLine("Sumando desde Program...Delegado 1");
            Ancho = 2200;
        }
        public void EventSumar(object sender, EventArgs e)
        {
            Operaciones o = (Operaciones)sender;
            o.Result++;
            Console.WriteLine("Evento desde fuera!!" + o.Result);
          
        }

        public void Run()
        {
            Operaciones p = new Operaciones();
            p.Event += new EventHandler(EventSumar);
         
            p.delegateCalcular += Sumar;
            p.Operacion();
            p.delegateCalcular += Sumar2;
            p.Operacion();
        }
    }

    class Poligono
    {
        public string Nombre { get; protected set; }
    }

    class Program
    {


        static int NumDigitos(int n)
        {
            if (n < 10)
            {
                return 1;
            }
            else
            {
                return 1 + NumDigitos(n / 10);
            }
        }


        static void Main(string[] args)
        {
            TestClass tc = new TestClass();
            tc.Test();
            return;
            Form pr = new Form();
            pr.Ancho = 100;
            pr.Run();
            Console.WriteLine(pr.Ancho);
        
           

           int d = NumDigitos(20000);
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
                //p.Sumar(pr.Sumar);
            }
        
        }
    }
}
