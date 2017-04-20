using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operaciones.ActivityModel.Util
{
    public class VariableSatisfaccion : Base
    {
        public string variable { get; set; }
        public string value { get; set; }
        public Satisfaction Satisfaccion {get;set;}
        public TipoVariable tipo { get; set; }
        public TipoEscala escala { get; set; }
        public VariableGanancia ganancia { get; set; }
        public double pSatisfaccion { get; set; }
    }
}
