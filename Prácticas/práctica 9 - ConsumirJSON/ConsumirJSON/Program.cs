using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ConsumirJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Model.DBCasaEntities db = new Model.DBCasaEntities();


            //foreach(Model.TblEstudiantes t in db.TblEstudiantes){
            //    Console.WriteLine(t.Nombre);
            //    Console.WriteLine(t.ApPaterno);
            //}

            var q = (from e in db.TblEstudiantes
                    where e.Id == 4
                     select e).Single();
            q.Nombre = "Pedro";
            db.SaveChanges();
            Console.WriteLine(q.Nombre);


            //Model.TblEstudiantes tbl = new Model.TblEstudiantes();
            //tbl.Nombre = "Pedro";
            //tbl.ApPaterno = "Picapiedra";
            //tbl.ApMaterno = "S";
            //tbl.Matricula = "S01203102";
            
            //db.AddToTblEstudiantes(tbl);
            //db.SaveChanges();
            
            
            var c = new WebClient();
            string json = c.DownloadString("https://www.googleapis.com/customsearch/v1?key=AIzaSyDPrJ6scmDKqUeJQfAGLn9u53f09UX0o1c&cx=017576662512468239146:omuauf_lfve&q=futbol");

            //Console.WriteLine(json);
        }
    }
}
