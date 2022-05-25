using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class Users : EntityBase, ICloneable
    {
        public int? ID { get; set; }

        public string FullName { get; set; }
        public string LoginId { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string UserPassword { get; set; }
        public int? UserType { get; set; }
        public string UserTypeName
        {
            get
            {

                return RAHMSLibrary.Entity.Masters.UserTypes.GetById(UserType.Value).Name;

            }
          
        }
        public int? UserStatus { get; set; }
        public string Address { get; set; }

        public static IList<Users> GetAll()
        {
            //Create Collection
            IList<Users> list = new List<Users>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Users.GetAll, "RAHMS", conn))
                {
                    list = Fill(new Users(), reader).Cast<Users>().ToList();
                }
            }

            return list;
        }
        public static Users GetById(int id)
        {
            //Create Collection
            IList<Users> list = new List<Users>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Users.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new Users(), reader).Cast<Users>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static IList<Users> GetByUserTypesID(int UserTypesId)
        {
            //Create Collection
            IList<Users> list = new List<Users>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Users.GetByUserTypesID + UserTypesId, "RAHMS", conn))
                {
                    list = Fill(new Users(), reader).Cast<Users>().ToList();
                }
            }

            return list;
        }


        public static int Insert(Users entity)
        {
            string query = "INSERT into UserTable (FullName, LoginId, EmailId, MobileNumber, UserPassword, UserTypes, UserStatus, Address, Remarks, IsValid, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) Values('" + entity.FullName + "','" + entity.LoginId + "','" + entity.EmailId + "','" + entity.MobileNumber + "','" + entity.UserPassword + "'," + entity.UserType + "," + entity.UserStatus + ",'" + entity.Address + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "update UserTable set isvalid=false where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(Users entity)
        {
            string query = "update UserTable set LoginId='" + entity.LoginId + "', FullName='" + entity.FullName + "',ModifiedDate='" + entity.ModifiedDate + "' where Id=" + entity.ID;
            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            Users _tmp = new Users();
            _tmp.ID = this.ID;
            _tmp.FullName = this.FullName;
            _tmp.LoginId = this.LoginId;
            _tmp.EmailId = this.EmailId;
            _tmp.MobileNumber = this.MobileNumber;
            _tmp.UserPassword = this.UserPassword;
            _tmp.UserType = this.UserType;       
            _tmp.UserStatus = this.UserStatus;
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
