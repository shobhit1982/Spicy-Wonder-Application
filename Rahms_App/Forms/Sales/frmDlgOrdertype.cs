using RAHMSLibrary.Entity.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RAHMS.Forms.RAHMS
{
    public partial class frmDlgOrdertype : Form
    {
        public Frm_CounterSale MyParentForm;
        IList<MstOrderType> orderTypeList = new List<MstOrderType>();
        public frmDlgOrdertype()
        {
            InitializeComponent();
        }

        private void CmbCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                cmbOrderType1.Focus();
                if (cmbOrderType1.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Please Select Order Type", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    ((Frm_CounterSale)MyParentForm).cmbOrderType.SelectedValue = cmbOrderType1.SelectedValue;
                    ((Frm_CounterSale)MyParentForm).OrderTypeEnter = true;
                   this.Close();
                }
            }
        }

        private void frmDlgOrdertype_Load(object sender, EventArgs e)
        {
            LoadOrderType();
            cmbOrderType1.Focus();
            cmbOrderType1.SelectedValue = 1;

        }


   

        private void LoadOrderType()
        {
            try
            {

                orderTypeList.Clear();
                orderTypeList = MstOrderType.GetAll();
                //orderTypeList.Add(new MstOrderType { ID = 0, OrderType = "--Select--" });

                cmbOrderType1.DisplayMember = "OrderType";
                cmbOrderType1.ValueMember = "Id";
                cmbOrderType1.DataSource = orderTypeList.OrderBy(id => id.OrderType).ToList<MstOrderType>();
                cmbOrderType1.SelectedIndex = 0;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
           
        }
    }
}
