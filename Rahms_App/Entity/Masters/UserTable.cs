using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RAHMSLibrary.Entity;
using System.Data.SqlClient;

namespace RAHMS.Entity
{
    public class UserTable : EntityBase
    {
        public long Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public long UserTypes { get; set; }
        public string UserTypeName { get; set; }
        public string Address { get; set; }
        public static int Save(UserTable entity)
        {
            string sql = " INSERT INTO UserTable(LoginId,Password,Name, Email,Mobile,UserType,UserTypeName,Address,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate)" +
                            " VALUES ('" + entity.LoginId + "','" + entity.Password + "','" + entity.Name + "','" + entity.Email + "','" + entity.Mobile + "'," + entity.UserTypes + ",'" + entity.UserTypeName + "','" + entity.Address + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "' )";
            return ClsDBFunctions.RAHMS().ExecuteNonQuery(sql, "sho");

        }
        public static IList<UserTable> GetAll()
        {
            //Create Collection
            IList<UserTable> list = new List<UserTable>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserTable.GetAll, "sho", conn))
                {
                    list = Fill(new UserTable(), reader).Cast<UserTable>().ToList();
                }
            }

            return list;
        }
        public static IList<UserTable> GetByLoginId(string loginId)
        {
            //Create Collection
            IList<UserTable> list = new List<UserTable>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserTable.GetByLoginId + "'" + loginId + "'", "sho", conn))
                {
                    list = Fill(new UserTable(), reader).Cast<UserTable>().ToList();
                }
            }

            return list;
        }
        public static IList<UserTable> GetByEmailId(string emailId)
        {
            //Create Collection
            IList<UserTable> list = new List<UserTable>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserTable.GetByEmailId + "'" + emailId + "'", "sho", conn))
                {
                    list = Fill(new UserTable(), reader).Cast<UserTable>().ToList();
                }
            }

            return list;
        }
        public static IList<UserTable> GetByMobile(string mobile)
        {
            //Create Collection
            IList<UserTable> list = new List<UserTable>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserTable.GetByMobile + "'" + mobile + "'", "sho", conn))
                {
                    list = Fill(new UserTable(), reader).Cast<UserTable>().ToList();
                }
            }

            return list;
        }
        public static UserTable GetByAdminPassword(string password)
        {
            string query = "select * from usertable where isvalid=1 and usertype=1 and password='" + password + "'";           //Create Collection
            IList<UserTable> list = new List<UserTable>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "sho", conn))
                {
                    list = Fill(new UserTable(), reader).Cast<UserTable>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            else
                return null;
          
        }
        public static IList<UserTable> Search(UserTable entity)
        {

            string Search = "";
            if (!string.IsNullOrEmpty(entity.LoginId))
                Search = "select * from  UserTable where IsValid=1 and LoginId='" + entity.LoginId + "'";
            if (!string.IsNullOrEmpty(entity.Mobile))
                Search = "select * from  UserTable where IsValid=1 and Mobile='" + entity.Mobile + "'";
            if (!string.IsNullOrEmpty(entity.UserTypeName))
                Search = "select * from  UserTable where IsValid=1 and UserTypeName='" + entity.UserTypeName + "'";
            if (!string.IsNullOrEmpty(entity.Email)) 
                Search = "select * from  UserTable where IsValid=1 and Email='" + entity.Email + "'";
            if (!string.IsNullOrEmpty(entity.LoginId) && !string.IsNullOrEmpty(entity.Mobile))
                Search = "select * from  UserTable where IsValid=1 and LoginId=" + entity.LoginId + " and Mobile='" + entity.Mobile + "'";
            if (!string.IsNullOrEmpty(entity.LoginId) && !string.IsNullOrEmpty(entity.Mobile) && !string.IsNullOrEmpty(entity.Email))
                Search = "select * from  UserTable where IsValid=1 and LoginId=" + entity.LoginId + " and Mobile=" + entity.Mobile + " and Email=" + entity.Email;
            if (!string.IsNullOrEmpty(entity.LoginId) && !string.IsNullOrEmpty(entity.Mobile) && !string.IsNullOrEmpty(entity.Email) && !string.IsNullOrEmpty(entity.UserTypeName))
                Search = "select * from  UserTable where IsValid=1 and LoginId=" + entity.LoginId + " and Mobile=" + entity.Mobile + " and Email=" + entity.Email + " and UserTypeName=" + entity.UserTypeName;
            //Create Collection
            IList<UserTable> list = new List<UserTable>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Search, "sho", conn))
                {
                    list = Fill(new UserTable(), reader).Cast<UserTable>().ToList();
                }
            }

            return list;
        }
        public static int Delete(long Id)
        {
            return ClsDBFunctions.RAHMS().ExecuteNonQuery(Query.UserTable.Delete + Id, "sho");
        }

        public static int Update(UserTable entity)
        {
            string query = "update UserTable set Password='" + entity.Password + "',Name='" + entity.Name + "',Email='" + entity.Email + "',Mobile='" + entity.Mobile + "',UserType='" + entity.UserTypes + "',UserTypeName='" + entity.UserTypeName + "',Address='" + entity.Address + "',ModifiedDate='" + entity.ModifiedDate + "' where id=" + entity.Id + "";

            return ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "sho");
        }


    }
}
