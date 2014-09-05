using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyEstudiantes
{
    public partial class frmEstudiantes : Form
    {
        private ProyEstudiantes.Modelo.EstudianteRepositorio rEstudiante = new Modelo.EstudianteRepositorio();
          
        public frmEstudiantes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.tabControl1.Controls)
            {
                if (c is TextBox)
                {
                    //....
                }
                else if (c is CheckBox)
                {
                }
            }
            if (Util.Validar.Valida(this.))
            {
               
                ProyEstudiantes.Modelo.Estudiante estudiante = new Modelo.Estudiante
                {
                    Id = 0,
                    ApellidoMaterno = txtApellidoMaterno.Text,
                    ApellidoPaterno = txtApellidoPaterno.Text,
                    Nombre = txtNombre.Text,
                    Matricula = txtMatricula.Text
                };


                //Guardar
                rEstudiante.Add(estudiante);
            }
            else
            {
                MessageBox.Show(this, "Campos incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {

        }

        private void frmEstudiantes_Click(object sender, EventArgs e)
        {
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                cmbMatricula.DisplayMember = "Matricula";
                cmbMatricula.ValueMember = "Id";
                cmbMatricula.Items.Clear();
                cmbMatricula.DataSource = rEstudiante.GetAll();
                cmbMatricula.Refresh(); 
              }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Modelo.Estudiante e0 = (Modelo.Estudiante) cmbMatricula.SelectedItem;
                rEstudiante.Delete(e0);
                MessageBox.Show("Estudiante eliminado");
            }
            catch
            {
            }
        }

        private void cmbMatricula_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Modelo.Estudiante e0 = (Modelo.Estudiante) cmbMatricula.SelectedItem;
                lblNombreC.Text = e0.Nombre;
                lblApPaternoC.Text = e0.ApellidoPaterno;
                lblApMaternoC.Text = e0.ApellidoMaterno;
                lblMatriculaC.Text = e0.Matricula;

            }
            catch
            {
            }
        }
    }
}
