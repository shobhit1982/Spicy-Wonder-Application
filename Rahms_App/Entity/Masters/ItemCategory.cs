using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class ItemCategory : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static IList<ItemCategory> GetAll()
        {
            //Create Collection
            IList<ItemCategory> list = new List<ItemCategory>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.ItemCategory.GetAll, "RAHMS", conn))
                {
                    list = Fill(new ItemCategory(), reader).Cast<ItemCategory>().ToList();
                }
            }

            return list;
        }
        public static ItemCategory GetById(int id)
        {
            //Create Collection
            IList<ItemCategory> list = new List<ItemCategory>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.ItemCategory.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new ItemCategory(), reader).Cast<ItemCategory>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static ItemCategory GetByName(string name)
        {
            //Create Collection
            IList<ItemCategory> list = new List<ItemCategory>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.ItemCategory.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new ItemCategory(), reader).Cast<ItemCategory>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(ItemCategory entity)
        {
            string query = "INSERT into ItemCategory (Name,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values('" + entity.Name + "','" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "update ItemCategory set isvalid=false where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(ItemCategory entity)
        {
            string query = "update ItemCategory set Name='" + entity.Name + "',Description=" + entity.Description + ",Modifieddate='" + entity.ModifiedDate + "' where Id=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            ItemCategory _tmp = new ItemCategory();

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
