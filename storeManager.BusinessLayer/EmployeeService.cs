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
    public class EmployeeService : IRepositoryService<Employee>
    {

        public override int Add(Employee item)
        {
            string variables1 = " ( EmployeeNum,FisrtName,OtherNames,Sex,PhoneNumber1,PhoneNumber2,PhoneNumber3,"
                                + "Title,Email,JobTitle,StoreID,CardID,Address,EmployeeSince,ContactPerson )";

            string variables2 = " (@EmployeeNum,@FisrtName,@OtherNames,@Sex,@PhoneNumber1,@PhoneNumber2,@PhoneNumber3,"
                                + "@Title,@Email,@JobTitle,@StoreID,@CardID,@Address,@EmployeeSince,@ContactPerson ) ";

            return _db.Execute("Insert Into " + DBTables.EMPLOYEE + variables1 + " Values " + variables2, new
            {
                item.EmployeeNum,
                item.FisrtName,
                item.OtherNames,
                item.Sex,
                item.PhoneNumber1,
                item.PhoneNumber2,
                item.PhoneNumber3,
                item.Title,
                item.Email,
                item.JobTitle,
                item.StoreID,
                item.CardID,
                item.Address,
                item.EmployeeSince,
                item.ContactPerson
            });
        }

        public override int Remove(Employee item)
        {
            throw new NotImplementedException();
        }

        public override int Update(Employee item)
        {
            string variables1 = " ( EmployeeNum=@EmployeeNum,FisrtName=@FisrtName,OtherNames=@OtherNames,Sex=@Sex,PhoneNumber1=@PhoneNumber1,PhoneNumber2=@PhoneNumber2,PhoneNumber3=@PhoneNumber3,"
                                + "Title=@Title,Email=@Email,JobTitle=@JobTitle,StoreID=@StoreID,CardID=@CardID,Address=@Address,EmployeeSince=@EmployeeSince,ContactPerson=@ContactPerson )";
            return _db.Execute("Update " + DBTables.EMPLOYEE + " SET " + variables1 + " where EmployeeID=@EmployeeID", new
            {
                item.EmployeeID,
                item.EmployeeNum,
                item.FisrtName,
                item.OtherNames,
                item.Sex,
                item.PhoneNumber1,
                item.PhoneNumber2,
                item.PhoneNumber3,
                item.Title,
                item.Email,
                item.JobTitle,
                item.StoreID,
                item.CardID,
                item.Address,
                item.EmployeeSince,
                item.ContactPerson
            });
        }

        public override Employee FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public override Employee GetSingle(Employee item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Employee> Find(System.Linq.Expressions.Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Employee> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Employee> GetAll()
        {
            return _db.Query<Employee>("Select * from " + DBTables.EMPLOYEE);
        }
    }
}
