using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class MstOrderType : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public string OrderType { get; set; }
        public int IsDefault { get; set; }

        public static IList<MstOrderType> GetAll()
        {
            try
            {


                //Create Collection
                IList<MstOrderType> list = new List<MstOrderType>();
                list.Clear();
                using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
                {
                    using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MstOrderType.GetAll, "RAHMS", conn))
                    {
                        list = Fill(new MstOrderType(), reader).Cast<MstOrderType>().ToList();

                        //reader.Close();

                    }
                }
                //ClsDBFunctions.RAHMS().CloseConnections();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static MstOrderType GetById(int id)
        {
            //Create Collection
            IList<MstOrderType> list = new List<MstOrderType>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MstOrderType.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new MstOrderType(), reader).Cast<MstOrderType>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static MstOrderType GetByName(string name)
        {
            //Create Collection
            IList<MstOrderType> list = new List<MstOrderType>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MstOrderType.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new MstOrderType(), reader).Cast<MstOrderType>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(MstOrderType entity)
        {
            string query = "INSERT into OrderType (OrderType,IsDefault) Values('" + entity.OrderType + "'," + entity.IsDefault + ")";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "delete from OrderType where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(MstOrderType entity)
        {
            string query = "update OrderType set OrderType='" + entity.OrderType + "',IsDefault=" + entity.IsDefault + " where Id=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            MstOrderType _tmp = new MstOrderType();

            _tmp.ID = this.ID;
            _tmp.OrderType = this.OrderType;
            _tmp.IsDefault = this.IsDefault;           
            return _tmp;
        }
    }
}
