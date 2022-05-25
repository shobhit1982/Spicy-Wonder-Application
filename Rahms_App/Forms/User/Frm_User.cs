using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using RAHMS.Entity;
using System.Collections;
using System.Text.RegularExpressions;
using RAHMSLibrary.Entity.Masters;

namespace RAHMS.Forms
{
    public partial class Frm_User : Form
    {
        public Frm_User()
        {
            InitializeComponent();

        }
        private void Frm_User_Load(object sender, EventArgs e)
        {
          
           
            LoadUserTypes(CmbType);
            LoadUserTypes(cmbSearchUserTypes);
            LoadUsers();
            btnUpdate.Enabled = false;
        }
        private void LoadUsers()
        {
            IList usersList = (from user in UserTable.GetAll()
                               select new { ID = user.Id, LoginId = user.LoginId, Name = user.Name, Password = user.Password, UserTypes = user.UserTypeName, Mobile = user.Mobile, Email = user.Email, IsValid=user.IsValid }).ToList();

            grd.DataSource = usersList;
        }
        private void LoadUserTypes(ComboBox combo)
        {
            var UserTypessList = UserTypes.GetAll();
            UserTypessList.Add(new UserTypes { ID = 0, Name = "--Select--" });

            combo.DisplayMember = "Name";
            combo.ValueMember = "Id";
            combo.DataSource = UserTypessList.OrderBy(id => id.ID).ToList<UserTypes>();
            combo.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CmbType.SelectedIndex > 0)
            {
                if (Validate())
                {
                    DialogResult result = MessageBox.Show("Do you want to save ?", "Confirmation",
  MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        UserTable userTable = new UserTable();
                        userTable.Name = txt_Username.Text.Trim();
                        userTable.LoginId = txtLoginId.Text.Trim();
                        userTable.Password = txt_Password.Text.Trim();
                        userTable.Email = txtEmail.Text.Trim();
                        userTable.Mobile = textMobile.Text.Trim();
                        userTable.Address = textAddress.Text.Trim();
                        userTable.UserTypes = long.Parse(CmbType.SelectedValue.ToString());
                        userTable.UserTypeName = CmbType.Text;
                        userTable.CreatedBy = long.Parse(GlobalClass.userNameid);
                        userTable.ModifiedBy = long.Parse(GlobalClass.userNameid);
                        UserTable.Save(userTable);


                        LoadUsers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select user type!");
            }
        }

        private void txtLoginId_Leave(object sender, EventArgs e)
        {
            // ValidateLoginId();

        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //  ValidateEmail();
        }

        private void textMobile_Leave(object sender, EventArgs e)
        {
            // ValidatePhone();
        }

        private bool Validate()
        {
            if (!ValidateLoginId())
            {
                MessageBox.Show(" Login Id shoul be morethan 3 char and unique!!");
                txtLoginId.Focus();
                return false;
            }
            if (!ValidateEmail())
            {
                MessageBox.Show("Email Id should be unique and Email ID shoul be more than 4 char in lenght  ex: xxxx@gmail.com");
                txtEmail.Focus();
                return false;
            }
            if (!ValidatePhone())
            {
                MessageBox.Show("Mobile number should be unique and in correct format!!");
                textMobile.Focus();
                return false;
            }
            return true;
        }
        private bool ValidateLoginId()
        {
            if (txtLoginId.Text.Trim().Length <= 0)
                return false;
            if (txtLoginId.Text.Trim().Length > 0)
            {
                var userTables = UserTable.GetByLoginId(txtLoginId.Text.Trim().ToUpper());

                if (txtLoginId.ReadOnly)
                {
                    if (userTables != null && userTables.Count > 0 && userTables[0].LoginId.ToUpper() != txtLoginId.Text.ToUpper())
                    {
                        return false;
                    }
                }
                else
                {
                    if (userTables != null && userTables.Count > 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        private bool ValidateEmail()
        {
            //if (txtEmail.Text.Trim().Length <= 0)
            //    return false;
            if (txtEmail.Text.Trim().Length > 0)
            {
                var userTables = UserTable.GetByEmailId(txtEmail.Text.Trim().ToUpper());
                if (txtLoginId.ReadOnly)
                {
                    if (userTables != null && userTables.Count > 0 && userTables[0].LoginId.ToUpper() != txtLoginId.Text.ToUpper())
                        return false;
                }
                else
                {
                    if (userTables != null && userTables.Count > 0)
                        return false;
                }
                //if (!email(txtEmail.Text.Trim()))
                //{
                //    return false;
                //}
            }
            return true;
        }
        private bool ValidatePhone()
        {
            //if (textMobile.Text.Trim().Length <= 0) return false;
            if (textMobile.Text.Trim().Length > 0)
            {
                var userTables = UserTable.GetByMobile(textMobile.Text.Trim().ToUpper());


                if (txtLoginId.ReadOnly)
                {
                    if (userTables != null && userTables.Count > 0 && userTables[0].LoginId.ToUpper() != txtLoginId.Text.ToUpper())
                    {
                        return false;
                    }
                }
                else
                {
                    if (userTables != null && userTables.Count > 0)
                    {
                        return false;
                    }
                }
                //if (!phone(textMobile.Text.Trim()))
                //{
                //    return false;
                //}
            }
            return true;
        }

        private void grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (e.ColumnIndex)
            {
                case 0://edit
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                    if (grd.Rows[e.RowIndex].Cells[2].Value.ToString() == "4")
                    {
                        MessageBox.Show("System administrator can not be edited!!!!");
                    }
                    else
                    {
                        var userDetails = UserTable.GetByLoginId(grd.Rows[e.RowIndex].Cells[3].Value.ToString());
                        if (userDetails != null && userDetails.Count > 0)
                        {
                            CmbType.Text = userDetails[0].UserTypeName;
                            txt_Username.Text = userDetails[0].Name;
                            txtLoginId.Text = userDetails[0].LoginId;
                            txt_Password.Text = userDetails[0].Password;
                            txtEmail.Text = userDetails[0].Email;
                            textMobile.Text = userDetails[0].Mobile;
                            textAddress.Text = userDetails[0].Address;
                            txt_Username.Focus();
                            txtLoginId.ReadOnly = true;
                        }
                    }
                    break;
                case 1://delete
                    if (grd.Rows[e.RowIndex].Cells[2].Value.ToString() == "4")
                    {
                        MessageBox.Show("System administrator can not be deleted!!!!");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete user?", "Confirmation",
  MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            UserTable.Delete(long.Parse(grd.Rows[e.RowIndex].Cells[2].Value.ToString()));
                            btnUpdate.Enabled = false;
                            btnSave.Enabled = true;
                            txtLoginId.ReadOnly = false;
                            txt_Password.ResetText();
                            txt_Username.ResetText();
                            txtEmail.ResetText();
                            txtLoginId.ResetText();
                            textAddress.ResetText();
                            textMobile.ResetText();
                            CmbType.SelectedIndex = 0;
                            LoadUsers();
                        }

                    }
                    break;
            }

        }
        public bool email(string email)
        {
            Regex expr = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (expr.IsMatch(email))
            {
                return true;
            }
            else return false;
        }
        public bool phone(string no)
        {
            Regex expr = new Regex(@"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$");
            if (expr.IsMatch(no))
            {
                return true;
            }
            else return false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CmbType.SelectedIndex > 0)
            {
                if (Validate())
                {
                    DialogResult result = MessageBox.Show("Do you want to update ?", "Confirmation",
 MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        txtEmail_Leave(sender, e);
                        textMobile_Leave(sender, e);
                        UserTable userTable = UserTable.GetByLoginId(txtLoginId.Text.Trim())[0];
                        userTable.Name = txt_Username.Text.Trim();

                        userTable.Password = txt_Password.Text.Trim();
                        userTable.Email = txtEmail.Text.Trim();
                        userTable.Mobile = textMobile.Text.Trim();
                        userTable.Address = textAddress.Text.Trim();
                        userTable.UserTypes = long.Parse(CmbType.SelectedValue.ToString());
                        userTable.UserTypeName = CmbType.Text;
                        userTable.ModifiedBy = long.Parse(GlobalClass.userNameid);
                        UserTable.Update(userTable);

                       
                        LoadUsers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select user type!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                UserTable search = new UserTable();
                search.UserTypeName = cmbSearchUserTypes.Text;
                search.Mobile = txtSearchMobile.Text.Trim();
                search.Email = txtSearchEmail.Text.Trim();
                search.LoginId = txtSearchLoginId.Text.Trim();

                IList usersList = (from user in UserTable.Search(search)
                                   select new { ID = user.Id, LoginId = user.LoginId, Name = user.Name, Password = user.Password, UserTypes = user.UserTypeName, Mobile = user.Mobile, Email = user.Email, CreatedDate = user.CreatedDate }).ToList();


                grd.DataSource = null;
                grd.Refresh();
                grd.DataSource = usersList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txt_Password.ResetText();
            txt_Username.ResetText();
            txtEmail.ResetText();
            txtLoginId.ResetText();
            textAddress.ResetText();
            textMobile.ResetText();
            CmbType.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }







        #region Old Code
        //DataGridViewRow Editrow = null;
        //string s;

        //string y;
        //private void txt_Discount_TextChanged(object sender, EventArgs e)
        //{

        //}
        //private void SetGrid()
        //{
        //    //With...
        //    int colCount = 4;
        //    int colWidth = 60;
        //    int index;
        //    int x;
        //    for (x = 0; (x <= colCount); x++)
        //    {
        //        switch (x)
        //        {
        //            case 0:
        //                string sql = "select * from Tbl_Login";
        //                DataSet ds = new DataSet();
        //                ds = ClsDBFunctions.GetInstance().ExecuteQuery_DataSet(sql, this.Name);

        //                break;
        //            case 1:
        //                index = grd.Columns.Add("ID", "ID");
        //                grd.Columns[index].Width = colWidth;
        //                grd.Columns[index].Visible = false;
        //                break;
        //            case 2:
        //                index = grd.Columns.Add("USER TYPE", "USER TYPE");
        //                grd.Columns[index].Width = colWidth;
        //                break;
        //            case 3:
        //                index = grd.Columns.Add("NAME", "NAME");
        //                grd.Columns[index].Visible = true;
        //                break;

        //        }
        //    }
        //}

        //private void Frm_User_Load(object sender, EventArgs e)
        //{
        //    //SetGrid();
        //    SetControls();
        //    loadgrid();

        //}

        //private string chklstbox()
        //{
        //    s = "";
        //    y = "";
        //    StringBuilder sb = new StringBuilder();

        //    foreach (int checkeditem in checkedListBox1.CheckedIndices)
        //    {
        //        s = checkeditem.ToString();
        //        y = sb.Append(s).ToString();

        //    }


        //    return y;
        //}
        //private void loadgrid()
        //{
        //    grd.DataSource = null;
        //    grd.Rows.Clear();
        //    //List<Cls_Login> lislog = new List<Cls_Login>();
        //    //lislog = Cls_Login.Getinstance().GetAlls(this.Name);
        //    //if (lislog != null)
        //    //{
        //    //    grd.DataSource = lislog;
        //    //    //foreach (Cls_Login obj in lislog)
        //    //    //{

        //    //    //}
        //    //}

        //    string sql = "Select id,UserTypes ,username,password from tbl_login";
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    ds = ClsDBFunctions.GetInstance().ExecuteQuery_DataSet(sql, this.Name);

        //    //da.Fill(dt);

        //    grd.DataSource = ds.Tables[0];
        //    // grd.DataMember = ;
        //}
        //private void SetControls()
        //{
        //    Txt_code.Text = "";
        //    CmbType.Text = "";
        //    txt_Username.Text = "";
        //    txt_Password.Text = "";
        //    checkedListBox1.SetItemCheckState(0, CheckState.Unchecked);
        //    checkedListBox1.SetItemCheckState(1, CheckState.Unchecked);
        //    checkedListBox1.SetItemCheckState(2, CheckState.Unchecked);
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (ValidateValues() == true)
        //        return;
        //    Cls_UserMaster obj = new Cls_UserMaster();
        //    obj.UserTypes = (CmbType.Text.ToString());
        //    obj.UserName = txt_Username.Text;
        //    obj.Password = txt_Password.Text;
        //    obj.Restriction = chklstbox();

        //    #region Check Duplicate

        //    string query = "select * from  tbl_Login where UserTypes ='" + obj.UserTypes + "' and userName = '" + txt_Username.Text + "'";
        //    DataSet ds = new DataSet();
        //    ds = ClsDBFunctions.GetInstance().ExecuteQuery_DataSet(query, this.Name);
        //    //int id =  int.Parse(ds.Tables[0].Rows[0][0].);
        //    if (ds.Tables[0].Rows.Count != 0)
        //    {
        //        MessageBox.Show("This Item User Name is already Exists in this Category", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        CmbType.Text = "";
        //        txt_Username.Text = "";
        //        CmbType.Focus();
        //        return;
        //    }

        //    #endregion

        //    int val = obj.Insertdata(this.Name);

        //    if (val == 1)
        //    {
        //        MessageBox.Show("Record is Saved", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    else { MessageBox.Show("Record is not Saved", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information); }

        //    SetControls();
        //    loadgrid();

        //}


        //private Boolean ValidateValues()
        //{
        //    Boolean result = false;
        //    try
        //    {
        //        if (CmbType.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Select User Type", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            CmbType.Focus();
        //            result = true;
        //            return result;
        //        }

        //        if (txt_Username.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Enter The User Name", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txt_Username.Focus();
        //            result = true;
        //            return result;
        //        }
        //        if (txt_Password.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Set the Password M", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txt_Password.Focus();
        //            result = true;
        //            return result;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ModCommonFunctions.Getinstance().AddToLog(ex);
        //    }
        //    return result;
        //}

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();

        //}

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    //chklstbox();
        //    if ((CmbType.Text == "") || (txt_Username.Text == "") || (txt_Password.Text == ""))
        //    {
        //        MessageBox.Show("Please Fill In The All Entries");
        //        return;
        //    }
        //    string sql = "update Tbl_Login set UserTypes='" + CmbType.Text + "',UserName='" + txt_Username.Text + "',Password='" + txt_Password.Text + "' ,Restriction='" + chklstbox() + "' where ID=" + Txt_code.Text + "";
        //    DataSet ds = new DataSet();
        //    ds = ClsDBFunctions.GetInstance().ExecuteQuery_DataSet(sql, this.Name);
        //    MessageBox.Show("Record Updated Successfully");
        //    CmbType.SelectedIndex = -1;
        //    Txt_code.Text = "";
        //    txt_Password.Text = "";
        //    txt_Username.Text = "";
        //    loadgrid();
        //    SetControls();


        //    //grd.DataSource = ds.Tables[0];
        //    //string sql1 = "Select UserTypes ,username,password from tbl_login";
        //    //DataSet ds1 = new DataSet();
        //    //DataTable dt = new DataTable();
        //    //ds = ClsDBFunctions.GetInstance().ExecuteQuery_DataSet(sql, this.Name);

        //    ////da.Fill(dt);

        //    //grd.DataSource = ds1.Tables[1];


        //}

        //private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        Editrow = grd.Rows[e.RowIndex];
        //        Txt_code.Text = grd.Rows[e.RowIndex].Cells["id"].Value.ToString();
        //        CmbType.Text = grd.Rows[e.RowIndex].Cells["UserTypes"].Value.ToString();
        //        txt_Username.Text = grd.Rows[e.RowIndex].Cells["username"].Value.ToString();
        //        txt_Password.Text = grd.Rows[e.RowIndex].Cells["password"].Value.ToString();
        //        string sql = "select restriction from tbl_login where username='" + txt_Username.Text + "'";
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        ds = ClsDBFunctions.GetInstance().ExecuteQuery_DataSet(sql, this.Name);
        //        string str = ds.Tables[0].Rows[0]["restriction"].ToString();
        //        if (str == "012")
        //        {

        //            checkedListBox1.SetItemCheckState(0, CheckState.Checked);
        //            checkedListBox1.SetItemCheckState(1, CheckState.Checked);
        //            checkedListBox1.SetItemCheckState(2, CheckState.Checked);


        //        }
        //        else if (str == "01")
        //        {
        //            checkedListBox1.SetItemCheckState(0, CheckState.Checked);
        //            checkedListBox1.SetItemCheckState(1, CheckState.Checked);
        //            checkedListBox1.SetItemCheckState(2, CheckState.Unchecked);
        //        }
        //        else if (str == "02")
        //        {
        //            checkedListBox1.SetItemCheckState(0, CheckState.Checked);
        //            checkedListBox1.SetItemCheckState(1, CheckState.Unchecked);
        //            checkedListBox1.SetItemCheckState(2, CheckState.Checked);

        //        }
        //        else if (str == "12")
        //        {

        //            checkedListBox1.SetItemCheckState(0, CheckState.Unchecked);
        //            checkedListBox1.SetItemCheckState(1, CheckState.Checked);
        //            checkedListBox1.SetItemCheckState(2, CheckState.Checked);
        //        }
        //        else if (str == "0")
        //        {
        //            checkedListBox1.SetItemCheckState(0, CheckState.Checked);
        //            checkedListBox1.SetItemCheckState(1, CheckState.Unchecked);
        //            checkedListBox1.SetItemCheckState(2, CheckState.Unchecked);
        //        }
        //        else if (str == "1")
        //        {
        //            checkedListBox1.SetItemCheckState(0, CheckState.Unchecked);
        //            checkedListBox1.SetItemCheckState(1, CheckState.Checked);
        //            checkedListBox1.SetItemCheckState(2, CheckState.Unchecked);
        //        }
        //        else if (str == "2")
        //        {

        //            checkedListBox1.SetItemCheckState(0, CheckState.Unchecked);
        //            checkedListBox1.SetItemCheckState(1, CheckState.Unchecked);
        //            checkedListBox1.SetItemCheckState(2, CheckState.Checked);
        //        }
        //        btnUpdate.Enabled = true;
        //        btnSave.Enabled = false;
        //    }
        //}

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    Txt_code.Text = "";
        //    txt_Password.Text = "";
        //    txt_Username.Text = "";
        //    CmbType.SelectedIndex = -1;

        //}

        //private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (CmbType.SelectedIndex == 0)
        //    //{
        //    //    checkedListBox1.Enabled = false;

        //    //}
        //    //else
        //    //{
        //    //    checkedListBox1.Enabled = true;
        //    //}
        //} 
        #endregion

    }

}
