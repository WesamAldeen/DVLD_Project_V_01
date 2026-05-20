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
using DVLD.InternationalLicense;
using DVLD.Local_Driving_License;
using DVLD_BuisnessLayer;

namespace DVLD.Drivers
{
    public partial class ctrlDriver : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicenseHistory;
        private DataTable _dtDriverLicenseInternationalHistory;
        public ctrlDriver()
        {
            InitializeComponent();
        }
        private void _LoadLocaLicenseInfo()
        {
            clsGlobal.StyleDataGridView(dgvLocal);
            _dtDriverLocalLicenseHistory = clsDriver.GetLicenses(_DriverID);
            dgvLocal.DataSource = _dtDriverLocalLicenseHistory;
            lblLocalRecord.Text = "Records : #" + _dtDriverLocalLicenseHistory.Rows.Count.ToString();
        }
        private void _LoadInternationalLicenseInfo()
        {
            clsGlobal.StyleDataGridView(dgvInterNat);
            _dtDriverLicenseInternationalHistory = clsDriver.GetInternationalLicenses(_DriverID);
            dgvInterNat.DataSource = _dtDriverLicenseInternationalHistory;
            lblInterNatRecord.Text = "Records : #" + _dtDriverLicenseInternationalHistory.Rows.Count.ToString();
        }
        public void LoadInfo(int driverID)
        {
            _DriverID = driverID;
            _Driver = clsDriver.FindByDriverID(_DriverID);

            if(_Driver == null)
            {
                MessageBox.Show("There is no driver with this ID :" + _DriverID, "Not Allow",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadLocaLicenseInfo();
            _LoadInternationalLicenseInfo();
        }
        public void LoadInfoByPersonID(int personID)
        {
            _Driver = clsDriver.FindByPersonID(personID);

            if (_Driver == null)
            {
                MessageBox.Show("There is no driver linked with this Person ID :" + personID, "Not Allow",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DriverID = _Driver.DriverID;
            _LoadLocaLicenseInfo();
            _LoadInternationalLicenseInfo();
        }
        public void Clear()
        {
            _dtDriverLicenseInternationalHistory.Clear();
            _dtDriverLocalLicenseHistory.Clear();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocal.CurrentRow.Cells["PersonID"].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showInternationalLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocal.CurrentRow.Cells["PersonID"].Value;
            //frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(LicenseID);
            //frm.ShowDialog();
        }
    }
}
