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
    public class UserService:IRepositoryService<User> 
    {
        public User Login(string username, string password)
        {
            var query = "select * from " + DBTables.USER + " where username = @username and UserPassword = @password";
            return _db.Query<User>(query, new { username, password }).FirstOrDefault();
        }
        public int UpdatePassword(User item)
        {
            return _db.Execute("Update " + DBTables.USER + " set UserPassword = @UserPassword where UserID =@UserID", new { item.UserID, item.UserPassword });
        }

        public override int Add(User item)
        {
            string variables1 = " (UserName, UserPassword,EmployeeID,DateCreated,IsAdmin,Active)";
            string variables2 = " (@UserName, @UserPassword,@EmployeeID,@DateCreated,@IsAdmin,@Active)";

            var UserID = _db.Query<int>("Insert Into " + DBTables.USER + variables1 + " OUTPUT Inserted.userID Values " + variables2, new
            {
                item.UserName,
                item.UserPassword,
                item.EmployeeID,
                item.DateCreated,
                item.IsAdmin,
                item.Active
            }).Single();
            return UserID;
        }
        //public User Add(User item)
        //{
        //    string variables1 = " (UserName, UserPassword,EmployeeID,DateCreated,IsAdmin,Active)";
        //    string variables2 = " (@UserName, @UserPassword,@EmployeeID,@DateCreated,@IsAdmin,@Active)";

        //    var UserID = _db.Query<int>("Insert Into " + DBTables.USER + variables1 + " OUTPUT Inserted.userID Values " + variables2, new
        //    {
        //        item.UserName,
        //        item.UserPassword,
        //        item.EmployeeID,
        //        item.DateCreated,
        //        item.IsAdmin,
        //        item.Active
        //    }).Single();
        //    return _db.Query<User>("Select * from " + DBTables.USER + " Where UserID=@UserID", new { UserID }).FirstOrDefault();
        //}

        public override int Remove(User item)
        {
            throw new NotImplementedException();
        }
        public override int Update(User item)
        {
            string variables1 = " UserName=@UserName, UserPassword=@UserPassword,IsAdmin=@IsAdmin,Active=@Active";
            return _db.Execute("Update " + DBTables.USER + " set " + variables1 + " where UserID =@UserID", new
            {
                item.UserID,
                item.UserName,
                item.UserPassword,
                item.IsAdmin,
                item.Active
            });
        }

        public override User FindByID(int id)
        {
            return _db.Query<User>("select * from " + DBTables.USER + " where UserID = @id", new { id }).FirstOrDefault();
        }

        public override User GetSingle(User item)
        {

            var query = "select * from " + DBTables.USER + " where username = @UserName and UserPassword = @UserPassword";
            return _db.Query<User>(query, new { item.UserPassword,item.UserName}).FirstOrDefault();
        }

        public override IEnumerable<User> Find(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<User> FindAll(string includes)
        {
            return _db.Query<User>("Select * from " + DBTables.USER + " where " + includes);
        }

        public override IEnumerable<User> GetAll()
        {
            return _db.Query<User>("Select * from " + DBTables.USER);
        }
    }
}
