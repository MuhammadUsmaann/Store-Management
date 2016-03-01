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
    public class BrandService :IRepositoryService<Brand>
    {

        public override int Add(Brand item)
        {
            return _db.Execute("Insert into " + DBTables.BRAND + " (BrandName,Description) values (@BrandName, @Description)", new { item.BrandName, item.Description});
        }

        public override int Remove(Brand item)
        {
            return _db.Execute("Delete from " + DBTables.BRAND + " where BrandID=@BrandID", new { item.BrandID });
        }

        public override int Update(Brand item)
        {
            return _db.Execute("Update " + DBTables.BRAND + " set BrandName = @BrandName, Description = @Description where BrandID = @BrandID", new { item.BrandName, item.BrandID, item.Description });
        }

        public override Brand FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public override Brand GetSingle(Brand item)
        {
            return _db.Query<Brand>("Select * from " + DBTables.BRAND + " where BrandID = @BrandID", new { item.BrandID }).FirstOrDefault();
        }

        public override IEnumerable<Brand> Find(System.Linq.Expressions.Expression<Func<Brand, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Brand> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Brand> GetAll()
        {
            return _db.Query<Brand>("Select * from " + DBTables.BRAND);
        }
    }
}
