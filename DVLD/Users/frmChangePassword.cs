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
    public partial class frmChangePassword : Form
    {
        private int _userID = -1;
        private clsUsers _user;

        public frmChangePassword()
        {
            InitializeComponent();
        }
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _userID = UserID;
        }
        private void _ResetForm()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetForm();
            _user = clsUsers.FindUserByUserID(_userID);
            if(_user == null)
            {
                MessageBox.Show("Sorry This User Is Not Found!.");
                return;
            }
            ctrlUserCardControl1.LoadUserInfo(_userID);

        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtCurrentPassword.Text.Trim() != _user.Password.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "The password is not true.");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtCurrentPassword.Text.Trim() == txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Please enter a different password.");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtNewPassword.Text.Trim() !=  txtConfirmPassword.Text.Trim() ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {   
            _user.Password = txtNewPassword.Text.Trim();
            if (_user.Save())
            {
                MessageBox.Show("Password Changed Successfully.",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetForm();
            }
            else
            {
                MessageBox.Show("An Error Occured, Password did not changed",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
