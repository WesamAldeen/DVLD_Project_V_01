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

namespace DVLD.InternationalLicense
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        private DataTable _dtInternationalLicense;
        public frmShowInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            _dtInternationalLicense = clsInternationalLicense.GetAllInternationalLicenses();
            dataGridView1.DataSource = _dtInternationalLicense;
            clsGlobal.StyleDataGridView(dataGridView1);
            label2.Text = "Record : #" + dataGridView1.RowCount;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNewInterNationalLicense frm = new frmNewInterNationalLicense();
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dataGridView1.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            frmShwoCardInfo frm = new frmShwoCardInfo(PersonID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dataGridView1.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            frmLiceseHistory frm = new frmLiceseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
