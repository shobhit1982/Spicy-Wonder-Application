using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class Unit : EntityBase, ICloneable
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static IList<Unit> GetAll()
        {
            try
            {


                //Create Collection
                IList<Unit> list = new List<Unit>();
                list.Clear();
                using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
                {
                    using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Unit.GetAll, "RAHMS", conn))
                    {
                        list = Fill(new Unit(), reader).Cast<Unit>().ToList();

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
        public static Unit GetById(int id)
        {
            //Create Collection
            IList<Unit> list = new List<Unit>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Unit.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new Unit(), reader).Cast<Unit>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static Unit GetByName(string name)
        {
            //Create Collection
            IList<Unit> list = new List<Unit>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.Unit.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new Unit(), reader).Cast<Unit>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static int Insert(Unit entity)
        {
            string query = "INSERT into Unit (Name,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values('" + entity.Name + "','" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int DeleteById(int Id)
        {
            string query = "update Unit set isvalid=1 where Id=" + Id;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public static int Update(Unit entity)
        {
            string query = "update Unit set Name='" + entity.Name + "',Description='" + entity.Description + "',Modifieddate='" + entity.ModifiedDate + "' where Id=" + entity.ID;

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            Unit _tmp = new Unit();

            _tmp.ID = this.ID;
            _tmp.Name = this.Name;
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
