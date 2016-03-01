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
    public class PaymentModeService : IRepositoryService<PaymentMode>
    {
        public override int Add(PaymentMode item)
        {
            return _db.Query<int>("Insert into " + DBTables.PAYMENTMODES + " ( PayMode ) Values (@PayMode)", new { item.PayMode}).Single();
        }

        public override int Remove(PaymentMode item)
        {
            throw new NotImplementedException();
        }

        public override int Update(PaymentMode item)
        {
            return _db.Query<int>("Update " + DBTables.PAYMENTMODES + " SET PayMode=@PayMode Where PaymentModeID=@PaymentModeID", new { item.PayMode, item.PaymentModeID }).Single();
        }

        public override PaymentMode FindByID(int id)
        {
            return _db.Query<PaymentMode>("Select * from where PaymentModeID=@id" + DBTables.PAYMENTMODES, new { id }).FirstOrDefault();
        }

        public override PaymentMode GetSingle(PaymentMode item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<PaymentMode> Find(System.Linq.Expressions.Expression<Func<PaymentMode, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<PaymentMode> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<PaymentMode> GetAll()
        {
            return _db.Query<PaymentMode>("Select * from " + DBTables.PAYMENTMODES);
        }
    }
}
