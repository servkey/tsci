using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WQLUtil.Util.ProcessEx;
using System.Management;
using System.Windows.Forms;
namespace Pruebas
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
           
            
            //WQLUtil.Util.Mouse.MouseManager.Main();
            //List<Process> process = ProcessManager.GetAllProcess();
            //SERVKEY-XPS
            /*List<Process> process = ProcessManager.GetAllProcessByHost("SERVKEY-XPS","servkey","****");
            
            foreach(Process p in process){
                Console.Write("ProcessId: {0}, ", p.ProcessId);
                Console.Write("Name: {0}, ", p.Name);
                Console.Write("Priority: {0}, ", p.Priority);
                Console.Write("Status: {0}, ", p.Status);
                Console.Write("ThreadCount: {0}, ", p.ThreadCount);
                Console.Write("Handle: {0}, ", p.Handle);
                Console.WriteLine("OSName: {0}", p.OSName);
              }

            try
            {
                Process pr1 = process.Where<Process>(x => x.Name.Equals("notepad.exe")).Single<Process>();
                pr1.Input.InvokeMethod("Terminate", null);
            }
            catch { }
             
            return;*/
            Test t = new Test();
            System.Windows.Forms.Application.Run();
         }      
    }
}
