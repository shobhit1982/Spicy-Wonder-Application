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
    public partial class Frm_SeriesMaster : Form
    {
        public Frm_SeriesMaster()
        {
            InitializeComponent();
        }
        private void Frm_SeriesMaster_Load(object sender, EventArgs e)
        {
            try
            {
                dgvItemSeries.DataSource = ItemSeries.GetAll();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textName.Text.Trim()))
                {
                    ItemSeries itemSeries = new ItemSeries();
                    itemSeries.Name = textName.Text.Trim();
                    itemSeries.Description = textDescription.Text.Trim();                 
                    itemSeries.IsValid = 1;
                    itemSeries.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    itemSeries.CreatedBy = long.Parse(GlobalClass.userNameid);
                    ItemSeries.Insert(itemSeries);

                    dgvItemSeries.DataSource = ItemSeries.GetAll();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblId.Text != "XXX")
            {

                DialogResult result = MessageBox.Show("Do you want to update ?", "Confirmation",
MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    var details = ItemSeries.GetById(int.Parse(lblId.Text));
                    details.Name = textName.Text.Trim();
                    details.Description = textDescription.Text.Trim();
                    details.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    details.ModifiedDate = DateTime.Now;
                    ItemSeries.Update(details);

                    dgvItemSeries.DataSource = ItemSeries.GetAll();

                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    textName.ResetText();
                    textDescription.ResetText();                  
                    lblId.Text = "XXX";
                }

            }
            else
            {
                MessageBox.Show("Select user type!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void dgvItemSeries_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0://edit
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;


                    var details = ItemSeries.GetById(int.Parse(dgvItemSeries.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    if (details != null)
                    {
                        textName.Text = details.Name;
                        textDescription.Text = details.Description;                     
                        textName.Focus();
                        lblId.Text = details.ID.ToString();
                    }

                    break;
                case 1://delete


                    DialogResult result = MessageBox.Show("Do you want to delete selected tax?", "Confirmation",
MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ItemSeries.DeleteById(int.Parse(dgvItemSeries.Rows[e.RowIndex].Cells[2].Value.ToString()));
                        dgvItemSeries.DataSource = ItemSeries.GetAll();
                    }


                    break;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }
    }
}
