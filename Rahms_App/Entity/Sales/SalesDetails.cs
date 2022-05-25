using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RAHMSLibrary.Entity.Masters;
using System.Data.SqlClient;

namespace RAHMSLibrary.Entity.Sales
{
    public class SalesDetails : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public int? SaleMasterId { get; set; }
        public int? BillNumber { get; set; }
        public int? ItemId { get; set; }
        public int? Qty { get; set; }
        public decimal ? Amount { get; set; }
        public decimal ? Taxes { get; set; }
        public decimal? ItemPrice { get; set; }
        public int? GridSNo { get; set; }
        public string Description { get; set; }
        public IList<SalesTaxDetails> SalesTaxDetailsList
        {
            get
            {
                return SalesTaxDetails.GetBySalesDetailsId(ID.Value);
            }
            set { }
        }
        public ItemMaster ItemMaster
        {
            get
            {
                return RAHMSLibrary.Entity.Masters.ItemMaster.GetById(ItemId.Value);
                
            }
        }

        public static IList<SalesDetails> GetAll()
        {
            //Create Collection
            IList<SalesDetails> list = new List<SalesDetails>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesDetails.GetAll, "RAHMS", conn))
                {
                    list = Fill(new SalesDetails(), reader).Cast<SalesDetails>().ToList();
                }
            }

            return list;
        }
        public static SalesDetails GetById(int id)
        {
            //Create Collection
            IList<SalesDetails> list = new List<SalesDetails>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesDetails.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new SalesDetails(), reader).Cast<SalesDetails>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static SalesDetails GetByGridSnBillNoItemId(int BillNumber, int SaleMasterId,int ItemId,int gridSNo)
        {
            string query = "select * from SalesDetails where IsValid=1 and BillNumber=" + BillNumber + " and SaleMasterId=" + SaleMasterId + "  and gridsno=" + gridSNo;
            //Create Collection
            IList<SalesDetails> list = new List<SalesDetails>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "RAHMS", conn))
                {
                    list = Fill(new SalesDetails(), reader).Cast<SalesDetails>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
      
    
        public static IList<SalesDetails> GetBySaleMasterId(int SaleMasterId)
        {
            //Create Collection
            IList<SalesDetails> list = new List<SalesDetails>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesDetails.GetBySaleMasterId + SaleMasterId, "RAHMS", conn))
                {
                    list = Fill(new SalesDetails(), reader).Cast<SalesDetails>().ToList();
                }
            }

            return list;
        }
        public static SalesDetails GetByName(string name)
        {
            //Create Collection
            IList<SalesDetails> list = new List<SalesDetails>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesDetails.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new SalesDetails(), reader).Cast<SalesDetails>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(SalesDetails entity)
        {
            string query = "INSERT into SalesDetails (SaleMasterId,BillNumber,ItemId,Qty,Amount,Taxes,ItemPrice,GridSNo,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) OUTPUT INSERTED.ID Values(" + entity.SaleMasterId + "," + entity.BillNumber + "," + entity.ItemId + "," + entity.Qty + "," + entity.Amount + "," + entity.Taxes + "," + entity.ItemPrice + "," + entity.GridSNo + ",'" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

           
            object ret = ClsDBFunctions.RAHMS().ExecuteScalar(query, "RAHMS");
            if (ret != null) return int.Parse(ret.ToString());
            return 0;
        }


       
        public static int Update(SalesDetails entity)
        {
            string query = "update SalesDetails  set Qty=" + entity.Qty + ",Amount=" + entity.Amount + ",Taxes=" + entity.Taxes + ",ItemId=" + entity.ItemId + ",ItemPrice=" + entity.ItemPrice + ",Remarks='" + entity.Remarks + "',ModifiedDate='" + entity.ModifiedDate + "' where ID=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Delete(SalesDetails entity)
        {
            string query = "delete SalesDetails where ID=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");

            string SalesTaxDetails = "delete SalesTaxDetails where salesdetailsid=" + entity.ID;

            ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(SalesTaxDetails, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            SalesDetails _tmp = new SalesDetails();

            _tmp.ID = this.ID;
            _tmp.SaleMasterId = this.SaleMasterId;
            _tmp.BillNumber = this.BillNumber;
            _tmp.ItemId = this.ItemId;
            _tmp.Qty = this.Qty;
            _tmp.Amount = this.Amount;
            _tmp.Taxes = this.Taxes;
            _tmp.ItemPrice = this.ItemPrice;
            _tmp.GridSNo = this.GridSNo;
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
