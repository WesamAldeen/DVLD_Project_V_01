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

namespace DVLD.Local_Driving_License.License_Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        // Define Custom event Delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create Delegation function
        protected virtual void LicenseSelected(int  licenseId)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(licenseId);
            }
        }
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        private bool _FilterEnablad = true;
        private int _LicenseID = -1;
        public int LicenseID
        {
            get { return ctrlShowLicenseInfo1.LicenseID; }
        }
        public clsLicense SelectedLicenseInfo
        {
            get { return ctrlShowLicenseInfo1.SelectedLicenseInfo; }
        }

        public bool FilterEnablad
        {
            get { return _FilterEnablad; }
            set
            {
                _FilterEnablad = value;
                groupBox1.Enabled = _FilterEnablad;
            }
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            ctrlShowLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlShowLicenseInfo1.LicenseID;
            if (OnLicenseSelected != null && FilterEnablad)
                OnLicenseSelected(_LicenseID);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some filedss ate not valide!, put the mouse over the red point");
                txtLicenseID.Focus();
                return;
            }
            _LicenseID = int.Parse(txtLicenseID.Text);
            LoadLicenseInfo(_LicenseID);
        }
        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            // check if the pressed key is enter (character code 13)
            if(e.KeyChar == (char)13)
                button1.PerformClick();
        }
    }
}
