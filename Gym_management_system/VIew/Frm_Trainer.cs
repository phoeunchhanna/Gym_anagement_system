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
    public partial class Frm_Trainer : Form
    {
        public Frm_Trainer()
        {
            InitializeComponent();
        }
        Controller.Controller_Ttrainers my_trainer = new Controller.Controller_Ttrainers();
        public void load_trainer()
        {
            my_trainer.load_trainer();
         
        }
        private bool arrayfild()
        {
            if (string.IsNullOrWhiteSpace(txtfirstname.Text) ||
               string.IsNullOrWhiteSpace(txtlastname.Text) ||
               string.IsNullOrWhiteSpace(txtemail.Text) ||
               string.IsNullOrWhiteSpace(txtphone.Text) ||
               string.IsNullOrWhiteSpace(txtaddress.Text) ||
               string.IsNullOrWhiteSpace(dateDOB.Text) ||
               string.IsNullOrWhiteSpace(daterequest.Text) ||
               string.IsNullOrWhiteSpace(comgender.Text) ||
               string.IsNullOrWhiteSpace(txtspacial.Text)
              )
            {
                return false;
            }
            return true;

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!arrayfild())
            {
                MessageBox.Show("សូមឆែកព៍ត័មានម្តងទៀត", "chack data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                my_trainer.firstname = txtfirstname.Text;
                my_trainer.lastname = txtlastname.Text;
                my_trainer.gender = comgender.Text;
                my_trainer.address = txtaddress.Text;
                my_trainer.email = txtemail.Text;
                my_trainer.spaecial = txtspacial.Text;
                my_trainer.phonenumber = Convert.ToInt32(txtphone.Text);
                my_trainer.DOB = Convert.ToDateTime(dateDOB.Text);
                my_trainer.hiretdate = Convert.ToDateTime(daterequest.Text);
                my_trainer.usernote = Userdetail.UserName;
                my_trainer.insert();

                MessageBox.Show("អ្នកបានបញ្ចូល" + txtfirstname.Text + "ជោគជ័យ", "insert data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnInsert.Text = "Add News";
                btnUpdate.Enabled = false;
                
                this.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!arrayfild())
            {
                MessageBox.Show("សូមឆែកព៍ត័មានម្តងទៀត", "chack data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                my_trainer.trainer_id = Convert.ToInt32( txtID.Text);
                my_trainer.firstname = txtfirstname.Text;
                my_trainer.lastname = txtlastname.Text;
                my_trainer.gender = comgender.Text;
                my_trainer.address = txtaddress.Text;
                my_trainer.email = txtemail.Text;
                my_trainer.spaecial = txtspacial.Text;
                my_trainer.phonenumber = Convert.ToInt32(txtphone.Text);
                my_trainer.DOB = Convert.ToDateTime(dateDOB.Text);
                my_trainer.hiretdate = Convert.ToDateTime(daterequest.Text);
                my_trainer.usernoteupdate = Userdetail.UserName;
                my_trainer.update();

                MessageBox.Show("អ្នកបានបញ្ចូល" + txtfirstname.Text + "ជោគជ័យ", "updarer data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnInsert.Text = "Add News";
                btnUpdate.Enabled = false;

                this.Close();
            }
        }
    }
}
