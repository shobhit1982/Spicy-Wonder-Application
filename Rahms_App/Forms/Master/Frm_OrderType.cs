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
    public partial class Frm_OrderType : Form
    {
        public Frm_OrderType()
        {
            InitializeComponent();
        }
        private void Frm_Unit_Load(object sender, EventArgs e)
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
            var itemList = MstOrderType.GetAll();
            if (itemList != null && itemList.Count > 0)
            {
                var discountList = from dis in itemList
                                   select new { ID = dis.ID, Unit = dis.OrderType, Description = dis.IsDefault, IsValid = dis.IsValid };
                if (discountList != null && discountList.Count() > 0)
                {
                    dgvUnit.DataSource = discountList.ToList();
                    dgvUnit.Columns[2].Visible = false;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (!string.IsNullOrEmpty(textName.Text.Trim()))
                {
                    MstOrderType unit = new MstOrderType();
                    unit.OrderType = textName.Text.Trim();
                    unit.IsDefault = Convert.ToInt32(chkDefault.Checked);

                    unit.IsValid = 1;
                    unit.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    unit.CreatedBy = long.Parse(GlobalClass.userNameid);
                    MstOrderType.Insert(unit);

                    BindGrid();
                }
                else
                    MessageBox.Show("Order Type is required !!");
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

                    var details = MstOrderType.GetById(int.Parse(lblId.Text));
                    details.OrderType = textName.Text.Trim();

                    details.IsDefault = Convert.ToInt32(chkDefault.Checked);
                    details.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    MstOrderType.Update(details);

                    BindGrid();

                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    textName.ResetText();
                    chkDefault.Checked = false;


                    lblId.Text = "XXX";
                }

            }
            else
            {
                MessageBox.Show("Select Order type!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void dgvUnit_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0://edit
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;


                    var details = MstOrderType.GetById(int.Parse(dgvUnit.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    if (details != null)
                    {
                        textName.Text = details.OrderType;
                        chkDefault.Checked =Convert.ToBoolean( details.IsDefault);
                     
                        textName.Focus();
                        lblId.Text = details.ID.ToString();
                    }

                    break;
                case 1://delete


                    DialogResult result = MessageBox.Show("Do you want to delete Unit?", "Confirmation",
MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        MstOrderType.DeleteById(int.Parse(dgvUnit.Rows[e.RowIndex].Cells[2].Value.ToString()));
                        BindGrid();
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
