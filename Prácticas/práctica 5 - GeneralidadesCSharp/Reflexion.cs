using System;
using System.Reflection;

public class Reflexion
{
   public int nombre;
   public void Sumar() {} 

   static void Main()
   {
      //Assembly asm = Assembly.LoadFrom(@"C:\....\FrameworkTSCI.dll");
      //Type t = asm.GetType("FrameworkTSCI.Domain.Estudiante");
       
      Type t = typeof(Reflexion);
      // Tambi�n se puede usar lo siguiente
      // Reflexionobj = new Reflexion();
      // Type t = obj.GetType();

      Console.WriteLine("M�todos:");
      MethodInfo[] methodInfo = t.GetMethods();

      foreach (MethodInfo mInfo in methodInfo)
         Console.WriteLine(mInfo.ToString());

      Console.WriteLine("\n\nPropiedades de la clase:");
      MemberInfo[] memberInfo = t.GetMembers();

      foreach (MemberInfo mInfo in memberInfo)
         Console.WriteLine(mInfo.ToString());
   }
}