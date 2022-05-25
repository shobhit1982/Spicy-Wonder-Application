using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class ItemMaster : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemSeriesId { get; set; }
        //public string ItemSeriesName
        //{
        //    get
        //    {
        //        var series = ItemSeries.GetById(ItemSeriesId);
        //        if (series != null && series.ID > 0) return series.Name;// +" " + series.Description;
        //        return null;
        //    }
        //}

        public decimal? Price { get; set; }
        public int IsTaxable { get; set; }
        public int UnitId { get; set; }

        public int IsKot { get; set; }

        private IList<TaxAppliedOnItem> _TaxAppliedList;
        public IList<TaxAppliedOnItem> TaxAppliedList
        {
            get
            {
                if (_TaxAppliedList == null)
                {
                    if (IsTaxable == 1)
                    {
                        _TaxAppliedList = TaxAppliedOnItem.GetByItemMasterId(ID.Value);
                    }
                }
                ClsDBFunctions.RAHMS().CloseConnections();
                return _TaxAppliedList;
            }
        }

        public static IList<ItemMaster> GetAll()
        {
            //Create Collection
            IList<ItemMaster> list = new List<ItemMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.ItemMaster.GetAll, "RAHMS", conn))
                {
                    list = Fill(new ItemMaster(), reader).Cast<ItemMaster>().ToList();
                }
                //ClsDBFunctions.RAHMS().CloseConnections();
                return list;
            }
        }
        public static IList<ItemMaster> GetBySeriesId(string SeriesId)
        {
            //Create Collection
            IList<ItemMaster> list = new List<ItemMaster>();

            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.ItemMaster.GetBySeriesId + SeriesId, "RAHMS", conn))
                {
                    list = Fill(new ItemMaster(), reader).Cast<ItemMaster>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();
            return list;
        }
        public static IList<ItemMaster> GetBySeriesIdAndName(string SeriesId, string Name)
        {
            //Create Collection
            IList<ItemMaster> list = new List<ItemMaster>();
            string query = Query.ItemMaster.GetBySeriesIdAndName.Replace("@Name", Name);
            query = query.Replace("@SeriesId", SeriesId);
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "RAHMS", conn))
                {
                    list = Fill(new ItemMaster(), reader).Cast<ItemMaster>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();
            return list;
        }
        public static ItemMaster GetById(int id)
        {
            //Create Collection
            IList<ItemMaster> list = new List<ItemMaster>();

            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.ItemMaster.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new ItemMaster(), reader).Cast<ItemMaster>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static ItemMaster GetByName(string name)
        {
            //Create Collection
            IList<ItemMaster> list = new List<ItemMaster>();
            string query = Query.ItemMaster.GetByName.Replace("@Name", name);
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "RAHMS", conn))
                {
                    list = Fill(new ItemMaster(), reader).Cast<ItemMaster>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static IList<ItemMaster> GetByNameList(string name)
        {
            //Create Collection
            IList<ItemMaster> list = new List<ItemMaster>();
            string query = Query.ItemMaster.GetByName.Replace("@Name", name);
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "RAHMS", conn))
                {
                    list = Fill(new ItemMaster(), reader).Cast<ItemMaster>().ToList();
                }
            }
          
            //ClsDBFunctions.RAHMS().CloseConnections();
            return list;
        }
        public static int Insert(ItemMaster entity)
        {
            string query = "INSERT into ItemMaster (Name,Description,ItemSeriesId,Price,	IsTaxable, UnitId, IsKot,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) OUTPUT INSERTED.ID Values('" + entity.Name + "','" + entity.Description + "'," + entity.ItemSeriesId + ",'" + entity.Price + "'," + entity.IsTaxable + "," + entity.UnitId + "," + entity.IsKot + ",'" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            object ret = ClsDBFunctions.RAHMS().ExecuteScalar(query, "RAHMS");
            if (ret != null) return int.Parse(ret.ToString());
            return 0;

        }
        public static int DeleteById(int Id)
        {
            string query = "update ItemMaster set isvalid=0 where Id=" + Id;

            var ret =
ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(ItemMaster entity)
        {
            string query = "update ItemMaster set Name='" + entity.Name + "',IsKot=" + entity.IsKot + ",IsTaxable=" + entity.IsTaxable + ",ItemSeriesId=" + entity.ItemSeriesId + ",Price='" + entity.Price + "',UnitId=" + entity.UnitId + ",Modifieddate='" + entity.ModifiedDate + "' where Id=" + entity.ID;

            var ret =
ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            ItemMaster _tmp = new ItemMaster();

            _tmp.ID = this.ID;
            _tmp.Name = this.Name;
            _tmp.Description = this.Description;
            _tmp.ItemSeriesId = this.ItemSeriesId;
            _tmp.Price = this.Price;
            _tmp.IsTaxable = this.IsTaxable;
            _tmp.UnitId = this.UnitId;
            _tmp.IsKot = this.IsKot;
            _tmp.Remarks = this.Remarks;
            _tmp.CreatedBy = this.CreatedBy;
            _tmp.CreatedDate = this.CreatedDate;
            _tmp.ModifiedBy = this.ModifiedBy;
            _tmp.ModifiedDate = this.ModifiedDate;
            return _tmp;
        }
    }
}
