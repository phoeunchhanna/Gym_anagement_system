using Gym_management_system.VIew;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_management_system
{
    public partial class Frm_login : Form
    {
        public Frm_login()
        {
            InitializeComponent();
        }

        private void btnOpenEye_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnOpenEye.BringToFront();
                txtPassword.PasswordChar = '\0';
                txtPassword.UseSystemPasswordChar = false;
                btnOpenEye.Visible = false;
                btnCloseEye.Visible = true;
            }
        }
        Connection myconn = new Connection();
        int i;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please try again!");
            }
            else
            {
                try
                {
                    string sqluer = "SELECT * FROM Users WHERE username ='" + txtUserName.Text + "' AND password ='" + txtPassword.Text + "'";
                    SqlCommand cmd = myconn.conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqluer;
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adtb = new SqlDataAdapter(cmd);
                    adtb.Fill(dt);
                    i = Convert.ToInt16(dt.Rows.Count.ToString());
                    if (dt.Rows.Count>0)
                    {
                        Userdetail.UserName = dt.Rows[0]["username"].ToString();
                        Userdetail.Usertype = dt.Rows[0]["Usertype"].ToString();
                        this.Hide();
                        VIew.Frm_Dasbord frm_dasbord = new Frm_Dasbord();
                        frm_dasbord.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or password ","Login note success!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtUserName.Clear();
                        txtPassword.Clear();
                    }
                    
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("error"+ ex.Message);
                }
            }
        }

        private void btnCloseEye_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnOpenEye.BringToFront();
                txtPassword.PasswordChar = '*';
                txtPassword.UseSystemPasswordChar = true;
                btnOpenEye.Visible = true;
                btnCloseEye.Visible = false;
            }
        }

        private void lblClears_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUserName.Clear();
        }

       
        private void Frm_login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
