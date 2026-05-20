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

namespace DVLD.ApplicationTypes
{
    public partial class frmApplicationTypes : Form
    {
        public frmApplicationTypes()
        {
            InitializeComponent();
        }
        private void _Refrish()
        {
            dataGridView1.DataSource = clsApplicationType.LoadAllApplication();
        }
        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {
            clsGlobal.StyleDataGridView(dataGridView1);
            _Refrish();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            frmUpdateAppliationType frm = new frmUpdateAppliationType(id);
            frm.ShowDialog();
            _Refrish();
        }
    }
}
