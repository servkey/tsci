using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutosLib.Domain;
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
            try
            {
                Repositorios.AutoRepository autoRepository = new Repositorios.AutoRepository();
                Auto auto = new Auto()
                {
                    Marca = txtMarca.Text,
                    Modelo = txtModelo.Text,
                    Anio = Convert.ToInt32(txtAnio.Text)
                };

                autoRepository.Add(auto);

                MessageBox.Show(this, "Guardando....", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
        }

        private void tbConsulta_Click(object sender, EventArgs e)
        {

        }

        private void tabPrincipal_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                Model.TSCIEntities db = new Model.TSCIEntities();
                cmbClave.DataSource = db.TblAutos;
                cmbClave.ValueMember = "IdAuto";
                cmbClave.DisplayMember = "Marca";
            }
        }
    }
}
