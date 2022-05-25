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
    public partial class Frm_Location : Form
    {
        public Frm_Location()
        {
            InitializeComponent();
        }

        private void Frm_Location_Load(object sender, EventArgs e)
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
            var itemList = SeatingLocation.GetAll();
            if (itemList != null && itemList.Count > 0)
            {
                var discountList = from dis in itemList
                                   select new { ID = dis.ID, Name = dis.Name, Seats = dis.Seats, IsValid = dis.IsValid };
                if (discountList != null && discountList.Count() > 0)
                {
                    dgvLocation.DataSource = discountList.ToList();
                    dgvLocation.Columns[2].Visible = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textName.Text.Trim()))
                {
                    SeatingLocation seatingLocation = new SeatingLocation();
                    seatingLocation.Name = textName.Text.Trim();
                    seatingLocation.Remarks = textDescription.Text.Trim();
                    seatingLocation.Seats = int.Parse(textTotalTable.Text.Trim());
                    seatingLocation.IsValid = 1;
                    seatingLocation.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    seatingLocation.CreatedBy = long.Parse(GlobalClass.userNameid);
                    SeatingLocation.Insert(seatingLocation);

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
        void dgvLocation_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0://edit
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;


                    var details = SeatingLocation.GetById(int.Parse(dgvLocation.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    if (details != null)
                    {
                        textName.Text = details.Name;
                        textDescription.Text = details.Remarks;
                        textTotalTable.Text = details.Seats.ToString();
                        textName.Focus();
                        lblId.Text = details.ID.ToString();
                    }

                    break;
                case 1://delete


                    DialogResult result = MessageBox.Show("Do you want to delete user?", "Confirmation",
MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        SeatingLocation.DeleteById(int.Parse(dgvLocation.Rows[e.RowIndex].Cells[2].Value.ToString()));
                        BindGrid();
                    }


                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblId.Text != "XXX")
            {

                DialogResult result = MessageBox.Show("Do you want to update ?", "Confirmation",
MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    var details = SeatingLocation.GetById(int.Parse(lblId.Text));
                    details.Name = textName.Text.Trim();

                    details.Seats = int.Parse(textTotalTable.Text.Trim());
                    details.Remarks = textDescription.Text.Trim();
                    details.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    SeatingLocation.Update(details);

                    BindGrid();

                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    textName.ResetText();
                    textDescription.ResetText();
                    textTotalTable.ResetText();
                    lblId.Text = "XXX";
                }

            }
            else
            {
                MessageBox.Show("Select user type!");
            }
        }

        private void textTotalTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
    }
}
