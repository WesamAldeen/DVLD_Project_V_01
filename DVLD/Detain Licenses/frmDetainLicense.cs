using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Drivers;
using DVLD.Local_Driving_License;

namespace DVLD.Detain_Licenses
{
    public partial class frmDetainLicense : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        public frmDetainLicense(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;

            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnablad = false;
        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            if(_SelectedLicenseID == -1)
            {
                return;
            }

            lblLicenseID.Text = obj.ToString();
            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);
            // Check if the license is already detained
            if(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("The selected license is already detained!", "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtFees.Focus();
            btnDetain.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            _DetainID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFees.Text), clsGlobal.CurrentUser.UserId);
            if(_DetainID == -1 )
            {
                MessageBox.Show("Faild to detain license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License is detained successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDetain.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnablad = false;
            llShowLicenseInfo.Enabled = true;

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLiceseHistory frm = new frmLiceseHistory(_DetainID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_DetainID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
