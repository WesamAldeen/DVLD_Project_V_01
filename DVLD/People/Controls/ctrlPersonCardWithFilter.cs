using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace DVLD.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            OnPersonSelected?.Invoke(PersonID);
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set { _ShowAddPerson = value; btnAddNewPerson.Visible = _ShowAddPerson; }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set { _FilterEnabled = value; gbFilers.Enabled = _FilterEnabled; }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return ctrlPersonCard2.PersonId; }
        }
        public clsPeopleBuisnes SelectedPersonInfo
        {
            get { return ctrlPersonCard2.SelectedPersonInfo; }
        }

        public void LoadPersonInfo(int PersonID)
        {
            if (cbFilterBy.Items.Count > 1)
                cbFilterBy.SelectedIndex = cbFilterBy.FindString("Person ID");
                txtFilterValue.Text = PersonID.ToString();
                _FindNow();
        }

        private void _FindNow()
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text)) return;

            try
            {
                switch (cbFilterBy.Text)
                {
                    case "Person ID":
                        if (int.TryParse(txtFilterValue.Text, out int id))
                            ctrlPersonCard2.LoadPersonInfo(id);
                        break;
                    case "National No":
                        ctrlPersonCard2.LoadPersonInfo(txtFilterValue.Text.Trim());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while finding person: " + ex.Message);
            }

            if (FilterEnabled && ctrlPersonCard2.SelectedPersonInfo != null)
            {
                PersonSelected(ctrlPersonCard2.PersonId);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // تنفيذ البحث بدل فتح نموذج الإضافة
            _FindNow();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard2.LoadPersonInfo(PersonID);
            // رافع الحدث لما يكون مطلوباً
            if (FilterEnabled && ctrlPersonCard2.SelectedPersonInfo != null)
                PersonSelected(ctrlPersonCard2.PersonId);
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            if (cbFilterBy.Items.Count > 0)
                cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "this field is required");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            // فتح نموذج الإضافة وإعادة استقبال البيانات منه
            frmInsertEdit frm1 = new frmInsertEdit();
            frm1.DataBack += DataBackEvent;
            frm1.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
                e.Handled = true;
                return;
            }
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
