using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class UserMenuMapping : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public int? UserTypesId { get; set; }
        public int? MenuId { get; set; }
        public int? ParentMenuId { get; set; }
        public string Description { get; set; }

        public static IList<UserMenuMapping> GetAll()
        {
            //Create Collection
            IList<UserMenuMapping> list = new List<UserMenuMapping>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserMenuMapping.GetAll, "RAHMS", conn))
                {
                    list = Fill(new UserMenuMapping(), reader).Cast<UserMenuMapping>().ToList();
                }
            }

            return list;
        }
       
        public static UserMenuMapping GetById(int id)
        {
            //Create Collection
            IList<UserMenuMapping> list = new List<UserMenuMapping>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserMenuMapping.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new UserMenuMapping(), reader).Cast<UserMenuMapping>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static IList<UserMenuMapping> GetByUserTypesId(int UserTypesId)
        {
            //Create Collection
            IList<UserMenuMapping> list = new List<UserMenuMapping>();

            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserMenuMapping.GetByUserTypesId + UserTypesId, "RAHMS", conn))
                {
                    list = Fill(new UserMenuMapping(), reader).Cast<UserMenuMapping>().ToList();
                }
            }


            return list;
        }
        public static UserMenuMapping GetByName(string name)
        {
            //Create Collection
            IList<UserMenuMapping> list = new List<UserMenuMapping>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserMenuMapping.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new UserMenuMapping(), reader).Cast<UserMenuMapping>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(UserMenuMapping entity)
        {
            string query = "INSERT into UserMenuMapping (UserTypesId,MenuId,ParentMenuId,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values(" + entity.UserTypesId + "," + entity.MenuId + "," + entity.ParentMenuId + ",'" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }

        public object Clone()
        {
            UserMenuMapping _tmp = new UserMenuMapping();

            _tmp.ID = this.ID;
            _tmp.UserTypesId = this.UserTypesId;
            _tmp.MenuId = this.MenuId;
            _tmp.ParentMenuId = this.ParentMenuId;
            _tmp.Description = this.Description;
            _tmp.Remarks = this.Remarks;
            _tmp.CreatedBy = this.CreatedBy;
            _tmp.CreatedDate = this.CreatedDate;
            _tmp.ModifiedBy = this.ModifiedBy;
            _tmp.ModifiedDate = this.ModifiedDate;
            return _tmp;
        }
    }
}
