using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RAHMS.Entity;
using RAHMSLibrary.Entity.Masters;

namespace RAHMS.Forms
{
    public partial class Mst_MenuAndSubMenu : Form
    {
        public Mst_MenuAndSubMenu()
        {
            InitializeComponent();

        }
        int menuTypeFlag = 0;
        private void Mst_MenuAndSubMenu_Load(object sender, EventArgs e)
        {

            LoadMenu(cmbParentMenu, 0);
            menuTypeFlag = 1;//indicate to save master menu
            lblOption.Text = "Add MsterMenu by enter in Textbox";
            textName.Focus();
            LoadGrid(0);
            comboSubMenu.Enabled = false;
        }
        private void LoadGrid(long parentId)
        {
            var menuList = MenuAndSubMenu.GetAll();
            if (menuList != null && menuList.Count > 0)
            {
                menuList = menuList.Where(p => p.ParentId == parentId).ToList<MenuAndSubMenu>();
                dgvItemMaster.DataSource = menuList;
            }

        }
        private void LoadMenu(ComboBox combo, int parentId)
        {
            var menuList = MenuAndSubMenu.GetByParentId(parentId);
            if (menuList != null && menuList.Count > 0)
            {

                menuList.Add(new MenuAndSubMenu { ID = 0, Remarks = "--Select--" });

                combo.DisplayMember = "Remarks";
                combo.ValueMember = "Id";
                combo.DataSource = menuList.OrderBy(id => id.ID).ToList<MenuAndSubMenu>();
                combo.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to save?", "Confirmation",
MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void cmbParentMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParentMenu.SelectedIndex > 0)
            {
                LoadMenu(comboSubMenu, int.Parse(cmbParentMenu.SelectedValue.ToString()));
                menuTypeFlag = 2;//indicate to save sub menu
                lblSubMneu.Text = "Sub Menu Name"; 
                lblOption.Text = "Add SubMenu for :" + cmbParentMenu.Text.ToUpper() + ".";
                comboSubMenu.Enabled = true;
                textName.Focus();
                LoadGrid(long.Parse(cmbParentMenu.SelectedValue.ToString()));
            }
            else
            {
                lblSubMneu.Text = "Menu Name";
                comboSubMenu.Enabled = false;
            }
        }

        private void comboSubMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboSubMenu.SelectedIndex > 0)
            {
                var formName = MenuAndSubMenu.GetByParentId(int.Parse(comboSubMenu.SelectedValue.ToString()));
                if (formName != null && formName.Count > 0)
                {
                    menuTypeFlag = 3;//indicate to save contyrol menu
                    lblOption.Text = "Add control for:" + comboSubMenu.Text.ToUpper() + ".";
                    LoadGrid(formName[0].ID.Value);
                    textName.Focus();
                }
                lblSubMneu.Text = "Control Id";

            }
        }

    }
}
