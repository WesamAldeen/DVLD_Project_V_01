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
using DVLD.Local_Driving_License;
using DVLD_BuisnessLayer;

namespace DVLD.Detain_Licenses
{
    public partial class frmManageDetainLicense : Form
    {
        private DataTable _dtDetainLicense;
        public frmManageDetainLicense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageDetainLicense_Load(object sender, EventArgs e)
        {
            clsGlobal.StyleDataGridView(dataGridView1);
            cbFilterby.SelectedIndex = 0;
            _dtDetainLicense = clsDetainedLicense.GetAllDetainedLicenses();
            dataGridView1.DataSource = _dtDetainLicense;
            lblRecordCounts.Text = "Records : #" + dataGridView1.Rows.Count.ToString();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void showPersonInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells["LicenseID"].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;
            frmShwoCardInfo frm = new frmShwoCardInfo(PersonID);
            frm.ShowDialog();
        }

        private void showLicenseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells["LicenseID"].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells["LicenseID"].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;
            frmLiceseHistory frm = new frmLiceseHistory(PersonID);
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells["LicenseID"].Value;
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(LicenseID);
            frm.ShowDialog();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            // 1. التعامل مع حالة عدم وجود فلتر
            if (txtFilterValue.Text.Trim() == "" || cbFilterby.Text == "None")
            {
                _dtDetainLicense.DefaultView.RowFilter = "";
                lblRecordCounts.Text = "Records : #" + dataGridView1.Rows.Count.ToString();
                return;
            }

            // 2. الفلترة الديناميكية
            string FilterColumn = cbFilterby.Text;
            string FilterValue = txtFilterValue.Text.Trim();

            // نتحقق إذا كان العمود نصياً (NationalNo أو FullName) للبحث الجزئي
            if (FilterColumn == "FullName" || FilterColumn == "NationalNo")
            {
                _dtDetainLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);
            }
            else
            {
                // للأعمدة الرقمية (PersonID, LicenseID, FineFees)
                // التحقق من أن القيمة المدخلة رقمية لمنع الـ Crash
                if (int.TryParse(FilterValue, out int result))
                {
                    _dtDetainLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
                }
            }

            lblRecordCounts.Text = "Records : #" + dataGridView1.Rows.Count.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dataGridView1.CurrentRow.Cells[3].Value;
        }
    }
}
