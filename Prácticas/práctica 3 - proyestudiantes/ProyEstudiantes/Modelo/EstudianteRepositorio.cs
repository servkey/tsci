using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Collections.Generic;
namespace ProyEstudiantes.Modelo
{
    public class EstudianteRepositorio : IRepositorio <Estudiante>
    {
        //public static List<Estudiante> estudiante  = new List<Estudiante>();
        Util.MSSQLConexion con = new Util.MSSQLConexion();
         
        public bool Add(Estudiante e)
        {
            bool result = true;

              //string insert_sql = String.Format("INSERT INTO [dbo].[Tbl_Estudiantes]  ([Nombre], [ApellidoPaterno], [ApellidoMaterno], [Promedio], [Matricula])  VALUES  ('{0}','{1}','{2}','{3}','{4}')", e.Nombre, e.ApellidoPaterno, e.ApellidoMaterno, e.PromedioGeneral, e.Matricula);
             
                string insert_sql = "INSERT INTO [dbo].[Tbl_Estudiantes]  ([Nombre], [ApellidoPaterno], [ApellidoMaterno], [Promedio], [Matricula])  VALUES  ('"+  e.Nombre + " ', '" + e.ApellidoPaterno + "',  '" + e.ApellidoMaterno + "', '" + e.PromedioGeneral + "', '" + e.Matricula + "')";
                //insert_sql += ";delete from Tbl_Estudiantes;";
                con.NonQuery(insert_sql);
                //estudiante.Add(e);
                //....
            
            return result;
        }


        public bool Delete(Estudiante e)
        {

            bool result = true;
            try
            {
                //....
                //estudiante.Remove(e);
            }
            catch
            {
            }
            return result;
        }


        public List<Estudiante> GetAll()
        {
            string query = "select * from Tbl_Estudiantes;";
            DataSet dr = con.Query(query, "Tbl_Estudiantes");

            List<Estudiante> estudiantes = dr.Tables[0].Rows.Cast<DataRow>().
                        Select(

                        x =>

                        new Estudiante
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            Nombre = x[1].ToString(),
                            ApellidoPaterno = x[2].ToString(),
                            ApellidoMaterno = x[3].ToString(),
                            PromedioGeneral = x[4].ToString(),
                            Matricula = x[5].ToString()
                        }
            ).ToList<Estudiante>();
            return estudiantes; 
        
        }

        public Estudiante GetById(int id)
        {
            Estudiante usuario = null;
            string query = "select * from Tbl_Estudiantes where Id = {0};";
            query = String.Format(query, id);
            DataSet dr = con.Query(query, "Tbl_Estudiantes");

            usuario = dr.Tables[0].Rows.Cast<DataRow>().
                        Select(
                             x =>

                        new Estudiante
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            Nombre = x[1].ToString(),
                            ApellidoPaterno = x[2].ToString(),
                            ApellidoMaterno = x[3].ToString(),
                            PromedioGeneral = x[4].ToString(),
                            Matricula = x[5].ToString()
                        }
            ).ToList<Estudiante>()[0];
            return usuario;
        }

    }
}
