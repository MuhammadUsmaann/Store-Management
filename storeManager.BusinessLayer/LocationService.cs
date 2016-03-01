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
    public class LocationService:IRepositoryService<Location>
    {
        public override int Add(Location item)
        {
            return _db.Execute("Insert into " + DBTables.LOCATION + " (Name, isDefault, Comment) values (@Name, @isDefault, @Comment)", new { item.Name, item.IsDefault, item.Comment });
        }

        public override int Remove(Location item)
        {
            return _db.Execute("Delete from " + DBTables.LOCATION + " where Id=@Id", new { item.Id });
        }

        public override int Update(Location item)
        {
            return _db.Execute("Update " + DBTables.LOCATION + " set Name = @Name, Comment = @Comment where Id = @Id", new { item.Name, item.Id, item.Comment });
        }

        public override Location FindByID(int id)
        {
            return _db.Query<Location>("Select * from " + DBTables.LOCATION + " where Id = @Id", new { id }).FirstOrDefault();
        }

        public override Location GetSingle(Location item)
        {
            return _db.Query<Location>("Select * from " + DBTables.LOCATION + " where Id = @Id", new { item.Id }).FirstOrDefault();
        }

        public override IEnumerable<Location> Find(System.Linq.Expressions.Expression<Func<Location, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Location> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Location> GetAll()
        {
            return _db.Query<Location>("Select * from " + DBTables.LOCATION);
        }
    }
}
