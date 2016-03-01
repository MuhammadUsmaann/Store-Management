using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeManager.BusinessLayer.Interfaces
{
    public class RepositoryConfiguration
    {
        public static string USERNAME = "sa";
        public static string PASSWORD = "Netsolpk1";
        public static string DBNAME = "StoreManagerDB";
        public static string SERVERNAME = @"M-USMAN";


        public static string SECURITYKEY = "for encryption and decryption"; 
    }
    public class DBType
    {
       public static string SQLSERVER = "sqlserver";
       public static string SQLite= "sqlite";
    }
    public static class DBTables
    {
        public const string USER = "users";
        public const string COMPANY = "Companies";
        public const string LOCATION = "Locations";
        public const string BRAND = "Brands";
        public const string CATEGORY = "Categories";
        public const string MEASUREMENT = "Measurements";
        public const string ACCESSRIGHTS = "AccessRights";
        public const string EMPLOYEE = "employees";
        public const string CUSTOMER = "customers";
        public const string SUPPLIER = "Suppliers";
        public const string SALEDETAIL = "saledetails";
        public const string SALES = "sales";
        public const string PRODUCTLOCATION = "ProductLocations";
        public const string PRODUCT = "Products";
        public const string STOCKTRANSFER = "StockTranfers";
        public const string PAYMENTMODES = "PaymentModes";
        public const string TAXS = "Taxs";
        public const string SALESTATUS = "SaleStatuses";
        
    }
}
