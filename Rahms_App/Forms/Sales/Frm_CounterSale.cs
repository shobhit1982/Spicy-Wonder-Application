using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RAHMSLibrary.Entity.Masters;
using System.Collections;
using System.Drawing.Drawing2D;
using RAHMSLibrary.Entity.Sales;
using System.Threading.Tasks;
using RAHMS.Forms.Sales;
using RAHMS.Entity;
//using RAHMS.Forms.Report;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using RAHMS.Forms.Report;
using System.Drawing.Printing;

namespace RAHMS.Forms.RAHMS
{
    public partial class Frm_CounterSale : Form
    {
        public bool OrderTypeEnter { get; set; }
        public Frm_CounterSale()
        {
            InitializeComponent();
            CreateDataGridView();



        }


        private bool IsAnyBillPending()
        {
            // bool isBillPenind = false;
            foreach (var item in runningSalesMasterForLoginUser)
            {
                if (item.Status != 4)
                {
                    return true;
                }

            }
            return false;
        }
        static SalesMaster runningSaleMaster;
        IList<MstOrderType> orderTypeList = new List<MstOrderType>();
        public static int discount = 0;
        public static int billNumber = 0;
        public static string tableNumber = "";
        public static string adminPassword = "";
        public string _PaymentMode = string.Empty;
        public int EditedBillNumber = 0;
        bool IsFormLoad = false;
        int TableCount = 0;
        ArrayList arrTaxValue = new ArrayList();


        private void Frm_CounterSale_Load(object sender, EventArgs e)
        {
            try
            {

                IsFormLoad = true;
                // this.Opacity = 0.30;
                //  BaseForm.ButtonPainter(btnAdd, Color.Gray);
                // BaseForm.ButtonPainter(btnCancel, Color.Gray);
                //  BaseForm.ButtonPainter(btnClose, Color.Gray);
                //  BaseForm.ButtonPainter(btnSave, Color.Gray);
                //BaseForm.PanelPainter(pnlTop, Color.Khaki);
                BaseForm.PanelPainter(pnlTable, Color.WhiteSmoke);
                //  BaseForm.PanelPainter(pnlTakeAway, Color.Cyan);

                btnAdd.Enabled = false;
                btnCancel.Enabled = false;
                btnClose.Enabled = false;
                btnSave.Enabled = false;

                lblLoginUser.Text = "Welcome " + GlobalClass.username;
                lblDateAndTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

                CreateTaxControls();
                CBPaymentMode.Text = "CASH";
                _PaymentMode = CBPaymentMode.Text;
                //txtPaymentMode1.KeyDown += new KeyEventHandler(Control_KeyDown);
                LoadOrderType();
                GetTable();
                //textTableNumber.Focus();// = true;
                // this.Opacity = 1.0;
                string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;
                if (x == "Administrator")
                {
                    CBPaymentMode.Visible = true;
                    label4.Visible = true;
                    Btn_EditBill.Visible = true;
                    lblPrintedBillDate.Visible = true;

                }
                else
                {
                    CBPaymentMode.Visible = false;
                    label4.Visible = false;
                    Btn_EditBill.Visible = false;
                    lblPrintedBillDate.Visible = false;


                }
            }
            catch
            {
            }
        }


        private void LoadOrderType()
        {
            try
            {

                orderTypeList.Clear();
                orderTypeList = MstOrderType.GetAll();
                //orderTypeList.Insert(0, new MstOrderType { ID = 0, OrderType = "--Select--" });

                cmbOrderType.DisplayMember = "OrderType";
                cmbOrderType.ValueMember = "Id";
                cmbOrderType.DataSource = orderTypeList.OrderBy(id => id.OrderType).ToList<MstOrderType>();
                cmbOrderType.SelectedIndex = 0;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BindDiscount(bool Enabled = false, string runningDiscount = "0")
        {

            IList<DiscountManage> discountList = DiscountManage.GetAll();
            if (discountList != null && discountList.Count > 0)
            {
                discountList.Add(new DiscountManage { ID = 0, Discount = 0 });
                comboBoxDiscount.DisplayMember = "Discount";
                comboBoxDiscount.ValueMember = "ID";
                comboBoxDiscount.DataSource = discountList.OrderBy(id => id.ID).ToList<DiscountManage>();
                comboBoxDiscount.Text = runningDiscount;
                comboBoxDiscount.Enabled = Enabled;
                if (!Enabled)
                {
                    comboBoxDiscount.DroppedDown = false;
                    //labelDiscount.Enabled = Enabled;
                    comboBoxDiscount.Enabled = Enabled;
                    lblDiscountAmont.Enabled = Enabled;

                }
                else
                {
                    // labelDiscount.Enabled = Enabled;
                    comboBoxDiscount.Enabled = Enabled;
                    lblDiscountAmont.Enabled = Enabled;
                    comboBoxDiscount.DroppedDown = true;
                    comboBoxDiscount.Focus();
                }

            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                textTableNumber.Focus();
            }
            if (keyData == (Keys.Control | Keys.C))
            {
                this.Close();
            }
            if (keyData == (Keys.Control | Keys.S))
            {

                if (this.EditedBillNumber != 0)
                {

                    runningSaleMaster.Discount = discount;
                    foreach (var item in runningSaleMaster.SalesDetailsList)
                    {
                        if (discount != 0) { item.Amount = item.ItemPrice * item.Qty - ((item.ItemPrice * item.Qty) * discount / 100); }
                        else { item.Amount = item.ItemPrice * item.Qty; }
                        item.ModifiedBy = runningSaleMaster.ModifiedBy;
                        decimal totalTax = 0;
                        decimal _totalTaxAfterdiscount = 0;
                        int Quantity = item.Qty.Value;
                        IList<SalesTaxDetails> salesTaxDetailsList = GetSalesTaxDetailListObject(item.ItemMaster, Quantity, out totalTax, Convert.ToInt32(cmbOrderType.SelectedValue.ToString()));
                        foreach (var saleTaxitem in salesTaxDetailsList)
                        {
                            if (discount != 0) { saleTaxitem.Amount = saleTaxitem.Amount - (saleTaxitem.Amount * discount / 100); }
                            else { saleTaxitem.Amount = saleTaxitem.Amount; }
                            _totalTaxAfterdiscount += saleTaxitem.Amount.Value;
                        }
                        item.Taxes = _totalTaxAfterdiscount;

                        int ret = RAHMSLibrary.Entity.Sales.SalesDetails.Update(item);

                        //var salesDetailsid = RAHMSLibrary.Entity.Sales.SalesDetails.GetById(salesDetails.ID);
                        if (ret > 0)
                        {
                            if (salesTaxDetailsList != null)
                            {
                                for (int i = 0; i < salesTaxDetailsList.Count; i++)
                                {
                                    salesTaxDetailsList[i].SalesDetailsId = item.SalesTaxDetailsList[i].SalesDetailsId;
                                    salesTaxDetailsList[i].ID = item.SalesTaxDetailsList[i].ID;
                                    SalesTaxDetails.Update(salesTaxDetailsList[i]);


                                }
                            }
                            //update sales master
                            runningSaleMaster = SalesMaster.GetByBillNumber(runningSaleMaster.BillNumber.ToString());

                            if (salesTaxDetailsList != null)
                            {
                                runningSaleMaster.Taxes = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes);
                                runningSaleMaster.OriginalTaxAmount = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes).Value;
                            }
                        }
                        SetPriceAndTax(runningSaleMaster);

                    }
                    runningSaleMaster.Discount = discount;
                    runningSaleMaster.IsBillAlreadyPrinted = false;
                    this.EditedBillNumber = 0;
                    runningSaleMaster.Remarks = "Printed";
                    if (!string.IsNullOrEmpty(_PaymentMode))
                        runningSaleMaster.PaymentMode = _PaymentMode;
                    runningSaleMaster.Status = (int)RAHMSLibrary.Entity.EntityBase.SalesMasterStatus.Printed;
                    SalesMaster.Update(runningSaleMaster);





                    GridColumnsReadOnly(true);
                    btnCancel.Enabled = true;
                    btnClose.Enabled = true;
                    btnAdd.Enabled = true;
                    btnSave.Enabled = false;
                    comboBoxDiscount.Enabled = false;
                    btnFirst.Enabled = true;
                    btnLast.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    btnSearchPrintedBill.Enabled = true;
                    Btn_EditBill.Enabled = true;
                    textTableNumber.Enabled = true;
                    txtBoxBillNumber.Enabled = true;
                    CBPaymentMode.Enabled = false;
                    cmbOrderType.Enabled = false;
                    MessageBox.Show("Edited Bills Saved successfully . ");

                }

            }
            if (keyData == (Keys.Control | Keys.D))
            {
                DialogResult result = MessageBox.Show("Do you want to cancel current bill " + lblBillNo.Text + "?", "Confirmation",
  MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    textTableNumber.Focus();
                    SalesMaster.Delete(Convert.ToInt32(lblBillNo.Text));
                    FreeTable(pnlTable, runningSaleMaster.TableNumber);
                    ResetForNewGrid();
                    GetTable();
                }
            }
            if (keyData == (Keys.Control | Keys.A))
            {

                var tables = RAHMSLibrary.Entity.Masters.SeatingLocation.GetAll();
                if (tables[0].Seats > runningSalesMasterForLoginUser.Count)
                {
                    FuntionF7();
                    Cleartaxdetails();
                }
                else
                {
                    MessageBox.Show("No more tables vacate. Please release existig bill to create new bills!!!!");
                }

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }




        private void CreateTaxControls()
        {
            int leftLabel = 0;
            int leftValue = 100;
            int top = 80;
            var taxList = Taxes.GetAll();
            foreach (Taxes tax in taxList)
            {
                if (tax.IsValid == 1)
                {
                    top += 22;
                    Label lblTaxLabel = GetLabel("" + tax.Name + " (" + tax.Rate + "%): ", 120, 25, leftLabel, top, "lbl" + tax.ID, true);

                    lblTaxLabel.Name = "lblTaxLabel_" + tax.ID;
                    lblTaxLabel.Text = tax.Name + " " + tax.Rate;
                    lblTaxLabel.TextAlign = ContentAlignment.TopRight;
                    pnlBillDetails.Controls.Add(lblTaxLabel);

                    Label lblTaxValue = GetLabel("lblTax", 120, 25, leftValue + 50, top, "lblTax" + tax.ID);
                    lblTaxValue.TextAlign = ContentAlignment.TopLeft;
                    lblTaxValue.Name = "lblTaxValue_" + tax.ID.ToString();


                    arrTaxValue.Add(lblTaxValue);
                    pnlBillDetails.Controls.Add(lblTaxValue);
                }
            }
        }

        private void SetPriceAndTax(SalesMaster slmstr)
        {
            if (slmstr != null && slmstr.ID != null)
            {

                lblAmount.Text = String.Format("{0:0.00}", slmstr.Amount.Value);
                LblNetAmt.Text = String.Format("{0:0.00}", slmstr.TotalAmount.Value);
                lblRoundOff.Visible = true;
                lblRoundOff.Text = String.Format("{0:0.00}", slmstr.Difference.Value);



                pnlBillDetails.Refresh();
                // lblPercentage.Refresh();
                lblDiscountAmont.Refresh();
                lblAmount.Refresh();
                // lblTotalTax.Refresh();
                lblNetAmount.Refresh();
                cmbOrderType.SelectedValue = slmstr.CustomerId;
                ///get all tax lavel to set alue          
                var taxdeatils = slmstr.TaxCalculationList(Convert.ToInt32(cmbOrderType.SelectedValue.ToString()));
                decimal totaltax = 0;


                for (int i = 0; i < arrTaxValue.Count; i++)
                {
                    if (taxdeatils != null && taxdeatils.Count > 0)
                    {
                        foreach (var tax in taxdeatils)
                        {
                            Label lblValue = (Label)arrTaxValue[i];
                            if (lblValue.Name.Split('_')[1].ToString() == tax.TaxId.ToString())
                            {
                                //  string rate = tax.TaxDetails.Rate;// lblLabel.Text.Split('(')[1].Split('%')[0].ToString();
                                //  payableAmount += double.Parse(rate) * totalAmount / 100;
                                lblValue.Text = tax.TaxAmount.Value.ToString("#.##");
                                totaltax += tax.TaxAmount.Value;
                            }
                        }
                    }
                    else
                    {
                        Label lblValue = (Label)arrTaxValue[i];
                        lblValue.Text = "0.0";
                    }
                }


                lblNetAmount.Text = String.Format("{0:0.00}", slmstr.RoundAmount.Value);

                // lblPercentage.Text = slmstr.Discount.Value.ToString() + "%";



                if (slmstr.Discount.Value > 0)
                {
                    var discountamt = slmstr.Amount.Value * slmstr.Discount.Value / 100;
                    var taxdiscount = totaltax * slmstr.Discount.Value / 100;
                    var totaldiscount = discountamt + taxdiscount;
                    lblDiscountCal.Text = String.Format("{0:0.00}", discountamt);//+ " + Tax Discount=" + String.Format("{0:0.00}", taxdiscount) + " = " + String.Format("{0:0.00}", totaldiscount);
                    decimal _totalAmount = slmstr.Amount.Value - discountamt;
                    lblAmtAftDist.Text = String.Format("{0:0.00}", _totalAmount);
                }
                else
                {
                    lblDiscountCal.Text = String.Format("{0:0.00}", 0);//+ " + Tax Discount=" + String.Format("{0:0.00}", 0) + " = " + String.Format("{0:0.00}", 0);
                    lblAmtAftDist.Text = String.Format("{0:0.00}", slmstr.Amount.Value);
                }


            }
            else
            {

                lblAmount.Text = "0.00";
                //lblTotalTax.Text = "0.00";
                lblNetAmount.Text = "0.00";
                // lblPercentage.Text = "0%";
                lblDiscountAmont.Text = "0.00";
            }

        }
        private RAHMSLibrary.Entity.Sales.SalesMaster UpdateSalesMaster(int BillNumber, decimal amount, decimal tax)
        {
            RAHMSLibrary.Entity.Sales.SalesMaster salesMaster = RAHMSLibrary.Entity.Sales.SalesMaster.GetByBillNumber(BillNumber.ToString());
            salesMaster.Amount = amount;
            salesMaster.Status = 2;
            salesMaster.Taxes = tax;
            RAHMSLibrary.Entity.Sales.SalesMaster.Update(salesMaster);
            return RAHMSLibrary.Entity.Sales.SalesMaster.GetByBillNumber(BillNumber.ToString());
        }
        private Label GetLabel(string text, int sizeW, int sizeH, int locationX, int locationY, string controlId = "", bool bold = false)
        {
            Label lbl = new Label();
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Left = locationX;// new System.Drawing.Point(locationX, locationY);
            lbl.Top = locationY;
            if (controlId == "")
                lbl.Name = "lbl" + text.Replace(" ", "_");
            else
                lbl.Name = controlId;
            lbl.Text = "0.0";
            lbl.Size = new System.Drawing.Size(sizeW, sizeH);
            lbl.ForeColor = System.Drawing.Color.Black;
            if (bold)
            {

                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.ForeColor = Color.Black;
            }

            lbl.BorderStyle = BorderStyle.None;
            lbl.BackColor = Color.Transparent;
            return lbl;
        }

        private void SetOrderType()
        {
            //Open Ordertype popup here
            //Call Order type dialog            
            frmDlgOrdertype dlg = new frmDlgOrdertype();
            dlg.MyParentForm = this;
            DialogResult dresult = dlg.ShowDialog();
            if (OrderTypeEnter == false)
            {
                MessageBox.Show("Please Select Order Type", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (Convert.ToInt32(cmbOrderType.SelectedValue.ToString()) > 1)
                {
                    CBPaymentMode.Text = "CREDIT";
                    _PaymentMode = CBPaymentMode.Text;

                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                comboBoxDiscount.SelectedIndex = -1;



                //            DialogResult result = MessageBox.Show("Do you want to create new bill?", "Confirmation",
                //MessageBoxButtons.YesNo);
                //            if (result == DialogResult.Yes)
                //            {
                var tables = RAHMSLibrary.Entity.Masters.SeatingLocation.GetAll();
                if (tables[0].Seats > runningSalesMasterForLoginUser.Count)
                {
                    FuntionF7();


                    if (runningSaleMaster.SalesDetailsList != null)
                    {

                        Cleartaxdetails();
                    }
                    //ResetForNewGrid();

                    //btnAdd.Enabled = false;
                    //btnCancel.Enabled = false;
                    //btnClose.Enabled = false;
                    //btnSave.Enabled = false;
                    //btnCancel.Enabled = false;

                    ////comboTables.BackColor = Color.Khaki;
                    ////comboTables.Enabled = true;
                    ////comboTables.Focus();
                    //textTableNumber.Enabled = true;

                    //textTableNumber.Focus();


                    //lblBillNo.Text = "";
                    ////  lblTableNo.Text = "";
                    //lblAmount.Text = "0.0";
                    //lblNetAmount.Text = "0.0";
                    //lblTotalTax.Text = "0.0";
                    //// lblPercentage.Text = "0%";
                    //lblDiscountAmont.Text = "0.0";
                }
                else
                {
                    MessageBox.Show("No more tables vacate. Please release existig bill to create new bills!!!!");
                }

                //}
            }
        }

        private void Cleartaxdetails()
        {
            int _appendNumber = 0;
            //runningSaleMaster.TaxCalculationList( Convert.ToInt32(cmbOrderType.SelectedValue.ToString())).Count() > 0 ? runningSaleMaster.TaxCalculationList(Convert.ToInt32(cmbOrderType.SelectedValue.ToString())).Count() : 0;


            object obj = runningSaleMaster.TaxCalculationList(Convert.ToInt32(cmbOrderType.SelectedValue.ToString()));

            if (obj != null)
            {
                _appendNumber = runningSaleMaster.TaxCalculationList(Convert.ToInt32(cmbOrderType.SelectedValue.ToString())).Count();
            }

            for (int i = 1; i <= _appendNumber; i++)
            {
                string LableName = "lblTaxLabel_" + i;
                string LableValue = "lblTaxValue_" + i;

                foreach (Control c in pnlBillDetails.Controls)
                {
                    //if (c.Name.Contains(LableName))                   
                    //    c.Text = "0.0";
                    if (c.Name.Contains(LableValue))
                        c.Text = "0.0";

                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (textTableNumber.Text == "00")
                    SetOrderType();
                //if (comboTables.SelectedIndex > 0)
                //{
                //add items to grid          
                btnSave.Enabled = false;

                btnClose.Enabled = true;
                BaseForm.ButtonPainter(btnClose, Color.Green);
                btnClose.ForeColor = Color.White;

                btnAdd.Enabled = true;
                BaseForm.ButtonPainter(btnAdd, Color.Orchid);
                btnAdd.ForeColor = Color.White;

                lblBillNo.ForeColor = Color.Red;
                lblBillNo.Text = GetNewBill().ToString();
                // lblTableNo.Text = comboTables.Text;

                //save bill in DB
                // InsertSaleMaster(int.Parse(lblBillNo.Text.Trim()), comboTables.Text);
                InsertSaleMaster(int.Parse(lblBillNo.Text.Trim()), textTableNumber.Text);

                // if (comboTables.SelectedIndex > 0)
                //{
                // Control ctrlButton = GetControlByText(pnlTable, comboTables.SelectedValue.ToString());
                Control ctrlButton = GetControlByText(pnlTable, textTableNumber.Text.ToString());
                // ctrlButton.Name = comboTables.SelectedValue.ToString() + "_" + runningSaleMaster.BillNumber;
                ctrlButton.Name = textTableNumber.Text.ToString() + "_" + runningSaleMaster.BillNumber;
                ((Button)ctrlButton).Enabled = true;

                BaseForm.ButtonPainter(((Button)ctrlButton), Color.Red);
                //}


                GetTable();


                //}
                //else
                //{
                //    MessageBox.Show("Please select table number from combobox!!!");
                //}
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Enabled)
            {

                Frm_AdminPassword frmAdmin = new Frm_AdminPassword();
                Frm_AdminPassword.AdminPassword = "123";
                this.Opacity = 0.30;

                DialogResult dialogresult = frmAdmin.ShowDialog();
                if (!string.IsNullOrEmpty(adminPassword) && adminPassword == "000000")
                {
                    this.Opacity = 1.0;
                    return;

                }

                string adminPasswordAsInDB = "";
                var userAdmin = UserTable.GetByAdminPassword(adminPassword);

                if (userAdmin != null && userAdmin.Id > 0)
                    adminPasswordAsInDB = userAdmin.Password;
                if (adminPasswordAsInDB != "" && adminPassword == adminPasswordAsInDB)
                {
                    //delete all entry from DB
                    // comboTables.Focus();
                    textTableNumber.Focus();

                    SalesMaster.Delete(Convert.ToInt32(lblBillNo.Text));

                    // FreeTable(pnlTable, lblTableNo.Text);
                    ResetForNewGrid();
                    GetTable();
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

        private void btnClose_Click(object sender, EventArgs e)
        {

            //  runningSalesMasterForLoginUser.Add(runningSaleMaster);
            string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;

            if (x != "Administrator")
            {

                if (IsAnyBillPending())
                {

                    MessageBox.Show("Please close all pending bills , before LogOut");
                }
                else
                {
                    this.Close();

                }
            }
            else
            {
                this.Close();

            }

        }


        private void Frm_CounterSale_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;
                if (x != "Administrator")
                {
                    if (IsAnyBillPending())
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please close all pending bills , before LogOut");
                    }
                }
                else if (runningSaleMaster != null && runningSaleMaster.IsBillAlreadyPrinted)
                {
                    e.Cancel = true;
                    MessageBox.Show("Please save opened bill using CTRL + S.");
                }
            }


        }


        public void btnTable_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.30;
            Button btn = (Button)sender as Button;

            if (btn.Name.Contains('_'))
            {
                string billNumber = btn.Name.Split('_')[1];
                string tableNumber = btn.Name.Split('_')[0];
                runningSalesMasterForLoginUser = SalesMaster.GetRunningBillByUserId(long.Parse(GlobalClass.userNameid));


                if (lblBillNo.Text.Trim() != billNumber)
                {
                    for (int i = 0; i < runningSalesMasterForLoginUser.Count; i++)
                    {
                        if (runningSalesMasterForLoginUser[i].BillNumber.ToString() == billNumber)
                        {
                            runningSalesMasterForLoginUser[i].Remarks = "Running Bill";
                            runningSalesMasterForLoginUser[i].Status = (int)RAHMSLibrary.Entity.EntityBase.SalesMasterStatus.Running;
                            SalesMaster.Update(runningSalesMasterForLoginUser[i]);

                            runningSaleMaster = runningSalesMasterForLoginUser[i];// SalesMaster.GetByBillNumber(billNumber);

                            textTableNumber.Text = runningSaleMaster.TableNumber;
                        }
                        else
                        {
                            runningSalesMasterForLoginUser[i].Remarks = "Hold";
                            runningSalesMasterForLoginUser[i].Status = (int)RAHMSLibrary.Entity.EntityBase.SalesMasterStatus.Hold;
                            SalesMaster.Update(runningSalesMasterForLoginUser[i]);
                        }
                    }

                    btn.ForeColor = Color.White;
                    ResetForNewGrid();
                    CreateSalesGridForAllRunningTables(billNumber, tableNumber);

                }
            }
            if (runningSaleMaster.TableNumber == "00")
                BaseForm.PanelPainter(pnlTop, Color.Cyan);
            else
                BaseForm.PanelPainter(pnlTop, Color.Khaki);

            this.Opacity = 1.0;
        }



        private void CreateSalesGridForAllRunningTables(string billNumber, string tableNumber)
        {
            if (tableNumber == "0") tableNumber = "00";
            SalesMaster salesMasterTable = GetSalesMaster(int.Parse(billNumber), tableNumber); // SalesMaster.GetByBillNumberAndTableNumber(billNumber, tableNumber);
            if (salesMasterTable != null && salesMasterTable.ID > 0)
            {
                GridColumnsReadOnly(false);
                AddingItemsToGrid(salesMasterTable);

                lblBillNo.Text = salesMasterTable.BillNumber.Value.ToString();
                cmbOrderType.SelectedValue = salesMasterTable.CustomerId;
                if (Convert.ToInt32(cmbOrderType.SelectedValue.ToString()) > 1)
                {
                    CBPaymentMode.Text = "CREDIT";
                    _PaymentMode = CBPaymentMode.Text;

                }
                else if (Convert.ToInt32(cmbOrderType.SelectedValue.ToString()) == 1)
                {
                    if (salesMasterTable.PaymentMode != null)
                    {
                        CBPaymentMode.Text = salesMasterTable.PaymentMode;
                        _PaymentMode = CBPaymentMode.Text;
                    }
                    else
                    {
                        CBPaymentMode.Text = "CASH";
                        _PaymentMode = CBPaymentMode.Text;
                    }

                }

                // lblTableNo.Text = salesMasterTable.TableNumber;
                textTableNumber.Text = tableNumber;
                if (runningSaleMaster.BillNumber == salesMasterTable.BillNumber)//because running may be updated
                    SetPriceAndTax(runningSaleMaster);
                else
                    SetPriceAndTax(salesMasterTable);
                BindDiscount(false, runningSaleMaster.Discount.ToString());
            }

        }

        private void AddingItemsToGrid(SalesMaster salesMasterTable, bool IsPrintedBill = false)
        {

            dgvItems.Rows.Add();
            dgvItems[0, 0].Value = 1;

            if (!IsPrintedBill)
                dgvItems.CurrentCell = dgvItems[1, 0];
            dgvItems.Focus();
            int col = dgvItems.CurrentCell.ColumnIndex;
            int row = dgvItems.CurrentCell.RowIndex;
            if (salesMasterTable.SalesDetailsList != null && salesMasterTable.SalesDetailsList.Count > 0)
            {

                for (int i = 0; i < salesMasterTable.SalesDetailsList.Count; i++)
                {

                    dgvItems[0, row].Value = row + 1;
                    //   dgvItems[1, row].Value = salesMasterTable.SalesDetailsList[i].ItemMaster.ItemSeriesName + " " + salesMasterTable.SalesDetailsList[i].ItemMaster.Name;
                    string iName = "";
                    decimal? iPrice = 0;
                    if (salesMasterTable.SalesDetailsList[i].ItemMaster != null)
                    {
                        iName = salesMasterTable.SalesDetailsList[i].ItemMaster.ItemSeriesId + " " + salesMasterTable.SalesDetailsList[i].ItemMaster.Name;
                        iPrice = salesMasterTable.SalesDetailsList[i].ItemMaster.Price;
                    }
                    dgvItems[1, row].Value = iName;
                    dgvItems[2, row].Value = iPrice;
                    dgvItems[3, row].Value = salesMasterTable.SalesDetailsList[i].Qty;
                    dgvItems[4, row].Value = salesMasterTable.SalesDetailsList[i].ItemPrice * salesMasterTable.SalesDetailsList[i].Qty;
                    dgvItems[5, row].Value = salesMasterTable.SalesDetailsList[i].ID.Value;
                    dgvItems.Rows[row].DefaultCellStyle.BackColor = Color.LightGreen;
                    row++;


                    dgvItems.Rows.Add();


                }
                if (!IsPrintedBill)
                {
                    currentCell = dgvItems[1, row];
                    dgvItems.CurrentCell = currentCell;
                }

                RefreshSerialNumber();

            }

        }
        void comboTables_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        bool IsTableFree(string text)
        {
            //for (int i = 0; i <  comboTables.Items.Count; i++)
            //{
            //    RAHMS.TableClass tableClass = (RAHMS.TableClass)comboTables.Items[i] as RAHMS.TableClass;
            //    if (text == tableClass.Name)
            //        return true;
            //}

            var salesmaster = SalesMaster.GetOpenBillByUserId(long.Parse(GlobalClass.userNameid));
            if (salesmaster != null && salesmaster.Count > 0)
            {
                for (int i = 0; i < salesmaster.Count; i++)
                {
                    if (text == salesmaster[i].TableNumber)
                        return false;
                }
            }
            textTableNumber.Focus();
            return true;
        }
        void comboTables_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && !IsFormLoad)
            {
                //generate bill and focus on save button   
                if (IsTableFree(textTableNumber.Text))
                //  if (IsTableFree(comboTables.Text))
                {
                    btnSave.Enabled = true;
                    BaseForm.ButtonPainter(btnSave, Color.Green);
                    btnSave.ForeColor = Color.White;
                    btnSave.Focus();

                    btnClose.Enabled = false;
                    btnCancel.Enabled = false;
                    btnAdd.Enabled = false;


                    lblBillNo.ForeColor = Color.Orange;
                    lblBillNo.Text = GetNewBill().ToString();

                    // comboTables.Enabled = false;
                }
            }
            IsFormLoad = false;

        }
        #region Private Functions
        private Control GetControlByText(Panel panel, string text, bool IsTakeAway = false)
        {
            if (text == "0") text = "00";
            if (IsTakeAway)
            {
                if (panel != null && panel.Controls != null)
                {
                    foreach (Control c in panel.Controls)
                        if (c.Text == "00 -" + text)
                            return c;
                }
            }
            else
            {
                if (panel != null && panel.Controls != null)
                {
                    foreach (Control c in panel.Controls)
                        if (c.Text == "Table -" + text)
                            return c;
                }
            }
            return null;
        }
        private void FreeTable(Panel btnPanel, string tableName, bool IsTakeAway = false)
        {
            Control ctrlButton = GetControlByText(btnPanel, tableName, IsTakeAway);

            if (IsTakeAway)
            {
                btnPanel.Controls.Remove(ctrlButton);
            }
            else
            {
                ((Button)ctrlButton).Enabled = false;
                BaseForm.ButtonPainter(((Button)ctrlButton), Color.Cyan);
            }
        }

        static IList<SalesMaster> runningSalesMasterForLoginUser = new List<SalesMaster>();

        private void GetTable()
        {
            bool IsPendingBillexist = false;
            int buttonLocationx = 20;
            int buttonLocationy = 20;
            int buttonLocationTakeAwayx = 20;
            int buttonLocationTakeAwayy = 20;
            int tabIndex = 20;
            var locations = RAHMSLibrary.Entity.Masters.SeatingLocation.GetAll();
            TableCount = Convert.ToInt16(locations[0].Seats);
            //   pnlTakeAway.Controls.Clear();

            runningSalesMasterForLoginUser = SalesMaster.GetRunningBillByUserId(long.Parse(GlobalClass.userNameid));
            if (runningSalesMasterForLoginUser != null && runningSalesMasterForLoginUser.Count > 0)
            {
                runningSaleMaster = null;
            }
            //check if not bill in running status than make latest to in running status
            CheckIfAnyOneInRunningStatusOrNot(runningSalesMasterForLoginUser);
            //foreach (SalesMaster sm in runningSalesMasterForLoginUser)
            //{
            //    if (sm.TableNumber == "00")
            //    {
            //        TakeAway(ref IsPendingBillexist, buttonLocationTakeAwayx, ref buttonLocationTakeAwayy, ref tabIndex, sm);
            //    }
            //}

            TableSale(ref IsPendingBillexist, buttonLocationx, ref buttonLocationy, ref tabIndex, locations);



            if (runningSaleMaster != null && runningSaleMaster.TableNumber == "00")
                BaseForm.PanelPainter(pnlTop, Color.Cyan);
            else
                BaseForm.PanelPainter(pnlTop, Color.Khaki);

            if (runningSaleMaster != null)
                cmbOrderType.SelectedValue = runningSaleMaster.CustomerId;
        }
        bool IsGridOpen = false;
        //private void TakeAway(ref bool IsPendingBillexist, int buttonLocationx, ref int buttonLocationy, ref int tabIndex, SalesMaster salesMasterBillStatus)
        //{
        //    if (salesMasterBillStatus != null && salesMasterBillStatus.ID > 0)
        //    {

        //        if (salesMasterBillStatus.Status.Value == 1 || salesMasterBillStatus.Status.Value == 2)
        //        {
        //            Button btn = GetTableButton(salesMasterBillStatus.BillNumber.ToString(), "00 -" + salesMasterBillStatus.BillNumber.ToString(), buttonLocationx, buttonLocationy, tabIndex, Color.Red);
        //            btn.Name = salesMasterBillStatus.TableNumber + "_" + salesMasterBillStatus.BillNumber;
        //            pnlTakeAway.Controls.Add(btn);
        //            buttonLocationy += 30;
        //            tabIndex++;

        //            IsPendingBillexist = true;
        //            if (!IsGridOpen)
        //            {
        //                IsGridOpen = true;
        //                runningSaleMaster = salesMasterBillStatus;

        //                btnSave.Enabled = false;
        //                btnClose.Enabled = true;
        //                BaseForm.ButtonPainter(btnClose, Color.Green);
        //                btnClose.ForeColor = Color.White;

        //                btnAdd.Enabled = true;
        //                BaseForm.ButtonPainter(btnAdd, Color.Green);
        //                btnAdd.ForeColor = Color.White;

        //                CreateSalesGridForAllRunningTables(salesMasterBillStatus.BillNumber.ToString(), salesMasterBillStatus.TableNumber);
        //            }
        //        }
        //        else
        //        {
        //            Button btn = GetTableButton(salesMasterBillStatus.BillNumber.ToString(), "00 -" + salesMasterBillStatus.BillNumber.ToString(), buttonLocationx, buttonLocationy, tabIndex, Color.Red);
        //            btn.Name = salesMasterBillStatus.TableNumber + "_" + salesMasterBillStatus.BillNumber;
        //            pnlTakeAway.Controls.Add(btn);
        //            buttonLocationy += 30;
        //            tabIndex++;
        //        }
        //    }
        //}
        private void TableSale(ref bool IsPendingBillexist, int buttonLocationx, ref int buttonLocationy, ref int tabIndex, IList<SeatingLocation> locations)
        {
            if (locations != null && locations.Count > 0)
            {
                List<TableClass> tableList = new List<TableClass>();
                //TableClass objSelect = new TableClass();
                //objSelect.Id = "0";
                //objSelect.Name = "00";
                //  tableList.Add(objSelect);
                foreach (var location in locations)
                {
                    for (int i = 0; i < location.Seats + 1; i++)
                    {
                        string name1 = i.ToString();
                        if (i == 0) name1 = "00";
                        var salesMasterBillStatus = GetSalesMaster(runningSalesMasterForLoginUser, i);
                        if (salesMasterBillStatus != null && salesMasterBillStatus.ID > 0)
                        {
                            // for take away so button 0 will not be considered

                            Button btn = GetTableButton(i.ToString(), "Table -" + name1, buttonLocationx, buttonLocationy, tabIndex, Color.Red);
                            btn.Name = salesMasterBillStatus.TableNumber + "_" + salesMasterBillStatus.BillNumber;
                            pnlTable.Controls.Add(btn);
                            buttonLocationy += 30;
                            tabIndex++;

                            if (salesMasterBillStatus.Status.Value == 1 || salesMasterBillStatus.Status.Value == 2)
                            {
                                IsPendingBillexist = true;
                                if (!IsGridOpen)
                                {
                                    IsGridOpen = true;
                                    runningSaleMaster = salesMasterBillStatus;

                                    btn.ForeColor = Color.White;

                                    btnSave.Enabled = false;
                                    btnClose.Enabled = true;
                                    BaseForm.ButtonPainter(btnClose, Color.Green);
                                    btnClose.ForeColor = Color.White;

                                    btnAdd.Enabled = true;
                                    BaseForm.ButtonPainter(btnAdd, Color.Green);
                                    btnAdd.ForeColor = Color.White;

                                    CreateSalesGridForAllRunningTables(salesMasterBillStatus.BillNumber.ToString(), salesMasterBillStatus.TableNumber);
                                }
                            }

                        }
                        else
                        {
                            Button btn = GetTableButton(i.ToString(), "Table -" + name1, buttonLocationx, buttonLocationy, tabIndex, Color.Cyan);
                            btn.Enabled = false;
                            pnlTable.Controls.Add(btn);
                            buttonLocationy += 30;
                            tabIndex++;

                            TableClass tblBtn = new TableClass();
                            tblBtn.Id = i.ToString();
                            tblBtn.Name = i == 0 ? i.ToString() + "0" : i.ToString();
                            tableList.Add(tblBtn);
                        }
                    }
                }

                //if (!IsPendingBillexist)
                //{
                //    comboTables.ValueMember = "Id";
                //    comboTables.DisplayMember = "Name";
                //    comboTables.DataSource = tableList;
                //    comboTables.Enabled = true;
                //}
                //else
                //{
                //    comboTables.ValueMember = "Id";
                //    comboTables.DisplayMember = "Name";
                //    comboTables.DataSource = tableList;
                //    // comboTables.Enabled = false;
                //}
                if (runningSaleMaster != null)
                    // comboTables.Text = runningSaleMaster.TableNumber;
                    textTableNumber.Text = runningSaleMaster.TableNumber;
                else
                    textTableNumber.Text = "";
            }
        }

        private static SalesMaster GetSalesMaster(IList<SalesMaster> salesMaster, int i)
        {
            string tblNumber = i == 0 ? "00" : i.ToString();
            if (salesMaster != null && salesMaster.Count > 0)
            {
                for (int j = 0; j < salesMaster.Count; j++)
                {
                    if (salesMaster[j].TableNumber == tblNumber)
                        return salesMaster[j];
                }
            }
            return null;
        }
        private void CheckIfAnyOneInRunningStatusOrNot(IList<SalesMaster> salesMaster)
        {
            if (salesMaster != null && salesMaster.Count > 0)
            {
                var chkStatus = salesMaster.Where(st => st.Status == 2 || st.Status == 1);
                if (chkStatus.FirstOrDefault() == null)
                {
                    SalesMaster sm = salesMaster[0];
                    sm.Status = 2;
                    SalesMaster.Update(sm);
                }
            }
            else
            {

                //ResetForNewGrid();

                //btnAdd.Enabled = false;
                //btnCancel.Enabled = false;
                //btnClose.Enabled = false;
                //btnSave.Enabled = false;
                //btnCancel.Enabled = false;

                //comboTables.Enabled = true;
                //comboTables.Focus();
                textTableNumber.Text = string.Empty;
                textTableNumber.Enabled = true;
                textTableNumber.Focus();

                lblBillNo.Text = "";
                // lblTableNo.Text = "";
                lblAmount.Text = "0.0";
                lblNetAmount.Text = "0.0";
                //lblTotalTax.Text = "0.0";
                // lblPercentage.Text = "0%";
                lblDiscountAmont.Text = "0.0";
                runningSaleMaster = null;

                for (int i = 0; i < arrTaxValue.Count; i++)
                {
                    Label lblValue = (Label)arrTaxValue[i];
                    lblValue.Text = "0.0";
                }


            }
        }
        private static SalesMaster GetSalesMaster(int billNumber, string tableNumber)
        {
            if (runningSalesMasterForLoginUser != null && runningSalesMasterForLoginUser.Count > 0)
            {
                for (int i = 0; i <= runningSalesMasterForLoginUser.Count; i++)
                {
                    if (runningSalesMasterForLoginUser[i].TableNumber == tableNumber && runningSalesMasterForLoginUser[i].BillNumber.Value == billNumber)
                        return runningSalesMasterForLoginUser[i];
                }

            }
            return null;
        }
        private Button GetTableButton(string Id, string Name, int x, int y, int tabIndex, System.Drawing.Color color)
        {
            Button btnTable = new Button();
            btnTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTable.Location = new System.Drawing.Point(x, y);
            btnTable.Name = Id;
            //btnTable.Enabled = false;
            btnTable.Size = new System.Drawing.Size(100, 25);
            btnTable.TabIndex = tabIndex;
            btnTable.Text = Name;
            BaseForm.ButtonPainter(btnTable, color);
            btnTable.Click += new EventHandler(btnTable_Click);
            //btnTable.DoubleClick += new EventHandler(btnTable_DoubleClick);
            btnTable.ForeColor = Color.Black;
            return btnTable;
        }

        #endregion Private Functions
        #region Bill Related
        int GetNewBill()
        {
            return SalesMaster.GetNewBillNumber().Value + 1;
        }
        private void InsertSaleMaster(int billNumber, string tableNo)
        {
            SalesMaster salesMasterObject = new SalesMaster()
            {
                BillNumber = billNumber,
                TableNumber = tableNo,
                CustomerId = Convert.ToInt32(cmbOrderType.SelectedValue),
                Amount = 0,
                Taxes = 0,
                IsValid = 1,
                TotalAmount = 0,
                Discount = 0,
                Status = (int)RAHMSLibrary.Entity.EntityBase.SalesMasterStatus.Created,
                CreatedBy = long.Parse(GlobalClass.userNameid),
                ModifiedBy = long.Parse(GlobalClass.userNameid),
                Remarks = "Bill Created",

            };
            int ret = SalesMaster.Insert(salesMasterObject);
            if (ret > 0)
            {
                if (runningSaleMaster != null && runningSaleMaster.Status != 4)
                {
                    runningSaleMaster.Remarks = "Hold";
                    runningSaleMaster.Status = (int)RAHMSLibrary.Entity.EntityBase.SalesMasterStatus.Hold;
                    SalesMaster.Update(runningSaleMaster);
                    runningSaleMaster = null;
                }
                runningSaleMaster = SalesMaster.GetById(ret);
            }
        }
        private void DeleteSaleDetails(ItemMaster itemMaster, int quantity, int salesDetailsId)
        {
            RAHMSLibrary.Entity.Sales.SalesDetails salesDetails = runningSaleMaster.SalesDetailsList.Where(sd => sd.ID.Value == salesDetailsId).First<SalesDetails>();
            int ret = RAHMSLibrary.Entity.Sales.SalesDetails.Delete(salesDetails);

            if (ret >= 0)
            {
                //update sales master
                runningSaleMaster = SalesMaster.GetByBillNumber(runningSaleMaster.BillNumber.ToString());

                if (runningSaleMaster.SalesDetailsList != null)
                {
                    runningSaleMaster.Taxes = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes);
                    runningSaleMaster.OriginalTaxAmount = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes).Value;

                    runningSaleMaster.Amount = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Amount);
                }
                else
                {
                    runningSaleMaster.Taxes = 0;
                    runningSaleMaster.Amount = 0;
                }
                SalesMaster.Update(runningSaleMaster);

            }
        }
        private void UpdateSaleDetails(ItemMaster itemMaster, int quantity, int salesDetailsId)
        {
            RAHMSLibrary.Entity.Sales.SalesDetails salesDetails = runningSaleMaster.SalesDetailsList.Where(sd => sd.ID.Value == salesDetailsId).First<SalesDetails>();
            if (runningSaleMaster.Discount != 0)
                salesDetails.Amount = itemMaster.Price * quantity - ((itemMaster.Price * quantity) * runningSaleMaster.Discount / 100);
            else
                salesDetails.Amount = itemMaster.Price * quantity;

            salesDetails.Qty = quantity;
            salesDetails.ModifiedBy = runningSaleMaster.ModifiedBy;
            // salesDetails.Remarks = itemMaster.ItemSeriesName + " " + itemMaster.Name;
            salesDetails.Remarks = itemMaster.ItemSeriesId + " " + itemMaster.Name;
            salesDetails.ItemPrice = itemMaster.Price;
            salesDetails.ItemId = itemMaster.ID;

            decimal totalTax = 0;
            decimal _totalTaxAfterdiscount = 0;
            IList<SalesTaxDetails> salesTaxDetailsList = GetSalesTaxDetailListObject(itemMaster, quantity, out totalTax, Convert.ToInt32(cmbOrderType.SelectedValue.ToString()));
            foreach (var saleTaxitem in salesTaxDetailsList)
            {
                if (runningSaleMaster.Discount != 0) { saleTaxitem.Amount = saleTaxitem.Amount - (saleTaxitem.Amount * runningSaleMaster.Discount / 100); }
                else { saleTaxitem.Amount = saleTaxitem.Amount; }
                _totalTaxAfterdiscount += saleTaxitem.Amount.Value;
            }
            salesDetails.Taxes = _totalTaxAfterdiscount;

            int ret = RAHMSLibrary.Entity.Sales.SalesDetails.Update(salesDetails);

            //var salesDetailsid = RAHMSLibrary.Entity.Sales.SalesDetails.GetById(salesDetails.ID);
            if (ret > 0)
            {
                if (salesTaxDetailsList != null)
                {
                    for (int i = 0; i < salesTaxDetailsList.Count; i++)
                    {
                        salesTaxDetailsList[i].SalesDetailsId = salesDetails.SalesTaxDetailsList[i].SalesDetailsId;
                        salesTaxDetailsList[i].ID = salesDetails.SalesTaxDetailsList[i].ID;
                        SalesTaxDetails.Update(salesTaxDetailsList[i]);


                    }
                }
                //update sales master
                runningSaleMaster = SalesMaster.GetByBillNumber(runningSaleMaster.BillNumber.ToString());

                if (salesTaxDetailsList != null)
                {
                    runningSaleMaster.Taxes = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes);
                    runningSaleMaster.OriginalTaxAmount = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes).Value;
                }
                decimal _amount = 0;
                foreach (var item in runningSaleMaster.SalesDetailsList)
                {
                    _amount += item.ItemPrice.Value * item.Qty.Value;
                }
                runningSaleMaster.Amount = _amount;

                SalesMaster.Update(runningSaleMaster);

            }

        }
        private int InsertSaleDetails(ItemMaster itemMaster, int quantity, int gridSno)
        {

            RAHMSLibrary.Entity.Sales.SalesDetails salesDetails = new RAHMSLibrary.Entity.Sales.SalesDetails();
            if (runningSaleMaster.Discount != 0)
                salesDetails.Amount = itemMaster.Price * quantity - ((itemMaster.Price * quantity) * runningSaleMaster.Discount / 100);
            else
                salesDetails.Amount = itemMaster.Price * quantity;

            // salesDetails.Amount = itemMaster.Price * quantity;
            salesDetails.ItemId = itemMaster.ID;
            salesDetails.SaleMasterId = runningSaleMaster.ID;
            salesDetails.BillNumber = runningSaleMaster.BillNumber;
            salesDetails.Description = runningSaleMaster.TableNumber;
            salesDetails.Qty = quantity;
            salesDetails.CreatedBy = runningSaleMaster.CreatedBy;
            salesDetails.ModifiedBy = runningSaleMaster.ModifiedBy;
            salesDetails.IsValid = 1;
            salesDetails.ItemPrice = itemMaster.Price;
            salesDetails.GridSNo = gridSno;
            //salesDetails.Remarks = itemMaster.ItemSeriesName + " " + itemMaster.Name;
            salesDetails.Remarks = itemMaster.ItemSeriesId + " " + itemMaster.Name;
            //get list of salesTaxDetails object to enter in db
            decimal totalTax = 0;
            decimal _totalTaxAfterdiscount = 0;
            IList<SalesTaxDetails> salesTaxDetailsList = GetSalesTaxDetailListObject(itemMaster, quantity, out totalTax, Convert.ToInt32(cmbOrderType.SelectedValue.ToString()));
            foreach (var saleTaxitem in salesTaxDetailsList)
            {
                if (runningSaleMaster.Discount != 0) { saleTaxitem.Amount = saleTaxitem.Amount - (saleTaxitem.Amount * runningSaleMaster.Discount / 100).Value; }
                else { saleTaxitem.Amount = saleTaxitem.Amount; }
                _totalTaxAfterdiscount += saleTaxitem.Amount.Value;
            }
            salesDetails.Taxes = _totalTaxAfterdiscount;

            int ret = RAHMSLibrary.Entity.Sales.SalesDetails.Insert(salesDetails);

            if (ret > 0)
            {
                if (salesTaxDetailsList != null)
                {
                    for (int i = 0; i < salesTaxDetailsList.Count; i++)
                    {
                        salesTaxDetailsList[i].SalesDetailsId = ret;
                        SalesTaxDetails.Insert(salesTaxDetailsList[i]);
                    }
                }

                //update sales master
                //no need to get again because all are updated in running bill
                //runningSaleMaster = SalesMaster.GetByBillNumber(runningSaleMaster.BillNumber.ToString());

                if (salesTaxDetailsList != null)
                {
                    runningSaleMaster.OriginalTaxAmount = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes).Value;
                    runningSaleMaster.Taxes = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes);
                }

                decimal _amount = 0;
                foreach (var item in runningSaleMaster.SalesDetailsList)
                {
                    _amount += item.ItemPrice.Value * item.Qty.Value;
                }
                runningSaleMaster.Amount = _amount;
                // runningSaleMaster.Amount = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Amount);
                runningSaleMaster.Remarks = "Running Bill";
                //runningSaleMaster.PaymentMode = string.Empty;
                runningSaleMaster.Status = (int)RAHMSLibrary.Entity.EntityBase.SalesMasterStatus.Running;
                SalesMaster.Update(runningSaleMaster);

                //Print KOT Bill
                //PrintKOT(itemMaster.Name, quantity, runningSaleMaster.TableNumber);
            }
            return ret;
        }

        private static IList<SalesTaxDetails> GetSalesTaxDetailListObject(ItemMaster itemMaster, int Quantity, out decimal totalTax, int ordertype)
        {
            totalTax = 0;
            IList<SalesTaxDetails> salesTaxDetailsList = new List<SalesTaxDetails>();
            if (ordertype > 1)
                return salesTaxDetailsList;
            if (itemMaster.IsTaxable == 1 && itemMaster.TaxAppliedList != null)
            {
                //IList<SalesTaxDetails> salesTaxDetailsList = new List<SalesTaxDetails>();
                for (int i = 0; i < itemMaster.TaxAppliedList.Count; i++)
                {
                    // decimal y = 1.256m;
                    //decimal x =  Math.Round(y,4);

                    SalesTaxDetails salesTaxDetails = new SalesTaxDetails
                    {


                        TaxId = itemMaster.TaxAppliedList[i].TaxDetails.ID,
                        TaxName = itemMaster.TaxAppliedList[i].TaxDetails.Name,
                        TaxRate = itemMaster.TaxAppliedList[i].TaxDetails.Rate,
                        Amount = Math.Round((itemMaster.Price * Quantity * itemMaster.TaxAppliedList[i].TaxDetails.Rate / 100).Value, 4),
                        IsValid = 1,
                        // Description = itemMaster.ID + " " + itemMaster.ItemSeriesName + " " + itemMaster.Name,
                        Description = itemMaster.ID + " " + itemMaster.ItemSeriesId + " " + itemMaster.Name,
                        CreatedBy = long.Parse(GlobalClass.userNameid),
                        ModifiedBy = long.Parse(GlobalClass.userNameid)
                    };
                    totalTax += salesTaxDetails.Amount.Value;
                    salesTaxDetailsList.Add(salesTaxDetails);
                }
                return salesTaxDetailsList;
            }
            return null;
        }

        #endregion Bill related



        #region Grid Related
        DataGridView dgvItems = new DataGridView();
        // ItemMaster itemMaster = null;
        DataGridViewCell currentCell = null;
        private DataGridViewCell _celWasEndEdit;
        IList<ItemMaster> itemList = new List<ItemMaster>();
        AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
        void ResetForNewGrid()
        {
            IsGridOpen = false;
            dgvItems.Rows.Clear();
            dgvItems.Refresh();

        }
        private void CreateDataGridView()
        {
            dgvItems = new DataGridView();
            dgvItems.DataSource = null;

            dgvItems.BackgroundColor = System.Drawing.Color.White;
            dgvItems.BorderStyle = BorderStyle.None;
            dgvItems.Size = new System.Drawing.Size(910, 500);
            dgvItems.ColumnHeadersHeight = 40;
            dgvItems.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            dgvItems.DefaultCellStyle.Font = new Font("Tahoma", 18);

            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Bold);

            dgvItems.Name = "dgvItem";
            dgvItems.RowTemplate.Height = 35;

            dgvItems.TabIndex = 0;
            // dgvItems.ColumnHeadersDefaultCellStyle = GetDataGridViewCellStyle();

            dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvItems.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvItems.KeyDown += new KeyEventHandler(Control_KeyDown);
            dgvItems.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvItems_EditingControlShowing);
            dgvItems.CellEndEdit += new DataGridViewCellEventHandler(dgvItems_CellEvent);
            dgvItems.CellEnter += dgvItems_CellEnter;
            dgvItems.CellLeave += dgvItems_CellLeave;
            dgvItems.SelectionChanged += new EventHandler(dgvItems_SelectionChanged);


            DataGridViewTextBoxColumn dgvTxtBoxColumnSrNo = new DataGridViewTextBoxColumn();
            dgvTxtBoxColumnSrNo.HeaderText = "SrNo";
            dgvTxtBoxColumnSrNo.Name = "dgvTxtBoxColumnSrNo";
            dgvTxtBoxColumnSrNo.Width = 80;

            dgvTxtBoxColumnSrNo.ReadOnly = true;
            dgvTxtBoxColumnSrNo.Resizable = DataGridViewTriState.True;
            dgvItems.Columns.Add(dgvTxtBoxColumnSrNo);


            DataGridViewTextBoxColumn dgvTxtBoxColumnItem_Name = new DataGridViewTextBoxColumn();
            dgvTxtBoxColumnItem_Name.HeaderText = "Item_Name";
            dgvTxtBoxColumnItem_Name.Name = "dgvTxtBoxColumnItem_Name";
            dgvTxtBoxColumnItem_Name.Width = 450;
            dgvTxtBoxColumnItem_Name.ReadOnly = false;
            dgvTxtBoxColumnItem_Name.Resizable = DataGridViewTriState.True;
            dgvItems.Columns.Add(dgvTxtBoxColumnItem_Name);

            DataGridViewTextBoxColumn dgvTxtBoxColumnRate = new DataGridViewTextBoxColumn();
            dgvTxtBoxColumnRate.HeaderText = "Rate";
            dgvTxtBoxColumnRate.Name = "dgvTxtBoxColumnRate";
            dgvTxtBoxColumnRate.Width = 100;
            dgvTxtBoxColumnRate.DefaultCellStyle.ForeColor = Color.Red;
            dgvTxtBoxColumnRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTxtBoxColumnRate.ReadOnly = false;

            dgvTxtBoxColumnRate.Resizable = DataGridViewTriState.True;
            dgvItems.Columns.Add(dgvTxtBoxColumnRate);


            //DataGridViewTextBoxColumn dgvTxtBoxColumnTax = new DataGridViewTextBoxColumn();
            //dgvTxtBoxColumnRate.HeaderText = "Tax";
            //dgvTxtBoxColumnRate.Name = "dgvTxtBoxColumnTax";
            //dgvTxtBoxColumnRate.Width = 100;
            //dgvTxtBoxColumnRate.DefaultCellStyle.ForeColor = Color.Red;
            //dgvTxtBoxColumnRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvTxtBoxColumnRate.ReadOnly = false;

            //dgvTxtBoxColumnRate.Resizable = DataGridViewTriState.True;
            //dgvItems.Columns.Add(dgvTxtBoxColumnTax);

            DataGridViewTextBoxColumn dgvTxtBoxColumnQty = new DataGridViewTextBoxColumn();

            dgvTxtBoxColumnQty.HeaderText = "Qty";
            dgvTxtBoxColumnQty.Name = "dgvTxtBoxColumnQty";
            dgvTxtBoxColumnQty.Width = 70;
            dgvTxtBoxColumnQty.MaxInputLength = 2;
            dgvTxtBoxColumnQty.ReadOnly = false;
            dgvTxtBoxColumnQty.Resizable = DataGridViewTriState.True;

            dgvItems.Columns.Add(dgvTxtBoxColumnQty);


            DataGridViewTextBoxColumn dgvTxtBoxColumnAmount = new DataGridViewTextBoxColumn();
            dgvTxtBoxColumnAmount.HeaderText = "Net Amount";
            dgvTxtBoxColumnAmount.Name = "dgvTxtBoxColumnAmount";
            dgvTxtBoxColumnAmount.Width = 110;
            dgvTxtBoxColumnAmount.DefaultCellStyle.ForeColor = Color.Red;
            dgvTxtBoxColumnAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTxtBoxColumnAmount.ReadOnly = false;
            dgvTxtBoxColumnAmount.Resizable = DataGridViewTriState.True;
            dgvItems.Columns.Add(dgvTxtBoxColumnAmount);

            DataGridViewTextBoxColumn dgvTxtBoxColumnHidden = new DataGridViewTextBoxColumn();
            dgvTxtBoxColumnHidden.HeaderText = "Hidden";
            dgvTxtBoxColumnHidden.Name = "dgvTxtBoxColumnSrNo";
            dgvTxtBoxColumnHidden.Width = 20;
            dgvTxtBoxColumnHidden.ReadOnly = true;
            dgvTxtBoxColumnHidden.Visible = false;
            dgvTxtBoxColumnHidden.Resizable = DataGridViewTriState.True;
            dgvItems.Columns.Add(dgvTxtBoxColumnHidden);

            dgvItems.GridColor = Color.Silver;

            dgvItems.BackgroundImage = BaseForm.Gradient2D(dgvItems.ClientRectangle);

            dgvItems.AllowUserToAddRows = false;
            //dgvItems.RowCount = 15;
            // dgvItems.Rows.Add();
            // dgvItems[0, 0].Value = 1;

            // dgvItems.CurrentCell = dgvItems[1, 0];  
            dgvItems.AllowUserToResizeColumns = false;
            dgvItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvItems.AllowUserToResizeRows = false;
            dgvItems.Focus();

            pnlGrid.Controls.Add(dgvItems);
        }
        private void PriceCalculate(int ItemQuantity, ItemMaster itemMaster, SalesMaster salesMaster, string NewOrUpdate)
        {

            if (itemMaster != null && salesMaster != null)
            {

                if (ItemQuantity > 0)
                {

                    switch (NewOrUpdate)
                    {
                        case "Delete":

                            DeleteSaleDetails(itemMaster, ItemQuantity, int.Parse(dgvItems[5, dgvItems.CurrentRow.Index].Value.ToString()));
                            break;
                        case "Update":
                            decimal amount = (itemMaster.Price.Value * ItemQuantity);
                            dgvItems[4, dgvItems.CurrentCell.RowIndex].Value = amount.ToString();
                            dgvItems[4, dgvItems.CurrentCell.RowIndex].ReadOnly = true;

                            UpdateSaleDetails(itemMaster, ItemQuantity, int.Parse(dgvItems[5, dgvItems.CurrentRow.Index].Value.ToString()));
                            break;
                        case "New":
                            amount = (itemMaster.Price.Value * ItemQuantity);
                            dgvItems[4, dgvItems.CurrentCell.RowIndex].Value = amount.ToString();
                            dgvItems[4, dgvItems.CurrentCell.RowIndex].ReadOnly = true;

                            dgvItems[5, dgvItems.CurrentCell.RowIndex].Value = amount.ToString();
                            dgvItems[5, dgvItems.CurrentCell.RowIndex].ReadOnly = true;

                            int salesDetaiilsId = InsertSaleDetails(itemMaster, ItemQuantity, int.Parse(dgvItems[0, dgvItems.CurrentRow.Index].Value.ToString()));

                            dgvItems[5, dgvItems.CurrentCell.RowIndex].Value = salesDetaiilsId;
                            break;
                    }
                    SetPriceAndTax(runningSaleMaster);
                }

            }

        }
        public void AddItem(AutoCompleteStringCollection col)
        {
            if (itemList != null && itemList.Count <= 0)
            {
                if (itemList != null && itemList.Count <= 0)
                    itemList = ItemMaster.GetAll();

                foreach (var item in itemList)
                {
                    // col.Add(item.ItemSeriesName.Split(' ')[0].ToString() + " " + item.Name);
                    col.Add(item.ItemSeriesId.ToString() + " " + item.Name);
                }
            }
        }
        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridView dgvItems = (DataGridView)sender as DataGridView;
                if (dgvItems.CurrentCell.ColumnIndex == 1)
                {
                    string titleText = dgvItems.Columns[1].HeaderText;
                    if (titleText.Equals("Item_Name"))
                    {
                        TextBox autoItemCode = e.Control as TextBox;
                        if (autoItemCode != null)
                        {
                            autoItemCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            autoItemCode.Font = new Font(autoItemCode.Font.FontFamily, 20F);
                            autoItemCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AddItem(DataCollection);
                            autoItemCode.AutoCompleteCustomSource = DataCollection;

                            autoItemCode.Leave += new EventHandler(textBoxItemCode_Leave);
                        }
                        autoItemCode.Leave += new EventHandler(textBoxItemCode_Leave);

                    }
                }
                else
                {

                    TextBox autoItemCode = e.Control as TextBox;
                    if (autoItemCode != null)
                    {
                        autoItemCode.AutoCompleteMode = AutoCompleteMode.None;
                    }
                    if (dgvItems.CurrentCell.ColumnIndex == 3)
                    {

                        autoItemCode.KeyPress += new KeyPressEventHandler(textBoxQty_KeyPress);
                    }
                }
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxItemCode_Leave(object sender, System.EventArgs e)
        {
            TextBox textBoxItemCode = (TextBox)sender as TextBox;
            if (string.IsNullOrEmpty(textBoxItemCode.Text))
            {
                textBoxItemCode.Focus();
                return;
            }
            else
            {
                if (DataCollection.Contains(textBoxItemCode.Text.Trim()))
                {
                    textBoxItemCode.BackColor = System.Drawing.Color.White;
                    textBoxItemCode.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    textBoxItemCode.BackColor = System.Drawing.Color.Red;
                    textBoxItemCode.ForeColor = System.Drawing.Color.White;
                    textBoxItemCode.Focus();
                }
            }
        }
        private void textBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        void dgvItems_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgvItems = (DataGridView)sender as DataGridView;
            if (dgvItems.Rows[e.RowIndex].Cells[1].Value != null)
                dgvItems.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;


        }
        void dgvItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgvItems = (DataGridView)sender as DataGridView;
            if (dgvItems.Rows[e.RowIndex].Cells[1].Value != null)
                dgvItems.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;


        }
        private ItemMaster GetItem(string itemName)
        {
            ItemMaster itemMasterRet = new ItemMaster();
            if (itemList != null && itemList.Count > 0)
            {
                var itemNM = from item in itemList
                             where item.Name == itemName
                             select item;

                if (itemNM != null && itemNM.Count() > 0)
                    return itemMasterRet = itemNM.First<ItemMaster>();
            }
            else
                return itemMasterRet = ItemMaster.GetByName(itemName.Trim());
            return null;
        }


        private void dgvItems_CellEvent(object sender, DataGridViewCellEventArgs e)
        {

            if (runningSaleMaster != null && runningSaleMaster.Status == 4)
                return;
            DataGridView dgvItems = (DataGridView)sender as DataGridView;
            int col = dgvItems.CurrentCell.ColumnIndex;
            int row = dgvItems.CurrentCell.RowIndex;
            if (col == 1 || col == 3)
            {
                if (dgvItems.CurrentCell.Value != null)
                {
                    if (!dgvItems.CurrentCell.Value.ToString().Contains(" ") && dgvItems.CurrentCell.ColumnIndex == 1)
                    {
                        MessageBox.Show("Please select series code ex. 100/200/300...!");
                        //currentCell = dgvItems[col, row];
                        // e.Handled = true;
                        return;
                    }
                    //dgvItems.CurrentCell = dgvItems[col, row];
                    currentCell = dgvItems[col, row];
                }
                else
                {
                    if (dgvItems.CurrentCell.ColumnIndex == 1)
                        MessageBox.Show("Please select series code ex. 100/200/300...!");
                    if (dgvItems.CurrentCell.ColumnIndex == 3)
                        MessageBox.Show("Please enter quantity!");
                    // e.Handled = true;
                    return;
                }
            }
            try
            {
                if (col == 1 || col == 3)
                {
                    string itemName = dgvItems[1, row].Value.ToString().Substring(dgvItems[1, row].Value.ToString().IndexOf(' '), dgvItems[1, row].Value.ToString().Length - dgvItems[1, row].Value.ToString().IndexOf(' '));
                    ItemMaster itemMaster = GetItem(itemName.Trim());
                    if (itemMaster != null)
                    {
                        if (col < dgvItems.ColumnCount - 3)
                        {
                            col = col + 2;
                        }
                        else
                        {
                            col = 0;
                            row++;
                        }
                        if (col == 3)
                        {
                            if (itemMaster != null)
                            {
                                // dgvItems[2, row].Style.BackColor = Color.White;
                                dgvItems[2, row].Style.ForeColor = Color.OrangeRed;

                                dgvItems[2, row].Value = itemMaster.Price;
                                dgvItems[2, row].ReadOnly = true;

                            }
                            else
                            {
                                MessageBox.Show("Please select series code ex. 100/200/300...! 3 " + dgvItems.CurrentCell.RowIndex);
                                //  e.Handled = true;
                                return;
                            }
                        }
                        if (row == dgvItems.RowCount)
                        {
                            if (dgvItems[1, row - 1].Value != null && dgvItems[3, row - 1].Value != null && DataCollection.Contains(dgvItems[1, row - 1].Value.ToString().Trim()))
                            {
                                int quantity = int.Parse(dgvItems.CurrentCell.Value.ToString());
                                if (quantity > 0)
                                {
                                    if (dgvItems.RowCount >= 15)
                                    {
                                        PriceCalculate(quantity, itemMaster, runningSaleMaster, "New");
                                        dgvItems.Rows[dgvItems.CurrentRow.Index - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                                        MessageBox.Show("No more Item can be added.");
                                        return;
                                    }
                                    else
                                    {

                                        PriceCalculate(quantity, itemMaster, runningSaleMaster, "New");
                                        dgvItems.Rows.Add();
                                        currentCell = dgvItems[col, row];
                                        dgvItems.CurrentCell = currentCell;
                                        dgvItems[0, row].Value = dgvItems.Rows.Count - 1;

                                        dgvItems.Rows[dgvItems.CurrentRow.Index - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please enter quantity!");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter correct item or quantity!");
                                return;
                            }
                        }
                        else
                        {
                            if (dgvItems.CurrentCell.Value != null)
                            {
                                col = col == 0 ? 1 : col;

                                //current row set when edited
                                if (dgvItems.CurrentRow.Index != (dgvItems.Rows.Count - 1) && dgvItems.CurrentCell.ColumnIndex == 3)
                                {
                                    row = dgvItems.Rows.Count - 2;

                                }
                                currentCell = dgvItems[col, row];
                                //  dgvItems.CurrentCell = dgvItems[col, row];

                                //return;
                            }
                            else
                            {

                                MessageBox.Show("Please select series code ex. 100/200/300...! 4 " + dgvItems.CurrentCell.RowIndex);
                                return;
                            }
                        }

                        if (e.ColumnIndex == 3 || e.ColumnIndex == 1)
                        {

                            col = col == 0 ? 1 : col;

                            //current row set when edited
                            if (dgvItems.CurrentRow.Index != (dgvItems.Rows.Count - 1))
                            {
                                switch (e.ColumnIndex)
                                {
                                    case 1:
                                        if (dgvItems[3, dgvItems.CurrentRow.Index] != null && dgvItems[3, dgvItems.CurrentRow.Index].Value != null)
                                            PriceCalculate(int.Parse(dgvItems[3, dgvItems.CurrentRow.Index].Value.ToString()), itemMaster, runningSaleMaster, "Update");
                                        break;
                                    case 3:
                                        PriceCalculate(int.Parse(dgvItems.CurrentCell.Value.ToString()), itemMaster, runningSaleMaster, "Update");
                                        break;
                                }

                                row = dgvItems.Rows.Count - 1;
                            }
                            // dgvItems.CurrentCell = dgvItems[col, row];
                            currentCell = dgvItems[col, row];
                            return;
                        }

                        //if
                    }
                    else
                    {
                        MessageBox.Show("Item not found!! ");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

            finally
            {
                if (dgvItems != null && dgvItems.Rows.Count > 0 && runningSaleMaster.Status != 4)
                {
                    dgvItems.CurrentCell = currentCell;
                    if (dgvItems.CurrentCell != null)
                    {
                        _celWasEndEdit = dgvItems[dgvItems.CurrentCell.ColumnIndex, e.RowIndex];
                        RefreshSerialNumber();
                    }
                    else
                    {

                        _celWasEndEdit = dgvItems[1, 0];
                    }
                }

            }
            // e.Handled = true;
        }
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                #region
                DataGridView dgvItems = (DataGridView)sender as DataGridView;
                if (e.KeyCode == Keys.F7)
                {
                    IsFormLoad = true;
                    // DialogResult result = MessageBox.Show("Do you want to create new bill?", "Confirmation",   MessageBoxButtons.YesNo);
                    //if (result == DialogResult.Yes)
                    //{
                    FuntionF7();
                    Cleartaxdetails();

                    //}
                }
                #endregion

                #region F10 Key
                if (e.KeyCode == Keys.F10)
                {
                    if (runningSaleMaster != null)
                    {
                        if (runningSaleMaster.Status != 4)
                            BindDiscount(true);
                        else
                            comboBoxDiscount.Enabled = false;
                        billNumber = int.Parse(lblBillNo.Text);
                        this.Opacity = 1.0;
                        return;

                    }
                }
                #endregion F10

                #region F12 Key Function
                string ordertype = string.Empty;
                if (e.KeyCode == Keys.F12)  //runningSalesMasterForLoginUser
                {
                    if (runningSaleMaster != null && runningSaleMaster.Amount > 0 && runningSaleMaster.SalesDetailsList != null && runningSaleMaster.SalesDetailsList.Count > 0 && runningSaleMaster.Status != 4)
                    {
                        //Call Order type dialog            
                        //frmDlgOrdertype dlg = new frmDlgOrdertype();
                        //dlg.MyParentForm = this;
                        //DialogResult dresult = dlg.ShowDialog();
                        //if (OrderTypeEnter == false)
                        //{
                        //    MessageBox.Show("Please Select Order Type", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        //else
                        //{
                        if (Convert.ToInt32(cmbOrderType.SelectedValue.ToString()) > 1)
                        {
                            CBPaymentMode.Text = "CREDIT";
                            _PaymentMode = CBPaymentMode.Text;
                            ordertype = cmbOrderType.Text;
                        }
                        //}

                        runningSaleMaster.CustomerId = Convert.ToInt32(cmbOrderType.SelectedValue);
                        billNumber = int.Parse(lblBillNo.Text);
                        runningSaleMaster.PaymentMode = _PaymentMode;
                        if (billNumber > 0)
                        {
                            int bnToPrint = runningSaleMaster.BillNumber.Value;
                            this.Opacity = 0.30;
                            runningSaleMaster.Remarks = "Printed";
                            runningSaleMaster.Status = (int)
                            RAHMSLibrary.Entity.EntityBase.SalesMasterStatus.Printed;
                            SalesMaster.Update(runningSaleMaster);
                            if (runningSaleMaster.TableNumber == "0")
                                FreeTable(pnlTable, runningSaleMaster.BillNumber.ToString(), true);
                            // FreeTable(pnlTable, lblTableNo.Text,true);
                            else
                                FreeTable(pnlTable, runningSaleMaster.TableNumber);


                            var salm = SalesMaster.GetById(runningSaleMaster.ID.Value);
                            if (salm != null)
                            {
                                runningSaleMaster = salm;
                                // this.Opacity = 0.30;
                                ResetForNewGrid();

                                AddingItemsToGrid(runningSaleMaster, true);
                                dgvItems.Rows.RemoveAt(dgvItems.Rows.Count - 1);
                                GridColumnsReadOnly(true);
                                lblBillNo.Text = runningSaleMaster.BillNumber.Value.ToString();
                                //lblTableNo.Text = runningSaleMaster.TableNumber;

                                SetPriceAndTax(runningSaleMaster);

                                BaseForm.PanelPainter(pnlTop, Color.White);
                                btnAdd.Enabled = true;
                                btnSave.Enabled = false;

                                this.Opacity = 1.0;
                                //CBPaymentMode.SelectedText = "CASH";
                                btnAdd.Focus();
                                // return;
                            }


                        }

                        for (int i = 0; i < runningSalesMasterForLoginUser.Count; i++)
                        {
                            if (runningSalesMasterForLoginUser[i].BillNumber.ToString() == runningSaleMaster.BillNumber.ToString())
                            {
                                runningSalesMasterForLoginUser[i].Status = runningSaleMaster.Status;
                                runningSalesMasterForLoginUser[i].Remarks = runningSaleMaster.Remarks;

                            }
                        }

                        //}
                        //---------Add print option--------------------------------
                        frmReportViewer frm = new frmReportViewer();
                        //Report.BillPrint rpt = new Report.BillPrint();        // Spicy A4 half Paper
                          Report.BillPrintNew rpt = new Report.BillPrintNew(); // Achman 4 Inch Paper
                        try
                        {
                            //DataSet ds = GlobalClass.executeQuery(sql, "data");
                            DataSet ds = GlobalClass.GetDataForPrintInvoice(Convert.ToString(billNumber));
                            DataSet dsComapny = GlobalClass.GetCompanyInfo();
                            if (ds != null)
                            {
                                rpt.SetDataSource(ds.Tables[0]);
                                rpt.Database.Tables["CompanyInfo"].SetDataSource(dsComapny.Tables[0]);
                                rpt.SetParameterValue("BillNumber", billNumber.ToString());
                                rpt.SetParameterValue("OrderType", ordertype);
                                //rpt.SetParameterValue("OrderTypeId", cmbOrderType.SelectedValue.ToString());

                                //PageMargins margins;

                                //margins = rpt.PrintOptions.PageMargins;
                                //margins.bottomMargin = 10;
                                //margins.leftMargin = 10;
                                //margins.rightMargin = 10;
                                //margins.topMargin = 10;
                                //rpt.PrintOptions.ApplyPageMargins(margins);

                                //rpt.PrintToPrinter(1, false, 0, 0);
                                //rpt.Close();

                                frm.crystalReportViewer1.ReportSource = rpt;
                                frm.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No Data Found To be Print");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("There Is issue in Printing Please check with Admin.");
                            rpt.Close();
                        }

                        //--------end print option-------------------------------

                    }
                    else
                    {
                        MessageBox.Show("Blank billcan not be printed!!!");
                    }
                    return;
                }

                #endregion F12 Key



                if (runningSaleMaster.Status != 4 && runningSaleMaster.Discount != 0 && ModCommonFunctions.Getinstance().UserTypes.UserTypes != "Administrator")
                {
                    MessageBox.Show("Once discount applied, bill can not be alter. Please create new bill. ");
                }


                #region  Enter Key
                if (e.KeyData == Keys.Enter && dgvItems.Rows != null && dgvItems.Rows.Count > 0)
                {
                    int col = dgvItems.CurrentCell.ColumnIndex;
                    int row = dgvItems.CurrentCell.RowIndex;

                    if (dgvItems.CurrentCell.Value != null)
                    {
                        if (!dgvItems.CurrentCell.Value.ToString().Contains(" ") && dgvItems.CurrentCell.ColumnIndex == 1)
                        {
                            MessageBox.Show("Please select series code ex. 100/200/300...! 5 " + dgvItems.CurrentCell.RowIndex);
                            e.Handled = true;
                            return;
                        }
                        // dgvItems.CurrentCell = dgvItems[col, row];
                    }
                    else
                    {
                        if (dgvItems.CurrentCell.ColumnIndex == 1)
                            MessageBox.Show("Please select series code ex. 100/200/300...! 6 " + dgvItems.CurrentCell.RowIndex);
                        if (dgvItems.CurrentCell.ColumnIndex == 3)
                            MessageBox.Show("Please enter quantity!");
                        e.Handled = true;
                        return;
                    }

                    if (dgvItems.CurrentCell.ColumnIndex == 3)
                    {
                        // PriceCalculate(dgvItems, dgvItems.CurrentCell.RowIndex, "Update", null, null);//GetActiveBill()    

                        col = col == 0 ? 1 : col;

                        //current row set when edited
                        if (dgvItems.CurrentRow.Index != (dgvItems.Rows.Count - 1))
                            row = dgvItems.Rows.Count - 1;
                        // dgvItems.CurrentCell = dgvItems[col, row];
                        currentCell = dgvItems[col, row];
                        //return;
                    }
                }
                #endregion Enter Key

                #region  //to delete
                if (e.KeyData == Keys.F9)
                {
                    if (runningSaleMaster.Status != 4)
                    {


                        int currentRowIndex = dgvItems.CurrentCell.RowIndex;
                        int row = currentRowIndex;
                        if (dgvItems[5, currentRowIndex].Value != null && dgvItems[1, currentRowIndex].Value != null && dgvItems[1, currentRowIndex].Value.ToString().Contains(" "))
                        {
                            string itemName = dgvItems[1, row].Value.ToString().Substring(dgvItems[1, row].Value.ToString().IndexOf(' '), dgvItems[1, row].Value.ToString().Length - dgvItems[1, row].Value.ToString().IndexOf(' '));
                            ItemMaster itemMaster = GetItem(itemName.Trim());

                            if (itemMaster != null)
                            {

                                PriceCalculate(int.Parse(dgvItems[3, currentRowIndex].Value.ToString()), itemMaster, runningSaleMaster, "Delete");

                                dgvItems.Rows.RemoveAt(currentRowIndex);
                                dgvItems.Focus();
                                currentCell = dgvItems[1, currentRowIndex];
                                // dgvItems.CurrentCell = dgvItems[1, currentRowIndex];
                                dgvItems.CurrentCell = currentCell;
                                RefreshSerialNumber();
                            }
                        }
                        e.Handled = true;
                        return;
                        //  MessageBox.Show("Item already added!");

                    }
                    else
                    {
                        MessageBox.Show("You Dont have rights to Edit this bill  ");
                        return;

                    }
                }

                #endregion for Delete

            }
            catch (Exception ex)
            {
                e.Handled = true;
                return;
            }

        }

        private void FuntionF7()
        {
            ResetForNewGrid();
            pnlBillDetails.Refresh();
            textTableNumber.ReadOnly = false;
            textTableNumber.Text = string.Empty;
            btnAdd.Enabled = false;
            btnCancel.Enabled = false;
            btnClose.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            //txtPaymentMode.Text = string.Empty;
            //comboTables.Focus();
            textTableNumber.Focus();
            CBPaymentMode.Text = "CASH";
            _PaymentMode = "CASH";
            cmbOrderType.SelectedIndex = 0;
            lblBillNo.Text = "";
            lblPrintedBillDate.Text = string.Empty;
            //  lblTableNo.Text = "";
            lblAmount.Text = "0.0";
            lblNetAmount.Text = "0.0";
            //lblTotalTax.Text = "0.0";
            // lblPercentage.Text = "0%";
            lblDiscountAmont.Text = "0.0";
            lblRoundOff.Visible = false;
            lblAmtAftDist.Text = "0.0";
            LblNetAmt.Text = "0.0";
            //SetOrderType();
        }

        void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int col = dgvItems.CurrentCell.ColumnIndex;
                int row = dgvItems.CurrentCell.RowIndex;

                if (_celWasEndEdit != null && dgvItems.CurrentCell != null)
                {
                    if (row == _celWasEndEdit.RowIndex + 1 && col == _celWasEndEdit.ColumnIndex)
                    {
                        if (_celWasEndEdit.ColumnIndex >= 4)
                        {

                            dgvItems.CurrentCell = dgvItems[4, _celWasEndEdit.RowIndex];


                        }
                        else if (_celWasEndEdit.ColumnIndex == 1)
                        {
                            dgvItems.CurrentCell = dgvItems[1, dgvItems.RowCount - 1];

                        }
                        else
                        {
                            dgvItems.CurrentCell = dgvItems[_celWasEndEdit.ColumnIndex, _celWasEndEdit.RowIndex];

                        }
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                _celWasEndEdit = null;
            }

        }
        void RefreshSerialNumber()
        {
            for (int i = 0; i < dgvItems.RowCount; i++)
            {
                dgvItems[0, i].Value = i + 1;
            }
        }
        #endregion
        private void GridColumnsReadOnly(bool TrueOrFalse)
        {
            dgvItems.Columns[0].ReadOnly = TrueOrFalse;
            dgvItems.Columns[1].ReadOnly = TrueOrFalse;
            dgvItems.Columns[2].ReadOnly = TrueOrFalse;
            dgvItems.Columns[3].ReadOnly = TrueOrFalse;
            dgvItems.Columns[4].ReadOnly = TrueOrFalse;



        }


        private void btnFirst_Click(object sender, EventArgs e)
        {
            string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;
            if (x == "Administrator")
            {
                var salm = SalesMaster.GetFirstTPrintedBillUserWiseAdmin(long.Parse(GlobalClass.userNameid));
                if (salm != null)
                {
                    GetPrintedOldBills(salm);
                    return;
                }
                else
                {
                    MessageBox.Show("Bill not available ! ");
                    return;

                }
            }
            else
            {
                var salm = SalesMaster.GetFirstTodayPrintedBillUserWise(long.Parse(GlobalClass.userNameid));
                if (salm != null)
                {
                    GetPrintedOldBills(salm);
                    return;
                }
                else
                {
                    MessageBox.Show("Bill not available ! ");
                    return;

                }
            }
        }

        private void GetPrintedOldBills(SalesMaster salm)
        {
            runningSaleMaster = salm;
            // this.Opacity = 0.30;
            ResetForNewGrid();

            AddingItemsToGrid(runningSaleMaster, true);
            dgvItems.Rows.RemoveAt(dgvItems.Rows.Count - 1);
            GridColumnsReadOnly(true);
            lblBillNo.Text = runningSaleMaster.BillNumber.Value.ToString();
            textTableNumber.Text = runningSaleMaster.TableNumber.ToString();
            textTableNumber.ReadOnly = true;
            //  lblTableNo.Text = runningSaleMaster.TableNumber;

            SetPriceAndTax(runningSaleMaster);
            BindDiscount(false, runningSaleMaster.Discount.ToString());
            CBPaymentMode.Text = runningSaleMaster.PaymentMode.ToString();
            _PaymentMode = CBPaymentMode.Text;
            cmbOrderType.SelectedValue = runningSaleMaster.CustomerId;
            BaseForm.PanelPainter(pnlTop, Color.White);

            //  this.Opacity = 1.0;
            lblPrintedBillDate.Text = "Bill date :" + runningSaleMaster.CreatedDate.ToLongDateString() + " " + runningSaleMaster.CreatedDate.ToLongTimeString();

            btnCancel.Enabled = true;
            btnClose.Enabled = true;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            CBPaymentMode.Enabled = false;
            cmbOrderType.Enabled = false;
            comboBoxDiscount.Enabled = false;
            return;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (runningSaleMaster != null && runningSaleMaster.BillNumber != null)
            {
                string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;
                if (x == "Administrator")
                {
                    var salm = SalesMaster.GetNextPriviousTodayPrintedBillUserWiseAdmin(long.Parse(GlobalClass.userNameid), runningSaleMaster.BillNumber.Value, 1);
                    if (salm != null)
                    {
                        GetPrintedOldBills(salm);
                        return;
                    }
                }
                else
                {
                    var salm = SalesMaster.GetNextPriviousTodayPrintedBillUserWise(long.Parse(GlobalClass.userNameid), runningSaleMaster.BillNumber.Value, 1);
                    if (salm != null)
                    {
                        GetPrintedOldBills(salm);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bill not available ! ");
                return;
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (runningSaleMaster != null && runningSaleMaster.BillNumber != null)
            {
                string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;
                if (x == "Administrator")
                {
                    var salm = SalesMaster.GetNextPriviousTodayPrintedBillUserWiseAdmin(long.Parse(GlobalClass.userNameid), runningSaleMaster.BillNumber.Value, 2);
                    if (salm != null)
                    {
                        GetPrintedOldBills(salm);
                        return;
                    }
                }
                else
                {
                    var salm = SalesMaster.GetNextPriviousTodayPrintedBillUserWise(long.Parse(GlobalClass.userNameid), runningSaleMaster.BillNumber.Value, 2);
                    if (salm != null)
                    {
                        GetPrintedOldBills(salm);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bill not available ! ");
                return;
            }

        }

        private void btnLast_Click(object sender, EventArgs e)
        {

            string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;
            if (x == "Administrator")
            {
                var salm = SalesMaster.GetLastTodayPrintedBillUserWiseADMIN(long.Parse(GlobalClass.userNameid));
                if (salm != null)
                {
                    GetPrintedOldBills(salm);
                    return;
                }
                else
                {
                    MessageBox.Show("Bill not available ! ");
                    return;
                }
            }
            else
            {
                var salm = SalesMaster.GetLastTodayPrintedBillUserWise(long.Parse(GlobalClass.userNameid));
                if (salm != null)
                {
                    GetPrintedOldBills(salm);
                    return;
                }
                else
                {
                    MessageBox.Show("Bill not available ! ");
                    return;

                }
            }

        }

        private void lblAmountLA_Click(object sender, EventArgs e)
        {

        }



        private void comboBoxDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyDiscount();
            }
        }

        private void ApplyDiscount()
        {
            discount = int.Parse(comboBoxDiscount.Text);

            if (billNumber > 0)
            {
                runningSaleMaster.Discount = discount;
                foreach (var item in runningSaleMaster.SalesDetailsList)
                {
                    if (discount != 0) { item.Amount = item.ItemPrice * item.Qty - ((item.ItemPrice * item.Qty) * discount / 100); }
                    else { item.Amount = item.ItemPrice * item.Qty; }
                    item.ModifiedBy = runningSaleMaster.ModifiedBy;
                    decimal totalTax = 0;
                    decimal _totalTaxAfterdiscount = 0;
                    int Quantity = item.Qty.Value;
                    IList<SalesTaxDetails> salesTaxDetailsList = GetSalesTaxDetailListObject(item.ItemMaster, Quantity, out totalTax, Convert.ToInt32(cmbOrderType.SelectedValue.ToString()));
                    foreach (var saleTaxitem in salesTaxDetailsList)
                    {
                        if (discount != 0) { saleTaxitem.Amount = saleTaxitem.Amount - (saleTaxitem.Amount * discount / 100); }
                        else { saleTaxitem.Amount = saleTaxitem.Amount; }
                        _totalTaxAfterdiscount += saleTaxitem.Amount.Value;
                    }
                    item.Taxes = _totalTaxAfterdiscount;

                    int ret = RAHMSLibrary.Entity.Sales.SalesDetails.Update(item);

                    //var salesDetailsid = RAHMSLibrary.Entity.Sales.SalesDetails.GetById(salesDetails.ID);
                    if (ret > 0)
                    {
                        if (salesTaxDetailsList != null)
                        {
                            for (int i = 0; i < salesTaxDetailsList.Count; i++)
                            {
                                salesTaxDetailsList[i].SalesDetailsId = item.SalesTaxDetailsList[i].SalesDetailsId;
                                salesTaxDetailsList[i].ID = item.SalesTaxDetailsList[i].ID;
                                SalesTaxDetails.Update(salesTaxDetailsList[i]);


                            }
                        }
                        //update sales master
                        runningSaleMaster = SalesMaster.GetByBillNumber(runningSaleMaster.BillNumber.ToString());

                        if (salesTaxDetailsList != null)
                        {
                            runningSaleMaster.Taxes = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes);
                            runningSaleMaster.OriginalTaxAmount = runningSaleMaster.SalesDetailsList.Sum(amt => amt.Taxes).Value;
                        }

                    }

                }
                runningSaleMaster.Discount = discount;
                SalesMaster.Update(runningSaleMaster);
                SetPriceAndTax(runningSaleMaster);
                // BindDiscount(false, runningSaleMaster.Discount.ToString());
                comboBoxDiscount.Enabled = false;
            }
        }
        private void textTableNumber_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textTableNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !IsFormLoad)
            {
                if (!string.IsNullOrEmpty(textTableNumber.Text))
                {
                    if (Convert.ToInt16(textTableNumber.Text) <= TableCount)
                    {

                        textTableNumber.Text = Convert.ToInt32(textTableNumber.Text).ToString() == "0" ? "00" : Convert.ToInt32(textTableNumber.Text).ToString();
                        //generate bill and focus on save button   
                        if (IsTableFree(textTableNumber.Text))
                        //  if (IsTableFree(comboTables.Text))
                        {
                            btnSave.Enabled = true;
                            BaseForm.ButtonPainter(btnSave, Color.Green);
                            btnSave.ForeColor = Color.White;
                            btnSave.Focus();

                            btnClose.Enabled = false;
                            btnCancel.Enabled = false;
                            btnAdd.Enabled = false;



                            lblBillNo.ForeColor = Color.Orange;
                            lblBillNo.Text = GetNewBill().ToString();
                            textTableNumber.ReadOnly = true;
                            // comboTables.Enabled = false;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Table number is not exist in our Restaurant ! Please enter correct table number. ");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter customer Table Number . ");
                }
            }
            IsFormLoad = false;
        }

        private void Btn_EditBill_Click(object sender, EventArgs e)
        {
            //IList<SalesMaster> salm = SalesMaster.GetByAdminUser(4, Convert.ToInt32(runningSaleMaster.BillNumber));
            //if (salm != null && salm.Count > 0)
            //{

            txtBoxBillNumber.Text = string.Empty;
            runningSaleMaster.IsBillAlreadyPrinted = true;
            runningSaleMaster.Remarks = "Running Bill";
            runningSaleMaster.EditedBillNumber = Convert.ToInt32(runningSaleMaster.BillNumber);
            this.EditedBillNumber = Convert.ToInt32(runningSaleMaster.BillNumber);
            runningSaleMaster.Status = (int)RAHMSLibrary.Entity.EntityBase.SalesMasterStatus.Running;
            SalesMaster.Update(runningSaleMaster);
            runningSalesMasterForLoginUser.Add(runningSaleMaster);
            SetPriceAndTax(runningSaleMaster);
            discount = runningSaleMaster.Discount.Value;

            // runningSaleMaster = runningSaleMaster;// SalesMaster.GetByBillNumber(billNumber);

            textTableNumber.Text = runningSaleMaster.TableNumber;

            // btn.ForeColor = Color.White;
            ResetForNewGrid();
            CreateSalesGridForAllRunningTables(runningSaleMaster.BillNumber.ToString(), runningSaleMaster.TableNumber);

            btnCancel.Enabled = false;
            btnClose.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = false;  // default
            comboBoxDiscount.Enabled = false;  // default
            txtBoxBillNumber.Enabled = false;
            textTableNumber.Enabled = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            Btn_EditBill.Enabled = false;
            btnSearchPrintedBill.Enabled = false;
            CBPaymentMode.Enabled = true;
            cmbOrderType.Enabled = true;
            //
        }

        //private string GetPaymentmode(int billno)
        //{
        //    string sql = "select * from SalesMaster where BillNumber = " + billno + "";

        //    GlobalClass dbfun = new GlobalClass()

        //    return "";
        //}



        private void txtBoxBillNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBoxBillNumber.Text))
                {
                    string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;
                    if (x == "Administrator")
                    {
                        IList<SalesMaster> salm = SalesMaster.GetByAdminUser(4, Convert.ToInt32(txtBoxBillNumber.Text));
                        if (salm != null && salm.Count > 0)
                        {

                            txtBoxBillNumber.Text = string.Empty;
                            runningSaleMaster = salm[0];
                            // this.Opacity = 0.30;
                            ResetForNewGrid();

                            AddingItemsToGrid(runningSaleMaster, true);
                            dgvItems.Rows.RemoveAt(dgvItems.Rows.Count - 1);
                            GridColumnsReadOnly(true);
                            lblBillNo.Text = runningSaleMaster.BillNumber.Value.ToString();
                            textTableNumber.Text = runningSaleMaster.TableNumber.ToString();
                            textTableNumber.ReadOnly = true;
                            //  lblTableNo.Text = runningSaleMaster.TableNumber;

                            SetPriceAndTax(runningSaleMaster);
                            BindDiscount(false, runningSaleMaster.Discount.ToString());
                            BaseForm.PanelPainter(pnlTop, Color.White);
                            CBPaymentMode.Text = runningSaleMaster.PaymentMode.ToString();
                            _PaymentMode = CBPaymentMode.Text;
                            btnCancel.Enabled = true;
                            btnClose.Enabled = true;
                            btnAdd.Enabled = true;
                            btnSave.Enabled = false;
                            comboBoxDiscount.Enabled = false;
                            CBPaymentMode.Enabled = false;
                            cmbOrderType.Enabled = false;
                            cmbOrderType.SelectedValue = runningSaleMaster.CustomerId;

                        }
                        else
                        {
                            txtBoxBillNumber.Text = string.Empty;
                            textTableNumber.Focus();
                            MessageBox.Show("Bill Number not found  !");

                        }
                        return;

                    }
                    else
                    {
                        IList<SalesMaster> salm = SalesMaster.GetByStatusAndUserId(4, long.Parse(GlobalClass.userNameid), Convert.ToInt32(txtBoxBillNumber.Text));
                        if (salm != null && salm.Count > 0)
                        {

                            txtBoxBillNumber.Text = string.Empty;
                            runningSaleMaster = salm[0];
                            // this.Opacity = 0.30;
                            ResetForNewGrid();

                            AddingItemsToGrid(runningSaleMaster, true);
                            dgvItems.Rows.RemoveAt(dgvItems.Rows.Count - 1);
                            GridColumnsReadOnly(true);
                            lblBillNo.Text = runningSaleMaster.BillNumber.Value.ToString();
                            textTableNumber.Text = runningSaleMaster.TableNumber.ToString();
                            textTableNumber.ReadOnly = true;
                            //  lblTableNo.Text = runningSaleMaster.TableNumber;

                            SetPriceAndTax(runningSaleMaster);

                            BaseForm.PanelPainter(pnlTop, Color.White);

                            //  this.Opacity = 1.0;
                            btnCancel.Enabled = false;
                            btnClose.Enabled = true;
                            btnAdd.Enabled = false;
                            btnSave.Enabled = false;
                            comboBoxDiscount.Enabled = false;

                        }
                        else
                        {
                            txtBoxBillNumber.Text = string.Empty;
                            textTableNumber.Focus();
                            MessageBox.Show("Bill Number not found  !");

                        }

                        return;
                    }


                }
                else
                {
                    MessageBox.Show("Please enter bill number  !");
                }
            }

        }

        private void btnSearchPrintedBill_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxBillNumber.Text))
            {
                string x = ModCommonFunctions.Getinstance().UserTypes.UserTypes;
                if (x == "Administrator")
                {
                    IList<SalesMaster> salm = SalesMaster.GetByAdminUser(4, Convert.ToInt32(txtBoxBillNumber.Text));
                    if (salm != null && salm.Count > 0)
                    {

                        txtBoxBillNumber.Text = string.Empty;
                        runningSaleMaster = salm[0];
                        // this.Opacity = 0.30;
                        ResetForNewGrid();

                        AddingItemsToGrid(runningSaleMaster, true);
                        dgvItems.Rows.RemoveAt(dgvItems.Rows.Count - 1);
                        GridColumnsReadOnly(true);
                        lblBillNo.Text = runningSaleMaster.BillNumber.Value.ToString();
                        textTableNumber.Text = runningSaleMaster.TableNumber.ToString();
                        textTableNumber.ReadOnly = true;
                        //  lblTableNo.Text = runningSaleMaster.TableNumber;

                        SetPriceAndTax(runningSaleMaster);
                        BindDiscount(false, runningSaleMaster.Discount.ToString());
                        BaseForm.PanelPainter(pnlTop, Color.White);
                        CBPaymentMode.Text = runningSaleMaster.PaymentMode.ToString();
                        _PaymentMode = CBPaymentMode.Text;
                        btnCancel.Enabled = true;
                        btnClose.Enabled = true;
                        btnAdd.Enabled = true;
                        btnSave.Enabled = false;
                        comboBoxDiscount.Enabled = false;
                        CBPaymentMode.Enabled = false;
                        cmbOrderType.Enabled = false;
                        cmbOrderType.SelectedValue = runningSaleMaster.CustomerId;
                    }
                    else
                    {
                        txtBoxBillNumber.Text = string.Empty;
                        textTableNumber.Focus();
                        MessageBox.Show("Bill Number not found  !");

                    }

                    return;

                }
                else
                {
                    IList<SalesMaster> salm = SalesMaster.GetByStatusAndUserId(4, long.Parse(GlobalClass.userNameid), Convert.ToInt32(txtBoxBillNumber.Text));
                    if (salm != null && salm.Count > 0)
                    {

                        txtBoxBillNumber.Text = string.Empty;
                        runningSaleMaster = salm[0];
                        // this.Opacity = 0.30;
                        ResetForNewGrid();

                        AddingItemsToGrid(runningSaleMaster, true);
                        dgvItems.Rows.RemoveAt(dgvItems.Rows.Count - 1);
                        GridColumnsReadOnly(true);
                        lblBillNo.Text = runningSaleMaster.BillNumber.Value.ToString();
                        textTableNumber.Text = runningSaleMaster.TableNumber.ToString();
                        textTableNumber.ReadOnly = true;
                        //  lblTableNo.Text = runningSaleMaster.TableNumber;

                        SetPriceAndTax(runningSaleMaster);

                        BaseForm.PanelPainter(pnlTop, Color.White);

                        //  this.Opacity = 1.0;
                        btnCancel.Enabled = false;
                        btnClose.Enabled = true;
                        btnAdd.Enabled = false;
                        btnSave.Enabled = false;
                        comboBoxDiscount.Enabled = false;

                    }
                    else
                    {
                        txtBoxBillNumber.Text = string.Empty;
                        textTableNumber.Focus();
                        MessageBox.Show("Bill Number not found  !");

                    }
                    //if (runningSaleMaster.TableNumber == "00")
                    //    BaseForm.PanelPainter(pnlTop, Color.Cyan);
                    //else
                    //    BaseForm.PanelPainter(pnlTop, Color.Khaki);

                    return;
                }


            }
            else
            {
                MessageBox.Show("Please enter bill number  !");
            }
        }




        private void txtPaymentMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvItems.Focus();
            }

        }

        private void txtPaymentMode1_SelectedValueChanged(object sender, EventArgs e)
        {

            dgvItems.Focus();

        }






        private void CBPaymentMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _PaymentMode = (sender as ComboBox).SelectedItem as string;
            dgvItems.Focus();
        }

        private void PrintKOT(string name, int qty, string tableno)
        {
            frmReportViewer frm = new frmReportViewer();
            Report.KOT rpt = new Report.KOT();

            try
            {
                //DataSet ds = GlobalClass.executeQuery(sql, "data");
                DataSet ds = GlobalClass.GetDataForPrintInvoice(Convert.ToString(billNumber));
                DataSet dsComapny = GlobalClass.GetCompanyInfo();
                if (ds != null)
                {
                    //rpt.SetDataSource(ds.Tables[0]);
                    //rpt.Database.Tables["CompanyInfo"].SetDataSource(dsComapny.Tables[0]);
                    rpt.SetParameterValue("BillNumber", billNumber.ToString());
                    rpt.SetParameterValue("ItemName", name);
                    rpt.SetParameterValue("QTY", qty);
                    rpt.SetParameterValue("TableNo", tableno);

                    //PageMargins margins;
                    //PrinterSettings printerSettings = new PrinterSettings();
                    //printerSettings.PrinterName = System.Configuration.ConfigurationManager.AppSettings["KOTPrinter"].ToString();
                    //PageSettings pageSettings = new PageSettings();
                    //PrintLayoutSettings printLayoutSettings = new PrintLayoutSettings();

                    //pageSettings.
                    //margins = rpt.PrintOptions.PageMargins;
                    //margins.bottomMargin = 10;
                    //margins.leftMargin = 10;
                    //margins.rightMargin = 10;
                    //margins.topMargin = 10;
                    //rpt.PrintOptions.ApplyPageMargins(margins);
                    rpt.PrintOptions.NoPrinter = false;
                    rpt.PrintOptions.PrinterName = System.Configuration.ConfigurationManager.AppSettings["KOTPrinter"].ToString();
                    rpt.PrintToPrinter(1, false, 0, 0);
                    //rpt.PrintToPrinter(printerSettings,pageSettings,true, printLayoutSettings);
                    rpt.Close();

                    //frm.crystalReportViewer1.ReportSource = rpt;
                    //frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Data Found To be Print");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There Is issue in Printing Please check with Admin.");
                rpt.Close();
            }

            //--------end print option-------------------------------

        }

        private void cmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //OrderTypeEnter = true;
            //if (Convert.ToInt32(cmbOrderType.SelectedValue.ToString()) > 1)
            //{
            //    //set tax 0 in tables for already saved data

            //    arrTaxValue = new ArrayList();

            //}
            //SetPriceAndTax(runningSaleMaster);
        }
    }

    public class TableClass
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
