using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyEstudiantes.Modelo
{
    public class EstudianteRepositorio : IRepositorio <Estudiante>
    {
        public static List<Estudiante> estudiante  = new List<Estudiante>();

        public bool Add(Estudiante e)
        {
            bool result = true;
            try
            {
                estudiante.Add(e);
                //....
            }
            catch
            {
            }
            return result;
        }


        public bool Delete(Estudiante e)
        {

            bool result = true;
            try
            {
                //....
                estudiante.Remove(e);
            }
            catch
            {
            }
            return result;
        }


        public List<Estudiante> GetAll()
        {
            List<Estudiante> result = null;
            try
            {
                //....
                result = estudiante;
            }
            catch
            {
            }
            return result;
        }
    }
}
