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

namespace DVLD.Users
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUsers User = clsUsers.FindUserByUsernameAndPassword(txtUsername.Text, txtPassword.Text);
            if (User != null)
            {
                if (cbRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtUsername.Text, txtPassword.Text);
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                if(!User.IsActive)
                {
                    txtUsername.Focus();
                    MessageBox.Show("Sorry, your are not Active to login Contact the Admin!");
                    return;
                }

                clsGlobal.CurrentUser = User;
                this.Hide();
                MainForm frm = new MainForm(this);
                frm.ShowDialog();
            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Username and Password did not match!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref Username, ref Password))
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                cbRememberMe.Checked = true;
            }
            else
            {
                cbRememberMe.Checked = false;
            }
        }
    }
}
