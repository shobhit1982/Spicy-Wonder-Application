using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Configuration;
using RAHMSLibrary.Entity.Masters;
using RAHMSLibrary.Entity;



class ClsDBFunctions :EntityBase, IDisposable
{

    SqlConnection sqlConn = null;
    
    SqlCommand sqlCmd = new SqlCommand();

    //private string connectionName = "";
    //static string connectionName = "MyApp";
    public string connectionName { get; set; }


    #region "Public Functions"

    static ClsDBFunctions sInstance;
    static ClsDBFunctions RahmsInstance;
    public ClsDBFunctions(string _connectionName )
    {
        connectionName = _connectionName;
    }

    string connStr = "";


    // '' <summary>
    // '' This function is used to get Instance of this class
    // '' </summary>
    // '' <returns>Instance of this class</returns>
    // '' <remarks></remarks>
    // '' 
    //public static ClsDBFunctions GetInstance()
    //{

    //   // connectionName = "MyApp";
    //    sInstance = new ClsDBFunctions("MyApp");

    //    return sInstance;
    //}

    public static ClsDBFunctions RAHMS()
    {

       // connectionName = "RAHMS";
        RahmsInstance = new ClsDBFunctions("RAHMS");

        return RahmsInstance;
    }
    #endregion

    #region "Private Functions"

    public string GetConnectionString(string connectionName)
    {
        // If connStr Is Nothing Or connStr.Trim = "" Then
        connStr = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        // End If
        return connStr;
    }

    private SqlConnection GetSQLConnection(string connectionName)
    {
       
        sqlConn = new SqlConnection(GetConnectionString(connectionName));
        return sqlConn;
    }

    public static SqlConnection GetSQLConnection()
    {
        ClsDBFunctions clsDBFunctions = ClsDBFunctions.RAHMS();
        return clsDBFunctions.GetSQLConnection(clsDBFunctions.connectionName);
    }

    #endregion

    #region "Query Functions"

    public DataSet ExecuteQuery_DataSet(string sql, string calledBy)
    {
        DataSet dataSet = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        using (SqlConnection conn = new SqlConnection(GetConnectionString(connectionName)))
        {
            adapter.SelectCommand = new SqlCommand(sql, conn);
            adapter.Fill(dataSet);
            adapter.Dispose();
            conn.Close();
            return dataSet;
        }
    }

    //public DataSet ExecuteQuery_DataSet(string sql,string calledBy)
    //{
    //    return ExecuteQueryDataSet(sql, "myApp");
    //}

    public int ExecuteNonQuery(string sql, string calledBy)
    {
        int retVal = 0;
        using (SqlConnection conn = new SqlConnection(GetConnectionString(connectionName)))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Connection.Open();
            retVal = cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd.Connection.Close();
            conn.Close();
            return retVal;
        }
    }
    public void ExecuteNonQuery(string sql)
    {
       
        using (SqlConnection conn = new SqlConnection(GetConnectionString(connectionName)))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd.Connection.Close();
            conn.Close();
            
        }
    }
    public void CloseConnections()
    {
       // sqlConn.Close();
       // sqlCmd.Connection.Close();
       // SqlConnection.ClearAllPools();
    }

    public IDataReader ExecuteReader(string sql, string calledBy)
    {

        SqlConnection conn = GetSQLConnection(connectionName);
        
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Connection.Open();
            return cmd.ExecuteReader();
        
    }


    public IDataReader ExecuteReader(string sql, string calledBy, SqlConnection conn)
    {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Connection.Open();
            return cmd.ExecuteReader();   
    }


   // public void CloseConnections
    
    private SqlCommand OpenConnection(SqlCommand sqlCmd)
    {
        if (sqlCmd.Connection.State == ConnectionState.Open)
        {
            sqlCmd.Connection.Close();
            sqlCmd.Connection.Open();
            return sqlCmd;
        }
        sqlCmd.Connection.Open();
        return sqlCmd;
    }
    //public int ExecuteQuery_NonQuery(string sql, string calledBy)
    //{
    //    return ExecuteNonQuery(sql, "myApp");
    //}

    public object ExecuteScalar(string sql, string calledBy)
    {
        object retVal = 0;
        using (SqlConnection conn = new SqlConnection(GetConnectionString(connectionName)))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Connection.Open();
            retVal = cmd.ExecuteScalar();

            cmd.Dispose();
            cmd.Connection.Close();
            conn.Close();
            return retVal;
        }
    }

    //public object ExecuteQuery_Scalar(string sql, string calledBy)
    //{
    //             return ExecuteScalar(sql, "myApp");
    //}

    public DataSet ExecuteServer_DataSet(string sql, string calledBy)
    {
        return ExecuteQuery_DataSet(sql, "MYServer");
    }
    public IDataReader ExecuteReader_SP(string sql, SqlParameter[] parameter, string calledBy)
    {
        SqlConnection conn = GetSQLConnection(connectionName);
        SqlCommand cmd = new SqlCommand(sql, conn);    
       
        foreach (SqlParameter param in parameter)
        {
            cmd.Parameters.Add(param);
        }

        //sqlCmd = new SqlCommand(sql, sqlConn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Connection.Open();
        //sqlCmd.Connection = sqlConn;
        return cmd.ExecuteReader();
    }
    public DataSet ExecuteQueryDataSet_parameter(string sql, SqlParameter[] sp, string calledBy)
    {
        DataSet dataSet = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        sqlConn = GetSQLConnection("MyApp");
        foreach (SqlParameter param in sp)
        {
            sqlCmd.Parameters.Add(param);
        }

        //sqlCmd = new SqlCommand(sql, sqlConn);
        sqlCmd.CommandType = CommandType.StoredProcedure;

        if ((sqlConn.State != ConnectionState.Open))
        {
            sqlConn.Open();
        }
        //sqlCmd.Connection = sqlConn;
        adapter.SelectCommand = new SqlCommand(sql, GetSQLConnection("MyApp"));

        adapter.Fill(dataSet);
        sqlCmd.Dispose();
        sqlConn.Close();
        return dataSet;
    }

    #endregion

    #region "Execute SP Functions"

    // '' <summary>
    // '' This Function is to excute the Scalar Stored Procedure 
    // '' </summary>
    // '' <param name="SP_Name">Name of the Stored Procedure</param>
    // '' <param name="sp">Sql Parameters</param>
    // '' <param name="calledBy">Used for log purpose</param>
    // '' <remarks></remarks>
    public object ExecuteScalarQuery_SP(string SP_Name, SqlParameter[] sp, string calledBy)
    {
        object ret = 0;
        sqlConn = GetSQLConnection("MyApp");
        sqlCmd = new SqlCommand(SP_Name, sqlConn);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter param in sp)
        {
            sqlCmd.Parameters.Add(param);
        }
        if ((sqlConn.State != ConnectionState.Open))
        {
            sqlConn.Open();
        }
        sqlCmd.Connection = sqlConn;
        try
        {
            ret = sqlCmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlCmd.Dispose();
            sqlConn.Close();
        }
        return ret;
    }

    // '' <summary>
    // '' This Function is to excute the NonQuery Stored Procedure 
    // '' </summary>
    // '' <param name="SP_Name">Name of the Stored Procedure</param>
    // '' <param name="sp">Sql Parameters</param>
    // '' <param name="calledBy">Used for log purpose</param>
    // '' <remarks></remarks>
    public int ExecuteNonQuery_SP(string SP_Name, SqlParameter[] sp, string calledBy)
    {
        int ret = 0;
        sqlConn = GetSQLConnection("MyApp");
        sqlCmd = new SqlCommand(SP_Name, sqlConn);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter param in sp)
        {
            sqlCmd.Parameters.Add(param);
        }
        if ((sqlConn.State != ConnectionState.Open))
        {
            sqlConn.Open();
        }
        sqlCmd.Connection = sqlConn;
        try
        {
            ret = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ModCommonFunctions.Getinstance().AddToLog(ex);
        }
        finally
        {
            sqlCmd.Dispose();
            sqlConn.Close();
        }
        return ret;
    }

    // '' <summary>
    // '' This Function is Used For Execute the Stored Procedure Dataset Function  
    // '' </summary>
    // '' <param name="SP_Name">Name Of the Stored Procedure </param>
    // '' <param name="sp">Sql Parameters </param>
    // '' <param name="Tbl_Name">Name of the Table </param>
    // '' <param name="calledBy">Used For Log Purpose</param>
    // '' <remarks></remarks>
    public DataSet ExecuteQuery_DataSet_SP(string SP_Name, SqlParameter[] sp, string Tbl_Name, string calledBy)
    {
        sqlCmd = new SqlCommand(SP_Name, GetSQLConnection("MyApp"));
        // sqlCmd = New SqlCommand(SP_Name, sqlConn)
        sqlCmd.CommandTimeout = 120;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter();
        foreach (SqlParameter param in sp)
        {
            sqlCmd.Parameters.Add(param);
        }
        DataSet ds = new DataSet();
        da.SelectCommand = sqlCmd;
        if ((sqlConn.State != ConnectionState.Open))
        {
            sqlConn.Open();
        }
        try
        {
            da.Fill(ds, Tbl_Name);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlCmd.Connection.Close();
            sqlCmd.Dispose();
        }
        return ds;
    }




    #endregion



    public void Dispose()
    {
        sInstance = null;
        RahmsInstance = null;
    }

   
}


public class ConnSingleton
{
    private static ConnSingleton dbInstance;
    private readonly SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1;database=soa;User id=sa1;Password=sa1;");

    private ConnSingleton()
    {
    }

    public static ConnSingleton getDbInstance()
    {
        if (dbInstance == null)
        {
            dbInstance = new ConnSingleton();
        }
        return dbInstance;
    }

    public SqlConnection GetDBConnection()
    {
        try
        {
            conn.Open();
            Console.WriteLine("Connected");
        }
        catch (SqlException e)
        {
            Console.WriteLine("Not connected : " + e.ToString());
            Console.ReadLine();
        }
        finally
        {
            Console.WriteLine("End..");
            // Console.WriteLine("Not connected : " + e.ToString());
            Console.ReadLine();
        }
        Console.ReadLine();
        return conn;
    }

}


