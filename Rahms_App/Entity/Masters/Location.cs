using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RAHMSLibrary.Entity.Masters
{
    [Serializable]
    public class SeatingLocation : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public int? Seats { get; set; }

        public static IList<SeatingLocation> GetAll()
        {
            //Create Collection
            IList<SeatingLocation> locationList = new List<SeatingLocation>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Location.GetAll, "RAHMS", conn))
                {
                    locationList = Fill(new SeatingLocation(), reader).Cast<SeatingLocation>().ToList();
                }
            }

            return locationList;
        }
        public static SeatingLocation GetById(int id)
        {
            //Create Collection
            IList<SeatingLocation> locationList = new List<SeatingLocation>();

            using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Location.GetById + id, "RAHMS"))
            {
                locationList = Fill(new SeatingLocation(), reader).Cast<SeatingLocation>().ToList();
            }

            if (locationList != null && locationList.Count > 0)
                return locationList[0];
            return null;
        }
        public static SeatingLocation GetByName(string name)
        {
            //Create Collection
            IList<SeatingLocation> locationList = new List<SeatingLocation>();

            using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Location.GetByName + "'" + name + "'", "RAHMS"))
            {
                locationList = Fill(new SeatingLocation(), reader).Cast<SeatingLocation>().ToList();
            }
            if (locationList != null && locationList.Count > 0)
                return locationList[0];
            return null;
        }

        public static int Insert(SeatingLocation entity)
        {
            string query = "INSERT into Location (Name, Seats,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) OUTPUT INSERTED.ID Values('" + entity.Name + "'," + entity.Seats + ",'" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "update Location set isvalid=0 where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(SeatingLocation entity)
        {
            string query = "update Location set Name='" + entity.Name + "',Seats=" + entity.Seats + ",Modifieddate='" + entity.ModifiedDate + "' where Id=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            SeatingLocation _tmp = new SeatingLocation();

            _tmp.ID = this.ID;
            _tmp.Name = this.Name;
            _tmp.Seats = this.Seats;
            _tmp.Remarks = this.Remarks;
            _tmp.CreatedBy = this.CreatedBy;
            _tmp.CreatedDate = this.CreatedDate;
            _tmp.ModifiedBy = this.ModifiedBy;
            _tmp.ModifiedDate = this.ModifiedDate;
            return _tmp;
        }
    }
}
