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

namespace DVLD.TestTypes
{
    public partial class frmTestTypes : Form
    {
        private DataTable _dtAllTestTypes;
        private void _Refresh()
        {
            _dtAllTestTypes = clsTestTypes.LoadAllTestTypes();
            dataGridView1.DataSource = _dtAllTestTypes;
        }
        public frmTestTypes()
        {
            InitializeComponent();
        }

        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            frmUpdateTestType frm = new frmUpdateTestType(id);
            frm.ShowDialog();
            _Refresh();
        }
    }
}
