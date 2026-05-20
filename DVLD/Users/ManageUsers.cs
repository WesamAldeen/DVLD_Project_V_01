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
using DVLD.Users;
using DVLD_BuisnessLayer;

namespace DVLD
{
    public partial class ManageUsers : Form
    {
        private void _RefreshData()
        {
            dataGridView1.DataSource = clsUsers.LoadAllUsers();
            lblTotalCountUsers.Text = "Total #" + clsUsers.TotalUserCount().ToString();
        }
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            clsGlobal.StyleDataGridView(this.dataGridView1);
            _RefreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshData();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            frmChangePassword frm1 = new frmChangePassword(UserID);
            frm1.ShowDialog();
            _RefreshData();
        }

        private void copyUserIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            // تأكد أن هناك صف محدد
            if (dataGridView1.CurrentRow != null)
            {
                // احصل على قيمة أول خلية (الـ ID)
                var idValue = dataGridView1.CurrentRow.Cells[1].Value?.ToString();

                if (!string.IsNullOrEmpty(idValue))
                {
                    Clipboard.SetText(idValue); // انسخ القيمة إلى الحافظة
                    MessageBox.Show("Person ID Coped successfully: " + idValue, "Copeds", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ID is not found!", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please chose a row!", "Notefcation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
    }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshData();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshData();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (clsUsers.DeleteUser(id))
            {
                MessageBox.Show("User deleted successfully.");
                _RefreshData();
            }
            else
            {
                MessageBox.Show("Error while deleting user.");
            }
        }
    }
}
