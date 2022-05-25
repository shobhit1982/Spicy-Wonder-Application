using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RAHMS.Forms.Report
{
    public partial class UserWiseSaleReport : Form
    {
        public UserWiseSaleReport()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime DtFrom = dtpFrom.Value;
            DateTime DtTo = dtpTo.Value;
            string DtFrom1 = DtFrom.ToString("dd/MM/yyyy");
            string DtTo1 = DtTo.ToString("dd/MM/yyyy");
            string UserId = comboBox1.Text;
            Report.UserWiseSalesReport rpt = new Report.UserWiseSalesReport();
            frmReportViewer frm = new frmReportViewer();
            try
            {
                string sql = "select '" + DtFrom1 + "' FromDate,'" + DtTo1 + "' ToDate, sm.BillNumber,sm.Amount,sm.Taxes,TotalAmount,RoundAmount,Difference,sm.CreatedBy,u.Name,CONVERT(VARCHAR(10),sm.CreatedDate,103) CreatedDate,sm.PaymentMode , sm.Discount from SalesMaster sm inner join UserTable u on u.Id=sm.CreatedBy where u.LoginId='" + UserId + "' and sm.Status=4 and sm.CreatedDate between convert(datetime,'" + DtFrom1 + "',103) and CONVERT(datetime,'" + DtTo1 + "',103)+1";
                DataSet ds = GlobalClass.executeQuery(sql, "data");
                DataSet dsComapny = GlobalClass.GetCompanyInfo();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rpt.SetDataSource(ds.Tables[0]);
                    rpt.Database.Tables["CompanyInfo"].SetDataSource(dsComapny.Tables[0]);
                    frm.crystalReportViewer1.ReportSource = rpt;
                    frm.ShowDialog();
                    //rpt.Close ();
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UserWiseSaleReport_Load(object sender, EventArgs e)
        {
            LoadUser();
        }
        private void LoadUser()
        {
            string sql = "select * from UserTable where isvalid=1";
            DataSet ds = GlobalClass.executeQuery(sql, "cust");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                comboBox1.DataSource = ds.Tables["cust"];
                comboBox1.DisplayMember = "LoginId";
            }
            else
            {
                MessageBox.Show("User Not Found");
            }
        }
    }
}
