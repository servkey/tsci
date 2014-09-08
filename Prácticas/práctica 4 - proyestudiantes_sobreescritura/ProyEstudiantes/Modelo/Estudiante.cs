using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyEstudiantes.Modelo
{
    //Modelo Estudiante
    public class Estudiante : Persona
    {
        public String Matricula { get; set; }
        public String PromedioGeneral { get; set; }

        public override String Mostrar()
        {
            String result = String.Format("Estudiante -> Matrícula {0} Nombre: {1} Apellidos {2}", Matricula, Nombre, ApellidoPaterno);
            return result;
        }
    }
}
