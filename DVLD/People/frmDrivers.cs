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
using DVLD_BuisnessLayer;

namespace DVLD.People
{
    public partial class frmDrivers : Form
    {
        private DataTable _dtAllDrivers;
        public frmDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDrivers_Load(object sender, EventArgs e)
        {
            _dtAllDrivers = clsDriver.GetAllDrivers();
            dataGridView1.DataSource = _dtAllDrivers;
            lblRecords.Text = dataGridView1.Rows.Count.ToString();
            if(dataGridView1.Rows.Count > 0)
            {
                clsGlobal.StyleDataGridView(dataGridView1);
            }

        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells["PersonID"].Value;
            frmShwoCardInfo frm = new frmShwoCardInfo(PersonID);
            frm.ShowDialog();
        }

        private void showDriverHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells["PersonID"].Value;
            frmLiceseHistory frm = new frmLiceseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
