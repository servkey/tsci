using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Management;
using System.Reflection;
namespace WQLUtil.Util.ProcessEx
{
    public class Process
    {
        public uint ProcessId { get; set; }
        public String Name { get; set; }
        public uint Priority { get; set; }
        public String Handle { get; set; }
        public uint HandleCount { get; set; }
        public String Status { get; set; }
        public uint ThreadCount { get; set; }
        public String OSName { get; set; }
        public ManagementObject Input { get; set; }
        public Process()
        {
        }

        public Process(ManagementBaseObject input)
        {
            Input = (ManagementObject) input;
            foreach(var x in input.Properties){
                try
                {
                    this.GetType().InvokeMember(string.Format("set_{0}", x.Name),
                            BindingFlags.InvokeMethod,
                            null,
                            this,
                            new object[] { x.Value });
                }
                catch { }
                /*
                 ProcessId = Convert.ToInt32(x.["ProcessId"].ToString());
                 Name = x["Name"];
                 Priority = x["Priority"];
                 Status = x["Status"];
                 ThreadCount = x["ThreadCount"].ToString();
                 OSName = x["OSName"].ToString();
                 Handle = x["Handle"].ToString();*/
            }
        }
    }
}
