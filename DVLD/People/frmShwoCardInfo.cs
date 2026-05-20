using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmShwoCardInfo : Form
    {
        public frmShwoCardInfo(int personId)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(personId);
        }
        public frmShwoCardInfo(string NationalNumber)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(NationalNumber);
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
