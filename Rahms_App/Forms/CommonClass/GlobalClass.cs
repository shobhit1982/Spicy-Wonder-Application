using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace RAHMS.Forms
{
    class GlobalClass
    {

        //internal static String CnnStr = @"Data source =ACHMAN-PC\SQLEXPRESS;Initial Catalog =SpicySpoon; User Id = sa; Password = rt123456";
        //internal static String CnnStr = @"Data source =VAIO;Initial Catalog =SpicySpoon; User Id = sa; Password =saiisys";

        internal static String CnnStr = System.Configuration.ConfigurationManager.ConnectionStrings["RAHMS"].ConnectionString;

        internal static SqlConnection Cnn = new SqlConnection(CnnStr);
        public static long UserTypeId { get; set; }
        public static String username = "", GAccGroupIDSupplier = "1"
            , userNameid = ""
            , GAccGroupIDCustomer = "2"
            , GTabacco_Item_id = "1", GCompound_Item_id = "2", GFinYear = ""
            , GPrintMat_Item_id = "3", GLineTube_Item_id = "4";
        internal static long GSearchId = 0;
        public static void OpenConnection()
        {
            if (GlobalClass.Cnn.State == ConnectionState.Closed)
            {
                GlobalClass.Cnn.Open();
            }
        }

        internal static void CloseConnection()
        {
            if (GlobalClass.Cnn.State == ConnectionState.Open)
            {
                GlobalClass.Cnn.Close();
            }
        }
        internal static DataSet executeQuery(String sql, String tblName)
        {
            OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, Cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, tblName);
            return ds;
        }

        internal static Boolean executeUpdate(String sql)
        {
            OpenConnection();
            SqlCommand cm = new SqlCommand(sql, Cnn);
            cm.ExecuteNonQuery();
            return true;
        }
        internal static long IntGenCode(string Tbl, string Fld)
        {
            long NewID = 1;
            DataSet ds = new DataSet();
            //String sql = "SELECT iif(isnull(MAX(" + Fld + ")),0,MAX(" + Fld + ")) AS MID FROM " + Tbl + "";
            String sql = "SELECT isnull(MAX(" + Fld + "),0) AS MID FROM " + Tbl + "";
            ds = executeQuery(sql, "0");
            if (ds.Tables["0"].Rows.Count > 0)
            {
                NewID = long.Parse(ds.Tables["0"].Rows[0]["MID"].ToString()) + 1;
            }
            return NewID;
        }

        internal static string CharGenCode(string Tbl, string Fld, string Prefix, string dtpicker)
        {
            int LastNo = 1;
            String retCode = "";
            String sql = "select MAX(CONVERT(numeric(18, 0), SUBSTRING(" + Fld + ", " + (Prefix.Length + 1) + ", LEN(" + Fld + ")))) as cnt from " + Tbl.Trim() +
                " where  sale_Date='" + dtpicker + "'";
            try
            {
                DataSet ds = GlobalClass.executeQuery(sql, "0");
                if (ds.Tables["0"].Rows.Count > 0)
                {
                    if (ds.Tables["0"].Rows[0][0].ToString() == "")
                        LastNo = 0;
                    else
                        LastNo = Int32.Parse(ds.Tables["0"].Rows[0][0].ToString());

                    LastNo++;
                    retCode = Prefix + "" + LastNo;
                }
                else
                {
                    retCode = Prefix + "" + LastNo;
                }
            }
            catch (Exception e)
            {
                retCode = "";
            }
            return retCode;
        }
        #region Queries for report
        internal static DataSet GetDataForPrintInvoice(string BillNimber)
        {
            OpenConnection();
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand("GetDataForPrintInvoice", Cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BillNumber", SqlDbType.VarChar).Value = BillNimber;
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            return ds;
        }
        internal static DataSet GetDataForSaleReport(string fromDate,string toDate)
        {
            OpenConnection();
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand("GetDataForSalesReport", Cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = toDate;
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            return ds;
        }

        internal static DataSet GetCompanyInfo()
        {
            OpenConnection();
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand("Select * from CompanyInfo", Cnn))
            {
                cmd.CommandType = CommandType.Text;
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            return ds;
        }
        #endregion
    }
}
