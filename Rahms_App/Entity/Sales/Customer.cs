using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class Customer : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public int? SalesMasterId { get; set; }
        public string CustName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public static IList<Customer> GetAll()
        {
            //Create Collection
            IList<Customer> list = new List<Customer>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Customer.GetAll, "RAHMS", conn))
                {
                    list = Fill(new Customer(), reader).Cast<Customer>().ToList();
                }
            }

            return list;
        }
        public static Customer GetById(int id)
        {
            //Create Collection
            IList<Customer> list = new List<Customer>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Customer.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new Customer(), reader).Cast<Customer>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static int Insert(Customer entity)
        {
            string query = "INSERT into Customer (SalesMasterId,CustName,Mobile,Email,Address,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values(" + entity.SalesMasterId + ",'" + entity.CustName + "','" + entity.Mobile + "','" + entity.Email + "','" + entity.Address + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "update Customer set isvalid=false where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(Customer entity)
        {
            string query = "update Customer set CustName='" + entity.CustName + "',Mobile='" + entity.Mobile + "',Modifieddate='" + entity.ModifiedDate + "' where Id=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            Customer _tmp = new Customer();
            _tmp.ID = this.ID;
            _tmp.SalesMasterId = this.SalesMasterId;
            _tmp.CustName = this.CustName;
            _tmp.Mobile = this.Mobile;
            _tmp.Email = this.Email;
            _tmp.Address = this.Address;
            _tmp.Remarks = this.Remarks;
            _tmp.CreatedBy = this.CreatedBy;
            _tmp.CreatedDate = this.CreatedDate;
            _tmp.ModifiedBy = this.ModifiedBy;
            _tmp.ModifiedDate = this.ModifiedDate;
            return _tmp;
        }
    }
}
