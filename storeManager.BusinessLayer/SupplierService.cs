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
    public class SupplierService : IRepositoryService<Supplier>
    {

        public override int Add(Supplier item)
        {
            string variables1 = " (SupplierNum,Name,ContactPerson,PostalAddress,LocationAdress,"
                                 + " PhoneNumber1,PhoneNumber2,PhoneNumber3,Email,Website,"
                                 + " Remarks,SupplierSince,Salutation,Country,City,IsActive )";

            string variables2 = " (@SupplierNum,@Name,@ContactPerson,@PostalAddress,@LocationAdress,"
                                 + " @PhoneNumber1,@PhoneNumber2,@PhoneNumber3,@Email,@Website,"
                                 + " @Remarks,@SupplierSince,@Salutation,@Country,@City,@IsActive )";

            return _db.Execute("Insert Into " + DBTables.SUPPLIER + variables1  + " VALUES " + variables2, new
            {
                item.SupplierNum,
                item.Name,
                item.ContactPerson,
                item.PostalAddress,
                item.LocationAdress,
                item.PhoneNumber1,
                item.PhoneNumber2,
                item.PhoneNumber3,
                item.Email,
                item.Website,
                item.Remarks,
                item.SupplierSince,
                item.Salutation,
                item.Country,
                item.City,
                item.IsActive
            });
        }

        public override int Remove(Supplier item)
        {
            throw new NotImplementedException();
        }

        public override int Update(Supplier item)
        {
            string variables1 = " (SupplierNum=@SupplierNum,Name=@Name,ContactPerson=@ContactPerson,PostalAddress=@PostalAddress,LocationAdress=@LocationAdress,"
                                + " PhoneNumber1=@PhoneNumber1,PhoneNumber2=@PhoneNumber2,PhoneNumber3=@PhoneNumber3,Email=@Email,Website=@Website,"
                                + " Remarks=@Remarks,SupplierSince=@SupplierSince,Salutation=@Salutation,Country=@Country,City=@City,IsActive=@IsActive )";
            return _db.Execute("UPDATE " + DBTables.SUPPLIER + " SET " + variables1 + " WHERE SupplierID=@SupplierID", new
                        {
                            item.SupplierNum,
                            item.Name,
                            item.ContactPerson,
                            item.PostalAddress,
                            item.LocationAdress,
                            item.PhoneNumber1,
                            item.PhoneNumber2,
                            item.PhoneNumber3,
                            item.Email,
                            item.Website,
                            item.Remarks,
                            item.SupplierSince,
                            item.Salutation,
                            item.Country,
                            item.City,
                            item.IsActive,
                            item.SupplierID
                        });
        }

        public override Supplier FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public override Supplier GetSingle(Supplier item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Supplier> Find(System.Linq.Expressions.Expression<Func<Supplier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Supplier> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Supplier> GetAll()
        {
            return _db.Query<Supplier>("Select * from " + DBTables.SUPPLIER);
        }
    }
}
