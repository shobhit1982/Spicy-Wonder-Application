using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RAHMS.Forms.RAHMS;
using RAHMSLibrary.Entity.Sales;

namespace RAHMS.Forms.Sales
{
    public partial class Frm_PendingBills : Form
    {
        public Frm_PendingBills()
        {
            InitializeComponent();
            LoadPendingBills();
        }

        public Frm_PendingBills(bool IsPrintedBill, int BillNumber)
        {
            InitializeComponent();
            LoadAlreadyPrintedBills(IsPrintedBill, BillNumber);

        }

        private void LoadAlreadyPrintedBills(bool IsPrintedBill ,int BillNumber)
        {
            var printedBills = SalesMaster.GetByStatusAndUserId(4, long.Parse(GlobalClass.userNameid),BillNumber);
            if (printedBills != null && printedBills.Count > 0)
            {

                var pending = from p in printedBills
                              select new { ID = p.BillNumber, Name = "BillNumber: " + p.BillNumber + " TableNo: " + p.TableNumber + " Amount: " + p.Amount };


                // listBoxPendingBills.DisplayMember = "BillNumber";
                //   listBoxPendingBills.ValueMember = "BillNumber";
                foreach (var item in pending)
                {
                    listBoxPendingBills.Items.Add(item.Name);
                }
            }
            
        }

        private void LoadPendingBills()
        {
            //var pendingBills = SalesMaster.GetByStatusAndUserId(3, long.Parse(GlobalClass.userNameid));
            //if (pendingBills != null && pendingBills.Count > 0)
            //{

            //    var pending = from p in pendingBills
            //                  select new { ID = p.BillNumber, Name = "BillNumber: " + p.BillNumber + " TableNo: " + p.TableNumber + " Amount: " + p.Amount };


            //    // listBoxPendingBills.DisplayMember = "BillNumber";
            //    //   listBoxPendingBills.ValueMember = "BillNumber";
            //    foreach (var item in pending)
            //    {
            //        listBoxPendingBills.Items.Add(item.Name);
            //    }
            //}
        }
      
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            { this.Close(); }
            if (keyData == Keys.Enter)
            {
                string str = listBoxPendingBills.SelectedItem.ToString();

                Frm_CounterSale.billNumber = int.Parse(str.Split(':')[1].ToString().Split(' ')[1].ToString());
                Frm_CounterSale.tableNumber = str.Split(' ')[3].ToString();
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void listBoxPendingBills_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
    public class PendingBill
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
