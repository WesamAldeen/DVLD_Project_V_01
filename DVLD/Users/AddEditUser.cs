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
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew =1, Update=2 };
        private enMode _Mode;
        private int _UserID = -1;
        clsUsers _user;
       

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _user = new clsUsers();
                tpLoginInfo.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFocus();

            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfermPassword.Text = "";
            cbIsActive.Checked = true;
        }

        private void _LoadData()
        {
            _user = clsUsers.FindUserByUserID(_UserID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            if(_user == null)
            {
                MessageBox.Show("No user with ID " + _UserID + " user not found.");
                this.Close();
                return;
            }
            lblUserID.Text = _user.UserId.ToString();
            txtUserName.Text = _user.UserName.ToString();
            txtPassword.Text = _user.Password.ToString();
            txtConfermPassword.Text = _user.Password.ToString();
            cbIsActive.Checked = _user.IsActive;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_user.PersonID);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tapControl.SelectedTab = tapControl.TabPages["tpLoginInfo"];
                return;
            }
            if(ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if(clsUsers.IsUserExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected person is already a user");
                    ctrlPersonCardWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tapControl.SelectedTab = tapControl.TabPages["tpLoginInfo"];

                }
            }
            else
            {
                MessageBox.Show("Please Select person", "Select person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _user.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _user.UserName = txtUserName.Text.Trim();
            _user.Password = txtPassword.Text.Trim();
            _user.IsActive = cbIsActive.Checked;
            if(_user.Save())
            {
                lblUserID.Text = _user.UserId.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                this.Text = "Update User";
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
