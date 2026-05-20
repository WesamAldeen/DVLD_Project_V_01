using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_BuisnessLayer;
using DVLD.Properties;
using DVLD;

namespace DVLD
{
    public partial class frmInsertEdit : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

    //OpenFileDialog openFileDialog1;

        enum enMode { Add = 1, Edit = 2 };
        enMode Mode;
        int _PersonId;
        clsPeopleBuisnes _Person;

        private void _FillComboBoxCountries()
        {
            DataTable dt = clsBusCountries.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {
                cbCountries.Items.Add(dr["CountryName"]);
            }
            cbCountries.SelectedIndex = 164;
            // sudan 165 jordan 90
        }
        private void _LoadDate()
        {
            // Load countries data in comboBox.
            _FillComboBoxCountries();

            if (Mode == enMode.Add) 
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPeopleBuisnes();
                lblID.Text = "??";
                llRemoveImg.Visible = false;
                BirthOfDate.MinDate = DateTime.Now.AddYears(-60);
                BirthOfDate.MaxDate = DateTime.Now.AddYears(-18);
                BirthOfDate.Value = BirthOfDate.MaxDate;
                return;
            }
            _Person = clsPeopleBuisnes.Find(_PersonId);
            if (_Person == null )
            {
                MessageBox.Show("Oops! Closing Screen...");
                this.Close();
                return;
            }
            lblTitle.Text = "Edit Person Information";
            lblID.Text = _Person.PersonID.ToString();
            txtAddress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            txtFirstName.Text = _Person.Fname;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtPhone.Text = _Person.Phone;
            txtLastName.Text = _Person.Lname;
            txtNationalNumber.Text = _Person.Nationalnumber;
            BirthOfDate.Value = _Person.DateOfBirth;
            if(_Person.Gendor == 0)
            {
                rbMale.Checked = true;
                pbPersonImg.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(Resources.Male_icon_removebg_preview));
            }
            else if( _Person.Gendor == 1)
            {
                rbFemale.Checked = true;
                pbPersonImg.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(Resources.fmale_icon_removebg_preview));
            }

            if (_Person.ImagePath != null)
            {
                pbPersonImg.ImageLocation = _Person.ImagePath;
            }
                llRemoveImg.Visible = (_Person.ImagePath != "");
            cbCountries.SelectedIndex = cbCountries.FindString(clsBusCountries.FindCountryById(_Person.NationalityCountryID).CountryName);
            
            
        }
        public frmInsertEdit()
        {
            InitializeComponent();
            Mode = enMode.Add;
        }
        public frmInsertEdit(int personid)
        {
            InitializeComponent();

            _PersonId = personid;
            if (_PersonId == -1)
            {
                Mode = enMode.Add;
            }
            else
            {
                Mode= enMode.Edit;
            }
        }

        private void frmInsertEdit_Load(object sender, EventArgs e)
        {
            _LoadDate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 🟢 تحديد الدولة
            int countryid = clsBusCountries.FindCountryByName(cbCountries.Text).CountryId;
            _Person.NationalityCountryID = countryid;

            // 🟢 تعبئة الخصائص من الفورم
            _Person.Fname = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.Lname = txtLastName.Text;
            _Person.Nationalnumber = txtNationalNumber.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.Gendor = rbFemale.Checked ? (byte)1 : (byte)0;
            _Person.DateOfBirth = BirthOfDate.Value;
            _Person.Address = txtAddress.Text;

            // 🟢 الصورة
            if (!string.IsNullOrEmpty(pbPersonImg.ImageLocation))
            {
                _Person.ImagePath = pbPersonImg.ImageLocation;
            }
            else
            {
                _Person.ImagePath = null; // نخزن NULL في قاعدة البيانات لو مفيش صورة
            }

            // 🟢 الحفظ
            if (_Person.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
                Mode = enMode.Edit;
                lblTitle.Text = "Edit Person Information";
            }
            else
            {
                MessageBox.Show("Data Was Not Saved.");
            }
        }
        private bool _HandleImgPerson()
        {
            if(_Person.ImagePath != pbPersonImg.ImageLocation)
            {
                if(_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);

                    }
                    catch (IOException)
                    {

                    }
                }
            }
            if(pbPersonImg.ImageLocation != null)
            {
                string SourceImageFile = pbPersonImg.ImageLocation.ToString();
                if (clsUtle.CopyIamgeToProjectImagesFolder(ref  SourceImageFile))
                {
                    pbPersonImg.ImageLocation = SourceImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("!Opps Error Coping Image.");
                    return false;
                }
            }
            return true;
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImg.ImageLocation == null) {
                pbPersonImg.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(Resources.Male_icon_removebg_preview));
            }
        }

        private void llRemoveImg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImg.ImageLocation = null;
            if (rbMale.Checked)
                pbPersonImg.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(Resources.Male_icon_removebg_preview));
            else
                pbPersonImg.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(Resources.Male_icon_removebg_preview));
            llRemoveImg.Visible = false;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(pbPersonImg.ImageLocation == null)
            {
                pbPersonImg.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(Resources.fmale_icon_removebg_preview));
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "This field is required.");
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(txtEmail.Text == "")
            {
                return;
            }
            if(!clsValidate.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email format!.");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            // لو فارغ
            if (string.IsNullOrWhiteSpace(txtNationalNumber.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNumber, "National ID cannot be empty.");
                return;
            }

            // لو الرقم مستخدم من قبل (مع مراعاة حالة التعديل)
            if (txtNationalNumber.Text != _Person.Nationalnumber &&
                clsPeopleBuisnes.IsExist(txtNationalNumber.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNumber, "The national ID must be unique.");
            }
            else
            {
                errorProvider1.SetError(txtNationalNumber, null);
            }
        }

        private void llSetImg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImg.Load(selectedFilePath);
                llRemoveImg.Visible = true;
            }
        }
    }
}
