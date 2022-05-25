using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RAHMS.Forms.Report
{
    public partial class DlgCreditReport : Form
    {
        public DlgCreditReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime DtFrom = dtpFrom.Value;
            DateTime DtTo = dtpTo.Value;
            string DtFrom1 = DtFrom.ToString("dd/MM/yyyy");
            string DtTo1 = DtTo.ToString("dd/MM/yyyy");
            var OrdertypeId = comboBox1.SelectedValue;


            Report.Rpt_CreditSaleReport rpt = new Report.Rpt_CreditSaleReport();
            frmReportViewer frm = new frmReportViewer();
            try
            {
                string sql = "select '" + DtFrom1 + "' FromDate,'" + DtTo1 + "' ToDate,ordertype.OrderType,ordertype.id as ordertypeid, sm.BillNumber,sm.Amount,sm.Taxes,TotalAmount,RoundAmount,Difference,sm.CreatedBy,CONVERT(VARCHAR(10),sm.CreatedDate,103) CreatedDate,sm.PaymentMode , sm.Discount from SalesMaster sm Left join  ordertype  ON ordertype.id = sm.CustomerId where Status=4 and PaymentMode='CREDIT' and ordertype.id ='"+ OrdertypeId + "' and sm.CreatedDate between convert(datetime,'" + DtFrom1 + "',103) and CONVERT(datetime,'" + DtTo1 + "',103)+1";
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

        private void DlgCreditReport_Load(object sender, EventArgs e)
        {
            LoadOrderType();
        }
        private void LoadOrderType()
        {
            string sql = "select * from OrderType where IsDefault != 1";
            DataSet ds = GlobalClass.executeQuery(sql, "OrdType");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                comboBox1.DataSource = ds.Tables["OrdType"];
                comboBox1.DisplayMember = "OrderType";
                comboBox1.ValueMember = "id";
            }
            else
            {
                MessageBox.Show("Order Type does Not Found");
            }
        }
    }

  


    //{
    //    DateTime DtFrom = dtpFrom.Value;
    //    DateTime DtTo = dtpTo.Value;
    //    string DtFrom1 = DtFrom.ToString("MM/dd/yyyy");
    //    string DtTo1 = DtTo.ToString("MM/dd/yyyy");


    //    Report.Rpt_CreditSaleReport rpt = new Report.Rpt_CreditSaleReport();
    //    frmReportViewer frm = new frmReportViewer();

    //    string sql = " SELECT  ordertype.OrderType,Tran_Sale_Mas.Sale_Id,Tran_Sale_Mas.sale_date, Tran_Sale_Mas.Total_Amt,Tran_Sale_Mas.TaxAmount, Tran_Sale_Mas.TaxAmount2, Mst_Info.FirmName, " +
    //                " Mst_Info.Address, Mst_Info.HeadOfficeAddress, Mst_Info.PhoneNo, Mst_Info.Email, Mst_Info.TinNo, Mst_Info.SaletaxNo, Mst_Tax.Tax_name, " +
    //                " Mst_Tax.TaxPer, Mst_Tax1.Tax_name as Tax_name2,Tran_Sale_Mas.TaxPer2 " +
    //                " FROM Tran_Sale_Mas Left JOIN Mst_Tax ON Tran_Sale_Mas.TaxId = Mst_Tax.Id " +
    //                " Left join  Mst_Tax Mst_Tax1 ON Tran_Sale_Mas.TaxId2 = Mst_Tax1.Id  " +
    //                " Left join  ordertype  ON ordertype.id = Tran_Sale_Mas.Person_Acc_Id CROSS JOIN Mst_Info " +
    //                " WHERE   (Tran_Sale_Mas.Sale_Date BETWEEN '" + DtFrom1 + "' AND '" + DtTo1 + "') AND " + "(Tran_Sale_Mas.Bill_Status is null)  and Tran_Sale_Mas.Payment_Mode= 'Credit' ";




    //    DataSet ds = GlobalClass.executeQuery(sql, "sho");

    //    if (ds != null)
    //    {
    //        rpt.SetDataSource(ds.Tables["sho"]);
    //        frm.CrViewer.ReportSource = rpt;
    //        rpt.SetParameterValue(0, DtFrom.ToString("dd/MM/yyyy"));
    //        rpt.SetParameterValue(1, DtTo.ToString("dd/MM/yyyy"));
    //        //rpt.PrintOptions.PrinterName = "EPSON TM-T81 Receipt".ToString();
    //        //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
    //        //rpt.PrintToPrinter(1, false, 0, 0);
    //        //rpt.Close();
    //        frm.Show();
    //    }
    //    else
    //    {
    //        MessageBox.Show("No Data Between These Date");
    //    }

    //}

    //private void DlgCreditReport_Load(object sender, EventArgs e)
    //{

    //}
}

