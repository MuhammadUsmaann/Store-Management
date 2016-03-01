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
    public class CustomerService : IRepositoryService<Customer>
    {
        public override int Add(Customer item)
        {
            string variables1 = " ( CustomerNum,Surname,OtherNames,Sex,CustomerTypeID,PhoneNumber1,"
                                 + " PhoneNumber2,PhoneNumber3,EmailAddress,Website,Discount,CreditLimit,DateAdded,"
                                 + "IsActive,CustomerName,ContactPerson,PostalAddress,LocationAdress,Remarks,CustomerSince,"
                                 + "Salutation,Country,City )";

            string variables2 = " ( @CustomerNum,@Surname,@OtherNames,@Sex,@CustomerTypeID,@PhoneNumber1,"
                                 + " @PhoneNumber2,@PhoneNumber3,@EmailAddress,@Website,@Discount,@CreditLimit,@DateAdded,"
                                 + "@IsActive,@CustomerName,@ContactPerson,@PostalAddress,@LocationAdress,@Remarks,@CustomerSince,"
                                 + "@Salutation,@Country,@City)";


            return _db.Execute("insert into " + DBTables.CUSTOMER + variables1 + " VALUES " + variables2 , new
            {
                item.CustomerNum,
                item.Surname,
                item.OtherNames,
                item.Sex,
                item.CustomerTypeID,
                item.PhoneNumber1,
                item.PhoneNumber2,
                item.PhoneNumber3,
                item.EmailAddress,
                item.Website,
                item.Discount,
                item.CreditLimit,
                item.DateAdded,
                item.IsActive,
                item.CustomerName,
                item.ContactPerson,
                item.PostalAddress,
                item.LocationAdress,
                item.Remarks,
                item.CustomerSince,
                item.Salutation,
                item.Country,
                item.City
            });
        }

        public override int Remove(Customer item)
        {
            throw new NotImplementedException();
        }

        public override int Update(Customer item)
        {
            string variables1 = " ( CustomerNum=@CustomerNum,Surname=@Surname,OtherNames=@OtherNames,Sex=@Sex,CustomerTypeID=@CustomerTypeID,PhoneNumber1=@PhoneNumber1,"
                                 + " PhoneNumber2=@PhoneNumber2,PhoneNumber3=@PhoneNumber3,EmailAddress=@EmailAddress,Website=@Website,Discount=@Discount,CreditLimit=@CreditLimit,DateAdded=@DateAdded,"
                                 + "IsActive=@IsActive,CustomerName=@CustomerName,ContactPerson=@ContactPerson,PostalAddress=@PostalAddress,LocationAdress=@LocationAdress,Remarks=@Remarks,CustomerSince=@CustomerSince,"
                                 + "Salutation=@Salutation,Country=@Country,City=@City )";


            return _db.Execute(" UPDATE " + DBTables.CUSTOMER + " SET " + variables1 + " WHERE CustomerID=@CustomerID", new
            {
                item.CustomerNum,
                item.Surname,
                item.OtherNames,
                item.Sex,
                item.CustomerTypeID,
                item.PhoneNumber1,
                item.PhoneNumber2,
                item.PhoneNumber3,
                item.EmailAddress,
                item.Website,
                item.Discount,
                item.CreditLimit,
                item.DateAdded,
                item.IsActive,
                item.CustomerName,
                item.ContactPerson,
                item.PostalAddress,
                item.LocationAdress,
                item.Remarks,
                item.CustomerSince,
                item.Salutation,
                item.Country,
                item.City,
                item.CustomerID
            });
        }

        public override Customer FindByID(int id)
        {
            return _db.Query<Customer>("Select * from " + DBTables.CUSTOMER + " where CustomerID=@CustomerID", new { id }).FirstOrDefault();
        }

        public override Customer GetSingle(Customer item)
        {
            return _db.Query<Customer>("Select * from " + DBTables.CUSTOMER + " where CustomerID=@CustomerID", new { item.CustomerID }).FirstOrDefault();
        }

        public override IEnumerable<Customer> Find(System.Linq.Expressions.Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Customer> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
