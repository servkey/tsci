using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConfiguracionLib.DAO
{
    public interface IRepository<E>
    {
        void Add(E tbl);
        /*void Update(E tbl);
        void Delete(E tbl);
        List<E> GetAll();
        E GetById(int id);*/
    }
}
