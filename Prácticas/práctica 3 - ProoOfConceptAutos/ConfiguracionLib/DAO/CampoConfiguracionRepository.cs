using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Collections.Generic;
using ConfiguracionLib.DAO;
using ConfiguracionLib.GUI;
using ConfiguracionLib.Util;

namespace ConfiguracionLib.DAO
{
    public class CampoConfiguracionRepository : IRepository<CampoConfiguracion>
    {
        //public static List<Estudiante> estudiante  = new List<Estudiante>();
        Util.MSSQLConexion con = new Util.MSSQLConexion();
         
        public void Add(CampoConfiguracion e)
        {
            bool result = true;

              string insert_sql = String.Format("INSERT INTO [dbo].[Tbl_Estudiantes] ");// ([Nombre], [ApellidoPaterno], [ApellidoMaterno], [Promedio], [Matricula])  VALUES  ('{0}','{1}','{2}','{3}','{4}')", e.Nombre, e.ApellidoPaterno, e.ApellidoMaterno, e.PromedioGeneral, e.Matricula);
             
                //string insert_sql = "INSERT INTO [dbo].[Tbl_Estudiantes]  ([Nombre], [ApellidoPaterno], [ApellidoMaterno], [Promedio], [Matricula])  VALUES  ('"+  e.Nombre + " ', '" + e.ApellidoPaterno + "',  '" + e.ApellidoMaterno + "', '" + e.PromedioGeneral + "', '" + e.Matricula + "')";
                //insert_sql += ";delete from Tbl_Estudiantes;";
                con.NonQuery(insert_sql);
                //estudiante.Add(e);
                //....
            
            
        }


        public bool Delete(CampoConfiguracion e)
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


        public List<CampoConfiguracion> GetAll()
        {
            string query = "select * from Tbl_Estudiantes;";
            DataSet dr = con.Query(query, "Tbl_Estudiantes");

            List<CampoConfiguracion> estudiantes = dr.Tables[0].Rows.Cast<DataRow>().
                        Select(

                        x =>

                        new CampoConfiguracion
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            Nombre = x[1].ToString(),
                            Requerido = Convert.ToBoolean(x[2].ToString()),
                            Mascara = x[3].ToString(),
                            Tipo = x[4].ToString(),
                       }
            ).ToList<CampoConfiguracion>();
            return estudiantes; 
        
        }

        public CampoConfiguracion GetById(int id)
        {
            CampoConfiguracion usuario = null;
            string query = "select * from Tbl_Estudiantes where Id = {0};";
            query = String.Format(query, id);
            DataSet dr = con.Query(query, "Tbl_Estudiantes");

            usuario = dr.Tables[0].Rows.Cast<DataRow>().
                        Select(
                             x =>

                        new CampoConfiguracion
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            Nombre = x[1].ToString(),
                            Requerido = Convert.ToBoolean(x[2].ToString()),
                            Mascara = x[3].ToString(),
                            Tipo = x[4].ToString(),
                        }
            ).ToList<CampoConfiguracion>()[0];
            return usuario;
        }

    }
}
