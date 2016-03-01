using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Dapper;
using storeManager.BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class ProductService : IRepositoryService<Product>
    {
        ProductLocationService _productLocation;
        IErrorLogRepository _logger;

        public ProductService()
        {
            _productLocation = new ProductLocationService();
            _logger = new ErrorLogRepository();
        }

        #region IProductService Members

        public void CalculateSellingPrice(decimal percent, decimal purchasePrice, out decimal sellingPrice, out decimal profitMargin)
        {
            try
            {
                decimal percentage = percent / 100;

                sellingPrice = Math.Round((percentage * purchasePrice) + purchasePrice, 2);
                profitMargin = Math.Round(sellingPrice - purchasePrice, 2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        public void ReduceInventory(int qty, int productID, int locationID)
        {
            try
            {
                int stockQty = 0;
                ProductLocation prodloc = _productLocation.GetSingle(new ProductLocation { ProductID = productID, LocationID = locationID });

                stockQty = (int)prodloc.Quantity - qty;

                prodloc.Quantity = stockQty;

                _productLocation.Update(prodloc);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
    
        }

        public void AddInventory(int qty, int productID, int locationID)
        {
            try
            {
                int stockQty = 0;
                ProductLocation prodloc = _productLocation.GetSingle(new ProductLocation { ProductID = productID, LocationID = locationID });

                stockQty = (int)prodloc.Quantity + qty;

                prodloc.Quantity = stockQty;
                prodloc.Id = prodloc.Id;
                _productLocation.Update(prodloc);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

        public int GetCurrentStock(int productid, int locationid)
        {
            try
            {
                ProductLocation productLocation = _productLocation.GetSingle(new ProductLocation{ ProductID = productid ,LocationID = locationid});

                if (productLocation == null) return 0;

                return (int)productLocation.Quantity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
            //return _productRepository.GetSingle(p => p.ProductID == productid).Quantity;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        public void AdjustStock(Product product)
        {
            try
            {
                Product newProduct = FindByID(product.ProductID);

                newProduct.Quantity += product.Quantity;
                newProduct.ReorderLevel = product.ReorderLevel == 0 ? newProduct.ReorderLevel : product.ReorderLevel;
                newProduct.UnitPrice = product.UnitPrice;
                newProduct.AdjustmentReason = product.AdjustmentReason;

                Update(newProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        public DataTable MapToTable(Func<IEnumerable<Product>> productList)
        {
            try
            {
                DataTable dt = new DataTable();
                IEnumerable<Product> products = productList();

                dt = CreateTable();

                foreach (var product in products)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = product.ProductID;
                    dr["Name"] = product.ProductName;
                    dr["Qty"] = product.Quantity;
                    dr["Price"] = product.UnitPrice;
                    dr["PurchasePrice"] = product.PurchasePrice;
                    dr["SellingPrice"] = product.SellingPrice;
                    dr["ManufactureDate"] = product.ManufactureDate.Value.ToShortDateString();
                    dr["ExpiryDate"] = product.ExpiryDate.Value.ToShortDateString();
                    dr["ReorderLevel"] = product.ReorderLevel;
                    dr["Desc"] = product.Description;

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        private DataTable CreateTable()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn[] cols;

                cols = new DataColumn[]{new DataColumn("ID",typeof(string)),
                  new DataColumn("Name",typeof(string)),
                  new DataColumn("Qty",typeof(string)),
                  new DataColumn("Price",typeof(string)),
                  new DataColumn("PurchasePrice",typeof(string)),
                  new DataColumn("SellingPrice",typeof(string)),
                  new DataColumn("ManufactureDate",typeof(string)),
                  new DataColumn("ExpiryDate",typeof(string)),
                  new DataColumn("ReorderLevel",typeof(string)),
                  new DataColumn("Desc",typeof(string))
            };

                dt.Columns.AddRange(cols);

                return dt;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            

        }

        public void Discontinue(int id)
        {
            try
            {
                _db.Execute("Update " + DBTables.PRODUCT + " set OnSale = false where ProductID = " + id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
                   
        }

        public List<string> GetExistingBarCodes()
        {
            return _db.Query<string>("Select BarCode from "+DBTables.PRODUCT).ToList();
        }

        #endregion

        public override int Add(Product item)
        {
            string variables1 = " ( Barcode,ProductName,Description,Quantity,UnitPrice,"
		                          +"CategoryID,ManufactureDate,ExpiryDate,ReorderLevel,PurchasePrice,"
		                          +"SellingPrice,ProductImage,OnSale,SupplierID,ProductNum,"
		                          +"Commission,Discount,DateAdded,LastDateAdjusted,"
		                          +"BrandID,LocationID,MeasurementID )";

            string variables2 = "( @Barcode,@ProductName,@Description,@Quantity,@UnitPrice,"
                                  + "@CategoryID,@ManufactureDate,@ExpiryDate,@ReorderLevel,@PurchasePrice,"
                                  + "@SellingPrice,@ProductImage,@OnSale,@SupplierID,@ProductNum,"
                                  + "@Commission,@Discount,@DateAdded,@LastDateAdjusted,"
                                  + "@BrandID,@LocationID,@MeasurementID )";


            return _db.Query<int>("Insert Into" + DBTables.PRODUCT + variables1 + " OUTPUT Inserted.ProductID VALUES " + variables2, new {
                item.Barcode,
                item.ProductName,
                item.Description,
                item.Quantity,
                item.UnitPrice,
                item.CategoryID,
                item.ManufactureDate,
                item.ExpiryDate,
                item.ReorderLevel,
                item.PurchasePrice,
                item.SellingPrice,
                item.ProductImage,
                item.OnSale,
                item.SupplierID,
                item.ProductNum,
                item.Commission,
                item.Discount,
                item.DateAdded,
                item.LastDateAdjusted,
                item.BrandID,
                item.LocationID,
                item.MeasurementID
            }).Single();
        }

        public override int Remove(Product item)
        {
            throw new NotImplementedException();
        }

        public override int Update(Product item)
        {
            string variables1 = " Barcode=@Barcode,ProductName=@ProductName,Description=@Description,Quantity=@Quantity,UnitPrice=@UnitPrice,"
                                + "CategoryID=@CategoryID,ManufactureDate=@ManufactureDate,ExpiryDate=@ExpiryDate,ReorderLevel=@ReorderLevel,PurchasePrice=@PurchasePrice,"
                                + "SellingPrice=@SellingPrice,ProductImage=@ProductImage,OnSale=@OnSale,SupplierID=@SupplierID,ProductNum=@ProductNum,"
                                + "Commission=@Commission,Discount=@Discount,DateAdded=@DateAdded,LastDateAdjusted=@LastDateAdjusted,"
                                + "BrandID=@BrandID,LocationID=@LocationID,MeasurementID=@MeasurementID ";
            return _db.Execute("Update " + DBTables.PRODUCT + " SET " + variables1 + " Where ProductID=@ProductID", new
            {
                item.Barcode,
                item.ProductName,
                item.Description,
                item.Quantity,
                item.UnitPrice,
                item.CategoryID,
                item.ManufactureDate,
                item.ExpiryDate,
                item.ReorderLevel,
                item.PurchasePrice,
                item.SellingPrice,
                item.ProductImage,
                item.OnSale,
                item.SupplierID,
                item.ProductNum,
                item.Commission,
                item.Discount,
                item.DateAdded,
                item.LastDateAdjusted,
                item.BrandID,
                item.ProductID,
                item.LocationID,
                item.MeasurementID
            });
        }

        public override Product FindByID(int id)
        {
            return _db.Query<Product>("Select * from " + DBTables.PRODUCT + " where ProductID = " + id).FirstOrDefault();
        }

        public override Product GetSingle(Product item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Product> Find(System.Linq.Expressions.Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Product> FindAll(string includes)
        {
            return _db.Query<Product>("Select * from " + DBTables.PRODUCT + " where " + includes);
        }

        public override IEnumerable<Product> GetAll()
        {
            return _db.Query<Product>("Select * from " + DBTables.PRODUCT);
        }


        public IEnumerable<Product> FindByName(string p)
        {
            return _db.Query<Product>("Select * from " + DBTables.PRODUCT + " where productName like '%" + p + "%'");
        }
    }
}
