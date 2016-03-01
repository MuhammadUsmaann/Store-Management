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
    public class StockTranferService : IRepositoryService<StockTranfer>
    {
        public override int Add(StockTranfer item)
        {

            string variables1 = "( FromLocationID , FromLocationQtyAfterTransfer , FromLocationQtyBeforeTranfer ,"
                                + " ProductID ,ToLocationAfterTranfer, ToLocationBeforeTransfer,ToLocationID ,"
                                + " TransferDate ,TransferQty  ,UserID  )";
            string variables2 = "( @FromLocationID , @FromLocationQtyAfterTransfer , @FromLocationQtyBeforeTranfer ,"
                                + " @ProductID ,@ToLocationAfterTranfer, @ToLocationBeforeTransfer,@ToLocationID ,"
                                + " @TransferDate ,@TransferQty  ,@UserID  )";
            return _db.Query<int>("Insert into " + DBTables.STOCKTRANSFER + variables1 + " OutPUT Inserted.StockTranferID VALUES " + variables2, new
            {
                item.FromLocationID,
                item.FromLocationQtyAfterTransfer,
                item.FromLocationQtyBeforeTranfer,
                item.ProductID,
                item.ToLocationAfterTranfer,
                item.ToLocationBeforeTransfer,
                item.ToLocationID,
                item.TransferDate,
                item.TransferQty,
                item.UserID,
            }).Single();
        }

        public override int Remove(StockTranfer item)
        {
            throw new NotImplementedException();
        }

        public override int Update(StockTranfer item)
        {
            throw new NotImplementedException();
        }

        public override StockTranfer FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public override StockTranfer GetSingle(StockTranfer item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<StockTranfer> Find(System.Linq.Expressions.Expression<Func<StockTranfer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<StockTranfer> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<StockTranfer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
