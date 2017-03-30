using System;
class csrefKeywordsOperators 
   {
       class Base
       {
           public override string  ToString()
           {
	             return "Base";
           }
       }
       class Derived : Base 
       { 
           public override string  ToString()
           {
	             return "Derived";
           }
	}

       class Program
       {
           static void Main()
           {

               Derived d = new Derived();
	       object obj = new object();
               Base b = d as Base;
               Base b1 = b as Base;
		if (b1 == null){
		   Console.WriteLine("No es Base");
		
		}
               if (b != null)
               {
                   Console.WriteLine(b.ToString());
		   Derived d1 = (Derived)b;
                   Console.WriteLine(d1.ToString());
               }

           }
       }
   }
