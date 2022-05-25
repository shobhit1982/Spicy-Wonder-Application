using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RAHMS.Entity;
using RAHMSLibrary.Entity.Masters;
using System.Linq;

namespace RAHMS.Forms
{
    public partial class Mst_UserTypess : Form
    {
        public Mst_UserTypess()
        {
            InitializeComponent();
         
        }
        private void Mst_UserTypess_Load(object sender, EventArgs e)
        {
            LoadDataGrid(1);
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void LoadDataGrid(long UserId)
        {
            var itemList = UserTypes.GetAll();
            if (itemList != null && itemList.Count > 0)
            {
                var discountList = from dis in itemList
                                   select new { ID = dis.ID, Name = dis.Name, Description = dis.Description, IsValid = dis.IsValid };
                if (discountList != null && discountList.Count() > 0)
                {
                    dgvUserRtpes.DataSource = discountList.ToList();
                    dgvUserRtpes.Columns[2].Visible = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               UserTypes entity=new UserTypes();
                entity.Name = textName.Text.Trim();
                entity.Remarks = textDescription.Text.Trim();
                entity.CreatedBy = long.Parse(GlobalClass.userNameid);
                entity.ModifiedBy = long.Parse(GlobalClass.userNameid);
                UserTypes.Insert(entity);

                LoadDataGrid(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void dgvUserRtpes_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0://edit
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;


                    var details = UserTypes.GetById(int.Parse(dgvUserRtpes.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    if (details != null)
                    {
                        textName.Text = details.Name;
                        textDescription.Text = details.Remarks;
                       
                        textName.Focus();
                        lblId.Text = details.ID.ToString();
                    }

                    break;
                case 1://delete


                    DialogResult result = MessageBox.Show("Do you want to delete user?", "Confirmation",
MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        UserTypes.DeleteById(int.Parse(dgvUserRtpes.Rows[e.RowIndex].Cells[2].Value.ToString()));
                        LoadDataGrid(1);
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

                    var details = UserTypes.GetById(int.Parse(lblId.Text));
                    details.Name = textName.Text.Trim();
                    details.Remarks = textDescription.Text.Trim();
                    details.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    UserTypes.Update(details);

                    LoadDataGrid(1);

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

      
       
    }
}
