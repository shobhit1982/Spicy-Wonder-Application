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
    public partial class Frm_Discount : Form
    {
        public Frm_Discount()
        {
            InitializeComponent();
        }
        private void Frm_Discount_Load(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid()
        {
            var disList = DiscountManage.GetAll();
            if (disList != null && disList.Count > 0)
            {
                var discount = from dis in disList
                               select new { ID = dis.ID, Discount = dis.Discount, Description = dis.Description, IsValid = dis.IsValid };
                if (discount != null && discount.Count() > 0)
                {
                    dgvDiscount.DataSource = discount.ToList();
                    dgvDiscount.Columns[2].Visible = false;
                }
            }
        }
        private void textDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textDiscount.Text.Trim()))
                {
                    DiscountManage discount = new DiscountManage();
                    discount.Discount = int.Parse(textDiscount.Text.Trim());
                    discount.Description = textDescription.Text.Trim();

                    discount.IsValid = 1;
                    discount.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    discount.CreatedBy = long.Parse(GlobalClass.userNameid);
                    DiscountManage.Insert(discount);

                    BindGrid();
                }
                else
                    MessageBox.Show("Name and table number are required !!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void dgvDiscount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0://edit
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;

                    int itemMasterId = int.Parse(dgvDiscount.Rows[e.RowIndex].Cells[2].Value.ToString());
                    var details = DiscountManage.GetById(itemMasterId);
                    if (details != null)
                    {
                        textDiscount.Text = details.Discount.ToString();
                        textDescription.Text = details.Description;

                        textDiscount.Focus();
                        lblId.Text = details.ID.ToString();
                    }

                    break;
                case 1://delete

                    DialogResult result = MessageBox.Show("Do you want to delete selected Item?", "Confirmation",
MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DiscountManage.DeleteById(int.Parse(dgvDiscount.Rows[e.RowIndex].Cells[2].Value.ToString()));

                        BindGrid();
                    }


                    break;
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (lblId.Text != "XXX")
            {
                DialogResult result = MessageBox.Show("Do you want to update ?", "Confirmation",
MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var details = DiscountManage.GetById(int.Parse(lblId.Text));
                    details.Discount = int.Parse(textDiscount.Text.Trim());
                    details.Description = textDescription.Text.Trim();
                    details.IsValid = 1;
                    details.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    details.ModifiedDate = DateTime.Now;
                    DiscountManage.Update(details);

                    BindGrid();

                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    textDiscount.ResetText();

                    textDescription.ResetText();
                    lblId.Text = "XXX";
                }
            }
            else
            {
                MessageBox.Show("Select Item !");
            }
        }


    }
}
