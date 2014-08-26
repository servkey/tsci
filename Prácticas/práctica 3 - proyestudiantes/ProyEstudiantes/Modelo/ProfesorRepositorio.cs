using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyEstudiantes.Modelo
{
    class ProfesorRepositorio : IRepositorio<Profesor>
    {
        public static List<Profesor> profesor = new List<Profesor>();

        public bool Add(Profesor e)
        {
            bool result = true;
            try
            {
                profesor.Add(e);
                //....
            }
            catch
            {
            }
            return result;
        }


        public bool Delete(Profesor e)
        {

            bool result = true;
            try
            {
                //....
                profesor.Remove(e);
            }
            catch
            {
            }
            return result;
        }


        public List<Profesor> GetAll()
        {
            List<Profesor> result = null;
            try
            {
                //....
                result = profesor;
            }
            catch
            {
            }
            return result;
        }
    }
}
