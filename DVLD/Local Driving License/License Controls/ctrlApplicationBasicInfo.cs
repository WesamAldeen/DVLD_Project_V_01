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

namespace DVLD.Local_Driving_License.License_Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationID = -1;
        private int _PersonID;
        private clsApplication _Application;
        public int ApplicationID
        {
            get { return  _ApplicationID; }
        }
        public void LoadApplicationIinfoByAppID(int app)
        {
            _Application = clsApplication.FindBaseApplication(app);
            if (_Application == null)
            {
                _ResetInfo();
                MessageBox.Show("No Application with Application ID : " + app);
                return;
            }
            _FillInfo();
        }
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
        private void _ResetInfo()
        {
            lblAppID.Text = "???";
            lblStatus.Text = "???";
            lblFees.Text = "???";
            lblType.Text = "???";
            lblApplicant.Text = "???";
            lblDate.Text = "???";
            lblStatusDate.Text = "???";
            lblCreatedBy.Text = "???";
            linkViewPersonInfo.Enabled = (_PersonID != -1);
        }
        private void _FillInfo()
        {

            _ApplicationID = _Application.ApplicationID;
            _PersonID = _Application.ApplicantPersonID;

            lblAppID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationTypeInfo.AppTitle;
            lblApplicant.Text = _Application.ApplicantFullName;
            lblDate.Text = _Application.ApplicationDate.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void linkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShwoCardInfo frm = new frmShwoCardInfo(_PersonID);
            frm.ShowDialog();
        }
    }
}
