using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RAHMSLibrary.Entity.Masters
{
    public class MenuAndSubMenu : EntityBase, ICloneable
    {
        public long? ID { get; set; }
        public long? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public static IList<MenuAndSubMenu> GetAll()
        {
            //Create Collection
            IList<MenuAndSubMenu> list = new List<MenuAndSubMenu>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MenuAndSubMenu.GetAll, "RAHMS", conn))
                {
                    list = Fill(new MenuAndSubMenu(), reader).Cast<MenuAndSubMenu>().ToList();
                }
            }

            return list;
        }
        public static IList<MenuAndSubMenu> GetAllParentMenu()
        {
            //Create Collection
            IList<MenuAndSubMenu> list = new List<MenuAndSubMenu>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MenuAndSubMenu.GetAllParentMenu, "RAHMS", conn))
                {
                    list = Fill(new MenuAndSubMenu(), reader).Cast<MenuAndSubMenu>().ToList();
                }
            }

            return list;
        }
        public static IList<MenuAndSubMenu> GetByParentId(int parentId)
        {
            //Create Collection
            IList<MenuAndSubMenu> list = new List<MenuAndSubMenu>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MenuAndSubMenu.GetByParentId + parentId, "RAHMS", conn))
                {
                    list = Fill(new MenuAndSubMenu(), reader).Cast<MenuAndSubMenu>().ToList();
                }
            }

            return list;
        }
        public static MenuAndSubMenu GetById(int id)
        {
            //Create Collection
            IList<MenuAndSubMenu> list = new List<MenuAndSubMenu>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MenuAndSubMenu.GetById + id, "RAHMS", conn))
                {
                    list = Fill(new MenuAndSubMenu(), reader).Cast<MenuAndSubMenu>().ToList();
                }
            }

            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static MenuAndSubMenu GetByName(string name)
        {
            //Create Collection
            IList<MenuAndSubMenu> list = new List<MenuAndSubMenu>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MenuAndSubMenu.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new MenuAndSubMenu(), reader).Cast<MenuAndSubMenu>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static IList<MenuAndSubMenu> GetByRemarks(string name)
        {
            //Create Collection
            IList<MenuAndSubMenu> list = new List<MenuAndSubMenu>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MenuAndSubMenu.GetByName + "'" + name + "'", "RAHMS", conn))
                {
                    list = Fill(new MenuAndSubMenu(), reader).Cast<MenuAndSubMenu>().ToList();
                }
            }
            return list;
        }
        
        public static MenuAndSubMenu GetByDescription(string description)
        {
            //Create Collection
            IList<MenuAndSubMenu> list = new List<MenuAndSubMenu>();
            using (SqlConnection conn = ClsDBFunctions.GetSQLConnection())
            {
                using (IDataReader reader = ClsDBFunctions.RAHMS().ExecuteReader(Query.MenuAndSubMenu.GetByDescription + "'" + description + "'", "RAHMS", conn))
                {
                    list = Fill(new MenuAndSubMenu(), reader).Cast<MenuAndSubMenu>().ToList();
                }
            }
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
        public static int Insert(MenuAndSubMenu entity)
        {
            string query = "INSERT into MenuAndSubMenu (ParentId,Name,Description,Remarks,IsValid,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) Values(" + entity.ParentId + ",'" + entity.Name + "','" + entity.Description + "','" + entity.Remarks + "'," + entity.IsValid + "," + entity.CreatedBy + ",'" + entity.CreatedDate + "'," + entity.ModifiedBy + ",'" + entity.ModifiedDate + "')";

            var ret = ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "RAHMS");
            return ret;

        }
        public object Clone()
        {
            MenuAndSubMenu _tmp = new MenuAndSubMenu();

            _tmp.ID = this.ID;
              _tmp.ParentId = this.ParentId;
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
