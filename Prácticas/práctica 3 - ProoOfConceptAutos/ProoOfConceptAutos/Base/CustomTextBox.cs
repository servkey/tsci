using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProoOfConceptAutos.Base
{
    public partial class CustomTextBox : TextBox
    {
        public string Mask { get; set; }
        public bool Required { get; set; }

        public CustomTextBox():base()
        {            
        }
    }
}
