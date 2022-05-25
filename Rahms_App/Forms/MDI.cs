using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RAHMS.Forms;
using RAHMS.Entity;
using RAHMS.Forms.RAHMS;
using RAHMS.Forms.Report;
using RAHMS.Forms.Sales;
using RAHMSLibrary.Entity;



namespace RAHMS
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }


        #region Contol function

        private void MDI_Load(object sender, EventArgs e)
        {

            long UserTypesId = GlobalClass.UserTypeId;
            if (UserTypesId == 1)
            {
            }
            else
            {
                var userRightsList = UserRights.GetUserRights(UserTypesId, long.Parse(GlobalClass.userNameid));

                foreach (ToolStripMenuItem mainmenu in menuStrip1.Items)
                {
                    if (!IsRights(mainmenu, userRightsList))
                    {
                        mainmenu.Visible = false;
                    }

                    foreach (ToolStripItem item in mainmenu.DropDownItems)
                    {
                        if (!IsRights(item, userRightsList))
                        {
                            item.Visible = false;
                        }
                    }
                }
            }
        }
        private bool IsRights(ToolStripItem toolStripItem, IList<UserRights> userRightsList)
        {
            for (int i = 0; i < userRightsList.Count; i++)
            {
                if (userRightsList[i].MenuName == toolStripItem.Name)
                    return true;
            }

            return false;
        }
        private void MDI_Load1(object sender, EventArgs e)
        {
            string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;
            string y = ModCommonFunctions.Getinstance().UserTypes.UserName;
            if (x == "Administrator")
            {


                reportToolStripMenuItem.Visible = true;
                toolsToolStripMenuItem.Visible = true;

            }
            else
            {
                string sql = "select restriction from tbl_login where username='" + y + "'";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = ClsDBFunctions.RAHMS().ExecuteQuery_DataSet(sql, this.Name);
                string str = ds.Tables[0].Rows[0]["restriction"].ToString();

                if (str == "012")
                {

                    dateWiseSaleReportToolStripMenuItem.Visible = true;

                    itemWiseSaleReportToolStripMenuItem.Visible = true;

                    resetToolStripMenuItem.Visible = true;

                }
                else if (str == "")
                {
                    reportToolStripMenuItem.Visible = false;
                    dateWiseSaleReportToolStripMenuItem.Visible = false;

                    itemWiseSaleReportToolStripMenuItem.Visible = false;

                    resetToolStripMenuItem.Visible = false;

                }
                else if (str == "01")
                {
                    dateWiseSaleReportToolStripMenuItem.Visible = true;

                    itemWiseSaleReportToolStripMenuItem.Visible = true;

                    resetToolStripMenuItem.Visible = false;

                }
                else if (str == "02")
                {
                    dateWiseSaleReportToolStripMenuItem.Visible = true;

                    itemWiseSaleReportToolStripMenuItem.Visible = false;

                    resetToolStripMenuItem.Visible = true;


                }
                else if (str == "12")
                {
                    dateWiseSaleReportToolStripMenuItem.Visible = false;

                    itemWiseSaleReportToolStripMenuItem.Visible = true;

                    resetToolStripMenuItem.Visible = true;

                }
                else if (str == "0")
                {
                    dateWiseSaleReportToolStripMenuItem.Visible = true;

                    itemWiseSaleReportToolStripMenuItem.Visible = false;

                    resetToolStripMenuItem.Visible = false;


                }
                else if (str == "1")
                {
                    dateWiseSaleReportToolStripMenuItem.Visible = false;

                    itemWiseSaleReportToolStripMenuItem.Visible = true;

                    resetToolStripMenuItem.Visible = false;

                }
                else if (str == "2")
                {
                    dateWiseSaleReportToolStripMenuItem.Visible = false;

                    itemWiseSaleReportToolStripMenuItem.Visible = false;

                    resetToolStripMenuItem.Visible = true;

                }

                // reportToolStripMenuItem.Visible = false;
                toolsToolStripMenuItem.Visible = false;
            }



        }
        #endregion

        #region Master
        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }
        #endregion

        private void fGItemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printTockenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateWiseSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelBillSummary obj = new CancelBillSummary();
            obj.ShowDialog(this);
        }

        private void itemWiseSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserWiseSaleReport obj = new UserWiseSaleReport();
            obj.ShowDialog(this);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_User obj = new Frm_User();
            obj.ShowDialog();
            obj.Close();
        }

        private void MDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            return;
        }

        private void mastersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MDI_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CardPaymentReport frm = new CardPaymentReport();
            frm.ShowDialog(this);
        }
        // public  string adminPassword = "";
        private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Reset billing ?", "Confirmation",
  MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Frm_AdminPassword frmAdmin = new Frm_AdminPassword();
                Frm_AdminPassword.AdminPassword = "123";
                this.Opacity = 0.30;

                DialogResult dialogresult = frmAdmin.ShowDialog();

                if (!string.IsNullOrEmpty(Frm_CounterSale.adminPassword) && Frm_CounterSale.adminPassword == "000000")
                {
                    this.Opacity = 1.0;
                    return;

                }
                string adminPasswordAsInDB = "";
                var userAdmin = UserTable.GetByAdminPassword(Frm_CounterSale.adminPassword);

                if (userAdmin != null && userAdmin.Id > 0)
                    adminPasswordAsInDB = userAdmin.Password;
                if (adminPasswordAsInDB != "" && Frm_CounterSale.adminPassword == adminPasswordAsInDB)
                {
                    TruncateTranactionDetails();
                    SetnewBillNumber();
                    // Delete from database 
                }
                else
                {
                    MessageBox.Show("enter correct password!!!");
                }
                this.Opacity = 1.0;
                return;

                //            DialogResult result = MessageBox.Show("Do you want to cancel current bill " + lblBillNo.Text + "?", "Confirmation",
                //MessageBoxButtons.YesNo);
                //            if (result == DialogResult.Yes)
                //            {
                //                //delete all entry from DB
                //                comboTables.Focus();

                //                SalesMaster.Delete(Convert.ToInt32(lblBillNo.Text));

                //                FreeTable(pnlTable, lblTableNo.Text);
                //                ResetForNewGrid();
                //                GetTable();
                //            }
            }


        }

        private void SetnewBillNumber()
        {
            Frm_AdminPassword frmAdmin = new Frm_AdminPassword("Set Bill Number");
            Frm_AdminPassword.AdminPassword = "123";
            this.Opacity = 0.30;

            DialogResult dialogresult = frmAdmin.ShowDialog();
            if (!string.IsNullOrEmpty(Frm_CounterSale.adminPassword))
            {
                var newBillvalue = SetNewBillNumerInDB(Frm_CounterSale.adminPassword);
                // Delete from database 
            }

            this.Opacity = 1.0;
            return;

        }

        private int SetNewBillNumerInDB(string p)
        {
            try
            {
                string _p;
                if (Convert.ToInt32(p) > 0)
                    _p = Convert.ToString(Convert.ToInt32(p) - 1);
                else
                    _p = p;
                string query = "INSERT INTO [SalesMaster]([BillNumber] ,[IsValid]) VALUES (" + _p + ",'False' )";
                return ClsDBFunctions.RAHMS().ExecuteNonQuery(query, "SHO");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void mBToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void TruncateTranactionDetails()
        {
            try
            {


                ClsDBFunctions.RAHMS().ExecuteNonQuery(Query.MDI.TruncateSalesMaster);
                ClsDBFunctions.RAHMS().ExecuteNonQuery(Query.MDI.TruncateSalesDetails);
                ClsDBFunctions.RAHMS().ExecuteNonQuery(Query.MDI.TruncateSalesTaxDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vatReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailySalesReport frm = new DailySalesReport();
            frm.ShowDialog(this);

        }

        private void taxMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateWiseBillReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuplicateCashMemoReport frm = new DuplicateCashMemoReport();
            frm.ShowDialog(this);
        }

        private void UserTypessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mst_UserTypess frm = new Mst_UserTypess();
            frm.ShowDialog(this);
        }

        private void tranjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mst_ManageRights frm = new Mst_ManageRights();
            frm.ShowDialog(this);
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new MDI().Close();
                new Frm_Login().Show();
            }
            catch
            {
            }
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_CounterSale frm = new Frm_CounterSale();
                frm.ShowDialog(this);
               

            }
            catch (Exception ex)
            {

              throw ex;
            }
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Location frm = new Frm_Location();
            frm.ShowDialog(this);
        }

        private void manageTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_TaxMaster frm = new Frm_TaxMaster();
            frm.ShowDialog(this);
        }

        private void itemSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_SeriesMaster frm = new Frm_SeriesMaster();
            frm.ShowDialog(this);
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ItemMaster frm = new Frm_ItemMaster();
            frm.ShowDialog(this);
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Unit frm = new Frm_Unit();
            frm.ShowDialog(this);
        }

        private void UserTypessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mst_UserTypess frm = new Mst_UserTypess();
            frm.ShowDialog(this);
        }

        private void userRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mst_ManageRights frm = new Mst_ManageRights();
            frm.ShowDialog(this);
        }

        private void menuAndSubMenuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mst_MenuAndSubMenu frm = new Mst_MenuAndSubMenu();
            frm.ShowDialog(this);
        }

        private void discountMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Discount frm = new Frm_Discount();
            frm.ShowDialog(this);
        }

        private void rAHMSMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_User obj = new Frm_User();
            obj.ShowDialog();
            obj.Close();
        }

        private void userRightsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuAndSubMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void orderTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_OrderType frm = new Frm_OrderType();
            frm.ShowDialog(this);
        }

        private void creditSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DlgCreditReport frm = new DlgCreditReport();
            frm.ShowDialog(this);
        }
    }
}
