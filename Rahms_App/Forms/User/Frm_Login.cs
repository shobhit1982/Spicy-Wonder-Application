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
using RAHMSLibrary.Entity.Masters;

namespace RAHMS.Forms
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }
        private void Frm_Login_Load(object sender, EventArgs e)
        {
            LoadUser();

         //   LoadUserTypes(comboBox1);

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
        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (ValidateValues() == false)
            {
                return;
            }
            try
            {

             
                DateTime det = Convert.ToDateTime("11-11-2020");

                //if (DateTime.Now >= det )
                //{
                //    MessageBox.Show("This is Demo Version Please contect Mr. Mukesh(9457004956)");
                //    return;
                //}

               // string sql = "Select * from UserTable where Isvalid=1 and UserTypeName ='" + comboBox1.Text + "' and LoginId = '" + cmb_UserName.Text + "' and password ='" + TxtPassword.Text + "'";

                string sql = "Select * from UserTable where Isvalid=1 and LoginId = '" + cmb_UserName.Text + "' and password ='" + TxtPassword.Text + "'";
                DataSet ds = new DataSet();
                ds = ClsDBFunctions.RAHMS().ExecuteQuery_DataSet(sql, this.Name);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GlobalClass.UserTypeId = long.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                    GlobalClass.username = ds.Tables[0].Rows[0]["Loginid"].ToString();
                    GlobalClass.userNameid = ds.Tables[0].Rows[0]["Id"].ToString();
                    ModCommonFunctions.Getinstance().UserTypes.UserTypes = ds.Tables[0].Rows[0]["UserTypeName"].ToString();
                    ModCommonFunctions.Getinstance().UserTypes.UserName = ds.Tables[0].Rows[0]["LoginId"].ToString();

                    this.Hide();
                    MDI frm = new MDI();
                    frm.ShowDialog();
                    return;
                }

                else
                    MessageBox.Show("Incorrct UserName  And Password");
                return;

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                //return;
            }

        }

        private Boolean ValidateValues()
        {
            Boolean result = true;
            try
            {
                if (cmb_UserName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter User Name", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmb_UserName.Focus();
                    result = false;
                    return result;
                }

                if (TxtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtPassword.Focus();
                    result = false;
                    return result;
                }

            }
            catch (Exception ex)
            {
                ModCommonFunctions.Getinstance().AddToLog(ex);
            }
            return result;

        }



        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_Login_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }


        private void comboBox1_Enter(object sender, EventArgs e)
        {
            string sql = "select * from UserTable where isvalid=1 and UserTypeName ='" + comboBox1.Text + "'";

            DataSet ds = GlobalClass.executeQuery(sql, "cust");

            cmb_UserName.DataSource = ds.Tables["cust"];
            cmb_UserName.DisplayMember = "LoginId";

        }

        private void LoadUser()
        {
            string sql = "select * from UserTable where isvalid=1";

            DataSet ds = GlobalClass.executeQuery(sql, "cust");

            cmb_UserName.DataSource = ds.Tables["cust"];
            cmb_UserName.DisplayMember = "LoginId";

        }


    }




}
