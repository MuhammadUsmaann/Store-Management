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
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;

namespace BusinessLayer
{
    public class StoredProcedureGatewayService
    {
        public SqlConnection _db = DBModel.Get_DB_SQL_Connection();
       // public SQLiteConnection _db = DBModel.Get_DB_SQLite_Connection();

        StoredProcedureGatewayRepository _repository;
        IErrorLogRepository _logger;

        public StoredProcedureGatewayService()
        {
            _repository = new StoredProcedureGatewayRepository();
            _logger = new ErrorLogRepository();
        }

        public IEnumerable<ProductSearchViewModel> GetProducts(string productName, string productCode, int categoryID)
        {
            try
            {
                return _db.Query<ProductSearchViewModel>("prc_GetProducts", new { ProductName = productName, ProductCode = productCode, CategoryID = categoryID }, commandType: CommandType.StoredProcedure);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
        }

        public IEnumerable<ProductPricingViewModel> GetProductList(string productName, string productCode, int categoryID,int locationID)
        {
            try
            {
                return _db.Query<ProductPricingViewModel>("prc_GetProductList", new { ProductName = productName, ProductCode = productCode, CategoryID = categoryID, LocationID = locationID }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
        }

        public IEnumerable<CurrentStockViewModel> GetCurrentStock(string productName, string productCode, int categoryID, int locationID)
        {
            try
            {
                var data = _db.Query<CurrentStockViewModel>("prcCurrentStock", new { ProductName = productName, ProductCode = productCode, CategoryID = categoryID, LocationID = locationID }, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }


        }

        public IEnumerable<SaleSearchViewModel> GetSaleList(string StartDate, string EndDate, int StatusID, string InvoiceNo)
        {
            try
            {
                string variables = "";
                return _db.Query<SaleSearchViewModel>("prcCurrentStock", new { StartDate = StartDate, EndDate = EndDate, InvoiceNo = InvoiceNo, StatusID = StatusID }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
                      
        }

        public IEnumerable<TransferStockViewModel> GetProductsAtLocation(int locationID, int productID, string productName)
        {
            try
            {
                var result = _db.Query<TransferStockViewModel>("prc_GetProductsAtLocation", new { ProductName = productName, LocationID = locationID }, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }
    }
}
