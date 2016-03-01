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
    public class CompanyService:IRepositoryService<Company> 
    {
        public override int Add(Company item)
        {
            var variables1 = " ( CompanyNum,CompanyName,Address1,"
                            + "Address2,Address3,PhoneLine1,PhoneLine2,"
                            + "PhoneLine3,Motto,Logo,Location,FaxNumber,"
                            + "Email,Misc,DefaultLocation,WebSite,City,Country )";
            var variables2 = "( @CompanyNum,@CompanyName,@Address1,"
                            + "@Address2,@Address3,@PhoneLine1,@PhoneLine2,"
                            + "@PhoneLine3,@Motto,@Logo,@Location,@FaxNumber,"
                            + "@Email,@Misc,@DefaultLocation,@WebSite,@City,@Country )";
            return _db.Execute("Insert Into " + DBTables.COMPANY  + variables1 + " Values " + variables2, new
            {
                item.CompanyNum,
                item.CompanyName,
                item.Address1,
                item.Address2,
                item.Address3,
                item.PhoneLine1,
                item.PhoneLine2,
                item.PhoneLine3,
                item.Motto,
                item.Logo,
                item.Location,
                item.FaxNumber,
                item.Email,
                item.Misc,
                item.DefaultLocation,
                item.WebSite,
                item.City,
                item.Country
            });
        }

        public override int Remove(Company item)
        {
            throw new NotImplementedException();
        }

        public override int Update(Company item)
        {
            var variables = "CompanyNum=@CompanyNum,CompanyName=@CompanyName,Address1=@Address1,"
                            + "Address2=@Address2,Address3=@Address3,PhoneLine1=@PhoneLine1,PhoneLine2=@PhoneLine2,"
                            + "PhoneLine3=@PhoneLine3,Motto=@Motto,Logo=@Logo,Location=@Location,FaxNumber=@FaxNumber,"
                            + "Email=@Email,Misc=@Misc,DefaultLocation=@DefaultLocation,WebSite=@WebSite,City=@City,Country=@Country";
            return _db.Execute("Update " + DBTables.COMPANY + " set " + variables + " where CompanyID =@CompanyID ", new
            {
                item.CompanyNum,
                item.CompanyName,
                item.Address1,
                item.Address2,
                item.Address3,
                item.PhoneLine1,
                item.PhoneLine2,
                item.PhoneLine3,
                item.Motto,
                item.Logo,
                item.Location,
                item.FaxNumber,
                item.Email,
                item.Misc,
                item.DefaultLocation,
                item.WebSite,
                item.City,
                item.Country,
                item.CompanyID
            });
        }

        public override Company FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public override Company GetSingle(Company item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Company> Find(System.Linq.Expressions.Expression<Func<Company, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Company> FindAll(string includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Company> GetAll()
        {
            return _db.Query<Company>("Select * from " + DBTables.COMPANY + "");
        }
    }
}
