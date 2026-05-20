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

namespace DVLD.Test
{
    public partial class frmScheduleTest : Form
    {
        private int _LDLAppID = -1;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private int _AppointmentID = -1;

        public frmScheduleTest(int Ldlappid, clsTestTypes.enTestType testTypeid, int appointmentID = -1)
        {
            InitializeComponent();
            _LDLAppID = Ldlappid;
            _TestTypeID = testTypeid;
            _AppointmentID = appointmentID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LDLAppID, _AppointmentID);
        }

        private void ctrlScheduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
