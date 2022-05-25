using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class Clients : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string MachineName { get; set; }
        public string StartDate { get; set; }
        public string ValidUpTo { get; set; }
        public string ActivationKey { get; set; }
        public bool IsActive { get; set; }

        public static IList<Clients> GetAll()
        {
            //Create Collection
            IList<Clients> list = new List<Clients>();

            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Clients.GetAll, "Text", conn))
                {
                    list = Fill(new Clients(), reader).Cast<Clients>().ToList();
                }
            }

            return list;
        }


        public static int Insert(Clients entity)
        {
            string query = "INSERT into Clients (Name,MachineName,StartDate,ValidUpTo,ActivationKey,IsActive) Values('" + entity.Name + "','" + entity.MachineName + "','" + entity.StartDate + "','" + entity.ValidUpTo + "','" + entity.ActivationKey + "'," + entity.IsActive + ")";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
      
        public object Clone()
        {
            Clients _tmp = new Clients();

            _tmp.ID = this.ID;
            _tmp.Name = this.Name;
            _tmp.ActivationKey = this.ActivationKey;
            _tmp.StartDate = this.StartDate;
            _tmp.ValidUpTo = this.ValidUpTo;
            _tmp.IsActive = this.IsActive;
            _tmp.MachineName = this.MachineName;        
            return _tmp;
        }
    }
}
