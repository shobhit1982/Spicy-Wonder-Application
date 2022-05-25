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
    public partial class DuplicateCashMemoReport : Form
    {
        public DuplicateCashMemoReport()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime DtFrom = dtpFrom.Value;
            DateTime DtTo = dtpTo.Value;
            string DtFrom1 = DtFrom.ToString("dd/MM/yyyy");
            string DtTo1 = DtTo.ToString("dd/MM/yyyy");
            Report.DuplicateCashMemo rpt = new Report.DuplicateCashMemo();
            frmReportViewer frm = new frmReportViewer();
            string sql = "select t1.SaleMasterId,t1.BillNumber,t1.TableNumber,t1.Amount,t1.Taxes,t1.Discount,t1.Difference,t1.TotalAmount,t1.RoundAmount,t1.Name,t1.Qty,t1.ItemPrice,t1.ItemWiseAmount,t1.CreatedDate,t1.LoggedUser,isnull(t2.Amount,0) as VatAmount,t2.TaxName as VatName,isnull(t3.Amount,0) as ServiceTax,t3.TaxName as ServiceName,case when t1.Status=6 then 'CANCELLED' else t1.PaymentMode end as PaymentMode from (SELECT  distinct sd.SaleMasterId,sd.ID as SalesDetailsId , sm.BillNumber, sm.TableNumber, sm.Amount, sm.RoundAmount,sm.Taxes,sm.TotalAmount, sm.Discount,sm.Difference, ItemMaster.Name, sd.Qty, sd.Amount AS ItemWiseAmount, sd.ItemPrice,sm.CreatedDate,UserTable.Name AS LoggedUser,sm.PaymentMode,sm.Status FROM SalesMaster as sm INNER JOIN SalesDetails as sd ON sm.ID = sd.SaleMasterId INNER JOIN ItemMaster ON sd.ItemId = ItemMaster.ID INNER JOIN UserTable ON sm.CreatedBy = UserTable.Id WHERE (sm.CreatedDate between convert(datetime,'" + DtFrom1 + "',103) and CONVERT(datetime,'" + DtTo1 + "',103)+1)) t1 left join SalesTaxDetails t2 on t1.SalesDetailsId=t2.SalesDetailsId and t2.TaxId=1 left join SalesTaxDetails t3 on t1.SalesDetailsId=t3.SalesDetailsId and t3.TaxId=2";
            try
            {
                DataSet ds = GlobalClass.executeQuery(sql, "data");
                DataSet dsComapny = GlobalClass.GetCompanyInfo();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rpt.SetDataSource(ds.Tables[0]);
                    rpt.Database.Tables["CompanyInfo"].SetDataSource(dsComapny.Tables[0]);
                    rpt.SetParameterValue("SaleDateFrom", DtFrom.ToString("dd/MM/yyyy"));
                    rpt.SetParameterValue("SaleDateTo", DtTo.ToString("dd/MM/yyyy"));
                    frm.crystalReportViewer1.ReportSource = rpt;
                    frm.ShowDialog();
                    //rpt.Close ();
                }
                else
                {
                    MessageBox.Show("No Data Found Between These Date");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
