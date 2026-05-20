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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicensApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _LicenseID;
        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        // constructer
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadApplicationInfoByLocalDrivingAppID(int LDLAppID)
        {
            _LocalDrivingLicensApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);
            if(_LocalDrivingLicensApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Application with Local Driving License Application ID : " + LDLAppID);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();

        }
        public void LoadApplicationInfoByAppID(int AppID)
        {
            _LocalDrivingLicensApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(AppID);

            if (_LocalDrivingLicensApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Local Driving License Application with ID : " + AppID);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();
        }
        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LicenseID = _LocalDrivingLicensApplication.GetActiveLicenseID();

            linkShowLicenseInfo.Enabled = (_LicenseID != -1);
            lblDLApplID.Text = _LocalDrivingLicensApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForTest.Text = clsLicenseClass.Find(_LocalDrivingLicensApplication.LicenseClassID).ClassName;
            lblPassedTests.Text = "3/3.Soon.";
            ctrlApplicationBasicInfo1.LoadApplicationIinfoByAppID(_LocalDrivingLicensApplication.ApplicationID);
        }
        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            //ctrlApplicationBasicInfo1
            lblDLApplID.Text = "[???]";
            linkShowLicenseInfo.Enabled = false;
            lblAppliedForTest.Text = "[???]";
            lblPassedTests.Text = "[???]";
        }
        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void ctrlDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }

    }
}
