using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Drivers;
using DVLD.Lokal_Driving_License;
using DVLD.Test;
using DVLD_BuisnessLayer;

namespace DVLD.Local_Driving_License
{
    public partial class frmListLocalDrivingLicenseApplication : Form
    {
        private DataTable _dtLDLA;
        public frmListLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _ScheduleTest(clsTestTypes.enTestType TestType)
        {

            int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmListTestAppointment frm = new frmListTestAppointment(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();
            //refresh
            frmListLocalDrivingLicenseApplication_Load(null, null);

        }

        private void frmListLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            clsGlobal.StyleDataGridView(this.dataGridView1);
            _dtLDLA = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dataGridView1.DataSource = _dtLDLA;
            lblTotal.Text = dataGridView1.Rows.Count.ToString();

            // filter will be add after the revejen how to make filter in Manage People.
            // cbFilterBy.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            // refresh this form.
            frmListLocalDrivingLicenseApplication_Load(null, null);
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);
            if (LDLApp != null)
            {
                if(LDLApp.Cancel())
                {
                    MessageBox.Show("Canseld Successfylly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                    MessageBox.Show("Canseld Request Falied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddLicesne_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(LDLAppID);
            frm.ShowDialog();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. الحصول على الرقم من الداتا جريد
            int LDLAppID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);
            // 2. سؤال المستخدم (الأمان أولاً)
            if (MessageBox.Show("Are you sure you want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (LocalDrivingLicenseApplication != null)
            {
                if(LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Deleted Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // إذا فشل الحذف، غالباً بسبب وجود قيود (Constraints)
                MessageBox.Show("Could not delete this application because it has related data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sechduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.VisionTest);
        }

        private void writenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.WrittenTest);
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.StreetTest);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int PassedTestCount = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PassedTestCount"].Value);
            string Status = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
            
            if(Status == "New" && PassedTestCount < 3)
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
            else
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
            }
            if (Status == "Cancelled" || Status == "Completed")
            {
                sechduleTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
            else if (PassedTestCount == 0)
            {
                sechduleTestToolStripMenuItem.Enabled = true;
                visionTestToolStripMenuItem.Enabled = true;
                writenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
            }
            else if (PassedTestCount == 1)
            {
                sechduleTestToolStripMenuItem.Enabled = true;
                visionTestToolStripMenuItem.Enabled = false;
                writenTestToolStripMenuItem.Enabled = true;
                streetTestToolStripMenuItem.Enabled = false;
            }
            else if (PassedTestCount == 2)
            {
                sechduleTestToolStripMenuItem.Enabled = true;
                visionTestToolStripMenuItem.Enabled = false;
                writenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = true;
            }
            else if (PassedTestCount == 3)
            {
                sechduleTestToolStripMenuItem.Enabled = false;
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmIssueLicenseForFirstTime frm = new frmIssueLicenseForFirstTime(LDLAppID);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLiceseHistory frm = new frmLiceseHistory();
            frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(
                LDLAppID).GetActiveLicenseID();
            if(LicenseID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
