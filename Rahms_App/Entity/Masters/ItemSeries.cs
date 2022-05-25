using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class ItemSeries : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DisplayName
        {
            get
            {
                return Name + " " + Description;
            }
            set{}
        }

        public static IList<ItemSeries> GetAll()
        {
            //Create Collection
            IList<ItemSeries> list = new List<ItemSeries>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.ItemSeries.GetAll, "RAHMS", conn))
                {
                    list = Fill(new ItemSeries(), reader).Cast<ItemSeries>().ToList();
                }
            }

            return list;
        }
        public static ItemSeries GetById(int id)
        {
            //Create Collection
            IList<ItemSeries> list = new List<ItemSeries>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.ItemSeries.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new ItemSeries(), reader).Cast<ItemSeries>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static ItemSeries GetByName(string name)
        {
            //Create Collection
            IList<ItemSeries> list = new List<ItemSeries>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.ItemSeries.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new ItemSeries(), reader).Cast<ItemSeries>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(ItemSeries entity)
        {
            string query = "INSERT into ItemSeries (Name,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values('" + entity.Name + "','" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "update ItemSeries set isvalid=0 where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(ItemSeries entity)
        {
            string query = "update ItemSeries set Name='" + entity.Name + "',Description='" + entity.Description + "',Modifieddate='" + entity.ModifiedDate + "', ModifiedBy=" + entity.ModifiedBy + " where Id=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            ItemSeries _tmp = new ItemSeries();

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
