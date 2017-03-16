using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutosLib.Domain;

namespace ProoOfConceptAutos.Repositorios
{
    public class AutoRepository:IRepository<Auto>
    {
        private Model.TSCIEntities db = new Model.TSCIEntities();
            
        public void Add(Auto auto)
        {
            Model.TblAutos autoTbl = new Model.TblAutos()
            {
                Marca = auto.Marca,
                Modelo = auto.Modelo,
                Anio = Convert.ToInt32(auto.Anio)
            };
            //Agregar instancia al modelo
            db.AddToTblAutos(autoTbl);
            //Guardar cambios
            db.SaveChanges();
        }

        public void Update(Auto auto)
        {
            Model.TblAutos autoTbl = db.TblAutos.Where(x => x.IdAuto == auto.IdAuto).Single();
            autoTbl.Modelo = auto.Modelo;
            autoTbl.Marca = auto.Marca;
            autoTbl.Anio = auto.Anio;
            db.SaveChanges();         
        }

        public void Delete(Auto auto)
        {
            Model.TblAutos autoTbl = db.TblAutos.Where(x => x.IdAuto == auto.IdAuto).Single();
            db.DeleteObject(autoTbl);
            db.SaveChanges();            
        }

        public List<Auto> GetAll()
        {
            return null;
        }


        public Auto GetById(int id)
        {
            Model.TblAutos autoTbl = db.TblAutos.Where(x => x.IdAuto == id).Single();
            return new Auto() { Marca = autoTbl.Marca, Modelo = autoTbl.Modelo, IdAuto = autoTbl.IdAuto, Anio = autoTbl.Anio};
        }

    }
}
