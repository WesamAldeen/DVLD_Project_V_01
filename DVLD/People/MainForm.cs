using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.ApplicationTypes;
using DVLD.Detain_Licenses;
using DVLD.InternationalLicense;
using DVLD.Local_Driving_License;
using DVLD.Lokal_Driving_License;
using DVLD.People;
using DVLD.TestTypes;
using DVLD.Users;
using DVLD_BuisnessLayer;

namespace DVLD
{
    public partial class MainForm : Form
    {
        frmLogin _frmlogin;
        public MainForm(frmLogin frm)
        {
            InitializeComponent();
            _frmlogin = frm;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbFilterBy frm = new cbFilterBy();
            frm.MdiParent = this;
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsers usrfrm = new ManageUsers();
            usrfrm.MdiParent = this;
            usrfrm.Show();
        }

        private void accountSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserId);
            frm.ShowDialog();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmlogin.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserId);
            frm.ShowDialog();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypes frm = new frmApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypes frm = new frmTestTypes();
            frm.ShowDialog();
        }

        private void localLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmLocalDrivingLicenseApplication frm = new frmLocalDrivingLicenseApplication();
            frmListLocalDrivingLicenseApplication frm = new frmListLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInterNationalLicense frm = new frmNewInterNationalLicense();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplication frm = new frmListLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplication frm = new frmListLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void drivingLicensesServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void renewDrivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewDrivingLicense frm = new frmRenewDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLostOrDamegedLicense frm = new frmLostOrDamegedLicense();
            frm.ShowDialog();
        }

        private void releasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivers frm = new frmDrivers();
            frm.ShowDialog();
        }

        private void detainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void detainLicensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainLicense frm = new frmManageDetainLicense();
            frm.ShowDialog();
        }

        private void showInternationalLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo();
            frm.ShowDialog();
        }
    }
}
