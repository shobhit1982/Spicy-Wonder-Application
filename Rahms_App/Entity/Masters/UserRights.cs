using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using RAHMSLibrary.Entity;

namespace RAHMS.Entity
{
    public class UserRights : EntityBase
    {
        public long ID { get; set; }
        public long UserTypeId { get; set; }
        public long MenuId { get; set; }
        public long MenuParentId { get; set; }
        public string MenuName { get; set; }



        public static int Save(UserRights entity)
        {
            string sql = " INSERT INTO UserRights(UserTypeId,MenuId,MenuParentId,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate)" +
                            " VALUES (" + entity.UserTypeId + "," + entity.MenuId + "," + entity.MenuParentId + ",'" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "' )";
            return ClsDBFunctions.RAHMS().ExecuteNonQuery(sql, "sho");

        }
        public static int Delete(long MenuId, long UserTypeId)
        {
            string query = "delete UserRights where MenuId=" + MenuId + " and UserTypeId=" + UserTypeId;
            return ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "sho");
        }
        public static IList<UserRights> GetUserRights(long UserTypeId, long userId)
        {
            //Create Collection
            IList<UserRights> list = new List<UserRights>();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
            param[0].Value = userId;
            param[1] = new SqlParameter("@UserTypeId", SqlDbType.BigInt);
            param[1].Value = UserTypeId;


            using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader_SP("P_GetUserRights", param, "sho"))
            {
                list = Fill(new UserRights(), reader).Cast<UserRights>().ToList();

            }

            return list;
        }
        public static IList<UserRights> GetByUserTypesId(long UserTypeId)
        {
            //Create Collection
            IList<UserRights> list = new List<UserRights>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserRights.GetByUserTypesId + UserTypeId, "sho", conn))
                {
                    list = Fill(new UserRights(), reader).Cast<UserRights>().ToList();
                }
            }

            return list;
        }
        public static IList<UserRights> GetByUserMenuId(long menuId, long UserTypeId)
        {
            //Create Collection
            IList<UserRights> list = new List<UserRights>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserRights.GetByUserMenuId + menuId + " and UserTypeId=" + UserTypeId, "sho", conn))
                {
                    list = Fill(new UserRights(), reader).Cast<UserRights>().ToList();
                }
            }
            return list;
        }
        public static IList<UserRights> GetByUserParentId(long menuParentId, long UserTypeId)
        {
            //Create Collection
            IList<UserRights> list = new List<UserRights>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserRights.GetByUserMenuParentId + menuParentId + " and UserTypeId=" + UserTypeId, "sho", conn))
                {
                    list = Fill(new UserRights(), reader).Cast<UserRights>().ToList();
                }
            }

            return list;
        }
    }
}
