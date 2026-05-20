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
    public partial class frmListTestAppointment : Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LDLAppID;
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        public frmListTestAppointment(int LDLAppID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _TestType = TestType;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestTypes.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestTypes.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }

        private void frmListTestAppointment_Load(object sender, EventArgs e)
        {
            // title and img
            // fill control data
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LDLAppID);
            // fill data grid view and dsign it
            clsGlobal.StyleDataGridView(dataGridView1);
            _dtLicenseTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LDLAppID, _TestType);
            dataGridView1.DataSource = _dtLicenseTestAppointments;
            // total count for record in the record lable.
            lblRecords.Text = "Records: # " + _dtLicenseTestAppointments.Rows.Count.ToString();

        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication Ldlapp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDLAppID);
            if(Ldlapp.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("person is already have an active appointment for this test.",
                    "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            clsTest LastTest = Ldlapp.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LDLAppID, _TestType);
                frm1.ShowDialog();
                frmListTestAppointment_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest
                (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmListTestAppointment_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;


            frmScheduleTest frm = new frmScheduleTest(_LDLAppID, _TestType, TestAppointmentID);
            frm.ShowDialog();
            frmListTestAppointment_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestType);
            frm.ShowDialog();
            frmListTestAppointment_Load(null, null);
        }
    }
}
