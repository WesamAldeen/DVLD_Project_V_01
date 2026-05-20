using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Properties;
using DVLD_BuisnessLayer;

namespace DVLD.Local_Driving_License.License_Controls
{
   
    public partial class ctrlShowLicenseInfo : UserControl
    {
        private int _LicenseID { get; set; }
        private clsLicense _LicenseInfo {  get; set; }
        private clsDriver _DriverInfo { get; set; }
        private int _DriverID { get; set; }
        private void _LoadPersonImg()
        {
            if (_LicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
                pbImg.Image = Resources.Male_512;
            else
                pbImg.Image = Resources.Female_512;
            string imgPath = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;
            if (imgPath != "")
                if (File.Exists(imgPath))
                    pbImg.Load(imgPath);
                else
                    MessageBox.Show("Could not find this image: " + imgPath);
        }
        public int LicenseID 
        {
            get { return _LicenseID; }
        }
        public ctrlShowLicenseInfo()
        {
            InitializeComponent();
        }
        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return _LicenseInfo;
            }
        }
        public void LoadInfo(int licenseID)
        {
            _LicenseID = licenseID;
            _LicenseInfo = clsLicense.Find(licenseID);
            _DriverInfo = clsDriver.FindByDriverID(_LicenseInfo.DriverID);

            if (_LicenseInfo != null)
            {
                lblClass.Text = _LicenseInfo.LicenseClassIfo.ClassName;
                lblName.Text = _DriverInfo.PersonInfo.FullName;
                lblLicenseID.Text = _LicenseID.ToString();
                lblNaionalNo.Text = _DriverInfo.PersonInfo.Nationalnumber;
                lblGendor.Text = _DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
                lblIssueDate.Text = _LicenseInfo.IssueDate.ToString();
                lblIssueReason.Text = _LicenseInfo.IssueReasonText;
                lblNotes.Text = _LicenseInfo.Notes == "" ? "No Notes" : _LicenseInfo.Notes;
                lblIsActive.Text = _LicenseInfo.IsActive ? "Yes" : "No";
                lblDateOfBirth.Text = clsFormat.DateToShort(_DriverInfo.PersonInfo.DateOfBirth).ToString();
                lblDriverID.Text = _LicenseInfo.DriverID.ToString();
                lblExpirationDate.Text = clsFormat.DateToShort(_LicenseInfo.ExpirationDate).ToString();
                lblIsDetained.Text = _LicenseInfo.IsDetained ? "Yes" : "No";
                _LoadPersonImg();
            }
            else
            {
                MessageBox.Show("There are no License with ID :" + licenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblIssueDate_Click(object sender, EventArgs e)
        {

        }
    }
}
