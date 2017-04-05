using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteVerificar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Verificar si hay alguna actualización disponible
            ServicioActualizacion.ActualizacionSoapClient cliente = new ServicioActualizacion.ActualizacionSoapClient();
            bool resultado = cliente.VerificarVersion("xkadjska");
            MessageBox.Show("¿Hay una nueva actualización?" + resultado, "Actualización");
        }
    }
}
