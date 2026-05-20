using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Properties;
using DVLD_BuisnessLayer;

namespace DVLD.Test
{
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { AddNew =0, Update= 1};
        private enMode _Mode = enMode.AddNew;
        public enum enCreationMode { FirstTimeSchedule =0, RetakeTestSchedule=1 };
        private enCreationMode _CreationMode= enCreationMode.FirstTimeSchedule;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        //-----------------------------------------------------------------------------------
        private clsLocalDrivingLicenseApplication _LDLApp;
        private int _LDLAppID = -1;
        private clsTestAppointment _TestAppointment;
        private int _TestAppointmentID = -1;
        public clsTestTypes.enTestType TestTypeID
        {
            get {  return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTesttypeImg.Image = Resources.Vision_512;
                            break;
                        }
                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTesttypeImg.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTesttypeImg.Image = Resources.driving_test_512;
                            break;
                        }
                }
            }
        }
        private bool _LoadTestAppintmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            if(_TestAppointment == null)
            {
                MessageBox.Show("Error: no Appointment with ID :" + _TestAppointmentID
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            // we compare the current date with the appointment date to set the min date.
            if(DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;

            dtpTestDate.Value = _TestAppointment.AppointmentDate;
            // if person take test for first time.
            if(_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";

            }
            else // if it's not test for first time.
            {
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
                gbRetakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
            }
            return true;
        }
        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.
                clsApplication Application = new clsApplication();

                Application.ApplicantPersonID = _LDLApp.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.FindApplicationTypeById((int)clsApplication.enApplicationType.RetakeTest).Fees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserId;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }
        private bool _HandlePrviousTestConstraint()
        {
            switch(TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblUserMessage.Visible = false;
                    return true;
                case clsTestTypes.enTestType.WrittenTest:
                    if(!_LDLApp.DoesPassTestType(clsTestTypes.enTestType.VisionTest))
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "Cannot sechdule, vision test.";
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }
                    return true;
                case clsTestTypes.enTestType.StreetTest:
                    if(!_LDLApp.DoesPassTestType(clsTestTypes.enTestType.WrittenTest))
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "Cannot sechdule, written test.";
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }
                    return true;
                default:
                    return true;
            }
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            if(_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Preson already sat for test, appointment is locked.";
                dtpTestDate.Enabled = false;
                gbRetakeTest.Enabled = false;
                btnSave.Enabled = false;
            }
            else
                lblUserMessage.Visible = false;
            return true;
        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if(_Mode == enMode.AddNew && clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LDLAppID, TestTypeID))
            {
                lblUserMessage.Text = "Person already have an active appointment.";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            return true;
        }
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LDLAppID, int AppointmentID = -1)
        {
            // if no AppointmentID this means AddNew mode otherwise it's Update mode.
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LDLAppID = LDLAppID;
            _TestAppointmentID = AppointmentID;
            _LDLApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);

            if(_LDLApp == null)
            {
                MessageBox.Show("There is no Local Driving License App with this ID :" + LDLAppID, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            if (_LDLApp.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;
            if(_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRetakeAppFees.Text = clsApplicationType.FindApplicationTypeById((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                gbRetakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTest.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }

                lblDLAppID.Text = LDLAppID.ToString();
                lblDClass.Text = clsLicenseClass.Find(_LDLApp.LicenseClassID).ClassName;
                lblName.Text = _LDLApp.PersonFullName;
                lblTrial.Text = _LDLApp.TotalTrialsPerTest(_TestTypeID).ToString();
            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestTypes.Find(_TestTypeID).TestTypeFees.ToString();
                dtpTestDate.MinDate = DateTime.Now;
                lblRetakeTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                // this function work in Update Mode it's have tow status for test first time or Retake test.
                if (!_LoadTestAppintmentData())
                    return;
            }
            // lbl total fees and other things.
            float totalFees = Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text);
            lblTotalFees.Text = totalFees.ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;
            if (!_HandleAppointmentLockedConstraint())
                return;
            if (!_HandlePrviousTestConstraint())
                return;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LDLApp.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserId;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
