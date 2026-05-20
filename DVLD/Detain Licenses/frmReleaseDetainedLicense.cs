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
using DVLD_BuisnessLayer;

namespace DVLD.Detain_Licenses
{
    public partial class frmReleaseDetainedLicense : Form
    {
        private int _SelectedLicenseID = -1;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedLicense(int licenseid)
        {
            InitializeComponent();
            _SelectedLicenseID = licenseid;
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnablad = false;
        }
        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLiceseHistory frm = new frmLiceseHistory();
            frm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmShowLicenseInfo frm = new frmShowLicenseInfo(1);
            frm.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            if(_SelectedLicenseID == -1)
            {
                return;
            }
            lblLicenseID.Text = _SelectedLicenseID.ToString();
            linkLabel1.Enabled = (_SelectedLicenseID != -1);
            // Check if license is already not detained
            if(!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected license is not detained !", "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblAppFees.Text = clsApplicationType.FindApplicationTypeById((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
            lblDetainID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblLicenseID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            lblUserName.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblDetainDate.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToString();
            lblFineFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblAppFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();
            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            int appID = -1;
            bool isReleased = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserId, ref appID);
            lblAppID.Text = appID.ToString();
            if (! isReleased)
            {
                MessageBox.Show("Fialed to release detained license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Releas is done successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnablad = false;
            linkLabel2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
