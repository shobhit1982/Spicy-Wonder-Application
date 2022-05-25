namespace RAHMS.Forms.Sales
{
    partial class Frm_PendingBills
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
            this.listBoxPendingBills = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxPendingBills
            // 
            this.listBoxPendingBills.BackColor = System.Drawing.Color.White;
            this.listBoxPendingBills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxPendingBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPendingBills.ForeColor = System.Drawing.Color.Red;
            this.listBoxPendingBills.FormattingEnabled = true;
            this.listBoxPendingBills.ItemHeight = 16;
            this.listBoxPendingBills.Location = new System.Drawing.Point(23, 14);
            this.listBoxPendingBills.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxPendingBills.Name = "listBoxPendingBills";
            this.listBoxPendingBills.Size = new System.Drawing.Size(400, 306);
            this.listBoxPendingBills.TabIndex = 0;
            this.listBoxPendingBills.SelectedIndexChanged += new System.EventHandler(this.listBoxPendingBills_SelectedIndexChanged);
            // 
            // Frm_PendingBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 344);
            this.Controls.Add(this.listBoxPendingBills);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_PendingBills";
            this.Text = "Frm_PendingBills";
           // this.Load += new System.EventHandler(this.Frm_PendingBills_Load);
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.ListBox listBoxPendingBills;
    }
}