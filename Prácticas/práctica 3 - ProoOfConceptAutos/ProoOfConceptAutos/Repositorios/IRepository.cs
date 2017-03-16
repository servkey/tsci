using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutosLib.Domain;
namespace ProoOfConceptAutos.Repositorios
{
    public interface IRepository<E>
    {
        void Add(E tbl);
        void Update(E tbl);
        void Delete(E tbl);
        List<E> GetAll();
        E GetById(int id);
    }
}
