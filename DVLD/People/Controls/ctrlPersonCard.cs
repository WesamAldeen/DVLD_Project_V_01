using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Properties;
using System.IO;
using DVLD_BuisnessLayer;

namespace DVLD
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPeopleBuisnes _Person;
        private int _PersonId = -1;
        public int PersonId
        {
            get { return _PersonId; }
        }
        public clsPeopleBuisnes SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        private void _LoadPersonImg()
        {
            if (_Person.Gendor == 0)
                pbImg.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(Resources.Male_icon_removebg_preview));
            else
                pbImg.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(Resources.fmale_icon_removebg_preview));
            string ImgPath = _Person.ImagePath;
            if (ImgPath != "")
            {
                if(File.Exists(ImgPath))
                {
                    pbImg.ImageLocation = ImgPath;
                }
            }
        }
        private void _FillPersonInfo()
        {
            if (_Person != null)
            {
                linkLabel1.Enabled = true;
                lblID.Text = _Person.PersonID.ToString();
                lblName.Text = _Person.Fname + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.Lname;
                lblNationalNo.Text = _Person.Nationalnumber;
                lblBirth.Text = _Person.DateOfBirth.ToString();
                lblCountry.Text = clsBusCountries.FindCountryById(_Person.NationalityCountryID).CountryName;
                lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
                lblEmail.Text = _Person.Email;
                lblAddress.Text = _Person.Address;
                lblPhone.Text = _Person.Phone;
                _LoadPersonImg();
            }
        }
        public void RestPersonInfo()
        {
            lblID.Text = "----";
            lblName.Text = "----";
            lblNationalNo.Text = "----";
            lblBirth.Text = "----";
            lblCountry.Text = "----";
            lblGendor.Text = "----";
            lblEmail.Text = "----";
            lblAddress.Text = "----";
            lblPhone.Text = "----";
        }
        public void LoadPersonInfo(int PersonId)
        {
            _Person = clsPeopleBuisnes.Find(PersonId);
            if(_Person == null)
            {
                RestPersonInfo();
                MessageBox.Show("Not Found.");
                return;
            }
            _PersonId = _Person.PersonID;
            _FillPersonInfo();
        }
        public void LoadPersonInfo(string nn)
        {
            _Person = clsPeopleBuisnes.Find(nn);
            if(_Person == null)
            {
                RestPersonInfo();
                MessageBox.Show("Not Found.");
                return;
            }
            _PersonId = _Person.PersonID;
            _FillPersonInfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInsertEdit frm = new frmInsertEdit(PersonId);
            frm.ShowDialog();
            // refresh
            LoadPersonInfo(PersonId);

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}
