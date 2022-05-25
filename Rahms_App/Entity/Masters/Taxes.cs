using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RAHMSLibrary.Entity.Masters
{
    public class Taxes : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public decimal ? Rate { get; set; }
        public string Description { get; set; }

        public static IList<Taxes> GetAll()
        {
            //Create Collection
            IList<Taxes> list = new List<Taxes>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Taxes.GetAll, "RAHMS", conn))
                {
                    list = Fill(new Taxes(), reader).Cast<Taxes>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();
            return list;
        }
        public static Taxes GetById(int id)
        {
            //Create Collection
            IList<Taxes> list = new List<Taxes>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Taxes.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new Taxes(), reader).Cast<Taxes>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static Taxes GetByName(string name)
        {
            //Create Collection
            IList<Taxes> list = new List<Taxes>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Taxes.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new Taxes(), reader).Cast<Taxes>().ToList();
                }
            }
            //ClsDBFunctions.RAHMS().CloseConnections();
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(Taxes entity)
        {
            string query = "INSERT into Taxes (Name,Rate,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values('" + entity.Name + "'," + entity.Rate + ",'" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "update Taxes set isvalid=0 where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(Taxes entity)
        {
            string query = "update Taxes set Name='" + entity.Name + "',Rate=" + entity.Rate + ",Description='" + entity.Description + "',Modifieddate='" + entity.ModifiedDate + "' where Id=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }

        public object Clone()
        {
            Taxes _tmp = new Taxes();

            _tmp.ID = this.ID;
            _tmp.Name = this.Name;
            _tmp.Rate = this.Rate;
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
