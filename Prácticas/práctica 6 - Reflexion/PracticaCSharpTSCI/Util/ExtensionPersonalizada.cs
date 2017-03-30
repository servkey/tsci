using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticaCSharpTSCI.Util
{
    public static class ExtensionPersonalizada
    {
        public static int NumeroDePalabras(this String cadena)
        {
            return cadena.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
