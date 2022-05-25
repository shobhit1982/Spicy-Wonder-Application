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
    public partial class Frm_TaxMaster : Form
    {
        public Frm_TaxMaster()
        {
            InitializeComponent();
        }
       
        private void Frm_TaxMaster_Load(object sender, EventArgs e)
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
            var itemList = Taxes.GetAll();
            if (itemList != null && itemList.Count > 0)
            {
                var result = from dis in itemList
                             select new { ID = dis.ID, Tax = dis.Name, Rate = dis.Rate, Description = dis.Description, IsValid = dis.IsValid };
                if (result != null && result.Count() > 0)
                {
                    dgvSeriesMaster.DataSource = result.ToList();
                    dgvSeriesMaster.Columns[2].Visible = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textName.Text.Trim()) && !string.IsNullOrEmpty(textRate.Text.Trim()))
                {
                    Taxes taxes = new Taxes();
                    taxes.Name = textName.Text.Trim();
                    taxes.Description = textDescription.Text.Trim();
                    taxes.Rate = decimal.Parse(textRate.Text.Trim());
                    taxes.IsValid = 1;
                    taxes.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    taxes.CreatedBy = long.Parse(GlobalClass.userNameid);
                    Taxes.Insert(taxes);

                    BindGrid();
                }
                else
                    MessageBox.Show("tax name and rate are required field!! !!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        void dgvTaxMaster_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0://edit
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;


                    var details = Taxes.GetById(int.Parse(dgvSeriesMaster.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    if (details != null)
                    {
                        textName.Text = details.Name;
                        textDescription.Text = details.Description;
                        textRate.Text = details.Rate.Value.ToString();
                        textName.Focus();
                        lblId.Text = details.ID.ToString();
                    }

                    break;
                case 1://delete


                    DialogResult result = MessageBox.Show("Do you want to delete selected tax?", "Confirmation",
MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Taxes.DeleteById(int.Parse(dgvSeriesMaster.Rows[e.RowIndex].Cells[2].Value.ToString()));
                        BindGrid();
                    }


                    break;
            }
        }

      
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (lblId.Text != "XXX")
            {

                DialogResult result = MessageBox.Show("Do you want to update ?", "Confirmation",
MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    var details = Taxes.GetById(int.Parse(lblId.Text));
                    details.Name = textName.Text.Trim();

                    details.Rate = decimal.Parse(textRate.Text.Trim());
                    details.Description = textDescription.Text.Trim();
                    details.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    Taxes.Update(details);

                    BindGrid();

                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    textName.ResetText();
                    textDescription.ResetText();
                    textRate.ResetText();
                    lblId.Text = "XXX";
                }

            }
            else
            {
                MessageBox.Show("Select user type!");
            }
        }

        private void textRate_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
