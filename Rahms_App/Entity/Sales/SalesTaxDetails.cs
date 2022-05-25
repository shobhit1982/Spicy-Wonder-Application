using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Sales
{
    public class SalesTaxDetails : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public int? SalesDetailsId { get; set; }
        public int? TaxId { get; set; }
        public string TaxName { get; set; }
        public decimal ? TaxRate { get; set; }
        public decimal ? Amount { get; set; }     
        public string Description { get; set; }

        public static IList<SalesTaxDetails> GetAll()
        {
            //Create Collection
            IList<SalesTaxDetails> list = new List<SalesTaxDetails>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesTaxDetails.GetAll, "Text", conn))
                {
                    list = Fill(new SalesTaxDetails(), reader).Cast<SalesTaxDetails>().ToList();
                }
            }
            return list;
        }
        public static SalesTaxDetails GetById(int id)
        {
            //Create Collection
            IList<SalesTaxDetails> list = new List<SalesTaxDetails>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesTaxDetails.GetById + id, "Text", conn))
                {
                    list = Fill(new SalesTaxDetails(), reader).Cast<SalesTaxDetails>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static IList<SalesTaxDetails> GetBySalesDetailsId(int salesDetailsId)
        {
            //Create Collection
            IList<SalesTaxDetails> list = new List<SalesTaxDetails>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesTaxDetails.GetBySalesDetailsId + salesDetailsId, "Text", conn))
                {
                    list = Fill(new SalesTaxDetails(), reader).Cast<SalesTaxDetails>().ToList();
                }
            }
            return list;
        }
        public static SalesTaxDetails GetByName(string name)
        {
            //Create Collection
            IList<SalesTaxDetails> list = new List<SalesTaxDetails>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesTaxDetails.GetByName + "'" + name + "'", "Text", conn))
                {
                    list = Fill(new SalesTaxDetails(), reader).Cast<SalesTaxDetails>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(SalesTaxDetails entity)
        {
            string query = "INSERT into SalesTaxDetails (SalesDetailsId,TaxId,TaxName,TaxRate,Amount,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values(" + entity.SalesDetailsId + "," + entity.TaxId + ",'" + entity.TaxName + "'," + entity.TaxRate + "," + entity.Amount + ",'" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        internal static void Update(SalesTaxDetails salesTaxDetails)
        {
            string query = "update SalesTaxDetails set Amount=" + salesTaxDetails.Amount + " where SalesDetailsId=" + salesTaxDetails.SalesDetailsId + " and id=" + salesTaxDetails.ID + " and IsValid=1";//  set Qty=" + entity.Qty + ",Amount=" + entity.Amount + ",Taxes=" + entity.Taxes + ",ItemId=" + entity.ItemId + ",ItemPrice=" + entity.ItemPrice + ",Remarks='" + entity.Remarks + "',ModifiedDate='" + entity.ModifiedDate + "' where ID=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            //return ret;
        }

        public object Clone()
        {
            SalesTaxDetails _tmp = new SalesTaxDetails();

            _tmp.ID = this.ID;
            _tmp.SalesDetailsId = this.SalesDetailsId;
            _tmp.TaxId = this.TaxId;
            _tmp.TaxName = this.TaxName;
            _tmp.TaxRate = this.TaxRate;
            _tmp.Amount = this.Amount;
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
