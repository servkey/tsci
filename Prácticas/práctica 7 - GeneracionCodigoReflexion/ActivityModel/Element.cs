using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Operaciones.ActivityModel.Util;
namespace Operaciones.ActivityModel
{
    public class Element:Variable
    {
        public string nombre { get; set; }
        public Signo signo { get; set; }
        public TipoComportamiento comportamiento { get; set; }
        public Orientacion orientacion { get; set; }
    }
}
