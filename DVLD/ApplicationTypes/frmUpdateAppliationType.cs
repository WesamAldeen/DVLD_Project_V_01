using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace DVLD.ApplicationTypes
{
    public partial class frmUpdateAppliationType : Form
    {
        private clsApplicationType _AplicationType;
        private int _AppliationTypeID;

        public frmUpdateAppliationType(int AppID)
        {
            InitializeComponent();
            _AppliationTypeID = AppID;
        }
        private void _LoadEidtScreen()
        {
            _AplicationType = clsApplicationType.FindApplicationTypeById(_AppliationTypeID);
            
            if(_AplicationType != null)
            {
                lblID.Text = _AplicationType.AppID.ToString();
                txtTitle.Text = _AplicationType.AppTitle.ToString();
                txtFees.Text = _AplicationType.Fees.ToString();
            }
            else
            {
                MessageBox.Show("Not Found!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateAppliationType_Load(object sender, EventArgs e)
        {
            _LoadEidtScreen();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _AplicationType.AppTitle = txtTitle.Text;
            _AplicationType.Fees = Convert.ToSingle(txtFees.Text);

            if (_AplicationType.Save())
            {
                MessageBox.Show("Saved successfully.");
            }
            else
            {
                MessageBox.Show("Not Saved.");
            }
        }
    }
}
