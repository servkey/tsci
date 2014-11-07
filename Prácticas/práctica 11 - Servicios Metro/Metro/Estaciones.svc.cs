using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Metro
{

    [DataContract]
    public class DataSocialPresenteDC
    {
        [DataMember(Name = "id")]
        public int? Id { get; set; }
        [DataMember(Name = "window")]
        public int? Window { get; set; }
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Estaciones" in code, svc and config file together.
    public class Estaciones : IEstaciones
    {
        public void DoWork()
        {
        }

        public List<DataSocialPresenteDC> GetAllEstaciones()
        {
            db_socialsensorEntities db = new db_socialsensorEntities();
            List<DataSocialPresenteDC> lista = 
                                                    (from e in db.tbl_pearson_significance
                                                    select new DataSocialPresenteDC{
                                                        Id = e.Id,
                                                        Window = e.N
                                                    }).ToList<DataSocialPresenteDC>();

            return lista;
            /*foreach (tbl_pearson_significance tbl1 in db.tbl_pearson_significance)
            {
            }*/
        }
    }
}
