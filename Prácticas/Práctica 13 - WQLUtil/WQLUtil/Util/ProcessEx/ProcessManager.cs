using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;

namespace WQLUtil.Util.ProcessEx
{
    public class ProcessManager
    {
        public static List<Process> GetAllProcess()
        {
            List<Process> process = null;
            try
            {
                string equipo = "127.0.0.1";
                ManagementPath path = new ManagementPath("\\\\" + equipo + "\\root\\cimv2");
               
                ManagementScope scope = new ManagementScope(path);               
                ObjectQuery selectQuery = new ObjectQuery("Select * from Win32_Process");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, selectQuery);
                process = searcher.Get().Cast<ManagementObject>().
                        Select(
                            x =>
                            new Process(x)
                        ).ToList<Process>();
            
            }
            catch (Exception ex)
            {
               //MessageBox.Show(ex.Message);
            }
            return process;
         
        }
        
        public static List<Process> GetAllProcessByHost(string hostname, string user, string password)
        {
            List<Process> process = null;
            try
            {
                //SERVKEY-XPS

                string equipo = hostname;
                ManagementPath path = new ManagementPath("\\\\" + equipo + "\\root\\cimv2");
                
                ConnectionOptions conexion = new ConnectionOptions(); ;
                conexion.Username = user;
                conexion.Password = password;
               
                ManagementScope scope = new ManagementScope(path, conexion);               
                ObjectQuery selectQuery = new ObjectQuery("Select * from Win32_Process");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, selectQuery);
                process = searcher.Get().Cast<ManagementObject>().
                        Select(
                            x =>
                            new Process(x)
                        ).ToList<Process>();
            
            }
            catch (Exception ex)
            {
               //MessageBox.Show(ex.Message);
            }
            return process;
         
        }

        
        public static void Kill(Process p){
            try
            {
                p.Input.InvokeMethod("Terminate", null);
            }
            catch { }
        }

        public static void KillByProcessId(List<Process> process, uint id)
        {
            try
            {
                Process pr1 = process.Where<Process>(x => x.ProcessId == id).Single<Process>();
                pr1.Input.InvokeMethod("Terminate", null);
            }
            catch { }
        }

        public static void KillByName(List<Process> process, String name)
        {
            try
            {
                Process pr1 = process.Where<Process>(x => x.Name.Equals(name)).Single<Process>();
                pr1.Input.InvokeMethod("Terminate", null);
            }
            catch { }
        }
    }
}
