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
    public class MeasurementService : IRepositoryService<Measurement>
    {
        public override int Add(Measurement item)
        {
            return _db.Execute("Insert into " + DBTables.MEASUREMENT+ " (Name,Description) values (@Name, @Description)", new { item.Name, item.Description });
        }

        public override int Remove(Measurement item)
        {
            return _db.Execute("Delete from " + DBTables.MEASUREMENT + " where Id=@Id", new { item.Id });
        }

        public override int Update(Measurement item)
        {
            return _db.Execute("Update " + DBTables.MEASUREMENT + " set Name = @Name, Description = @Description where Id = @Id ", new { item.Id, item.Name, item.Description });
        }

        public override Measurement FindByID(int id)
        {
            return _db.Query<Measurement>("Select * from " + DBTables.MEASUREMENT + " where Id = @Id", new { id }).FirstOrDefault();
        }

        public override Measurement GetSingle(Measurement item)
        {
            return _db.Query<Measurement>("Select * from " + DBTables.MEASUREMENT + " where Id = @Id", new { item.Id }).FirstOrDefault();
        }

        public override IEnumerable<Measurement> Find(System.Linq.Expressions.Expression<Func<Measurement, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Measurement> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Measurement> GetAll()
        {
            return _db.Query<Measurement>("Select * from " + DBTables.MEASUREMENT);
        }
    }
}
