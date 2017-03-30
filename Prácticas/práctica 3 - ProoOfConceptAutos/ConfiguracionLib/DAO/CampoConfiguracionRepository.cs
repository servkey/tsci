using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
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

              string insert_sql = String.Format("INSERT INTO [dbo].[Tbl_CamposConfiguraciones] ");// ([Nombre], [ApellidoPaterno], [ApellidoMaterno], [Promedio], [Matricula])  VALUES  ('{0}','{1}','{2}','{3}','{4}')", e.Nombre, e.ApellidoPaterno, e.ApellidoMaterno, e.PromedioGeneral, e.Matricula);
             
                //string insert_sql = "INSERT INTO [dbo].[Tbl_Estudiantes]  ([Nombre], [ApellidoPaterno], [ApellidoMaterno], [Promedio], [Matricula])  VALUES  ('"+  e.Nombre + " ', '" + e.ApellidoPaterno + "',  '" + e.ApellidoMaterno + "', '" + e.PromedioGeneral + "', '" + e.Matricula + "')";
                //insert_sql += ";delete from Tbl_Estudiantes;";
                con.NonQuery(insert_sql);
                //estudiante.Add(e);
                //....
            
            
        }


        public void Delete(CampoConfiguracion e)
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
        }


        public List<CampoConfiguracion> GetAll()
        {
            string query = "select * from TblCamposConfiguraciones;";
            DataSet dr = con.Query(query, "TblCamposConfiguraciones");

            List<CampoConfiguracion> campos = dr.Tables[0].Rows.Cast<DataRow>().
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
            return campos; 
        
        }

        public CampoConfiguracion GetById(int id)
        {
            CampoConfiguracion campo = null;
            string query = "select * from TblCamposConfiguraciones where Id = {0};";
            query = String.Format(query, id);
            DataSet dr = con.Query(query, "TblCamposConfiguraciones");

            campo = dr.Tables[0].Rows.Cast<DataRow>().
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
            return campo;
        }

    }
}
