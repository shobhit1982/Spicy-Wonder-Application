using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity
{
    public class Query
    {
        public struct Location
        {
            public const string GetAll = "select * from Location where isvalid=1";
            public const string GetById = "select * from Location where  isvalid=1 and id=";
            public const string GetByName = "select * from Location where isvalid=1 and  name=";
        }

        public struct TaxAppliedOnItem
        {
            public const string GetAll = "select * from TaxAppliedOnItem where isvalid=1";
            public const string GetById = "select * from TaxAppliedOnItem where isvalid=1 and id=";
            public const string GetByItemMasterId = "select * from TaxAppliedOnItem where isvalid=1 and ItemMasterId=";
        }
        public struct Taxes
        {
            public const string GetAll = "select * from Taxes where isvalid=1";
            public const string GetById = "select * from Taxes where isvalid=1 and id=";
            public const string GetByName = "select * from Taxes where isvalid=1 and name=";
        }
        public struct ItemCategory
        {
            public const string GetAll = "select * from ItemCategory where isvalid=1";
            public const string GetById = "select * from ItemCategory where isvalid=1 and id=";
            public const string GetByName = "select * from ItemCategory where isvalid=1 and name=";
        }
        public struct Unit
        {
            public const string GetAll = "select * from Unit where isvalid=1";
            public const string GetById = "select * from Unit where isvalid=1 and id=";
            public const string GetByName = "select * from Unit where isvalid=1 and name=";
        }
        public struct Discount
        {
            public const string GetAll = "select * from Discount where isvalid=1";
            public const string GetById = "select * from Discount where isvalid=1 and id=";
            public const string GetByDiscount = "select * from Discount where isvalid=1 and discount=";
        }
        public struct UserTypes
        {
            public const string GetAll = "select * from UserTypes where isvalid=1";
            public const string GetById = "select * from UserTypes where isvalid=1 and id=";
            public const string GetByName = "select * from UserTypes where isvalid=1 and name=";
        }
        public struct UserRights
        {
            public const string GetAll = "select * from UserRights where isvalid=1";
            public const string GetById = "select * from UserRights where isvalid=1 and id=";
            public const string GetByName = "select * from UserRights where isvalid=1 and name=";
            public const string GetByUserTypesId = "select * from UserRights where isvalid=1 and UserTypeId=";
            public const string GetByUserMenuId = "select * from UserRights where isvalid=1 and MenuId=";
            public const string GetByUserMenuParentId = "select * from UserRights where isvalid=1 and MenuParentId=";
            
        }
        
        public struct UserTable
        {
            public const string GetAll = "select * from UserTable where isvalid=1";
            public const string GetById = "select * from UserTable where isvalid=1 and id=";
            public const string GetByName = "select * from UserTable where isvalid=1 and name=";
            public const string GetByLoginId = "select * from UserTable where isvalid=1 and LoginId=";
            public const string GetByEmailId = "select * from UserTable where isvalid=1 and EmailId=";
            public const string GetByMobile = "select * from UserTable where isvalid=1 and Mobile=";
            public const string Delete = "update UserTable set isvalid=0  where id=";
            
            
        }
        public struct ItemSeries
        {
            public const string GetAll = "select * from ItemSeries where isvalid=1";
            public const string GetById = "select * from ItemSeries where isvalid=1 and id=";
            public const string GetByName = "select * from ItemSeries where isvalid=1 and name=";
        }
        public struct ItemMaster
        {
            public const string GetAll = "select * from ItemMaster where isvalid=1";
            public const string GetBySeriesId = "select * from ItemMaster where isvalid=1 and ItemSeriesId=";
            public const string GetById = "select * from ItemMaster where isvalid=1 and  id=";
            public const string GetByName = "SELECT * FROM ItemMaster where ItemMaster.IsValid=1 and ItemMaster.Name='@Name'";

            public const string GetBySeriesIdAndName = "select * from ItemMaster where isvalid=1 and ItemSeriesId like '%@SeriesId%' or Name like '%@Name%'";

        }
        public struct MenuAndSubMenu
        {
            public const string GetByParentId = "select * from MenuAndSubMenu where isvalid=1 and ParentId=";
            public const string GetAllParentMenu = "select * from MenuAndSubMenu where isvalid=1 and ParentId=0";
            public const string GetAll = "select * from MenuAndSubMenu where isvalid=1";
            public const string GetById = "select * from MenuAndSubMenu where id=";
            public const string GetByName = "select * from MenuAndSubMenu where isvalid=1 and Remarks=";
            public const string GetByDescription = "select * from MenuAndSubMenu where isvalid=1 and Description=";
            public const string GetByRemarks = "select * from MenuAndSubMenu where isvalid=1 and Remarks=";
            
        }
        public struct UserMenuMapping
        {
            public const string GetAll = "select * from UserMenuMapping where isvalid=1";          
            public const string GetById = "select * from UserMenuMapping where id=";
            public const string GetByUserTypesId = "select * from UserMenuMapping where isvalid=1 and UserTypeId=";
            
            public const string GetByName = "select * from UserMenuMapping where name=";
        }
        public struct SalesTaxDetails
        {
            public const string GetAll = "select * from SalesTaxDetails where IsValid=true";
            public const string GetById = "select * from SalesTaxDetails where IsValid=true and id=";
            public const string GetByName = "select * from SalesTaxDetails where isvalid=1 and name=";
            public const string GetBySalesDetailsId = "select * from SalesTaxDetails where isvalid=1 and SalesDetailsId=";
            
        }
        public struct SalesDetails
        {
            public const string GetAll = "select * from SalesDetails where IsValid=1";
            public const string GetById = "select * from SalesDetails where IsValid=1 and id=";
        
            public const string GetByName = "select * from SalesDetails where IsValid=1 and name=";
            public const string GetBySaleMasterId = "select * from SalesDetails where IsValid=1 and SaleMasterId=";
         
           
            
        }
        public struct SalesMaster
        {
            public const string GetAll = "select * from SalesMaster where IsValid=1";
            public const string GetById = "select * from SalesMaster where IsValid=1 and id=";
            public const string GetByBillNumber = "select * from SalesMaster where IsValid=1 and BillNumber=";
            public const string GetByStatus = "select * from SalesMaster where IsValid=1 and Status=";
            public const string GetByTableNumber = "select * from SalesMaster where IsValid=1 and TableNumber=";
            public const string GetNewBillNumber = "select MAX(BillNumber) from SalesMaster ";

            public const string GetRunningBillByUserId = "select * from SalesMaster where IsValid=1 and status in(1,2,3) and Createdby=";  
           
        }
        public struct Customer
        {
            public const string GetAll = "select * from Customer where isvalid=1";
            public const string GetById = "select * from Customer where isvalid=1 and id=";           
        }
        public struct Users
        {
            public const string GetAll = "select * from UserTable where isvalid=1";
            public const string GetById = "select * from UserTable where isvalid=1 and id=";
            public const string GetByUserTypesID = "select * from UserTable where isvalid=1 and UserType=";           
        }

        public struct Clients
        {
            public const string GetAll = "select * from Clients";
        }

        public struct MDI
        {
            public const string TruncateSalesMaster = " truncate table salesmaster ";
            public const string TruncateSalesDetails = "truncate table salesdetails";
            public const string TruncateSalesTaxDetails = "truncate table SalesTaxDetails";
            public const string ResetBillNumber = "INSERT INTO [RAHMS1].[dbo].[SalesMaster]([BillNumber] ,[IsValid]) VALUES (55,'False' )";
        }

        public struct MstOrderType
        {
            public const string GetAll = "select * from OrderType";
            public const string GetById = "select * from OrderType where id=";
            public const string GetByName = "select * from OrderType where OrderType=";
        }
    }
}
