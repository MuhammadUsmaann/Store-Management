using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace storeManager.BusinessLayer.Interfaces
{
    

    public abstract class IRepositoryService<T> where T : class
    {
        //public SqlConnection _db = DBModel.Get_DB_SQL_Connection();
        public SQLiteConnection _db = DBModel.Get_DB_SQLite_Connection();

        public StringBuilder _sb = new StringBuilder();
        public abstract int Add(T item);
        public abstract int Remove(T item);
        public abstract int Update(T item);
        public abstract T FindByID(int id);
        public abstract T GetSingle(T item);
        public abstract IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        public abstract IEnumerable<T> FindAll(string includes);
        public abstract IEnumerable<T> GetAll();
    }
   
}
