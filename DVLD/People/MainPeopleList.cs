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

namespace DVLD
{
    public partial class cbFilterBy : Form
    {
        private static DataTable _dtAllPeople = clsPeopleBuisnes.GetAllPeopleData();
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
            "FirstName", "SecondName", "ThirdName", "LastName", "GendorCaption", "Phone", "Email");
        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPeopleBuisnes.GetAllPeopleData();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                "FirstName", "SecondName", "ThirdName", "LastName", "GendorCaption", "Phone", "Email");
            dataGridView1.DataSource = _dtPeople;
            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 70;

                dataGridView1.Columns[1].HeaderText = "National No";
                dataGridView1.Columns[1].Width = 70;

                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 100;

                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 100;

                dataGridView1.Columns[6].HeaderText = "Gendor";
                dataGridView1.Columns[6].Width = 70;

                dataGridView1.Columns[7].HeaderText = "Phone";
                dataGridView1.Columns[7].Width = 120;

                dataGridView1.Columns[8].HeaderText = "Email";
                dataGridView1.Columns[8].Width = 170;
            }
        }
        private void _GetTotalCount()
        {
            label1.Text = "Total = #" + clsPeopleBuisnes.GetTotalCount().ToString();
        }
        public cbFilterBy()
        {
            InitializeComponent();
        }
        private void MainPeopleList_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            comboBox1.Items.Add("None");
            comboBox1.Items.Add("Person ID");
            comboBox1.Items.Add("National Number");
            comboBox1.Items.Add("First Name");
            comboBox1.Items.Add("Second Name");
            comboBox1.Items.Add("Third Name");
            comboBox1.Items.Add("Last Name");
            comboBox1.Items.Add("Phone");
            comboBox1.Items.Add("Email");

            comboBox1.SelectedIndex = 0;

            clsGlobal.StyleDataGridView(this.dataGridView1);
            // cbFilterBy.SelectedIndex = 0;
             _RefreshPeopleList();
            _GetTotalCount();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmInsertEdit frmAddEdit = new frmInsertEdit(-1);
            frmAddEdit.ShowDialog();
            _RefreshPeopleList();
            _GetTotalCount();
        }

        private void editPersonInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmInsertEdit frmEditInsert = new frmInsertEdit(id);
            frmEditInsert.ShowDialog();
            _RefreshPeopleList();
            _GetTotalCount();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this record?",
                "Countenue?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
                );
            if( result == DialogResult.OK )
            {
                if (clsPeopleBuisnes.DeletePerson(id))
                {
                    MessageBox.Show("Deleted Successfully.");
                }
                else
                {
                    MessageBox.Show("You can't delete this person.");
                }
            }
            _RefreshPeopleList();
            _GetTotalCount();
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int personId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                frmShwoCardInfo frm = new frmShwoCardInfo(personId);
                frm.ShowDialog();
                _RefreshPeopleList();
                _GetTotalCount();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            // Map selected filter to real column name
            switch(comboBox1.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National Number":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Thaird Name":
                    FilterColumn = "ThairdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            // Reset the filters in case nothing selected or filter value contains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                label1.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID")
            // in this case we deal with integer not string.
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            }
            else
            // deal with string
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            }
            label1.Text = dataGridView1.Rows.Count.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (comboBox1.Text != "None");
            if(txtFilterValue.Visible )
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }
    }
}

