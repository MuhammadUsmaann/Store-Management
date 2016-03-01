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
    public class CategoryService : IRepositoryService<Category>
    {

        public override int Add(Category item)
        {
            return _db.Execute("Insert into " + DBTables.CATEGORY + " (Name,comment) values (@Name, @comment)", new { item.Name, item.Comment });
        }

        public override int Remove(Category item)
        {
            return _db.Execute("Delete from " + DBTables.CATEGORY + " where CategoryID=@CategoryID", new { item.CategoryID });
        }

        public override int Update(Category item)
        {
            return _db.Execute("Update " + DBTables.BRAND + " set Name = @Name, Comment= @Comment where CategoryID = @CategoryID", new { item.Name, item.CategoryID, item.Comment }); 
        }

        public override Category FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public override Category GetSingle(Category item)
        {
            return _db.Query<Category>("Select * from " + DBTables.CATEGORY + " where CategoryID = @CategoryID", new { item.CategoryID }).FirstOrDefault();
        }

        public override IEnumerable<Category> Find(System.Linq.Expressions.Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Category> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Category> GetAll()
        {
            return _db.Query<Category>("Select * from " + DBTables.CATEGORY);
        }
    }
}
