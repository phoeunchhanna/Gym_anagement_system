using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_management_system.VIew
{
    public partial class Frm_Members : Form
    {
        public Frm_Members()
        {
            InitializeComponent();
        }
   
        Controller.Controller_Members my_members = new Controller.Controller_Members();
        //load data memberships 
        public void load_data_membersship()
        {
            commembership.DataSource = null;
            my_members.load_data_ship();
            commembership.DataSource = my_members.dtship;
            commembership.DisplayMember = "MembershipType";
            commembership.ValueMember = "MembershipID";
        }
        public void disable()
        {
            commembership.DataSource = null;
            txtaddress.Enabled = false;
            txtemail.Enabled = false;
            txtfirstname.Enabled = false;
            txtlastname.Enabled = false;
            txtphone.Enabled = false;
        }
        public void enable()
        {
            commembership.DataSource = null;
            txtaddress.Enabled = false;
            txtemail.Enabled = false;
            txtfirstname.Enabled = false;
            txtlastname.Enabled = false;
            txtphone.Enabled = false;
        }
        public void clear()
        {
            commembership.DataSource = null;
            txtaddress.Clear();
            txtemail.Clear();
            txtfirstname.Clear();
            txtID.Clear();
            txtlastname.Clear();
            txtphone.Clear();
        }
        private bool arrayfild()
        {
           if(string.IsNullOrWhiteSpace(txtfirstname.Text)||
              string.IsNullOrWhiteSpace(txtlastname.Text)||
              string.IsNullOrWhiteSpace(txtemail.Text)||
              string.IsNullOrWhiteSpace(txtphone.Text)||
              string.IsNullOrWhiteSpace(txtaddress.Text)||
              string.IsNullOrWhiteSpace(Dateofbirth.Text)||
              string.IsNullOrWhiteSpace(datejoin.Text)||
              string.IsNullOrWhiteSpace(comgender.Text)||
              string.IsNullOrWhiteSpace(commembership.Text)
             )
            {
                return false;
            }
           return true;

        }
        private int _membId = 0;
        private bool _isupdate = false;
        public int membId
        {
            get;
            set;
        }
        public bool isupdate
        {
            get;
            set;
        }
        public void insertdata()
        {
           /* if (!arrayfild())
            {
                MessageBox.Show("សូមឆែកព៍ត័មានម្តងទៀត", "chack data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                my_members.Fistname = txtfirstname.Text;
                my_members.lastnamme = txtlastname.Text;
                my_members.Gender = comgender.Text;
                my_members.Address = txtaddress.Text;
                my_members.Email = txtemail.Text;
                my_members.Phonenumber = Convert.ToInt32(txtphone.Text);
                my_members.DOB = Convert.ToDateTime(Dateofbirth.Text);
                my_members.Membership_id = Convert.ToInt32(commembership.SelectedValue);
                my_members.join_date = Convert.ToDateTime(datejoin.Text);
                my_members.usernote = Userdetail.UserName;
                my_members.Insert();

                MessageBox.Show("អ្នកបានបញ្ចូល" + txtfirstname.Text + "ជោគជ័យ", "chack data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnInsert.Text = "Add News";
                btnUpdate.Enabled = false;
                clear();
                this.Close();
            } */
        }
        public void updatedata()
        {
            
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
           /* if (this.isupdate)
            {
                updatedata();
                txtID.Enabled = true;
            }
            else
            {
                insertdata();
            } */

            if (!arrayfild())
            {
                MessageBox.Show("សូមឆែកព៍ត័មានម្តងទៀត", "chack data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                my_members.Fistname = txtfirstname.Text;
                my_members.lastnamme = txtlastname.Text;
                my_members.Gender = comgender.Text;
                my_members.Address = txtaddress.Text;
                my_members.Email = txtemail.Text;
                my_members.Phonenumber = Convert.ToInt32(txtphone.Text);
                my_members.DOB = Convert.ToDateTime(Dateofbirth.Text);
                my_members.Membership_id = Convert.ToInt32(commembership.SelectedValue);
                my_members.join_date = Convert.ToDateTime(datejoin.Text);
                my_members.usernote = Userdetail.UserName;
                my_members.Insert();

                MessageBox.Show("អ្នកបានបញ្ចូល" + txtfirstname.Text + "ជោគជ័យ", "chack data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnInsert.Text = "Add News";
                btnUpdate.Enabled = false;
                clear();
                this.Close();
            }
        }

        private void lblexit_Click(object sender, EventArgs e)
        {
            
        }

        private void Frm_Members_Load(object sender, EventArgs e)
        {
            load_data_membersship();
            //insertdata();
            //updatedata();
            txtID.Enabled=false;

            btnInsert.Enabled = true;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtCategoryID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void linkMemberShips_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_Memberships frm_Memberships = new Frm_Memberships();
            frm_Memberships.ShowDialog();
        }

        private void Frm_Members_Activated(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!arrayfild())
            {
                MessageBox.Show("សូមឆែកព៍ត័មានម្តងទៀត", "chack data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                my_members.Mem_id=Convert.ToInt16(txtID.Text);
                my_members.Fistname=txtfirstname.Text;
                my_members.lastnamme=txtlastname.Text;
                my_members.Membership_id=Convert.ToInt16(commembership.SelectedValue);
                my_members.Gender = comgender.Text;
                my_members.Email= txtemail.Text;
                my_members.Phonenumber=Convert.ToInt32(txtphone.Text);
                my_members.Address= txtaddress.Text;
                my_members.DOB=Convert.ToDateTime(Dateofbirth.Text);
                my_members.join_date=Convert.ToDateTime(datejoin.Text);
                my_members.usernoteupdate=Userdetail.UserName;
                my_members.Update();
               
                MessageBox.Show("ការកែប្រែសមាជិកបានជោគជ័យ", "update data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                clear();

            }
        }
    }
}
