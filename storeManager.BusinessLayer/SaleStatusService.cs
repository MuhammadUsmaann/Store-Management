using storeManager.BusinessLayer.Interfaces;
using storeManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace storeManager.BusinessLayer
{
    public class SaleStatusService:IRepositoryService<SaleStatus>
    {
        public override int Add(SaleStatus item)
        {
            return _db.Query<int>("Insert Into " + DBTables.SALESTATUS + " (status) OUTPUT Insert.Id VALUES (@status)", new { item.Status }).Single();
        }

        public override int Remove(SaleStatus item)
        {
            throw new NotImplementedException();
        }

        public override int Update(SaleStatus item)
        {
            return _db.Execute("Update " + DBTables.SALESTATUS + " SET status=@status where Id=@Id", new { item.Id, item.Status });
        }

        public override SaleStatus FindByID(int id)
        {
            return _db.Query<SaleStatus>("Select * from " + DBTables.SALESTATUS + " where Id=@Id", new { id }).FirstOrDefault();
        }

        public override SaleStatus GetSingle(SaleStatus item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SaleStatus> Find(System.Linq.Expressions.Expression<Func<SaleStatus, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SaleStatus> FindAll(string includes)
        {
            return _db.Query<SaleStatus>("Select * from " + DBTables.SALESTATUS + " where "+ includes);
        }

        public override IEnumerable<SaleStatus> GetAll()
        {
            return _db.Query<SaleStatus>("Select * from " + DBTables.SALESTATUS);
        }
    }
}
