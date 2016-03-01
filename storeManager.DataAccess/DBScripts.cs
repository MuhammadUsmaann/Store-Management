using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeManager.DataAccess
{
    public  class DBTables
    {
        public string AccessRights
        {
            get
            {
                return "CREATE TABLE AccessRights("
                        + "Id int IDENTITY(1,1) NOT NULL,"
                        + "FormID varchar(50) NULL,"
                        + "UserID int NULL,"
                        + "CanView bit NULL,"
                        + "CanEdit bit NULL,"
                     + "CONSTRAINT PK_AccessRights  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  Id ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }

        public string Addresses
        {
            get
            {
                return "CREATE TABLE Addresses("
                        + "Id int IDENTITY(1,1) NOT NULL,"
                     + "CONSTRAINT PK_Addresses  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  Id ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }

        public string AddressTypes
        {
            get
            {
                return "CREATE TABLE AddressTypes("
                       + " Id int IDENTITY(1,1) NOT NULL,"
                     + "CONSTRAINT PK_AddressTypes  [PRIMARY] KEY CLUSTERED "
                    + "(   Id ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }
        public string BackupDetails
        {
            get
            {
                return "CREATE TABLE BackupDetails("
                       + " BackupID int IDENTITY(1,1) NOT NULL,"
                       + " BackupDate datetime NULL,"
                        + "BackupFolder varchar(100) NULL,"
                        + "StartTime varchar(10) NULL,"
                        + "EndTime varchar(10) NULL,"
                        + "Comments nvarchar(max) NOT NULL,"
                        + "UserID smallint NOT NULL,"
                     + "CONSTRAINT PK_BackupDetails  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  BackupID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string Brands
        {
            get
            {
                return "CREATE TABLE Brands("
                       + " BrandID int IDENTITY(1,1) NOT NULL,"
                        + "BrandName nvarchar(20) NOT NULL,"
                        + "Description nvarchar(100) NULL,"
                     + "CONSTRAINT PK_Brands  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  BrandID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }
        public string CardInformations
        {
            get
            {
                return "CREATE TABLE CardInformations("
                        + "CardID int IDENTITY(1,1) NOT NULL,"
                        + "CardType nvarchar(30) NOT NULL,"
                    + " CONSTRAINT PK_CardInformations  [PRIMARY] KEY CLUSTERED "
                    + "("
                     + "   CardID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                   + " ) ON  [PRIMARY]";
            }
        }

        public string Categories
        {
            get
            {
                return "CREATE TABLE Categories("
                       + " CategoryID int IDENTITY(1,1) NOT NULL,"
                        + "Name nvarchar(50) NOT NULL,"
                        + "Comment nvarchar(max) NULL,"
                     + "CONSTRAINT PK_Categories  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  CategoryID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string Companies
        {
            get
            {
                return "CREATE TABLE Companies("
                        + "    CompanyNum nvarchar(20) NULL,"
                        + "   CompanyName nvarchar(30) NOT NULL,"
                        + "  Address1 nvarchar(100) NOT NULL,"
                        + " Address2 nvarchar(100) NULL,"
                        + "    Address3 nvarchar(100) NULL,"
                        + "    PhoneLine1 nvarchar(20) NOT NULL,"
                        + "    PhoneLine2 nvarchar(20) NULL,"
                        + "    PhoneLine3 nvarchar(20) NULL,"
                        + "   Motto nvarchar(150) NULL,"
                        + "    Logo varbinary(max) NULL,"
                        + "    Location nvarchar(50) NULL,"
                        + "    FaxNumber nvarchar(20) NULL,"
                        + "   Email nvarchar(50) NULL,"
                        + "    CompanyID int IDENTITY(1,1) NOT NULL,"
                        + "   Misc nvarchar(100) NULL,"
                        + "    DefaultLocation int NULL,"
                        + "    WebSite nvarchar(50) NULL,"
                        + "    City nvarchar(50) NULL,"
                        + "    Country nvarchar(50) NULL,"
                        + " CONSTRAINT PK_Companies  [PRIMARY] KEY CLUSTERED "
                        + "("
                         + "   CompanyID ASC"
                        + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                        + ") ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string CompanyDetails
        {
            get
            {
                return "CREATE TABLE CompanyDetails("
                       + " CompanyID int IDENTITY(1,1) NOT NULL,"
                       + " CompanyName varchar(50) NULL,"
                       + " Motto varchar(100) NULL,"
                       + " CompanyAddress varchar(100) NULL,"
                       + " LandLine varchar(20) NULL,"
                       + " Mobile varchar(20) NULL,"
                       + " Logo varbinary(max) NULL,"
                       + " City varchar(50) NULL,"
                       + " Email varchar(50) NULL,"
                       + " Website varchar(20) NULL,"
                       + " Fax varchar(20) NULL,"
                       + " MiscInfo varchar(200) NULL,"
                     + "CONSTRAINT PK_CompanyDetails  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  CompanyID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string Countries
        {
            get
            {
                return "CREATE TABLE Countries("
                       + " Id int IDENTITY(1,1) NOT NULL,"
                       + " Name nvarchar(max) NOT NULL,"
                       + " CONSTRAINT PK_Countries  [PRIMARY] KEY CLUSTERED "
                   + " ("
                     + "   Id ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string MyProperty
        {
            get
            {
                return "CREATE TABLE CustomerPaymentHistories("
                       + " ID int IDENTITY(1,1) NOT NULL,"
                       + " SaleID int NULL,"
                       + " PayAmount decimal(18, 2) NOT NULL,"
                       + " Balance decimal(18, 2) NOT NULL,"
                       + " PaymentDate datetime NOT NULL,"
                     + "CONSTRAINT PK_CustomerPaymentHistories  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  ID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }
        public string Customers
        {
            get
            {
                return "CREATE TABLE Customers("
                       + " CustomerNum nvarchar(20) NULL,"
                       + " Surname nvarchar(50) NULL,"
                       + " OtherNames nvarchar(50) NULL,"
                       + " Sex char(10) NULL,"
                       + " CustomerTypeID int NULL,"
                       + " PhoneNumber1 nvarchar(20) NULL,"
                       + " PhoneNumber2 nvarchar(20) NULL,"
                       + " PhoneNumber3 nvarchar(20) NULL,"
                       + " EmailAddress nvarchar(50) NULL,"
                       + " Website nvarchar(50) NULL,"
                       + " Discount decimal(18, 2) NULL,"
                       + " CreditLimit decimal(18, 2) NULL,"
                       + " DateAdded datetime NOT NULL,"
                       + " IsActive bit NULL,"
                       + " CustomerName varchar(30) NULL,"
                       + " ContactPerson nvarchar(100) NULL,"
                       + " PostalAddress nvarchar(100) NULL,"
                       + " LocationAdress nvarchar(100) NULL,"
                       + " Remarks nvarchar(200) NULL,"
                       + " CustomerSince datetime NULL,"
                       + " Salutation nchar(10) NULL,"
                       + " Country nvarchar(50) NULL,"
                       + " City nvarchar(50) NULL,"
                       + " CustomerID int IDENTITY(1,1) NOT NULL,"
                    + " CONSTRAINT PK_Customers  [PRIMARY] KEY CLUSTERED"
                   + " ("
                     + "   CustomerID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }
        public string Employees
        {
            get
            {
                return "CREATE TABLE Employees("
                       + " EmployeeNum nvarchar(20) NULL,"
                       + " FisrtName nvarchar(50) NOT NULL,"
                       + " OtherNames nvarchar(100) NOT NULL,"
                       + " Sex nchar(10) NOT NULL,"
                       + " PhoneNumber1 nvarchar(50) NOT NULL,"
                       + " PhoneNumber2 nvarchar(50) NULL,"
                       + " PhoneNumber3 nvarchar(50) NULL,"
                       + " Title nvarchar(50) NULL,"
                       + " Email nvarchar(50) NULL,"
                       + " JobTitle nvarchar(50) NULL,"
                       + " StoreID nvarchar(20) NULL,"
                       + " CardID int NULL,"
                       + " EmployeeID int IDENTITY(1,1) NOT NULL,"
                       + " Address nvarchar(100) NULL,"
                       + " EmployeeSince datetime NULL,"
                       + " ContactPerson nvarchar(50) NULL,"
                     + "CONSTRAINT PK_Employees  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  EmployeeID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }
        public string ErrorLogs
        {
            get
            {
                return "CREATE TABLE ErrorLogs("
                       + " ErrorLogID int IDENTITY(1,1) NOT NULL,"
                       + " CustomMessage nvarchar(max) NULL,"
                       + " ExceptionStackTrace nvarchar(max) NULL,"
                       + " ExceptionMessage nvarchar(max) NULL,"
                       + " InnerExeptionMessage nvarchar(max) NULL,"
                       + " InnerExceptionStackTrace nvarchar(max) NULL,"
                       + " ExceptionDate datetime NULL,"
                       + " ControlName nvarchar(100) NULL,"
                       + " FormName nvarchar(100) NULL,"
                     + "CONSTRAINT PK_ErrorLogs  [PRIMARY] KEY CLUSTERED"
                    + "("
                      + "  ErrorLogID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string InvoiceNumbers
        {
            get
            {
                return "CREATE TABLE InvoiceNumbers("
                        + "    id int IDENTITY(1,1) NOT NULL,"
                        + "    InvoiceNum bigint NOT NULL,"
                        + " CONSTRAINT PK_InvoiceNumbers  [PRIMARY] KEY CLUSTERED "
                        + "("
                         + "   id ASC"
                        + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                        + ") ON  [PRIMARY]";
            }
        }
        public string LabelSettings
        {
            get
            {
                return "CREATE TABLE LabelSettings("
                       + " id int IDENTITY(1,1) NOT NULL,"
                       + " ListStart int NULL,"
                       + " ListEnd int NULL,"
                       + " LabelLenghth int NULL,"
                       + " QtyToPrint int NULL,"
                       + " BarcodeType varchar(20) NULL,"
                       + " BorderType varchar(20) NULL,"
                       + " FontFamily varchar(20) NULL,"
                       + " ForeColor varchar(20) NULL,"
                       + " BarHeight int NULL,"
                       + " FontSize int NULL,"
                       + " ShowTest bit NULL,"
                       + " ShowBorder bit NULL,"
                       + " ShowCheckSum bit NULL,"
                    + " CONSTRAINT PK_LabelSettings  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  id ASC "
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }
        public string Locations
        {
            get
            {
                return "CREATE TABLE Locations("
                       + " Id int IDENTITY(1,1) NOT NULL,"
                       + " Name nvarchar(max) NOT NULL,"
                       + " IsDefault bit NULL,"
                       + " Comment nvarchar(100) NULL,"
                       + " CONSTRAINT PK_Locations  [PRIMARY] KEY CLUSTERED "
                       + " ( "
                       + " Id ASC "
                       + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                       + " ) ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string Measurements
        {
            get
            {
                return "CREATE TABLE Measurements("
                       + " Id int IDENTITY(1,1) NOT NULL,"
                       + " Description nvarchar(max) NOT NULL,"
                       + " Name nvarchar(20) NULL,"
                     + " CONSTRAINT PK_Measurements  [PRIMARY] KEY CLUSTERED "
                    + " ( "
                       + " Id ASC "
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string PaymentModes
        {
            get
            {
                return "CREATE TABLE PaymentModes("
                      + " PaymentModeID int IDENTITY(1,1) NOT NULL,"
                      + " PayMode varchar(20) NULL,"
                     + "CONSTRAINT PK_PaymentModes  [PRIMARY] KEY CLUSTERED "
                    + "("
                      + "  PaymentModeID ASC "
                   + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }
        public string ProductAdjustments
        {
            get
            {
                return "CREATE TABLE ProductAdjustments("
                       + " ID int IDENTITY(1,1) NOT NULL,"
                       + " ProductID int NOT NULL,"
                       + " LocationID int NOT NULL,"
                       + " ProductLocationID int NOT NULL,"
                       + " CurrentQty int NOT NULL,"
                       + " NewQty int NOT NULL,"
                       + " Difference int NOT NULL,"
                       + " AdjustmentDate datetime NULL,"
                       + " Remarks nvarchar(500) NULL,"
                       + " EmployeeID int NULL,"
                     + " CONSTRAINT PK_ProductAdjustments  [PRIMARY] KEY CLUSTERED "
                    + " ("
                       + " ID ASC"
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY]";
            }
        }
        public string ProductLocations
        {
            get
            {
                return "CREATE TABLE ProductLocations("
                        + "Id int IDENTITY(1,1) NOT NULL,"
                        + "LocationID int NOT NULL,"
                        + "ProductID int NOT NULL,"
                        + "Quantity int NOT NULL,"
                     + "CONSTRAINT PK_ProductLocations  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                    + "    Id ASC "
                   + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                    + ") ON  [PRIMARY]";
            }
        }
        public string Products
        {
            get
            {
                return "CREATE TABLE Products( "
                       + " Barcode nvarchar(50) NULL,"
                       + " ProductName nvarchar(50) NOT NULL,"
                       + " Description nvarchar(50) NULL,"
                       + " Quantity int NOT NULL,"
                       + " UnitPrice decimal(18, 2) NOT NULL,"
                       + " CategoryID int NOT NULL,"
                       + " ManufactureDate datetime NULL,"
                       + " ExpiryDate datetime NULL,"
                       + " ReorderLevel int NULL,"
                       + " PurchasePrice decimal(18, 2) NULL,"
                       + " SellingPrice decimal(18, 2) NOT NULL,"
                       + " ProductImage varbinary(max) NULL,"
                       + " OnSale bit NULL,"
                       + " SupplierID int NOT NULL,"
                       + " ProductNum nvarchar(20) NOT NULL,"
                       + " Commission decimal(10, 8) NULL,"
                       + " Discount decimal(10, 8) NULL,"
                       + " DateAdded datetime NULL,"
                       + " LastDateAdjusted datetime NULL,"
                       + " EmployeeID nvarchar(20) NULL,"
                       + " BrandID int NOT NULL,"
                       + " AdjustmentReason nvarchar(150) NULL,"
                       + " ProductID int IDENTITY(1,1) NOT NULL,"
                       + " LocationID int NOT NULL,"
                       + " MeasurementID int NOT NULL,"
                     + "CONSTRAINT PK_Products  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                     + "   ProductID ASC "
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY]"
                    + ") ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string PurchaseDetails
        {
            get
            {
                return "CREATE TABLE PurchaseDetails( "
                       + " InvoiceNumber nvarchar(20) NULL,"
                       + " ProductID nvarchar(20) NULL,"
                       + " Quantity int NULL,"
                       + " UnitPrice decimal(18, 2) NULL,"
                       + " PurchaseDetailID int IDENTITY(1,1) NOT NULL,"
                       + " Discount decimal(18, 2) NULL,"
                       + " Tax decimal(18, 2) NULL,"
                    + " CONSTRAINT PK_PurchaseDetails  [PRIMARY] KEY CLUSTERED "
                    + " ( "
                      + "  PurchaseDetailID ASC "
                    + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                    + " ) ON  [PRIMARY]";
            }
        }
        public string Purchases
        {
            get
            {
                return "CREATE TABLE Purchases("
                       + " InvoiceNumber nvarchar(20) NOT NULL,"
                       + " SupplierID nvarchar(20) NOT NULL,"
                       + " PurchaseAmount decimal(18, 2) NOT NULL,"
                       + " PurchaseDate datetime NOT NULL,"
                       + " AmountPaid decimal(18, 0) NULL,"
                       + " Balance decimal(18, 0) NULL,"
                       + " StoreID int NULL,"
                       + " PurchaseType nchar(10) NULL, "
                       + " EmployeeID nvarchar(20) NULL,"
                       + " PurchasetypeID int NULL,"
                       + " DetailedAccountID varchar(20) NULL,"
                       + " BillState varchar(10) NULL,"
                       + " Discount decimal(18, 2) NULL,"
                       + " Tax decimal(18, 2) NULL,"
                       + " PromisedDate datetime NULL,"
                       + " DateClosed datetime NULL,"
                       + " PurchaseOrderNo varchar(20) NULL,"
                    + " CONSTRAINT PK_Purchases  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                     + "   InvoiceNumber ASC "
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                    + ") ON  [PRIMARY]";
            }
        }
        public string Roles
        {
            get
            {
                return "CREATE TABLE Roles( "
                       + " RoleID int IDENTITY(1,1) NOT NULL, "
                       + " RoleName varchar(20) NULL,"
                    + " CONSTRAINT PK_Roles  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                     + "   RoleID ASC "
                    + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                    + " ) ON  [PRIMARY]";
            }
        }
        public string SaleDetails
        {
            get
            {
                return "CREATE TABLE SaleDetails( "
                       + " InvoiceNumber nvarchar(20) NOT NULL, "
                       + " UnitPrice decimal(18, 2) NOT NULL,"
                        + "Quantity int NOT NULL,"
                       + " SalesDetailsID int IDENTITY(1,1) NOT NULL, "
                       + " ProductID nvarchar(20) NULL,"
                       + " Discount decimal(18, 2) NULL,"
                       + " Tax decimal(18, 2) NULL,"
                       + " SaleID int NOT NULL,"
                       + " LineTotal decimal(8, 2) NULL, "
                       + " LocationID int NULL,"
                     + "CONSTRAINT PK_SaleDetails  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                    + "    SalesDetailsID ASC "
                    + ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                    + ") ON  [PRIMARY]";
            }
        }
        public string Sales
        {
            get
            {
                return "CREATE TABLE Sales( "
                       + " InvoiceNumber nvarchar(20) NOT NULL, "
                       + " Amount decimal(18, 2) NOT NULL,"
                       + " InvoiceDate datetime NOT NULL,"
                       + " AmountPaid decimal(18, 2) NULL,"
                       + " Balance decimal(18, 2) NULL,"
                       + " EmployeeID nvarchar(20) NULL,"
                       + " StoreID int NULL,"
                       + " CustomerID nvarchar(20) NULL,"
                       + " SaleTypeID int NULL,"
                       + " InvoiceState varchar(10) NULL,"
                       + " Discount decimal(18, 2) NULL,"
                       + " Tax decimal(18, 2) NULL,"
                       + " PromisedDate datetime NULL,"
                       + " DateClosed datetime NULL,"
                       + " CustomerPO varchar(40) NULL,"
                       + " PaymentModeID int NULL,"
                       + " VoidSale bit NULL,"
                       + " VoucherCode varchar(20) NULL,"
                       + "  SaleStatusID int NULL,"
                       + " SaleID int IDENTITY(1,1) NOT NULL,"
                       + " SubTotal decimal(8, 2) NULL,"
                       + " LocationID int NULL,"
                       + " CustBalance decimal(18, 2) NULL,"
                   + "  CONSTRAINT PK_Sales  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                   + "     SaleID ASC "
                   + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                    + ") ON  [PRIMARY]";
            }
        }
        public string SaleStatuses
        {
            get
            {
                return "CREATE TABLE SaleStatuses( "
                       + " Id int IDENTITY(1,1) NOT NULL, "
                       + " Status nvarchar(max) NOT NULL,"
                     + " CONSTRAINT PK_SaleStatuses  [PRIMARY] KEY CLUSTERED  "
                   + " ( "
                     + "   Id ASC "
                    + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                   + " ) ON  [PRIMARY] TEXTIMAGE_ON  [PRIMARY]";
            }
        }
        public string SaleTypes
        {
            get
            {
                return "CREATE TABLE SaleTypes( "
                       + " SaleTypeID int IDENTITY(1,1) NOT NULL, "
                       + " TypeName nvarchar(30) NOT NULL,"
                     + " CONSTRAINT PK_SaleTypes  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                     + "   SaleTypeID ASC "
                    + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                   + " ) ON  [PRIMARY]";
            }
        }
        public string Security
        {
            get
            {
                return "CREATE TABLE security( "
                       + " id int IDENTITY(1,1) NOT NULL, "
                       + " date nvarchar(250) NOT NULL, "
                       + " password nvarchar(250) NOT NULL, "
                       + " store_name nvarchar(250) NOT NULL, "
                     + " CONSTRAINT PK_security  [PRIMARY] KEY CLUSTERED "
                    + " ( "
                      + "  id ASC "
                    + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                    + " ) ON  [PRIMARY]";
            }
        }
        public string StockTranfers
        {
            get
            {
                return "CREATE TABLE StockTranfers( "
                       + " StockTranferID int IDENTITY(1,1) NOT NULL, "
                       + " FromLocationID int NULL,"
                       + " FromLocationQtyBeforeTranfer int NULL, "
                       + " FromLocationQtyAfterTransfer int NULL,"
                       + " ToLocationID int NULL,"
                       + " ToLocationBeforeTransfer int NULL, "
                       + " ToLocationAfterTranfer int NULL,"
                       + " ProductID int NULL,"
                       + " UserID int NULL, "
                       + " TransferDate datetime NULL, "
                       + " TransferQty int NULL,"
                    + " CONSTRAINT PK_StockTranfers  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                    + "    StockTranferID ASC "
                    + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                   + " ) ON  [PRIMARY]";
            }
        }
        public string Suppliers
        {
            get
            {
                return "CREATE TABLE Suppliers( "
                       + " SupplierNum nvarchar(20) NULL, "
                       + " Name nvarchar(50) NOT NULL, "
                       + " ContactPerson nvarchar(50) NULL, "
                       + " PostalAddress nvarchar(100) NULL, "
                       + " LocationAdress nvarchar(100) NULL, "
                       + " PhoneNumber1 nvarchar(50) NULL, "
                       + " PhoneNumber2 nvarchar(50) NULL, "
                       + " PhoneNumber3 nvarchar(50) NULL, "
                       + " Email nvarchar(50) NULL, "
                       + " Website nvarchar(50) NULL,"
                       + " Remarks varchar(200) NULL,"
                       + " SupplierSince datetime NULL,"
                       + " Salutation nchar(10) NULL,"
                       + " Country nvarchar(50) NULL,"
                       + " City nvarchar(50) NULL,"
                       + " IsActive bit NULL,"
                       + " SupplierID int IDENTITY(1,1) NOT NULL, "
                    + " CONSTRAINT PK_Suppliers  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                   + "     SupplierID ASC "
                   + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                   + " ) ON  [PRIMARY]";
            }
        }
        public string Taxes
        {
            get
            {
                return "CREATE TABLE Taxes( "
                       + " TaxID int IDENTITY(1,1) NOT NULL, "
                       + " TaxName nvarchar(50) NOT NULL, "
                       + " TaxRate decimal(10, 5) NOT NULL, "
                       + " TaxNumber nvarchar(50) NULL, "
                    + " CONSTRAINT PK_Taxes  [PRIMARY] KEY CLUSTERED "
                   + " ( "
                     + "   TaxID ASC "
                  + "  )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                  + "  ) ON  [PRIMARY]";
            }
        }
        public string Users
        {
            get
            {
                return "CREATE TABLE Users( "
                       + " UserID int IDENTITY(1,1) NOT NULL, "
                       + " UserName varchar(20) NULL, "
                       + " UserPassword varchar(20) NULL, "
                       + " EmployeeID int NULL, "
                       + " DateCreated datetime NULL, "
                       + " LastLogInDate datetime NULL, "
                       + " RoleID int NULL, "
                       + " Active bit NULL, "
                       + " IsAdmin bit NULL, "
                    + " CONSTRAINT PK_Users  [PRIMARY] KEY CLUSTERED  "
                   + " ( "
                     + "   UserID ASC "
                   + " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON  [PRIMARY] "
                   + " ) ON  [PRIMARY]";
            }
        }


    }


    public class DBKeys {
        public string Keys
        {
            get
            {
                return "ALTER TABLE ProductLocations  WITH CHECK ADD  CONSTRAINT FK_ProductLocationLocation FOREIGN KEY(LocationID) "
                       +" REFERENCES Locations (Id) "
                       +" ALTER TABLE ProductLocations CHECK CONSTRAINT FK_ProductLocationLocation "
                       +" ALTER TABLE ProductLocations  WITH CHECK ADD  CONSTRAINT FK_ProductLocationProduct FOREIGN KEY(ProductID) "
                       +" REFERENCES Products (ProductID) "
                       +" ALTER TABLE ProductLocations CHECK CONSTRAINT FK_ProductLocationProduct "
                       +" ALTER TABLE Products  WITH CHECK ADD  CONSTRAINT FK_MeasurementProduct FOREIGN KEY(MeasurementID) "
                       +" REFERENCES Measurements (Id) "
                       +" ALTER TABLE Products CHECK CONSTRAINT FK_MeasurementProduct "
                       +" ALTER TABLE Products  WITH CHECK ADD  CONSTRAINT FK_ProductBrand FOREIGN KEY(BrandID) "
                       +" REFERENCES Brands (BrandID) "
                       +" ALTER TABLE Products CHECK CONSTRAINT FK_ProductBrand "
                       +" ALTER TABLE Products  WITH CHECK ADD  CONSTRAINT FK_ProductCategory FOREIGN KEY(CategoryID) "
                       +" REFERENCES Categories (CategoryID) "
                       +" ALTER TABLE Products CHECK CONSTRAINT FK_ProductCategory "
                       +" ALTER TABLE Products  WITH CHECK ADD  CONSTRAINT FK_ProductSupplier FOREIGN KEY(SupplierID) "
                       +" REFERENCES Suppliers (SupplierID) "
                       +" ALTER TABLE Products CHECK CONSTRAINT FK_ProductSupplier "
                       +" ALTER TABLE SaleDetails  WITH CHECK ADD  CONSTRAINT FK_SaleSaleDetail FOREIGN KEY(SaleID) "
                       +" REFERENCES Sales (SaleID) "
                       +" ALTER TABLE SaleDetails CHECK CONSTRAINT FK_SaleSaleDetail";
            }
        }
    }
}
