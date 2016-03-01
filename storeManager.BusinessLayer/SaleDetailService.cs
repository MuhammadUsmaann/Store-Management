using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using storeManager.ViewModel;
using Dapper;
using storeManager.BusinessLayer.Interfaces;
namespace BusinessLayer
{
    public class SaleDetailService : IRepositoryService<SaleDetail>
    {
        public override int Add(SaleDetail item)
        {
            string variables1 = " (InvoiceNumber,UnitPrice,Quantity,ProductID,"
                                + "Discount,Tax,saleID,LineTotal,LocationID)";

            string variables2 = " (@InvoiceNumber,@UnitPrice,@Quantity,@ProductID,"
                                + "@Discount,@Tax,@saleID,@LineTotal,@LocationID)";

            return _db.Execute("Insert into " + DBTables.SALEDETAIL + variables1 + " VALUES " + variables2, new
            {
                item.InvoiceNumber,
                item.UnitPrice,
                item.Quantity,
                item.ProductID,
                item.Discount,
                item.Tax,
                item.SaleID,
                item.LineTotal,
                item.LocationID
            });
        }

        public override int Remove(SaleDetail item)
        {
            throw new NotImplementedException();
        }

        public override int Update(SaleDetail item)
        {
            string variables1 = " (InvoiceNumber=@InvoiceNumber,UnitPrice=@UnitPrice,Quantity=@Quantity,ProductID=@ProductID,"
                                 + "Discount=@Discount,Tax=@Tax,saleID=@saleID,LineTotal=@LineTotal,LocationID=@LocationID)";

            return _db.Execute("UPDATE " + DBTables.SALEDETAIL + " SET " + variables1 + " WHERE SalesDetailsID = @SalesDetailsID", new
            {
                item.InvoiceNumber,
                item.UnitPrice,
                item.Quantity,
                item.ProductID,
                item.Discount,
                item.Tax,
                item.SaleID,
                item.LineTotal,
                item.LocationID,
                item.SalesDetailsID
            });
        }

        public override SaleDetail FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public override SaleDetail GetSingle(SaleDetail item)
        {
            return _db.Query<SaleDetail>("Select * from " + DBTables.SALEDETAIL + " where SaleID = @SaleID", new { item.SaleID }).FirstOrDefault();
        }

        public override IEnumerable<SaleDetail> Find(System.Linq.Expressions.Expression<Func<SaleDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SaleDetail> FindAll(string includes)
        {
            return _db.Query<SaleDetail>("Select * from " + DBTables.SALEDETAIL + " where " + includes);
        }

        public override IEnumerable<SaleDetail> GetAll()
        {
            return _db.Query<SaleDetail>("Select * from " + DBTables.SALEDETAIL);
        }

        public void ReverseSale(int saleID, bool voidSale)
        {
            List<SaleDetail> saleDetails = FindAll(" SaleID = saleID" + saleID).ToList();

            saleDetails.ForEach(s =>
            {
                int qty = s.Quantity;
                int locationid = s.LocationID.Value;
                int productid = int.Parse(s.ProductID);

                ProductLocation location = new ProductLocationService().GetSingle(new ProductLocation { LocationID = locationid ,ProductID = productid });

                location.Quantity += qty;

                new ProductLocationService().Update(location);

            });

            Sale sale = new SaleService().FindAll("SaleID = " + saleID).FirstOrDefault();
            sale.VoidSale = voidSale;

            new SaleService().Update(sale);
        }

        public void SaveChangesToAffectedProducts(List<AffectedProductsViewModel> affectedProducts)
        {
            foreach (var detail in affectedProducts)
            {
                SaleDetail saledetail = new SaleDetail
                {
                    SalesDetailsID = detail.SaleDetailID,
                    Quantity = detail.Quantity,
                    LineTotal = detail.LineTotal,
                    Discount = detail.LineDiscount,
                    ProductID = detail.ProductID.ToString(),
                    InvoiceNumber = detail.InvoiceNumber,
                    SaleID = detail.SaleID
                };

                switch (detail.State)
                {
                    case ProductState.Unchanged:
                        break;
                    case ProductState.Modified:
                        Update(saledetail);
                        break;
                    case ProductState.Deleted:
                        Remove(saledetail);
                        break;
                    case ProductState.Added:
                        if (detail.InvoiceNumber == null) break;

                        Add(saledetail);
                        break;
                }
            }
        }
    }
}
