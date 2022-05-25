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
    public partial class Mst_ManageRights : Form
    {
        public Mst_ManageRights()
        {
            InitializeComponent();
        }

        private void Mst_ManageRights_Load(object sender, EventArgs e)
        {
            LoadUserTypes(CmbType);


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

        private void LoadTreeView()
        {
            tvMenuAndSubMenu.Nodes.Clear();
            var userRights = UserRights.GetByUserTypesId(long.Parse(CmbType.SelectedValue.ToString()));

            TreeNode nodeParent;
            IList<MenuAndSubMenu> menuAndSubMenuLIst = MenuAndSubMenu.GetAll();
            var groupWiseParent = menuAndSubMenuLIst.Where(pi => pi.ParentId == 0).GroupBy(p => p.Name);
            foreach (var parent in groupWiseParent)
            {
                // Add the category node.
                var firstDefault = parent.FirstOrDefault();
                nodeParent = tvMenuAndSubMenu.Nodes.Add(firstDefault.Remarks);
                nodeParent.Name = firstDefault.ID + "_" + firstDefault.ParentId + "_" + firstDefault.Name;
                if (IsExist(nodeParent.Name, userRights))
                    nodeParent.Checked = true;
                nodeParent.ImageIndex = 0;
                nodeParent.Tag = firstDefault.Remarks;
                var getChilds = menuAndSubMenuLIst.Where(pi => pi.ParentId == firstDefault.ID);
                foreach (var child in getChilds)
                {
                    // Add a "dummy" node.
                    TreeNode node = GetNodes(userRights, child);
                    nodeParent.Nodes.Add(node);


                    var getForms = menuAndSubMenuLIst.Where(pi => pi.ParentId == child.ID);
                    if (getForms != null && getForms.Count() > 0)
                    {
                        foreach (var form in getForms)
                        {
                            TreeNode nodeForm = GetNodes(userRights, form);
                            node.Nodes.Add(nodeForm);

                            var getControls = menuAndSubMenuLIst.Where(pi => pi.ParentId == form.ID);

                            foreach (var control in getControls)
                            {
                                TreeNode nodeControl = GetNodes(userRights, control);
                                nodeForm.Nodes.Add(nodeControl);

                            }
                        }
                    }
                }

                nodeParent.ExpandAll();
            }

            tvMenuAndSubMenu.ExpandAll();
        }

        private TreeNode GetNodes(IList<UserRights> userRights, MenuAndSubMenu child)
        {
            TreeNode node = new TreeNode();
            node.Text = child.Remarks;
            node.ExpandAll();
            node.Name = child.ID + "_" + child.ParentId + "_" + child.Name;
            if (IsExist(node.Name, userRights))
                node.Checked = true;
            return node;
        }

        private bool IsExist(string nodeName, IList<UserRights> userRightsList)
        {
            long menuId = long.Parse(nodeName.Split('_')[0].ToString());
            var IsFound = userRightsList.Where(ur => ur.MenuId == menuId);
            if (IsFound != null && IsFound.Count() > 0)
                return true;
            return false;
        }


        private int SaveMenuAndSubMenuForUserReghts(System.Windows.Forms.TreeNode aNode)
        {
            var menuAndSubMenuList = MenuAndSubMenu.GetByRemarks(aNode.Text);
            if (menuAndSubMenuList != null && menuAndSubMenuList.Count > 0)
            {
                MenuAndSubMenu menuAndSubMenu = menuAndSubMenuList[0];
                UserRights userRight = new UserRights();
                userRight.CreatedBy = 1;
                userRight.ModifiedBy = 1;
                userRight.MenuId = menuAndSubMenu.ID.Value;
                userRight.MenuParentId = menuAndSubMenu.ParentId.Value;
                userRight.UserTypeId = long.Parse(CmbType.SelectedValue.ToString());

              return  UserRights.Save(userRight);
            }
            return 0;
        }
        private void DeleteMenuAndSubMenuForUserReghts(System.Windows.Forms.TreeNode aNode)
        {
            var menuAndSubMenuList = MenuAndSubMenu.GetByRemarks(aNode.Text);
            if (menuAndSubMenuList != null && menuAndSubMenuList.Count > 0)
            {
                UserRights.Delete(menuAndSubMenuList[0].ID.Value, long.Parse(CmbType.SelectedValue.ToString()));
            }
        }
        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbType.SelectedIndex > 0)
            {
                LoadTreeView();
            }
            else
                tvMenuAndSubMenu.Nodes.Clear();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to save rights for selected user type?", "Confirmation",
MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (System.Windows.Forms.TreeNode aNode in tvMenuAndSubMenu.Nodes)
                    {
                        if (aNode.Checked)
                            SaveMenuAndSubMenuForUserReghts(aNode);
                        else
                            DeleteMenuAndSubMenuForUserReghts(aNode);
                        foreach (System.Windows.Forms.TreeNode childNode in aNode.Nodes)
                        {
                            if (childNode.Checked)
                            {
                                SaveMenuAndSubMenuForUserReghts(childNode);
                                foreach (System.Windows.Forms.TreeNode form in childNode.Nodes)
                                {
                                    if (form.Checked)
                                    {
                                        SaveMenuAndSubMenuForUserReghts(form);

                                        foreach (System.Windows.Forms.TreeNode control in form.Nodes)
                                        {
                                            if (control.Checked)
                                                SaveMenuAndSubMenuForUserReghts(control);
                                            else
                                                DeleteMenuAndSubMenuForUserReghts(control);
                                        }
                                    }
                                    else
                                        DeleteMenuAndSubMenuForUserReghts(form);
                                }
                            }
                            else
                            {
                                DeleteMenuAndSubMenuForUserReghts(childNode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
