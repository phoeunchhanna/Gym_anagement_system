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
    public partial class Frm_Paymant : Form
    {
        public Frm_Paymant()
        {
            InitializeComponent();
        }
        Controller.Controller_pyamernt mypay = new Controller.Controller_pyamernt();
        //load data member
        public void combo_members()
        {
            combolastname.DataSource = null;
            mypay.view_member();
            combolastname.DataSource = mypay.dtm;
            combolastname.DisplayMember = "LastName";
            combolastname.ValueMember = "MemberID";
        }
     
        public DataTable dtp= new DataTable();
        public void load_paymant()
        {
            string sql= "SELECT * FROM V_Payments";
            SqlDataAdapter adap = new SqlDataAdapter(sql,mypay.conn);
            dtp.Clear();
            adap.Fill(dtp);
        }
        //disable
        public void disable()
        {
            txtamount.Enabled = false;
            txtdatepay.Enabled = false;
            txtemail.Enabled = false;
            txtfirstname.Enabled = false;
        }
        //enable
        public void enable()
        {
            txtamount.Enabled = true;
            txtdatepay.Enabled = true;
            txtemail.Enabled = true;
            txtfirstname.Enabled = true;
        }
        //clears
        public void clears()
        {
            txtamount.Clear();
            txtdatepay.Text=DateTime.Now.ToString();
            txtemail.Clear();
            txtfirstname.Clear();
        }
        private void Frm_Paymant_Load(object sender, EventArgs e)
        {
            combo_members();
            load_paymant();
            disable();
        }

        private void payqrcode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Pay_QR_code qrcode = new Pay_QR_code();
            qrcode.ShowDialog();
            this.Hide();
        }

        private void combolastname_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(combolastname.SelectedValue!=null)
            {
                string sql = "SELECT FirstName , Email FROM Members where MemberID = @MemberID";
                SqlCommand cmd = new SqlCommand(sql,mypay.conn);
                cmd.Parameters.AddWithValue("@MemberID",combolastname.SelectedValue);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    txtfirstname.Text = dt.Rows[0]["FirstName"].ToString();
                    txtemail.Text = dt.Rows[0]["Email"].ToString();
                    enable();
                }
                else
                {
                    txtfirstname.Text=string.Empty;
                    txtemail.Text=string.Empty;
                }
            }
        }

        private void btnpayout_Click(object sender, EventArgs e)
        {
                mypay.member_id = Convert.ToInt32(combolastname.SelectedValue);
                mypay.amount = Convert.ToInt32(txtamount.Text);
                mypay.paymentdate = Convert.ToDateTime(txtdatepay.Text);

                if (check_direct_maney.Checked)
                {
                    mypay.paymenethod = "direct maney ";
                }
                else if (check_card.Checked)
                {
                    mypay.paymenethod = "Card";
                }
                else
                {
                    MessageBox.Show("Plase select a payment method ", "chack", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                mypay.usernote = Userdetail.UserName;
                mypay.Insert();
                MessageBox.Show("Your Payment inserted successfully  ", "insertd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_paymant();
                clears();
                disable();
                this.Close();
           
            
                
            
        }
    }
}
