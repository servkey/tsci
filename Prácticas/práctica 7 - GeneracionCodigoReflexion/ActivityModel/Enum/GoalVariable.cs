using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operaciones.ActivityModel.Enum
{
    public class GoalVariable : Element
    {
        public Operaciones.ActivityModel.Util.TipoVariable tipo { get; set; }
        public Enum.GoalType type { get; set; }
       
    }
}
