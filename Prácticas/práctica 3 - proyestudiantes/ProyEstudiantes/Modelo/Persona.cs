using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyEstudiantes.Modelo
{
    public class Persona
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String ApellidoMaterno { get; set; }
        public String ApellidoPaterno { get; set; }

        private int edad;
        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
                edad = value;
            }
        }

    }
}
