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
    public class ProductLocationService : IRepositoryService<ProductLocation>
    {
        public override int Add(ProductLocation item)
        {
            string variables1 = " (LocationID,ProductID,Quantity)";
            string variables2 = " (@LocationID,@ProductID,@Quantity)";
            var query = "Insert Into " + DBTables.PRODUCTLOCATION + variables1 + " Output inserted.Id VALUES " + variables2;
            return _db.Execute(query, new { item.LocationID, item.ProductID, item.Quantity });
        }

        public override int Remove(ProductLocation item)
        {
            throw new NotImplementedException();
        }

        public override int Update(ProductLocation item)
        {
            string variables1 = " LocationID=@LocationID,ProductID=@ProductID,Quantity=@Quantity";
            return _db.Execute("UPDATE " + DBTables.PRODUCTLOCATION + " SET " + variables1 + "  WHERE Id=@Id", new { item.LocationID, item.ProductID, item.Quantity, item.Id });
        }

        public override ProductLocation FindByID(int id)
        {
            return _db.Query<ProductLocation>("Select * from " + DBTables.PRODUCTLOCATION + " where LocationID=@Id", new { id }).FirstOrDefault();
        }

        public override ProductLocation GetSingle(ProductLocation item)
        {
            return _db.Query<ProductLocation>("Select * from " + DBTables.PRODUCTLOCATION + " where LocationID=@LocationID and ProductID=@ProductID", new { item.LocationID, item.ProductID }).FirstOrDefault();
        }

        public override IEnumerable<ProductLocation> Find(System.Linq.Expressions.Expression<Func<ProductLocation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ProductLocation> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ProductLocation> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
