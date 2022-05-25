namespace RAHMS.Forms.RAHMS
{
    partial class Frm_CounterSale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CounterSale));
            this.pnlTable = new System.Windows.Forms.Panel();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAmountLA = new System.Windows.Forms.Label();
            this.pnlBillDetails = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.lblRoundOff = new System.Windows.Forms.Label();
            this.LblNetAmt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblAmtAftDist = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDiscountCal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.comboBoxDiscount = new System.Windows.Forms.ComboBox();
            this.lblDiscountAmont = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.lblDateAndTime = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblLoginUser = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTableNo = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblPrintedBillDate = new System.Windows.Forms.Label();
            this.Btn_EditBill = new System.Windows.Forms.Button();
            this.txtBoxBillNumber = new System.Windows.Forms.TextBox();
            this.btnSearchPrintedBill = new System.Windows.Forms.Button();
            this.textTableNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBPaymentMode = new System.Windows.Forms.ComboBox();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pnlBillDetails.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTable
            // 
            this.pnlTable.AutoScroll = true;
            this.pnlTable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTable.Location = new System.Drawing.Point(872, 12);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(135, 579);
            this.pnlTable.TabIndex = 1;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Black;
            this.lblAmount.Location = new System.Drawing.Point(147, 8);
            this.lblAmount.MaximumSize = new System.Drawing.Size(100, 50);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAmount.Size = new System.Drawing.Size(31, 18);
            this.lblAmount.TabIndex = 10;
            this.lblAmount.Text = "0.0";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAmountLA
            // 
            this.lblAmountLA.AutoSize = true;
            this.lblAmountLA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountLA.Location = new System.Drawing.Point(2, 8);
            this.lblAmountLA.Name = "lblAmountLA";
            this.lblAmountLA.Size = new System.Drawing.Size(96, 18);
            this.lblAmountLA.TabIndex = 9;
            this.lblAmountLA.Text = "Amount Rs.";
            this.lblAmountLA.Click += new System.EventHandler(this.lblAmountLA_Click);
            // 
            // pnlBillDetails
            // 
            this.pnlBillDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBillDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBillDetails.Controls.Add(this.label19);
            this.pnlBillDetails.Controls.Add(this.lblRoundOff);
            this.pnlBillDetails.Controls.Add(this.LblNetAmt);
            this.pnlBillDetails.Controls.Add(this.label16);
            this.pnlBillDetails.Controls.Add(this.label15);
            this.pnlBillDetails.Controls.Add(this.label14);
            this.pnlBillDetails.Controls.Add(this.lblAmtAftDist);
            this.pnlBillDetails.Controls.Add(this.label11);
            this.pnlBillDetails.Controls.Add(this.label3);
            this.pnlBillDetails.Controls.Add(this.lblDiscountCal);
            this.pnlBillDetails.Controls.Add(this.lblDiscount);
            this.pnlBillDetails.Controls.Add(this.comboBoxDiscount);
            this.pnlBillDetails.Controls.Add(this.lblDiscountAmont);
            this.pnlBillDetails.Controls.Add(this.label12);
            this.pnlBillDetails.Controls.Add(this.label2);
            this.pnlBillDetails.Controls.Add(this.lblAmountLA);
            this.pnlBillDetails.Controls.Add(this.lblAmount);
            this.pnlBillDetails.Controls.Add(this.lblNetAmount);
            this.pnlBillDetails.Location = new System.Drawing.Point(1012, 16);
            this.pnlBillDetails.Name = "pnlBillDetails";
            this.pnlBillDetails.Size = new System.Drawing.Size(247, 305);
            this.pnlBillDetails.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(-2, 256);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(253, 9);
            this.label19.TabIndex = 31;
            this.label19.Text = "______________________________________________________________";
            // 
            // lblRoundOff
            // 
            this.lblRoundOff.AutoSize = true;
            this.lblRoundOff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRoundOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoundOff.ForeColor = System.Drawing.Color.Black;
            this.lblRoundOff.Location = new System.Drawing.Point(147, 237);
            this.lblRoundOff.MaximumSize = new System.Drawing.Size(100, 50);
            this.lblRoundOff.Name = "lblRoundOff";
            this.lblRoundOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRoundOff.Size = new System.Drawing.Size(31, 18);
            this.lblRoundOff.TabIndex = 30;
            this.lblRoundOff.Text = "0.0";
            this.lblRoundOff.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblRoundOff.Visible = false;
            // 
            // LblNetAmt
            // 
            this.LblNetAmt.AutoSize = true;
            this.LblNetAmt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblNetAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNetAmt.ForeColor = System.Drawing.Color.Black;
            this.LblNetAmt.Location = new System.Drawing.Point(147, 219);
            this.LblNetAmt.MaximumSize = new System.Drawing.Size(100, 50);
            this.LblNetAmt.Name = "LblNetAmt";
            this.LblNetAmt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblNetAmt.Size = new System.Drawing.Size(31, 18);
            this.LblNetAmt.TabIndex = 29;
            this.LblNetAmt.Text = "0.0";
            this.LblNetAmt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 239);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 18);
            this.label16.TabIndex = 28;
            this.label16.Text = "Round Off";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 218);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 18);
            this.label15.TabIndex = 27;
            this.label15.Text = "Net Amount";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(-2, 207);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(253, 9);
            this.label14.TabIndex = 26;
            this.label14.Text = "______________________________________________________________";
            // 
            // lblAmtAftDist
            // 
            this.lblAmtAftDist.AutoSize = true;
            this.lblAmtAftDist.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAmtAftDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtAftDist.ForeColor = System.Drawing.Color.Black;
            this.lblAmtAftDist.Location = new System.Drawing.Point(147, 71);
            this.lblAmtAftDist.MaximumSize = new System.Drawing.Size(100, 50);
            this.lblAmtAftDist.Name = "lblAmtAftDist";
            this.lblAmtAftDist.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAmtAftDist.Size = new System.Drawing.Size(31, 18);
            this.lblAmtAftDist.TabIndex = 25;
            this.lblAmtAftDist.Text = "0.0";
            this.lblAmtAftDist.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 18);
            this.label11.TabIndex = 24;
            this.label11.Text = "Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 9);
            this.label3.TabIndex = 23;
            this.label3.Text = "________________________________________________________________";
            // 
            // lblDiscountCal
            // 
            this.lblDiscountCal.AutoSize = true;
            this.lblDiscountCal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDiscountCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountCal.ForeColor = System.Drawing.Color.Black;
            this.lblDiscountCal.Location = new System.Drawing.Point(147, 32);
            this.lblDiscountCal.MaximumSize = new System.Drawing.Size(100, 50);
            this.lblDiscountCal.Name = "lblDiscountCal";
            this.lblDiscountCal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDiscountCal.Size = new System.Drawing.Size(31, 18);
            this.lblDiscountCal.TabIndex = 22;
            this.lblDiscountCal.Text = "0.0";
            this.lblDiscountCal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(3, 34);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(94, 18);
            this.lblDiscount.TabIndex = 21;
            this.lblDiscount.Text = "Discount %";
            // 
            // comboBoxDiscount
            // 
            this.comboBoxDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDiscount.FormattingEnabled = true;
            this.comboBoxDiscount.Location = new System.Drawing.Point(100, 31);
            this.comboBoxDiscount.Name = "comboBoxDiscount";
            this.comboBoxDiscount.Size = new System.Drawing.Size(38, 26);
            this.comboBoxDiscount.TabIndex = 20;
            this.comboBoxDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxDiscount_KeyDown);
            // 
            // lblDiscountAmont
            // 
            this.lblDiscountAmont.AutoSize = true;
            this.lblDiscountAmont.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDiscountAmont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountAmont.ForeColor = System.Drawing.Color.Green;
            this.lblDiscountAmont.Location = new System.Drawing.Point(2, 251);
            this.lblDiscountAmont.Name = "lblDiscountAmont";
            this.lblDiscountAmont.Size = new System.Drawing.Size(31, 17);
            this.lblDiscountAmont.TabIndex = 17;
            this.lblDiscountAmont.Text = "0.0";
            this.lblDiscountAmont.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDiscountAmont.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 24);
            this.label12.TabIndex = 19;
            this.label12.Text = "Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(703, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 11;
            this.label2.Tag = "";
            this.label2.Text = "Net Amount Rs.";
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.AutoSize = true;
            this.lblNetAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblNetAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmount.ForeColor = System.Drawing.Color.Red;
            this.lblNetAmount.Location = new System.Drawing.Point(134, 270);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNetAmount.Size = new System.Drawing.Size(45, 26);
            this.lblNetAmount.TabIndex = 12;
            this.lblNetAmount.Text = "0.0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(399, 630);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(385, 24);
            this.label5.TabIndex = 18;
            this.label5.Tag = "";
            this.label5.Text = "Net Amount = (Amount - Disscount%)+Taxes";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(901, 631);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "F12 To Print Bill";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(756, 630);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "F10 For Discount";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Location = new System.Drawing.Point(10, 92);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(854, 535);
            this.pnlGrid.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(633, 630);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 18);
            this.label10.TabIndex = 15;
            this.label10.Text = "F9 Delete Item";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bill No";
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.BackColor = System.Drawing.Color.Transparent;
            this.lblBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.ForeColor = System.Drawing.Color.Red;
            this.lblBillNo.Location = new System.Drawing.Point(254, 7);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(0, 22);
            this.lblBillNo.TabIndex = 2;
            // 
            // lblDateAndTime
            // 
            this.lblDateAndTime.AutoSize = true;
            this.lblDateAndTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateAndTime.ForeColor = System.Drawing.Color.Gray;
            this.lblDateAndTime.Location = new System.Drawing.Point(426, 634);
            this.lblDateAndTime.Name = "lblDateAndTime";
            this.lblDateAndTime.Size = new System.Drawing.Size(75, 17);
            this.lblDateAndTime.TabIndex = 4;
            this.lblDateAndTime.Text = "dateTime";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(93, 43);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(183, 43);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cance&l";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(3, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "&Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblLoginUser
            // 
            this.lblLoginUser.AutoSize = true;
            this.lblLoginUser.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginUser.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblLoginUser.Location = new System.Drawing.Point(687, 3);
            this.lblLoginUser.Name = "lblLoginUser";
            this.lblLoginUser.Size = new System.Drawing.Size(88, 18);
            this.lblLoginUser.TabIndex = 11;
            this.lblLoginUser.Text = "UserName";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(271, 43);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTableNo
            // 
            this.lblTableNo.AutoSize = true;
            this.lblTableNo.BackColor = System.Drawing.Color.Transparent;
            this.lblTableNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNo.ForeColor = System.Drawing.Color.Red;
            this.lblTableNo.Location = new System.Drawing.Point(483, 5);
            this.lblTableNo.Name = "lblTableNo";
            this.lblTableNo.Size = new System.Drawing.Size(0, 22);
            this.lblTableNo.TabIndex = 13;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrevious.BackgroundImage")));
            this.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrevious.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Location = new System.Drawing.Point(400, 43);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(27, 25);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFirst.BackgroundImage")));
            this.btnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFirst.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Location = new System.Drawing.Point(374, 43);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(27, 25);
            this.btnFirst.TabIndex = 16;
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(448, 45);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(28, 23);
            this.btnNext.TabIndex = 17;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLast.BackgroundImage")));
            this.btnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLast.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Location = new System.Drawing.Point(473, 45);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(24, 23);
            this.btnLast.TabIndex = 18;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.lblPrintedBillDate);
            this.pnlTop.Controls.Add(this.Btn_EditBill);
            this.pnlTop.Controls.Add(this.txtBoxBillNumber);
            this.pnlTop.Controls.Add(this.btnSearchPrintedBill);
            this.pnlTop.Controls.Add(this.textTableNumber);
            this.pnlTop.Controls.Add(this.btnLast);
            this.pnlTop.Controls.Add(this.btnNext);
            this.pnlTop.Controls.Add(this.btnFirst);
            this.pnlTop.Controls.Add(this.btnPrevious);
            this.pnlTop.Controls.Add(this.lblTableNo);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.lblLoginUser);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.btnCancel);
            this.pnlTop.Controls.Add(this.btnSave);
            this.pnlTop.Controls.Add(this.lblBillNo);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Location = new System.Drawing.Point(10, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(854, 74);
            this.pnlTop.TabIndex = 0;
            // 
            // lblPrintedBillDate
            // 
            this.lblPrintedBillDate.AutoSize = true;
            this.lblPrintedBillDate.BackColor = System.Drawing.Color.Transparent;
            this.lblPrintedBillDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrintedBillDate.ForeColor = System.Drawing.Color.Gray;
            this.lblPrintedBillDate.Location = new System.Drawing.Point(522, 5);
            this.lblPrintedBillDate.Name = "lblPrintedBillDate";
            this.lblPrintedBillDate.Size = new System.Drawing.Size(0, 17);
            this.lblPrintedBillDate.TabIndex = 23;
            // 
            // Btn_EditBill
            // 
            this.Btn_EditBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_EditBill.Location = new System.Drawing.Point(560, 45);
            this.Btn_EditBill.Name = "Btn_EditBill";
            this.Btn_EditBill.Size = new System.Drawing.Size(75, 23);
            this.Btn_EditBill.TabIndex = 22;
            this.Btn_EditBill.Text = "Edit";
            this.Btn_EditBill.UseVisualStyleBackColor = true;
            this.Btn_EditBill.Click += new System.EventHandler(this.Btn_EditBill_Click);
            // 
            // txtBoxBillNumber
            // 
            this.txtBoxBillNumber.Location = new System.Drawing.Point(746, 46);
            this.txtBoxBillNumber.Name = "txtBoxBillNumber";
            this.txtBoxBillNumber.Size = new System.Drawing.Size(103, 20);
            this.txtBoxBillNumber.TabIndex = 21;
            this.txtBoxBillNumber.Tag = "Enter Bill Number";
            this.txtBoxBillNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxBillNumber_KeyDown);
            // 
            // btnSearchPrintedBill
            // 
            this.btnSearchPrintedBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPrintedBill.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPrintedBill.Image")));
            this.btnSearchPrintedBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchPrintedBill.Location = new System.Drawing.Point(643, 44);
            this.btnSearchPrintedBill.Name = "btnSearchPrintedBill";
            this.btnSearchPrintedBill.Size = new System.Drawing.Size(97, 25);
            this.btnSearchPrintedBill.TabIndex = 20;
            this.btnSearchPrintedBill.Text = "Search Bill";
            this.btnSearchPrintedBill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchPrintedBill.UseVisualStyleBackColor = true;
            this.btnSearchPrintedBill.Click += new System.EventHandler(this.btnSearchPrintedBill_Click);
            // 
            // textTableNumber
            // 
            this.textTableNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTableNumber.Location = new System.Drawing.Point(5, 3);
            this.textTableNumber.Name = "textTableNumber";
            this.textTableNumber.Size = new System.Drawing.Size(156, 30);
            this.textTableNumber.TabIndex = 19;
            this.textTableNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTableNumber_KeyDown);
            this.textTableNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textTableNumber_KeyUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(1036, 630);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(173, 18);
            this.label13.TabIndex = 16;
            this.label13.Text = "F7 To Create New Bill";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1010, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Payment Mode";
            // 
            // CBPaymentMode
            // 
            this.CBPaymentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBPaymentMode.FormattingEnabled = true;
            this.CBPaymentMode.Items.AddRange(new object[] {
            "CASH",
            "CARD",
            "CREDIT"});
            this.CBPaymentMode.Location = new System.Drawing.Point(1166, 326);
            this.CBPaymentMode.Name = "CBPaymentMode";
            this.CBPaymentMode.Size = new System.Drawing.Size(92, 24);
            this.CBPaymentMode.TabIndex = 22;
            this.CBPaymentMode.SelectionChangeCommitted += new System.EventHandler(this.CBPaymentMode_SelectionChangeCommitted);
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.Enabled = false;
            this.cmbOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Items.AddRange(new object[] {
            "CASH",
            "CARD"});
            this.cmbOrderType.Location = new System.Drawing.Point(1166, 362);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(92, 24);
            this.cmbOrderType.TabIndex = 24;
            this.cmbOrderType.SelectedIndexChanged += new System.EventHandler(this.cmbOrderType_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.LightCoral;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1010, 362);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 24);
            this.label17.TabIndex = 23;
            this.label17.Text = "Order Type";
            // 
            // Frm_CounterSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1279, 605);
            this.Controls.Add(this.cmbOrderType);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblDateAndTime);
            this.Controls.Add(this.CBPaymentMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlBillDetails);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlTop);
            this.Name = "Frm_CounterSale";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Counter Sale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_CounterSale_FormClosing);
            this.Load += new System.EventHandler(this.Frm_CounterSale_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.pnlBillDetails.ResumeLayout(false);
            this.pnlBillDetails.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        //void comboTables_GotFocus(object sender, System.EventArgs e)
        //{
        //    if (!comboTables.DroppedDown)
        //    {
        //        comboTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        //        comboTables.DroppedDown = true;
        //    }
        //}

       
        #endregion

        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAmountLA;
        private System.Windows.Forms.Panel pnlBillDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblDiscountAmont;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.Label lblDateAndTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblLoginUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTableNo;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        internal System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxDiscount;
        private System.Windows.Forms.TextBox textTableNumber;
        private System.Windows.Forms.Button btnSearchPrintedBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxBillNumber;
        private System.Windows.Forms.ComboBox CBPaymentMode;
        private System.Windows.Forms.Button Btn_EditBill;
        private System.Windows.Forms.Label lblPrintedBillDate;
        private System.Windows.Forms.Label lblDiscountCal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAmtAftDist;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblRoundOff;
        private System.Windows.Forms.Label LblNetAmt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cmbOrderType;
    }
}