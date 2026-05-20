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
    public partial class ctrlUserCardControl : UserControl
    {
        private clsUsers _User;
        private int _UserID = -1;
        public int UserID
        {
            get { return _UserID; }
        }
        public ctrlUserCardControl()
        {
            InitializeComponent();
        }
        
        public void LoadUserInfo(int userid)
        {
            _UserID = userid;
            _User = clsUsers.FindUserByUserID(userid);
            if(_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No user with ID: " + userid.ToString());
                return;
            }
            _FillUserInfo();
        }
        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _UserID.ToString();
            lblUserName.Text = _User.UserName;
            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else 
                lblIsActive.Text = "No";
        }
        private void _ResetPersonInfo()
        {
            lblUserID.Text = "???";
            lblUserName.Text = "???";
            lblIsActive.Text = "???";
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
