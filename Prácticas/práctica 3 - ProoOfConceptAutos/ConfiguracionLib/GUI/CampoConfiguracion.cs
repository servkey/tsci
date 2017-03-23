using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfiguracionLib.GUI
{
    public class CampoConfiguracion
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public bool Requerido { get; set; }
        public String Mascara { get; set; }
        public String Tipo {get;set;}
    }
}
