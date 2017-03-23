using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProoOfConceptAutos.Base
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Control> GetControles(Control ctr)
        {
            var controls = ctr.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetControles(ctrl))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == typeof(CustomTextBox));
        }

        public void Limpiar()
        {
            IEnumerable<Control> controls = GetControles(this);
            foreach(Control c in controls){
                if (c is CustomTextBox)
                {
                    CustomTextBox txt = (CustomTextBox)c;
                    txt.Clear();
                }
            }
        }

        public IEnumerable<CustomTextBox> Validar()
        {
            IEnumerable<CustomTextBox> customs = null;
            IEnumerable<Control> controls = GetControles(this);
            foreach (Control c in controls)
            {
                if (c is CustomTextBox)
                {
                    CustomTextBox txt = (CustomTextBox)c;
                    //txt.Mask;
                }
            }
            return customs;
        }

    }
}
