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
    public class AccessRightService : IRepositoryService<AccessRight>
    {

        public override int Add(AccessRight item)
        {
            string variable1 = " (FormID,UserID,CanView,CanEdit)";
            string variable2 = " (@FormID,@UserID,@CanView,@CanEdit)";

            return _db.Query<int>("Insert into " + DBTables.ACCESSRIGHTS + variable1 + " OUTPUT Inserted.Id VALUES " + variable2, new {
                item.FormID,
                item.UserID,
                item.CanView,
                item.CanEdit
            }).Single();
        }

        public override int Remove(AccessRight item)
        {
            throw new NotImplementedException();
        }

        public override int Update(AccessRight item)
        {
            return _db.Execute("Update " + DBTables.ACCESSRIGHTS + " set CanEdit = @CanEdit, CanView=@CanView where FormID=@FormID, UserID=@UserID", new
            {
                item.FormID,
                item.UserID,
                item.CanView,
                item.CanEdit
            });
        }

        public override AccessRight FindByID(int id)
        {
            return _db.Query<AccessRight>("Select * from " + DBTables.ACCESSRIGHTS + " where Id=@id", new { id }).FirstOrDefault();
        }

        public override AccessRight GetSingle(AccessRight item)
        {
            return _db.Query<AccessRight>("Select * from " + DBTables.ACCESSRIGHTS + " where FormID=@FormID", new { item.FormID,item.UserID }).FirstOrDefault();
        }

        public override IEnumerable<AccessRight> Find(System.Linq.Expressions.Expression<Func<AccessRight, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AccessRight> FindAll(string includes)
        {
            return _db.Query<AccessRight>("Select * from " + DBTables.ACCESSRIGHTS + " where " + includes);
        }

        public override IEnumerable<AccessRight> GetAll()
        {
            return _db.Query<AccessRight>("Select * from " + DBTables.ACCESSRIGHTS);
        }
    }
}
