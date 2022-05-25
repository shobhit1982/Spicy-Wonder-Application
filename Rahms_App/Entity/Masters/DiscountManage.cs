using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class DiscountManage : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }

        public static IList<DiscountManage> GetAll()
        {
            //Create Collection
            IList<DiscountManage> list = new List<DiscountManage>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Discount.GetAll, "RAHMS", conn))
                {
                    list = Fill(new DiscountManage(), reader).Cast<DiscountManage>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();
            return list;
        }
        public static DiscountManage GetById(int id)
        {
            //Create Collection
            IList<DiscountManage> list = new List<DiscountManage>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Discount.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new DiscountManage(), reader).Cast<DiscountManage>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static DiscountManage GetByName(int discount)
        {
            //Create Collection
            IList<DiscountManage> list = new List<DiscountManage>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Discount.GetByDiscount + "" + discount + "", "RAHMS", conn))
                {
                    list = Fill(new DiscountManage(), reader).Cast<DiscountManage>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(DiscountManage entity)
        {
            string query = "INSERT into Discount (Discount,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values(" + entity.Discount + ",'" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "update Discount set isvalid=0 where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(DiscountManage entity)
        {
            string query = "update Discount set Discount=" + entity.Discount + ",Description='" + entity.Description + "',Modifieddate='" + entity.ModifiedDate + "' where Id=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            DiscountManage _tmp = new DiscountManage();

            _tmp.ID = this.ID;
            _tmp.Discount = this.Discount;
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
