namespace RAHMS.Forms.RAHMS
{
    partial class frmDlgOrdertype
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
            this.label15 = new System.Windows.Forms.Label();
            this.cmbOrderType1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Red;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(21, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 19);
            this.label15.TabIndex = 162;
            this.label15.Text = "Order type";
            // 
            // cmbOrderType1
            // 
            this.cmbOrderType1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOrderType1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOrderType1.BackColor = System.Drawing.SystemColors.Window;
            this.cmbOrderType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderType1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrderType1.FormattingEnabled = true;
            this.cmbOrderType1.Location = new System.Drawing.Point(25, 52);
            this.cmbOrderType1.Name = "cmbOrderType1";
            this.cmbOrderType1.Size = new System.Drawing.Size(298, 31);
            this.cmbOrderType1.TabIndex = 161;
            this.cmbOrderType1.Tag = "1";
            this.cmbOrderType1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbCustomer_KeyDown);
            // 
            // frmDlgOrdertype
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(335, 109);
            this.ControlBox = false;
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbOrderType1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDlgOrdertype";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Order Type";
            this.Load += new System.EventHandler(this.frmDlgOrdertype_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbOrderType1;
    }
}