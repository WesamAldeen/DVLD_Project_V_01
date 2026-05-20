using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace DVLD.Local_Driving_License
{
    public partial class frmRenewDrivingLicense : Form
    {
        private int _NewLicenseID = -1;
        

        public frmRenewDrivingLicense()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            // Code that save in app table and license table and return the RenewAppID , NewLicenseID.
            clsLicense NewLicense =
                ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserId);
            if(NewLicense == null )
            {
                MessageBox.Show("Falid to renew license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("License Renewed successfully with ID : " + _NewLicenseID.ToString());

            btnRenew.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnablad = false;
            llShowNewLicense.Enabled = true;
        }

        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblAppDate.Text;
            lblExpirationDate.Text = "???";
            lblAppFees.Text = clsApplicationType.FindApplicationTypeById((int)clsApplication.enApplicationType.RenewDrivingLicens).Fees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);
            if(SelectedLicenseID == -1)
            {
                return;
            }
            int DefaultValidtyLength = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidtyLength));
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblLicenseFees.Text)) + (Convert.ToSingle(lblAppFees.Text)).ToString();
            txtNotes.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;

            // Check if the license is not expired
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected license is not yet expired", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            // Check if the license is not active
            if(!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is not active", "Not Allowed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            btnRenew.Enabled = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblAppFees_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblLicenseFees_Click(object sender, EventArgs e)
        {

        }
    }
}
