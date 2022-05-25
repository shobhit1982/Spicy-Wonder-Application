using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;


class Cls_Login
{
    #region Property
    private string sUserTypes = "";
    private int sID = ModConstants.cInvalidId;
    private string sUserName = "";
    private string sPassword = "";
    private int sval = 0;

    public string  UserTypes
    {
        get { return sUserTypes; }
        set { sUserTypes = value; }
    }


    public int ID
    {
        get { return sID; }
        set { sID = value; }
    }
    public string UserName
    {
        get { return sUserName; }
        set { sUserName = value; }
    }

    public string Password
    {
        get { return sPassword; }
        set { sPassword = value; }
    }
    public int val
    {
        get { return sval; }
        set { sval = value; }
    }

    #endregion
    #region Static Variable

    static Cls_Login sInstance;
    public IDictionary<string, string> StoredProcedureList = new Dictionary<string, string>();

    public void StoredProcedures()
    {
        StoredProcedureList = new Dictionary<string, string>();
        StoredProcedureList.Add(ModConstants.cSelect, "dbo.Sp_Login_Select");
        StoredProcedureList.Add(ModConstants.cUpdate, "dbo.sp_Login_update");
    }


    #endregion
    #region "Public Functions"

    public Cls_Login()
    {
        StoredProcedures();
    }

    public static Cls_Login Getinstance()
    {
        if (sInstance == null)
        {
            sInstance = new Cls_Login();
        }
        return sInstance;
    }

    public DataSet  GetAll(string calledby)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ClsDBFunctions.RAHMS().ExecuteQuery_DataSet(StoredProcedureList[ModConstants.cSelect], this.UserName.ToString());

            
        }
        catch (Exception ex)
        {
            ModCommonFunctions.Getinstance().AddToLog(ex); 
            
        }
        return ds;
    }

    #endregion


 //public List<Cls_Login> GetAlls(string calledby)
 //   {
 //       List<Cls_Login> lCategoryMaster = new List<Cls_Login>();
 //       DataSet ds = new DataSet();

 //       ds = ClsDBFunctions.RAHMS().ExecuteQuery_DataSet(StoredProcedureList[ModConstants.cSelect],this.UserTypes);
 //       if (ds != null)
 //       {
 //           List<object> lObj = new List<Object>();
 //           Cls_Login obj = new Cls_Login();
 //           lObj = ModCommonFunctions.Getinstance().ConvertDsToList(obj, ds);
 //           if (lObj != null)
 //           {
 //               foreach (Cls_Login ob in lObj)
 //               {
 //                   lCategoryMaster.Add(ob);
 //               }
 //           }
 //       }
 //       return lCategoryMaster;
 //   }
    
}

