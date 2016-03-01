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
    public class SaleService : IRepositoryService<Sale>
    {
        IErrorLogRepository _logger;

        enum SaleStatus
        {
            Open = 1,
            Close = 2
        }

        #region ISaleService Members

        public override int Add(Sale item)
        {
            string variables1 = " ( InvoiceNumber,Amount,InvoiceDate,AmountPaid,Balance,EmployeeID,"
                                  +"StoreID,CustomerID,SaleTypeID,InvoiceState,Discount,Tax,PromisedDate,"
                                  +"DateClosed,CustomerPO,PaymentModeID,VoidSale,VoucherCode,SaleStatusID,"
                                  +"SubTotal,LocationID,CustBalance)";
            string variables2 = " (@InvoiceNumber,@Amount,@InvoiceDate,@AmountPaid,@Balance,@EmployeeID,"
                                  + "@StoreID,@CustomerID,@SaleTypeID,@InvoiceState,@Discount,@Tax,@PromisedDate,"
                                  + "@DateClosed,@CustomerPO,@PaymentModeID,@VoidSale,@VoucherCode,@SaleStatusID,"
                                  + "@SubTotal,@LocationID,@CustBalance)";

            return _db.Query<int>("Insert into " + DBTables.SALES + variables1 + " OUTPUT Inserted.SaleID  VALUES " + variables2, new
            {
                item.InvoiceNumber,
                item.Amount,
                item.InvoiceDate,
                item.AmountPaid,
                item.Balance,
                item.EmployeeID,
                item.StoreID,
                item.CustomerID,
                item.SaleTypeID,
                item.InvoiceState,
                item.Discount,
                item.Tax,
                item.PromisedDate,
                item.DateClosed,
                item.CustomerPO,
                item.PaymentModeID,
                item.VoidSale,
                item.VoucherCode,
                item.SaleStatusID,
                item.SubTotal,
                item.LocationID,
                item.CustBalance
            }).Single();
        }

        public override int Remove(Sale item)
        {
            return _db.Execute("Delete from " + DBTables.SALES + " where InvoiceNumber=@InvoiceNumber", new { item.InvoiceNumber });
        }

        public override int Update(Sale item)
        {
            string variables2 = " (InvoiceNumber=@InvoiceNumber,Amount=@Amount,InvoiceDate=@InvoiceDate,AmountPaid=@AmountPaid,Balance=@Balance,EmployeeID=@EmployeeID,"
                                  + "StoreID=@StoreID,CustomerID=@CustomerID,SaleTypeID=@SaleTypeID,InvoiceState=@InvoiceState,Discount=@Discount,Tax=@Tax,PromisedDate=@PromisedDate,"
                                  + "DateClosed=@DateClosed,CustomerPO=@CustomerPO,PaymentModeID=@PaymentModeID,VoidSale=@VoidSale,VoucherCode=@VoucherCode,SaleStatusID=@SaleStatusID,"
                                  + "SubTotal=@SubTotal,LocationID=@LocationID,CustBalance=@CustBalance)";

            return _db.Execute("Update " + DBTables.SALES  + " Set " + variables2 +" where saleID=@SaleID", new
            {
                item.InvoiceNumber,
                item.Amount,
                item.InvoiceDate,
                item.AmountPaid,
                item.Balance,
                item.EmployeeID,
                item.StoreID,
                item.CustomerID,
                item.SaleTypeID,
                item.InvoiceState,
                item.Discount,
                item.Tax,
                item.PromisedDate,
                item.DateClosed,
                item.CustomerPO,
                item.PaymentModeID,
                item.VoidSale,
                item.VoucherCode,
                item.SaleStatusID,
                item.SubTotal,
                item.SaleID,
                item.LocationID,
                item.CustBalance
            });
        }

        public override Sale FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public override Sale GetSingle(Sale item)
        {
            return _db.Query<Sale>("Select * from " + DBTables.SALES + " Where SaleID = @SaleID", new { item.SaleID }).FirstOrDefault();
        }

        public override IEnumerable<Sale> Find(System.Linq.Expressions.Expression<Func<Sale, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Sale> FindAll(string includes)
        {
            return _db.Query<Sale>("Select * from " + DBTables.SALES + " Where " + includes);
        }

        public override IEnumerable<Sale> GetAll()
        {
            return _db.Query<Sale>("Select * from " + DBTables.SALES );
        }
        public void RollBackSaleTransaction(string invoiceNo)
        {
            try
            {
                new SaleDetailService().Remove(new SaleDetail { InvoiceNumber = invoiceNo });
                Remove(new Sale { InvoiceNumber = invoiceNo });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }
        public void CalculateLineTotal(int lineItmQty, decimal lineItmPrice, decimal tax, decimal discount, out decimal subTotal, out decimal total)
        {
            decimal lineTotal = lineItmPrice * lineItmQty;

            subTotal = 0;
            total = 0;

            if (discount == 0 && tax == 0)
            {
                subTotal = lineTotal;
                total = lineTotal;
            }
            else if (discount != 0 && tax == 0)
            {
                subTotal = lineTotal - discount;

                total = lineTotal - discount;
            }
            else if (discount == 0 && tax != 0)
            {
                subTotal = lineTotal;
                total = lineTotal + tax;
            }
            else if (discount != 0 && tax != 0)
            {
                subTotal = lineTotal - discount;
                total = (lineTotal - discount) + tax;
            }
        }

        #endregion


        public decimal CalculateTax(decimal saleAmount, decimal tax)
        {
            try
            {
                decimal taxamount = ((tax / 100) * saleAmount);
                return taxamount;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }


        public int GetSaleStatus(decimal saleAmount, decimal amoutPaid)
        {
            try
            {
                return amoutPaid >= saleAmount ? (int)SaleStatus.Close : (int)SaleStatus.Open;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }
        public List<string> GetInvoiceNos(string invoiceNo)
        {
            try
            {
                var sales = GetAll();
                var invoices = (from s in sales
                                    where s.InvoiceNumber.Contains(invoiceNo)
                                    select s.InvoiceNumber);
                    return invoices.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

    }
}
