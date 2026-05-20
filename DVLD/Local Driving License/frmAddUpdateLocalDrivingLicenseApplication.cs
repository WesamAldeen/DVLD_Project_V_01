using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace DVLD.Lokal_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew =0, Update =1 };
        enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicensApplication;

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateLocalDrivingLicenseApplication(int localDLApp)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = localDLApp;
        }
        private void _FillLicenseClassInComboBox()
        {
            DataTable dtLicensClass = clsLicenseClass.GetAllLicenseClasses();
                foreach(DataRow row in dtLicensClass.Rows)
                {
                    cbLicenseClass.Items.Add(row["ClassName"]);
                }
        }
        private void _ResetDefaultValues()
        {
            _FillLicenseClassInComboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Driving License Application";
                this.Text = "New Driving License Application";
                _LocalDrivingLicensApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFilter1.FilterFocus();
                tpAppInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.FindApplicationTypeById((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblAppDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            // On Update Mode.
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                tpAppInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void _LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicensApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicensApplication == null)
            {
                MessageBox.Show("No Application With ID :" + _LocalDrivingLicenseApplicationID);
                this.Close();
                return;
            }
            // Not null.
            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicensApplication.ApplicantPersonID);
            lblDLApplicationID.Text = _LocalDrivingLicensApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppDate.Text = clsFormat.DateToShort(_LocalDrivingLicensApplication.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingLicensApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingLicensApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void frmLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. تحديد المعرفات من الواجهة مباشرة لضمان الدقة
            int CurrentSelectedPersonID = ctrlPersonCardWithFilter1.PersonID;
            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;

            // 2. التحقق من وجود طلب نشط (باستخدام معرف الشخص الحالي)
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(CurrentSelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("The selected person already has an active application for this license class with ID: " + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return; // الخروج يمنع التكرار
            }

            // 3. التحقق من وجود رخصة سابقة
            if (clsLicense.IsLicenseExistByPersonID(CurrentSelectedPersonID, LicenseClassID))
            {
                MessageBox.Show("The selected person already has a license for this class.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. تعبئة الكائن والحفظ
            _LocalDrivingLicensApplication.ApplicantPersonID = CurrentSelectedPersonID;
            _LocalDrivingLicensApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicensApplication.ApplicationTypeID = 1; // New Driving License
            _LocalDrivingLicensApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicensApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicensApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicensApplication.CreatedByUserID = clsGlobal.CurrentUser.UserId;
            _LocalDrivingLicensApplication.LicenseClassID = LicenseClassID;

            if (_LocalDrivingLicensApplication.Save())
            {
                lblDLApplicationID.Text = _LocalDrivingLicensApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";
                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Data was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ctrlPersonCardWithFilter_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpAppInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpAppInfo"];
                return;
            }
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tpAppInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpAppInfo"];
            }
            else
            {
                MessageBox.Show("Please select a person!", "select a person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }
        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);
        }
        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;

        }
    }
}
