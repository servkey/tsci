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
    public partial class FrmAutos : Base.FrmBase
    {
        Repositorios.AutoRepository autoRepository = new Repositorios.AutoRepository();

        public FrmAutos():base()
        {
           
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Base.CustomTextBox> controls = Validar().ToList<Base.CustomTextBox>();
                if (controls == null)
                {
                    Auto auto = new Auto()
                    {
                        Marca = txtMarca.Text,
                        Modelo = txtModelo.Text,
                        Anio = Convert.ToInt32(txtAnio.Text)
                    };

                    autoRepository.Add(auto);
                    Limpiar();
                    MessageBox.Show(this, "El auto fue registrado exitosamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

                cmbClave.DataSource = autoRepository.GetAll();
                cmbClave.ValueMember = "IdAuto";
                cmbClave.DisplayMember = "Marca";
            }
        }

        private void FrmAutos_Load(object sender, EventArgs e)
        {

        }

        private void cmbClave_SelectedIndexChanged(object sender, EventArgs e)
        {
            Auto auto = (Auto) cmbClave.SelectedItem;
            auto = autoRepository.GetById(auto);
            txtMarcaConsulta.Text = auto.Marca;
            txtModeloConsulta.Text = auto.Modelo;
            txtAnioConsulta.Text = auto.Anio.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Auto auto = (Auto)cmbClave.SelectedItem;
            autoRepository.Delete(auto);
        }
    }
}
