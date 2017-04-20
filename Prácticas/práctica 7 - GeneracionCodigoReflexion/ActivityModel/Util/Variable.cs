using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operaciones.ActivityModel.Util
{
    public class Variable : Base
    {
        public String Tipo { get; set; }
        public string Value { get; set; }
        public TipoVariable TipoVariable { get; set; }
        public TipoComportamiento Comportamiento { get; set; }
    }
}
