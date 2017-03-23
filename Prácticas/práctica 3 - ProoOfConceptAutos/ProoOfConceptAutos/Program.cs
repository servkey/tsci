using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProoOfConceptAutos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int[] x = { 1,34,5,7,10};
            int pares = x.Count(x1 => x1 % 2 == 0);
            return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAutos());
        }
    }
}
