using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Globalization;
using System.Threading;

namespace RAHMSLibrary.Entity
{
    [Serializable]
    public abstract class EntityBase
    {
       public enum SalesMasterStatus
        { 
            Created =1,
            Running=2,
            Hold = 3,
            Printed=4,
            Cancelled=5,
            Deleted=6
             
        }
        public EntityBase()
        {


             CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            //CultureInfo newCulture = new CultureInfo("en-US");
            newCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
           // newCulture.DateTimeFormat.LongTimePattern = "HH:mm";
            newCulture.DateTimeFormat.PMDesignator = "";
            newCulture.DateTimeFormat.AMDesignator = "";
            newCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = newCulture;

            this.CreatedDate = DateTime.Now ;// Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            this.ModifiedDate = DateTime.Now;
            this.IsValid = 1;
            this.Remarks = "";
             
        }

      
        /// <summary>
        /// ISVALID : 
        /// </summary>
        private int _isvalid;
        public int IsValid { get { return _isvalid; } set { _isvalid = value; } }
        /// <summary>
        /// REMARKS : 
        /// </summary>
        private string _remarks;
        public string Remarks { get { return _remarks; } set { _remarks = value; } }
        /// <summary>
        /// CREATEDBY : 
        /// </summary>
        private long? _createdby;
        public long? CreatedBy { get { return _createdby; } set { _createdby = value; } }
        /// <summary>
        /// CREATEDDATE : 
        /// </summary>
        private DateTime _createddate ;
        public DateTime CreatedDate { get { return _createddate; } set { _createddate = value; } }
        /// <summary>
        /// MODIFIEDBY : 
        /// </summary>

        private long? _modifiedby;
        public long? ModifiedBy { get { return _modifiedby; } set { _modifiedby = value; } }
        /// <summary>
        /// MODIFIEDDATE : 
        /// </summary>
        private DateTime? _modifieddate;
        public DateTime? ModifiedDate { get { return _modifieddate; } set { _modifieddate = value; } }
        /// <summary>
        /// To get set extra column 1
        /// </summary>
      //  public string Ext1 { get; set; }
        /// <summary>
        /// To get set extra column 1
        /// </summary>
     //   public string Ext2 { get; set; }
        /// <summary>
        /// To get set extra column 1
        /// </summary>
    //    public string Ext3 { get; set; }
        
        public static IList<EntityBase> Fill(EntityBase entity, IDataReader reader, int start, int pageLength, out int count)
        {
            count = -1;
            IList<EntityBase> entityList = new List<EntityBase>();
            for (int i = 0; i < start; i++)
            {
                if (!reader.Read())
                    return entityList;
            }
            for (int i = 0; i < pageLength; i++)
            {
                if (!reader.Read())
                    break;
                count++;
                entity = (EntityBase)Activator.CreateInstance(entity.GetType());
                entity = SetEntityValue(entity, reader);
                entityList.Add(entity);
            }

            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    count = (int)reader.GetDecimal(0);
                }
            }

            return entityList;
        }

        public static IList<EntityBase> Fill(EntityBase entity, IDataReader reader)
        {

            IList<EntityBase> entityList = new List<EntityBase>();            
            while (reader.Read())
            {
                entity = (EntityBase)Activator.CreateInstance(entity.GetType());
                entity = SetEntityValue(entity, reader);
                entityList.Add(entity);                
            }           
            return entityList;
        }

        protected static EntityBase SetEntityValue(EntityBase entity, string propertyName, object obj)
        {
            PropertyInfo prop = entity.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                switch (prop.PropertyType.ToString())
                {
                    case "System.Int16":
                        prop.SetValue(entity, Convert.ToInt16(obj), null);
                        break;
                    case "System.Int32":
                        prop.SetValue(entity, Convert.ToInt32(obj), null);
                        break;
                    case "System.Int64":
                        prop.SetValue(entity, Convert.ToInt64(obj), null);
                        break;
                    case "System.Boolean":
                        prop.SetValue(entity, Convert.ToBoolean(obj), null);
                        break;
                    case "System.String":
                        prop.SetValue(entity, obj.ToString(), null);
                        break;
                    case "System.DateTime":
                        prop.SetValue(entity, Convert.ToDateTime(obj), null);
                        break;

                }
            }
            return entity;
        }

        protected static EntityBase SetEntityValue(EntityBase entity, IDataReader reader)
        {
            //if (!reader.Read())
            //    return entity;

            for (int ordinal = 0; ordinal < reader.FieldCount; ordinal++)
            {

                if (reader.IsDBNull(ordinal))
                    continue;
                else
                {
                    string propertyName = reader.GetName(ordinal);
                    PropertyInfo[] props = entity.GetType().GetProperties();
                    foreach (PropertyInfo prop in props)
                    {
                        if (prop.Name.ToUpper().Trim() == propertyName.ToUpper().Trim())
                        {
                            switch (prop.PropertyType.ToString())
                            {
                                case "System.Int16":
                                    prop.SetValue(entity, Convert.ToInt16(reader[ordinal]), null);
                                    break;
                                case "System.Int32":
                                    prop.SetValue(entity, Convert.ToInt32(reader[ordinal]), null);
                                    break;
                                case "System.Int64":
                                    prop.SetValue(entity, Convert.ToInt64(reader[ordinal]), null);
                                    break;
                                case "System.Boolean":
                                    prop.SetValue(entity, Convert.ToBoolean(reader[ordinal]), null);
                                    break;
                                case "System.String":
                                    prop.SetValue(entity, reader[ordinal].ToString(), null);
                                    break;
                                case "System.Single":
                                    prop.SetValue(entity,Convert.ToSingle(reader[ordinal]), null);
                                    break;
                                case "System.DateTime":
                                   prop.SetValue(entity,Convert.ToDateTime(reader[ordinal]), null);
                                   
                                    break;
                                case "System.Nullable`1[System.Int64]":
                                    if (!reader.IsDBNull(ordinal)) prop.SetValue(entity, Convert.ToInt64(reader[ordinal]), null);
                                    break;
                                case "System.Nullable`1[System.Int32]":
                                    prop.SetValue(entity, Convert.ToInt32(reader[ordinal]), null);
                                    break;
                                case "System.Nullable`1[System.DateTime]":
                                    prop.SetValue(entity, Convert.ToDateTime(reader[ordinal]), null);
                                    break;
                                case "System.Nullable`1[System.Decimal]":
                                    prop.SetValue(entity, Convert.ToDecimal(reader[ordinal]), null);
                                    break;  
                                    

                            }
                            break;
                        }
                    }
                }
            }
            return entity;
        }

        
     
    }
}
