using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operaciones.ActivityModel
{
    public class Base
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public List<Util.Variable> Attributes { get; set; }
        public Base()
        {
            Attributes = new List<Util.Variable>();
        }
    }
}
