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
    public partial class Frm_ItemMaster : Form,IDisposable
    {
        public Frm_ItemMaster()
        {
            InitializeComponent();
            this.Load += Frm_ItemMaster_Load;
           

        }

        IList<Unit> unitList = new List<Unit>();
        IList<ItemSeries> itemSeriesList = new List<ItemSeries>();

        private void Frm_ItemMaster_Load(object sender, EventArgs e)
        {
            try
            {
                // LoadItemSeries(cmbItemSeries);
                // LoadItemSeries(comboSearchSeries);
                LoadUnit();


                LoadDatagridView();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadItemSeries(ComboBox comboBox)
        {
            itemSeriesList.Clear();
            itemSeriesList = ItemSeries.GetAll();
            if (itemSeriesList != null && itemSeriesList.Count > 0)
            {
                itemSeriesList.Add(new ItemSeries { ID = 0, DisplayName = "--Select--" });

                comboBox.DisplayMember = "DisplayName";
                comboBox.ValueMember = "Id";
                comboBox.DataSource = itemSeriesList.OrderBy(id => id.ID).ToList<ItemSeries>();
                comboBox.SelectedIndex = 0;
            }
        }
        private void LoadUnit()
        {
            try
            {

                unitList.Clear();
                unitList = Unit.GetAll();
                unitList.Add(new Unit { ID = 0, Name = "--Select--" });

                cmbUnit.DisplayMember = "Name";
                cmbUnit.ValueMember = "Id";
                cmbUnit.DataSource = unitList.OrderBy(id => id.ID).ToList<Unit>();
                cmbUnit.SelectedIndex = 0;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        static bool IsItemCodeExist(string seriesId)
        {
            var itemList = ItemMaster.GetBySeriesId(seriesId);
            if (itemList != null && itemList.Count > 0)
            {
                return true;
            }

            return false;
        }
        static bool IsItemNameExist(string itemName)
        {

            var itemListN = ItemMaster.GetByName(itemName);
            if (itemListN != null && itemListN.ID > 0)
            {
                return true;
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textName.Text.Trim()))
                {
                    if (IsItemCodeExist(textName.Text.Trim()))
                    {
                        MessageBox.Show("Item Code already exist!!");
                    }
                    else if (IsItemNameExist(textDescription.Text.Trim().ToUpper()))
                    {
                        MessageBox.Show("Item Name already exist!!");
                    }
                    else
                    {


                        ItemMaster itemMaster = new ItemMaster();
                        itemMaster.Name = textDescription.Text.Trim();
                        itemMaster.IsKot = chkIsKOT.Checked ? 1 : 0;
                        itemMaster.IsTaxable = chkIsTaxable.Checked ? 1 : 0;
                        itemMaster.UnitId = int.Parse(cmbUnit.SelectedValue.ToString());
                        itemMaster.ItemSeriesId = int.Parse(textName.Text.Trim()); // int.Parse(cmbItemSeries.SelectedValue.ToString());
                        itemMaster.Price = decimal.Parse(textPrice.Text.Trim());
                        itemMaster.Description = textDescription.Text.Trim();
                        itemMaster.IsValid = 1;
                        itemMaster.ModifiedBy = long.Parse(GlobalClass.userNameid);
                        itemMaster.CreatedBy = long.Parse(GlobalClass.userNameid);
                        int ItemMasterId = ItemMaster.Insert(itemMaster);
                        if (ItemMasterId > 0)
                        {
                            for (int i = 0; i < checkedListTaxes.Items.Count; i++)
                            {
                                if (checkedListTaxes.GetItemChecked(i))
                                {
                                    string str = (string)checkedListTaxes.Items[i];
                                    string taxName = str.Split('(')[0].ToString();
                                    Taxes tax = Taxes.GetByName(taxName);
                                    if (tax != null && tax.ID > 0)
                                    {
                                        TaxAppliedOnItem taxAppliedOnItem = new TaxAppliedOnItem();
                                        taxAppliedOnItem.ItemMasterId = ItemMasterId;
                                        taxAppliedOnItem.TaxId = tax.ID.Value;
                                        taxAppliedOnItem.IsValid = 1;
                                        taxAppliedOnItem.ModifiedBy = long.Parse(GlobalClass.userNameid);
                                        taxAppliedOnItem.CreatedBy = long.Parse(GlobalClass.userNameid);
                                        taxAppliedOnItem.Description = itemMaster.Name + " " + itemMaster.Price;
                                        taxAppliedOnItem.Remarks = tax.Rate.ToString();
                                        TaxAppliedOnItem.Insert(taxAppliedOnItem);
                                    }
                                }
                            }
                        }

                        btnReset_Click(sender, e);
                    }

                }
                else
                    MessageBox.Show("Please enter all required field!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        void dgvItemMaster_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0://edit
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;

                    int itemMasterId = int.Parse(dgvItemMaster.Rows[e.RowIndex].Cells[2].Value.ToString());
                    var details = ItemMaster.GetById(itemMasterId);
                    if (details != null)
                    {
                        textName.Text = details.ItemSeriesId.ToString();
                        textDescription.Text = details.Name;
                        textPrice.Text = details.Price.ToString();
                        // cmbItemSeries.Text = details.ItemSeriesName;
                        cmbUnit.SelectedValue = details.UnitId;
                        if (details.IsKot == 1)
                            chkIsKOT.Checked = true;
                        else chkIsKOT.Checked = false;
                        if (details.IsTaxable == 1)
                            chkIsTaxable.Checked = true;
                        else chkIsTaxable.Checked = false;
                        textName.Focus();
                        lblId.Text = details.ID.ToString();
                    }

                    var taxAppliedOnItems = TaxAppliedOnItem.GetByItemMasterId(itemMasterId);
                    if (taxAppliedOnItems != null && taxAppliedOnItems.Count > 0)
                    {
                        chkIsTaxable.Checked = true;
                        LoadTaxes();
                        foreach (var taxAppliedOnItem in taxAppliedOnItems)
                        {
                            var taxes = Taxes.GetById(taxAppliedOnItem.TaxId.Value);
                            if (taxes != null && taxes.ID > 0)
                            {
                                for (int i = 0; i < checkedListTaxes.Items.Count; i++)
                                {
                                    string str = (string)checkedListTaxes.Items[i];
                                    if (str.Contains(taxes.Name))
                                    {
                                        checkedListTaxes.SetItemCheckState(i, CheckState.Checked);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        chkIsKOT.Checked = false;
                        chkIsTaxable.Checked = false;
                        checkedListTaxes.Items.Clear();
                    }
                    break;
                case 1://delete

                    DialogResult result = MessageBox.Show("Do you want to delete selected Item?", "Confirmation",
MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ItemMaster.DeleteById(int.Parse(dgvItemMaster.Rows[e.RowIndex].Cells[2].Value.ToString()));


                        TaxAppliedOnItem.Delete(int.Parse(dgvItemMaster.Rows[e.RowIndex].Cells[2].Value.ToString()));

                        var itemList = ItemMaster.GetAll();
                        LoadDatagridView(itemList);
                    }


                    break;
            }
        }
        private string GetTax(IList<TaxAppliedOnItem> TaxAppliedOnItemList)
        {
            string TaxDetails = " ";
            if (TaxAppliedOnItemList != null && TaxAppliedOnItemList.Count > 0)
                foreach (TaxAppliedOnItem ta in TaxAppliedOnItemList)
                {
                    TaxDetails += ta.TaxDetails.Name + " " + ta.TaxDetails.Rate + "  ";
                }
            return TaxDetails;
        }
        void LoadDatagridView(IList<ItemMaster> itemList = null, bool IsSearch = false)
        {
            try
            {
                dgvItemMaster.DataSource = null;
                if (itemList == null)
                    itemList = ItemMaster.GetAll();

                if (itemList != null && itemList.Count > 0)
                {
                    
                    var discountList = from dis in itemList
                                       select new { ID = dis.ID, Code = dis.ItemSeriesId, Name = dis.Name, Price = dis.Price, TaxApplied = GetTax(dis.TaxAppliedList) };
                    if (discountList != null )
                    {
                        dgvItemMaster.DataSource = discountList.OrderBy(s => s.Code).ToList();

                        dgvItemMaster.Columns[2].Visible = false;
                    }
                }
                else
                {
                    if (IsSearch)
                    {
                        MessageBox.Show("Item not found!!");
                    }
                    else
                    {
                        dgvItemMaster.DataSource = null;
                    }
                }
            }

            catch (Exception ex)
            {

                throw ex;
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
                    var details = ItemMaster.GetById(int.Parse(lblId.Text));
                    details.Name = textDescription.Text.Trim();
                    details.ItemSeriesId = int.Parse(textName.Text.Trim());
                    details.IsKot = chkIsKOT.Checked ? 1 : 0;
                    details.IsTaxable = chkIsTaxable.Checked ? 1 : 0;
                    details.UnitId = int.Parse(cmbUnit.SelectedValue.ToString());

                    details.Price = decimal.Parse(textPrice.Text.Trim());
                    details.Description = textDescription.Text.Trim();
                    details.IsValid = 1;
                    details.ModifiedBy = long.Parse(GlobalClass.userNameid);
                    details.ModifiedDate = DateTime.Now;
                    ItemMaster.Update(details);

                    if (details.TaxAppliedList != null && details.TaxAppliedList.Count == 0)
                    {
                        for (int i = 0; i < checkedListTaxes.Items.Count; i++)
                        {
                            if (checkedListTaxes.GetItemChecked(i))
                            {
                                string str = (string)checkedListTaxes.Items[i];
                                string taxName = str.Split('(')[0].ToString();
                                Taxes tax = Taxes.GetByName(taxName);
                                if (tax != null && tax.ID > 0)
                                {
                                    TaxAppliedOnItem taxAppliedOnItem = new TaxAppliedOnItem();
                                    taxAppliedOnItem.ItemMasterId = details.ID;
                                    taxAppliedOnItem.TaxId = tax.ID.Value;
                                    taxAppliedOnItem.IsValid = 1;
                                    taxAppliedOnItem.ModifiedBy = long.Parse(GlobalClass.userNameid);
                                    taxAppliedOnItem.CreatedBy = long.Parse(GlobalClass.userNameid);
                                    taxAppliedOnItem.Description = details.Name + " " + details.Price;
                                    taxAppliedOnItem.Remarks = tax.Rate.ToString();
                                    TaxAppliedOnItem.Insert(taxAppliedOnItem);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (details.TaxAppliedList.Count > 0)
                        {
                            TaxAppliedOnItem.Delete(details.ID.Value);
                            for (int i = 0; i < checkedListTaxes.Items.Count; i++)
                            {
                                if (checkedListTaxes.GetItemChecked(i))
                                {
                                    string str = (string)checkedListTaxes.Items[i];
                                    string taxName = str.Split('(')[0].ToString();
                                    Taxes tax = Taxes.GetByName(taxName);
                                    if (tax != null && tax.ID > 0)
                                    {
                                        TaxAppliedOnItem taxAppliedOnItem = new TaxAppliedOnItem();
                                        taxAppliedOnItem.ItemMasterId = details.ID;
                                        taxAppliedOnItem.TaxId = tax.ID.Value;
                                        taxAppliedOnItem.IsValid = 1;
                                        taxAppliedOnItem.ModifiedBy = long.Parse(GlobalClass.userNameid);
                                        taxAppliedOnItem.CreatedBy = long.Parse(GlobalClass.userNameid);
                                        taxAppliedOnItem.Description = details.Name + " " + details.Price;
                                        taxAppliedOnItem.Remarks = tax.Rate.ToString();
                                        TaxAppliedOnItem.Insert(taxAppliedOnItem);
                                    }
                                }
                            }
                        }
                    }

                    btnReset_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Select Item !");
            }
        }

        private void chkIsTaxable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsTaxable.Checked)
            {
                checkedListTaxes.Enabled = true;

                LoadTaxes();
            }
            else
            {
                checkedListTaxes.Enabled = false;
                checkedListTaxes.ClearSelected();
                LoadTaxes();
            }
        }

        private void LoadTaxes()
        {
            checkedListTaxes.Items.Clear();
            var taxList = Taxes.GetAll();
            if (taxList != null && taxList.Count > 0)
            {

                for (int i = 0; i < taxList.Count; i++)
                {
                    checkedListTaxes.Items.Add(taxList[i].Name + "(" + taxList[i].Rate + " %)");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textName.Clear();
            textPrice.Clear();
            textDescription.Clear();
            cmbUnit.SelectedIndex = 0;
            //  cmbItemSeries.SelectedIndex = 0;
            chkIsKOT.Checked = false;
            chkIsTaxable.Checked = false;
            checkedListTaxes.Items.Clear();
            lblId.Text = "XXX";
            textName.Focus();

            LoadDatagridView();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

        }
        void comboSearchSeries_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textCodeSearch.Text.Trim().Length > 0 && textSearchItemName.Text.Trim().Length > 0)
            {
                var itemList = ItemMaster.GetBySeriesIdAndName(textCodeSearch.Text.ToString(), textSearchItemName.Text.Trim());
                LoadDatagridView(itemList, true);
            }
            else
            {
                if (textCodeSearch.Text.Trim().Length > 0)
                {
                    var itemList = ItemMaster.GetBySeriesId(textCodeSearch.Text.Trim());
                    LoadDatagridView(itemList, true);
                }
                else
                {
                    if (textSearchItemName.Text.Trim().Length > 0)
                    {
                        var itemList = ItemMaster.GetByNameList(textSearchItemName.Text.Trim());

                        LoadDatagridView(itemList, true);
                    }
                    else
                    {
                        MessageBox.Show("Enter any one search criteria");
                        var itemList = ItemMaster.GetAll();
                        LoadDatagridView(itemList);
                    }
                }
            }
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void textPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textCodeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        
    }
}
