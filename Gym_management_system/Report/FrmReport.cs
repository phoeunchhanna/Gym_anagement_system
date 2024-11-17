using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_management_system.Report
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();
        }

        private void imgClass_Click(object sender, EventArgs e)
        {
            Report.RepClass repClass = new Report.RepClass();
           repClass.ShowDialog();
        }

        private void imgMember_Click(object sender, EventArgs e)
        {
            Report.RepMember repMember = new Report.RepMember();
            repMember.ShowDialog();
        }
    }
}
