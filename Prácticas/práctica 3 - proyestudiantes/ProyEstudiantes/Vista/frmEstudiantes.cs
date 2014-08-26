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
        public frmEstudiantes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProyEstudiantes.Modelo.Estudiante estudiante = new Modelo.Estudiante
            {
                ApellidoMaterno = txtApellidoMaterno.Text,
                ApellidoPaterno = txtApellidoPaterno.Text,
                Nombre = txtNombre.Text,
            };
            //Guardar
            ProyEstudiantes.Modelo.EstudianteRepositorio r = new Modelo.EstudianteRepositorio();
            r.Add(estudiante);

        }
    }
}
