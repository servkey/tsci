using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProoOfConceptAutos
{
    public partial class FrmAutos : Form
    {
        public FrmAutos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //1: Modelo creado
            Model.TSCIEntities db = new Model.TSCIEntities();
            Model.TblAutos auto = new Model.TblAutos() { 
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                Anio = Convert.ToInt32(txtAnio.Text)
            };
            db.AddToTblAutos(auto);
            db.SaveChanges();
            MessageBox.Show("Guardando....", "Guardar");
        }
    }
}
