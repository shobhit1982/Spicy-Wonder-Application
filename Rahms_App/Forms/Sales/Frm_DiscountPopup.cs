using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RAHMSLibrary.Entity.Masters;

namespace RAHMS.Forms.RAHMS
{
    public partial class Frm_DiscountPopup : Form
    {
        public Frm_DiscountPopup()
        {
            InitializeComponent();

        }

        public static int billNumber = 0;
        private void Frm_DiscountPopup_Load(object sender, EventArgs e)
        {
            try
            {


                IList<DiscountManage> discountList = DiscountManage.GetAll();
                if (discountList != null && discountList.Count > 0)
                {
                    discountList.Add(new DiscountManage { ID = 0, Discount = 0 });

                    comboDiscount.DisplayMember = "Discount";
                    comboDiscount.ValueMember = "ID";
                    comboDiscount.DataSource = discountList.OrderBy(id => id.ID).ToList<DiscountManage>();
                    comboDiscount.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Frm_DiscountPopup_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void comboDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Frm_CounterSale.discount = int.Parse(comboDiscount.Text);
                Frm_CounterSale.billNumber = billNumber;
                this.Close();
            }
        }


    }
}
