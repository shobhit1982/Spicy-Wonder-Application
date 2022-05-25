using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RAHMSLibrary.Entity.Masters;
using System.Data.SqlClient;

namespace RAHMSLibrary.Entity.Sales
{
    public class SalesMaster : EntityBase, ICloneable
    {
        public int? ID { get; set; }
     
        public int? BillNumber { get; set; }
        public string TableNumber { get; set; }
        public int? CustomerId { get; set; }

        public int? Status { get; set; }

        public int? Discount { get; set; }
        // public bool IsBillAlreadyPrinted { get; set; }

        public decimal OriginalTaxAmount { get; set; }

        private int _editedBillNumber;

        public int EditedBillNumber
        {
            get
            {

                return _editedBillNumber;
            }
            set
            {
                _editedBillNumber = value;
            }
        }

        //public int EditedBillNumber { get; set; }
        private bool isBillAlreadyPrinted;

        public bool IsBillAlreadyPrinted
        {
            get
            {
                return isBillAlreadyPrinted;
            }
            set
            {
                isBillAlreadyPrinted = value;
            }
        }


        public string PaymentMode { get; set; }
        public IList<SalesDetails> SalesDetailsList
        {
            get
            {
                var salesDetailsList = SalesDetails.GetBySaleMasterId(ID.Value);
                if (salesDetailsList != null && salesDetailsList.Count > 0)
                {
                    return salesDetailsList;
                }
                return null;
            }
            set { }
        }
        public decimal? Amount
        {
            get;
            set;
        }

        //private decimal? _amount;

        //public decimal? Amount
        //{
        //    get
        //    {

        //        if (Discount != null)
        //            return (_amount - (_amount * Discount / 100));
        //       // return taxes;

        //        return _amount; 
        //    }
        //    set
        //    {
        //        _amount = value; 
        //    }
        //}


        //private decimal? taxes;

        //public decimal? Taxes
        //{
        //    get
        //    {
        //        if (taxes != null && Discount != null)
        //            return (taxes - (taxes * Discount / 100));
        //        return taxes;
        //    }
        //    set { taxes = value; }
        //}


        private decimal? _taxes;

        public decimal? Taxes
        {
            get
            {
                return _taxes;
            }
            set
            {
                _taxes = value;
            }
        }


        //public decimal? Taxes
        //{
        //    get;
        //    set;
        //}

        private decimal? TotalAmountAfterDiscount
        {
            get
            {
                if (Amount != null && Discount != null)
                    return (Amount - (Amount * Discount / 100));
                return Amount;

            }
            set { }
        }
        public decimal? TotalAmount
        {
            get
            {
                if (TotalAmountAfterDiscount != null)
                    return (Taxes + TotalAmountAfterDiscount);
                return 0;
            }
            set { }
        }


        public decimal? RoundAmount
        {
            get
            {
                if (TotalAmount != null)
                    return decimal.Round(TotalAmount.Value, 0, MidpointRounding.AwayFromZero);
                return 0;
            }
            set { }
        }
        public decimal? Difference
        {
            get
            {
                if (TotalAmount != null && RoundAmount != null)
                    return RoundAmount - TotalAmount;
                return 0;
            }
            set { }
        }
        public IList<TaxCalculation> TaxCalculationList(int orderType = 1)
        {

            IList<TaxCalculation> objTaxCalculation = new List<TaxCalculation>();
            if (orderType > 1)
                return null;
            DataTable dt = GetTaxCalculation(BillNumber.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {

                var taxGroup = dt.AsEnumerable().GroupBy(tax => tax.Field<long>("TaxId"));
                foreach (var tax in taxGroup)
                {
                    TaxCalculation obj = new TaxCalculation();
                    obj.TaxId = int.Parse(tax.Key.ToString());
                    obj.TaxName = tax.FirstOrDefault().Field<string>("TaxName");
                    obj.TaxRat = tax.FirstOrDefault().Field<decimal>("TaxRate");

                    decimal taxAmount = 0;
                    foreach (var taxamount in tax)
                    {
                        taxAmount += decimal.Parse(taxamount["Amount"].ToString());
                    }
                    obj.TaxAmount = taxAmount;
                    objTaxCalculation.Add(obj);

                }
                return objTaxCalculation;
            }
            return null;
        }



        public static IList<SalesMaster> GetAll()
        {
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesMaster.GetAll, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }

            return list;
        }
        public static int? GetNewBillNumber()
        {
            object ret = ClsDBFunctions.RAHMS().ExecuteScalar(Query.SalesMaster.GetNewBillNumber, "RAMHS");
            if (string.IsNullOrEmpty(ret.ToString())) return 10000;
            return int.Parse(ret.ToString());
        }
        public static SalesMaster GetById(int id)
        {
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesMaster.GetById + id, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static SalesMaster GetByBillNumber(string billNuumber)
        {
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesMaster.GetByBillNumber + "'" + billNuumber + "'", "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static SalesMaster GetByBillNumberAndTableNumber(string billNuumber, string tableNumber)
        {
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            string query = "select * from SalesMaster where IsValid=1 and BillNumber=" + billNuumber + " and TableNumber=" + tableNumber;
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static IList<SalesMaster> GetRunningBillByUserId(long UserId)
        {
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesMaster.GetRunningBillByUserId + UserId, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }


            return list;
        }

        public static DataTable GetTaxCalculation(string billNuumber)
        {
            //Create Collection

            string query = "select std.TaxId,std.TaxName,std.TaxRate,std.Amount from SalesMaster sm inner join SalesDetails sd on sm.ID=sd.SaleMasterId inner join SalesTaxDetails std on std.SalesDetailsId = sd.ID where sm.BillNumber=" + billNuumber + " order by std.TaxId";
            DataSet ds = ClsDBFunctions.RAHMS().ExecuteQuery_DataSet(query, "RAHMS");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0];
            return null;
        }
        /// <summary>
        /// 1-Bill Created 2- InProcess 3-Payment Received 4-Print - 5 Deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<SalesMaster> GetByStatus(int statusId)
        {
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesMaster.GetByStatus + statusId, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }


            return list;
        }

        internal static IList<SalesMaster> GetByAdminUser(int statusId, int BillNumber)
        {
            IList<SalesMaster> list = new List<SalesMaster>();
            try
            {                //Create Collection

                string query = "select * from SalesMaster where IsValid=1 and Status=" + statusId + "  AND BillNumber=" + BillNumber;
                using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
                {
                    using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                    {
                        list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                    }
                }


                return list;
            }
            catch (Exception)
            {

                return list;
            }
        }

        public static IList<SalesMaster> GetByStatusAndUserId(int statusId, long userId, int BillNumber)
        {
            IList<SalesMaster> list = new List<SalesMaster>();
            try
            {                //Create Collection

                string query = "select * from SalesMaster where IsValid=1 and Status=" + statusId + " and CreatedBy=" + userId + " AND BillNumber=" + BillNumber;
                using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
                {
                    using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                    {
                        list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                    }
                }


                return list;
            }
            catch (Exception)
            {

                return list;
            }
        }
        public static IList<SalesMaster> GetOpenBillByUserId(long userId)
        {
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            string query = "select * from SalesMaster where IsValid=1 and Status in (1,2,3) and CreatedBy=" + userId;
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }


            return list;
        }
        public static IList<SalesMaster> GetPrintedBillByUserId(long userId)
        {
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            string query = "select * from SalesMaster where IsValid=1 and Status in (1,2,3) and CreatedBy=" + userId;
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }


            return list;
        }
        public static IList<SalesMaster> GetByName(string name)
        {
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.SalesMaster.GetByTableNumber + "'" + name + "'", "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }

            return list;
        }

        public static SalesMaster GetFirstTPrintedBillUserWiseAdmin(long userId)
        {
            string query = "select top 1 *    from SalesMaster where IsValid=1 and  Status in(4)  order by BillNumber asc";
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static SalesMaster GetFirstTodayPrintedBillUserWise(long userId)
        {
            string query = "select top 1 *    from SalesMaster where IsValid=1 and  Status=4 and CreatedBy=" + userId + " and convert(varchar,CreatedDate,106)  = convert(varchar,GETDATE(),106) order by BillNumber asc";
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static SalesMaster GetLastTodayPrintedBillUserWiseADMIN(long userId)
        {
            string query = "select top 1 *    from SalesMaster where IsValid=1 and  Status in(4)  order by BillNumber desc ";
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static SalesMaster GetLastTodayPrintedBillUserWise(long userId)
        {
            string query = "select top 1 *    from SalesMaster where IsValid=1 and  Status=4 and CreatedBy=" + userId + " and convert(varchar,CreatedDate,106)  = convert(varchar,GETDATE(),106) order by BillNumber desc";
            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        /// <summary>
        /// 1= Previous 2- Next
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currentBillNumber"></param>
        /// <param name="sequence">1/2</param>
        /// <returns></returns>
        public static SalesMaster GetNextPriviousTodayPrintedBillUserWise(long userId, int currentBillNumber, int sequence)
        {
            string query = string.Empty;
            switch (sequence)
            {
                case 1:
                    query = "select top 1 *    from SalesMaster where IsValid=1 and  Status=4 and CreatedBy=" + userId + " and BillNumber < " + currentBillNumber + " and convert(varchar,CreatedDate,106)  = convert(varchar,GETDATE(),106) order by BillNumber desc";
                    break;
                case 2:
                    query = "select top 1 *    from SalesMaster where IsValid=1 and  Status=4 and CreatedBy=" + userId + " and BillNumber > " + currentBillNumber + " and convert(varchar,CreatedDate,106)  = convert(varchar,GETDATE(),106) order by BillNumber asc";
                    break;
            }

            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }


        public static SalesMaster GetNextPriviousTodayPrintedBillUserWiseAdmin(long userId, int currentBillNumber, int sequence)
        {
            string query = string.Empty;
            switch (sequence)
            {
                case 1:
                    query = "select top 1 *    from SalesMaster where IsValid=1 and Status in(4)   and BillNumber < " + currentBillNumber + "  order by BillNumber desc";
                    break;
                case 2:
                    query = "select top 1 *    from SalesMaster where IsValid=1 and  Status in(4)  and BillNumber > " + currentBillNumber + "  order by BillNumber ASC";
                    break;
            }

            //Create Collection
            IList<SalesMaster> list = new List<SalesMaster>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(query, "Text", conn))
                {
                    list = Fill(new SalesMaster(), reader).Cast<SalesMaster>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(SalesMaster entity)
        {
            string query = "INSERT into SalesMaster (BillNumber,TableNumber,CustomerId,Amount,Taxes,RoundAmount,TotalAmount,Difference,Discount,Status,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) OUTPUT INSERTED.ID Values(" + entity.BillNumber + ",'" + entity.TableNumber + "'," + entity.CustomerId + "," + entity.Amount + "," + entity.Taxes + "," + entity.RoundAmount + "," + entity.TotalAmount + "," + entity.Difference + "," + entity.Discount + "," + entity.Status + ",'" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            object ret = ClsDBFunctions.RAHMS().ExecuteScalar(query, "RAHMS");
            if (ret != null) return int.Parse(ret.ToString());
            return 0;

        }
        public static int Update(SalesMaster entity)
        {
            string query = string.Empty;
            if (!string.IsNullOrEmpty(entity.PaymentMode))
            {
                query = "Update SalesMaster set Amount=" + entity.Amount + ",RoundAmount=" + entity.RoundAmount + ",TotalAmount=" + entity.TotalAmount + ",Taxes=" + entity.Taxes + ",Difference=" + entity.Difference + ",Discount=" + entity.Discount + ",Remarks='" + entity.Remarks + "',Status=" + entity.Status + ",PaymentMode='" + entity.PaymentMode + "',CustomerId=" + entity.CustomerId + " where BillNumber=" + entity.BillNumber;
            }
            else
            {
                query = "Update SalesMaster set Amount=" + entity.Amount + ",RoundAmount=" + entity.RoundAmount + ",TotalAmount=" + entity.TotalAmount + ",Taxes=" + entity.Taxes + ",Difference=" + entity.Difference + ",Discount=" + entity.Discount + ",Remarks='" + entity.Remarks + "',Status=" + entity.Status + ",CustomerId=" + entity.CustomerId + " where BillNumber=" + entity.BillNumber;
            }
            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;
        }
        public static int Delete(int billNumber)
        {
            string query = "update SalesMaster set isvalid=0,status=6,remarks='Deleted' where BillNumber=" + billNumber;
            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;
        }


        public object Clone()
        {
            SalesMaster _tmp = new SalesMaster();

            _tmp.ID = this.ID;
            _tmp.TableNumber = this.TableNumber;
            _tmp.BillNumber = this.BillNumber;
            _tmp.CustomerId = this.CustomerId;
            _tmp.Amount = this.Amount;
            _tmp.Taxes = this.Taxes;
            _tmp.TotalAmount = this.TotalAmount;
            _tmp.RoundAmount = this.RoundAmount;
            _tmp.Difference = this.Difference;
            _tmp.Discount = this.Discount;
            _tmp.Status = this.Status;
            _tmp.Remarks = this.Remarks;
            _tmp.CreatedBy = this.CreatedBy;
            _tmp.CreatedDate = this.CreatedDate;
            _tmp.ModifiedBy = this.ModifiedBy;
            _tmp.ModifiedDate = this.ModifiedDate;
            return _tmp;
        }

    }

    public class TaxCalculation
    {
        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public decimal? TaxRat { get; set; }
        public decimal? TaxAmount { get; set; }
    }
}
