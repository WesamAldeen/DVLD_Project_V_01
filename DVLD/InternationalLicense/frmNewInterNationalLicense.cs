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

namespace DVLD.InternationalLicense
{
    public partial class frmNewInterNationalLicense : Form
    {
        private int _InternationalID = -1;
        public frmNewInterNationalLicense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblLocalLicenseID.Text = SelectedLicenseID.ToString();
            if(SelectedLicenseID == -1)
            {
                return;
            }
            // Check if license is not class3
            if(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("This license is not from Class 3", "Not Allow",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check if driver is already have an active international license
            int ActiveInternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);
            if (ActiveInternationalLicenseID != -1)
            {
                MessageBox.Show("This Driver already have an active international license!", "Not Allow",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblInterLicenseID.Text = ActiveInternationalLicenseID.ToString();
                btnIssue.Enabled = false;
                return;
            }
            btnIssue.Enabled = true;

        }

        private void frmNewInterNationalLicense_Load(object sender, EventArgs e)
        {

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsInternationalLicense internationalLicense = new clsInternationalLicense();
            internationalLicense.ApplicantPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            internationalLicense.ApplicationDate = DateTime.Now;
            internationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            internationalLicense.LastStatusDate = DateTime.Now;
            internationalLicense.PaidFees = clsApplicationType.FindApplicationTypeById((int)clsApplication.enApplicationType.NewInterNationalDrivingLicens).Fees;
            internationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserId;

            internationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            internationalLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            internationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserId;
            if(!internationalLicense.Save())
            {
                MessageBox.Show("Failed to issued international license!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblILAppID.Text = internationalLicense.ApplicationID.ToString();
            _InternationalID = internationalLicense.InternationalLicenseID;
            lblInterLicenseID.Text = _InternationalID.ToString();
            lblAppDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblFees.Text = internationalLicense.PaidFees.ToString();
            lblExpirationDate.Text = DateTime.Now.ToString();
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
            MessageBox.Show("International lincense issued successfully", "Success",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnIssue.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnablad = false;
        }
    }
}
