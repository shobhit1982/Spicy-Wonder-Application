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
    public partial class Frm_AdminPassword : Form
    {
        public Frm_AdminPassword()
        {
            InitializeComponent();
        }

        public Frm_AdminPassword(string p)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            label1.Text = p;
        }
        public static string AdminPassword = "";
        
        private void Frm_AdminPassword_Load(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            { this.Close(); }
            if (keyData == Keys.Enter)
            {


                Frm_CounterSale.adminPassword = textBoxAdminPassword.Text.Trim();
          
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_CounterSale.adminPassword = "000000";
            this.Close();

        }
    }
}
