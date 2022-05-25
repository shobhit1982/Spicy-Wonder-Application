using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class UserTypes : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static IList<UserTypes> GetAll()
        {
            //Create Collection
            IList<UserTypes> list = new List<UserTypes>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserTypes.GetAll, "RAHMS", conn))
                {
                    list = Fill(new UserTypes(), reader).Cast<UserTypes>().ToList();
                }
            }

            return list;
        }
        public static UserTypes GetById(int id)
        {
            //Create Collection
            IList<UserTypes> list = new List<UserTypes>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserTypes.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new UserTypes(), reader).Cast<UserTypes>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static UserTypes GetByName(string name)
        {
            //Create Collection
            IList<UserTypes> list = new List<UserTypes>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.UserTypes.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new UserTypes(), reader).Cast<UserTypes>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(UserTypes entity)
        {
            string query = "INSERT into UserTypes (Name,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values('" + entity.Name + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "update UserTypes set isvalid=0 where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(UserTypes entity)
        {
            string query = "update UserTypes set Name='" + entity.Name + "',Description=" + entity.Description + ",Modifieddate='" + entity.ModifiedDate + "' where Id=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            UserTypes _tmp = new UserTypes();

            _tmp.ID = this.ID;
            _tmp.Name = this.Name;
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
