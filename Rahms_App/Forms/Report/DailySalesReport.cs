using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace RAHMS.Forms.Report
{
    public partial class DailySalesReport : Form
    {
        public DailySalesReport()
        {
            InitializeComponent();
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            DateTime DtFrom = dtpFrom.Value;
            DateTime DtTo = dtpTo.Value;
            string DtFrom1 = DtFrom.ToString("dd/MM/yyyy");
            string DtTo1 = DtTo.ToString("dd/MM/yyyy");
            Report.DailySaleReport rpt = new Report.DailySaleReport();
            frmReportViewer frm = new frmReportViewer();
            try
            {
                DataSet ds = GlobalClass.GetDataForSaleReport(DtFrom1, DtTo1);
                DataSet dsComapny = GlobalClass.GetCompanyInfo();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rpt.SetDataSource(ds.Tables[0]);
                    rpt.Database.Tables["CompanyInfo"].SetDataSource(dsComapny.Tables[0]);
                    //rpt.SetParameterValue("SaleDateFrom", DtFrom.ToString("dd/MM/yyyy"));
                    //rpt.SetParameterValue("SaleDateTo", DtTo.ToString("dd/MM/yyyy"));
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
