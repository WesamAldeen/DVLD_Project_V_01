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

namespace DVLD.Local_Driving_License
{
    public partial class frmIssueLicenseForFirstTime : Form
    {
        private int _LDLAppID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public frmIssueLicenseForFirstTime(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            txtNots.Focus();
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDLAppID);
            if( _LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("No Application with ID " + _LDLAppID, "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            if(!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Person should pass all tests first", "Not Allow",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if( LicenseID != -1 )
            {
                MessageBox.Show("Person already has License before with ID = " + LicenseID, "Not Allow",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LDLAppID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirtTime(txtNots.Text, clsGlobal.CurrentUser.UserId);
            
            if(LicenseID != -1)
            {
                MessageBox.Show("License Issued successfully with LicenseID = " + LicenseID, "Succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("License was not issued", "Faild",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
