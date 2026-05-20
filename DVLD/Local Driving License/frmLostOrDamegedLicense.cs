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
using static DVLD_BuisnessLayer.clsLicense;

namespace DVLD.Local_Driving_License
{
    public partial class frmLostOrDamegedLicense : Form
    {
        private int _NewLicenseID = -1;
        private int _GetApplicationTypeID()
        {
            if (rbDamagedLicense.Checked)
                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicens;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicens;
        }
        private enIssueReason _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (rbDamagedLicense.Checked)

                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }
        public frmLostOrDamegedLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsLicense NewLicense =
                ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(),
                clsGlobal.CurrentUser.UserId);
            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            lblReLicsensID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            gbReplacementFor.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnablad = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void frmLostOrDamegedLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
            rbDamagedLicense.Checked = true;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbltitle.Text = "Replacement for Damaged License";
            this.Text = lbltitle.Text;
            lblAppFees.Text = clsApplicationType.FindApplicationTypeById(_GetApplicationTypeID()).Fees.ToString();
        }

        private void rbLostedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbltitle.Text = "Replacement for Losted License";
            this.Text = lbltitle.Text;
            lblAppFees.Text = clsApplicationType.FindApplicationTypeById(_GetApplicationTypeID()).Fees.ToString();
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
            // Don't Allow replacemeent if license is Active
            if(!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("This License ia already Active", "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            btnRenew.Enabled = true;
        }

    }
}
