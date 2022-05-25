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
    public partial class CardPaymentReport : Form
    {
        public CardPaymentReport()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime DtFrom = dtpFrom.Value;
            DateTime DtTo = dtpTo.Value;
            string DtFrom1 = DtFrom.ToString("dd/MM/yyyy");
            string DtTo1 = DtTo.ToString("dd/MM/yyyy");
            Report.CardPayment rpt = new Report.CardPayment();
            frmReportViewer frm = new frmReportViewer();
            try
            {
                string sql = "select sm.BillNumber,sm.Amount,sm.Taxes,TotalAmount,RoundAmount,Difference,CONVERT(VARCHAR(10),sm.CreatedDate,103) CreatedDate ,sm.Discount from SalesMaster sm where Status=4 and PaymentMode='CARD' and sm.CreatedDate between convert(datetime,'" + DtFrom1 + "',103) and CONVERT(datetime,'" + DtTo1 + "',103)+1";
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
    }
}
