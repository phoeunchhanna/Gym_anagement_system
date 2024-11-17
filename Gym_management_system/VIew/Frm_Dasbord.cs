using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_management_system.VIew
{
    public partial class Frm_Dasbord : Form
    {
        public Frm_Dasbord()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnclass_Click(object sender, EventArgs e)
        {
           Frm_Class frm_Class = new Frm_Class();
           frm_Class.Show();
        }

        private void btnenroll_Click(object sender, EventArgs e)
        {
            Frm_Enrollments frm_Enrollments = new Frm_Enrollments();
            frm_Enrollments.Show();
        }

        private void btnmem_Click(object sender, EventArgs e)
        {
           Frm_data_Members frm_Data_Members = new Frm_data_Members();
            frm_Data_Members.Show();
        }

        private void btnmembership_Click(object sender, EventArgs e)
        {
            Frm_Memberships frm_Memberships = new Frm_Memberships();
            frm_Memberships.Show();
        }

        private void btnpayment_Click(object sender, EventArgs e)
        {
            Frm_Paymant frm_Paymant = new Frm_Paymant();
            frm_Paymant.Show();
        }

        private void btntraler_Click(object sender, EventArgs e)
        {
            Frm_data_trainer frm_Data_Trainer = new Frm_data_trainer();
            frm_Data_Trainer.Show();
        }

        private void Frm_Dasbord_Load(object sender, EventArgs e)
        {
            lblusername.Text=Userdetail.UserName;

            timer1.Interval = 1000;

            // Enable the timer
            timer1.Enabled = true;

            // Attach event handler
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          lblshow_time.Text=DateTime.Now.ToString();
        }

        private void lblshow_time_Click(object sender, EventArgs e)
        {

        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            Report.FrmReport frmReport = new Report.FrmReport();
            frmReport.Show();
        }
    }
}
