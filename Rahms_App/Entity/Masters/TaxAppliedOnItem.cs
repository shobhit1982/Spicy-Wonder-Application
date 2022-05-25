using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RAHMSLibrary.Entity.Masters
{
    public class TaxAppliedOnItem : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public int? ItemMasterId { get; set; }
        public int? TaxId { get; set; }

        private Taxes _TaxDetails;
        public Taxes TaxDetails
        {
            get
            {
                if (_TaxDetails == null)
                {
                    Taxes tax = Taxes.GetById(TaxId.Value);
                    if (tax != null) _TaxDetails = tax;
                }

                return _TaxDetails;

            }
        }
        public string Description { get; set; }

        public static IList<TaxAppliedOnItem> GetAll()
        {
            //Create Collection
            IList<TaxAppliedOnItem> list = new List<TaxAppliedOnItem>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.TaxAppliedOnItem.GetAll, "RAHMS", conn))
                {
                    list = Fill(new TaxAppliedOnItem(), reader).Cast<TaxAppliedOnItem>().ToList();
                }
            }

            return list;
        }
        public static TaxAppliedOnItem GetById(int Id)
        {
            //Create Collection
            IList<TaxAppliedOnItem> list = new List<TaxAppliedOnItem>();

            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.TaxAppliedOnItem.GetById + Id, "RAHMS", conn))
                {
                    list = Fill(new TaxAppliedOnItem(), reader).Cast<TaxAppliedOnItem>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static IList<TaxAppliedOnItem> GetByItemMasterId(int itemMasterId)
        {
            //Create Collection
            IList<TaxAppliedOnItem> list = new List<TaxAppliedOnItem>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.TaxAppliedOnItem.GetByItemMasterId + itemMasterId, "RAHMS",conn))
                {
                    list = Fill(new TaxAppliedOnItem(), reader).Cast<TaxAppliedOnItem>().ToList();
                }
            }

                return list;
            
        }


        public static int Insert(TaxAppliedOnItem entity)
        {
            string query = "INSERT into TaxAppliedOnItem (ItemMasterId,TaxId,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values(" + entity.ItemMasterId + "," + entity.TaxId + ",'" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }

        public static int Update(TaxAppliedOnItem entity)
        {
            string query = "update TaxAppliedOnItem set Isvalid=" + entity.IsValid + ",Modifieddate='" + entity.ModifiedDate + "' where ItemMasterId=" + entity.ItemMasterId + " and TaxId" + entity.TaxId;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Delete(int itemMaterId)
        {
            string query = "delete Taxappliedonitem where itemmasterid=" + itemMaterId;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }

        public object Clone()
        {
            TaxAppliedOnItem _tmp = new TaxAppliedOnItem();

            _tmp.ID = this.ID;
            _tmp.ItemMasterId = this.ItemMasterId;
            _tmp.TaxId = this.TaxId;
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
