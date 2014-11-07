using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.EstacionesClient client = new ServiceReference1.EstacionesClient();

            ServiceReference1.DataSocialPresenteDC[] resultado =  client.GetAllEstaciones();

            foreach (ServiceReference1.DataSocialPresenteDC d in resultado)
            {
               Console.WriteLine(d.id);
            }

            return;
            db_socialsensorEntities db1 = new db_socialsensorEntities();

            List<tbl_historical_interactions_data_game> q = (from u in db1.tbl_historical_interactions_data_game
                    where u.CN.Equals(4) && u.G > 10
                    select u).ToList();



            foreach (tbl_pearson_significance r0 in db1.tbl_pearson_significance)
            {
                Console.WriteLine("Atr = {0}", r0.atr1);
            }

            equipo1Entities db = new equipo1Entities();
            foreach (rutas r in db.rutas)
            {
                Console.WriteLine("Nombre = {0}", r.nombre);
            }

        }
    }
}
