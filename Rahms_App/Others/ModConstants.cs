using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

    class ModConstants
    {
     static ModConstants sInstance;

     #region "Public Functions"

        public ModConstants() 
        {
            //StoredProcedures();
        }

        public static ModConstants GetInstance()
        {
            if (sInstance == null)
            {
                sInstance = new ModConstants();
            }
            return sInstance;
        }

        #endregion

     #region "General Constants"

        public const string cSelect = "Select";
        public const string cInsert = "Insert";
        public const string cUpdate = "Update";
        public const string cDelete = "Delete";
        public const string cDeleteZero = "DeleteZero";
        public const string cSelectByCode = "SelectByCode";
        public const string cSelectByTICode = "SelectByTICode";
        public const int cInvalidId = -1;

        #endregion 

     #region "Table Constants"
        public const string cId = "Id";
        public const string cCode = "Code";
        public const string cName = "Name";
        public const string cPrint = "Print";
        public const string cLogIn = "LogIn";
        public const string cLogDate = "LogDate";


      
        

        #endregion

    }

