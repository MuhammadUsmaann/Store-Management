using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using storeManager.BusinessLayer.Interfaces;
using Dapper;

namespace BusinessLayer
{
    public class TaxService : IRepositoryService<Tax>    {

        public override int Add(Tax item)
        {
            var variables1 = " (TaxName,TaxRate,TaxNumber )";
            var variables2 = " (@TaxName,@TaxRate,@TaxNumber )";

            return _db.Query<int>("Insert Into " + DBTables.TAXS + " Output Inserted.TaxID VALUES " + variables2, new { item.TaxName, item.TaxRate, item.TaxNumber }).Single();
        }

        public override int Remove(Tax item)
        {
            throw new NotImplementedException();
        }

        public override int Update(Tax item)
        {
            var s = "TaxID,TaxName,TaxRate,TaxNumber";
            return _db.Execute("Update " + DBTables.TAXS + " Set ");
        }

        public override Tax FindByID(int id)
        {
            return _db.Query<Tax>("Select * From Where TaxID=@id", new { id }).FirstOrDefault();
        }

        public override Tax GetSingle(Tax item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Tax> Find(System.Linq.Expressions.Expression<Func<Tax, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Tax> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Tax> GetAll()
        {
            return _db.Query<Tax>("Select * from " + DBTables.TAXS);
        }
    }
}
