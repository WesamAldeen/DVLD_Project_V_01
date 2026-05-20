using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace DVLD.TestTypes
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestTypes _TestType;
        private int _TestTypeID;
        public frmUpdateTestType(int id)
        {
            InitializeComponent();
            _TestTypeID = id;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestTypes.FindTestType(_TestTypeID);
            if (_TestType != null)
            {
                lblTestID.Text = _TestTypeID.ToString();
                txtDescrition.Text = _TestType.TestTypeDescription.ToString();
                txtFees.Text = _TestType.TestTypeFees.ToString();
                txtTitle.Text = _TestType.TestTypeTitle.ToString();
            }
            else
            {
                MessageBox.Show("Not Found!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblTestID_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestType.TestTypeTitle = txtTitle.Text;
            _TestType.TestTypeDescription = txtDescrition.Text;
            _TestType.TestTypeFees = Convert.ToSingle(txtFees.Text);

            if (_TestType.Save())
            {
                MessageBox.Show("Saved successfully.");
            }
            else
            {
                MessageBox.Show("Not saved.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
