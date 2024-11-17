using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Gym_management_system.VIew
{
    public partial class Frm_data_Members : Form
    {
        Controller.Controller_Members my_member = new Controller.Controller_Members();

        public Frm_data_Members()
        {
            InitializeComponent();
        }
        public void load_data_gride(){
            my_member.load_data_member();
            data_view_Members.DataSource = my_member.dtM;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Frm_Members member = new Frm_Members();
            member.Show();
        }

        private void Frm_data_Members_Load(object sender, EventArgs e)
        {
            load_data_gride();
        }
        SqlDataAdapter adpater;
        DataTable dtable;
        Connection conn;
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            adpater = new SqlDataAdapter("SELECT * FROM V_Members WHERE LastName LIKE '%"+guna2TextBox1.Text+"'",my_member.conn);
            dtable = new DataTable();
            data_view_Members.DataSource = dtable;
        }

        Controller.Controller_Members my_mem = new Controller.Controller_Members(); //inherit from controller 
        Frm_Members Mem = new Frm_Members(); //get form members 

        private void data_view_Members_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            //modul data to form 
            if (data_view_Members.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                if (data_view_Members.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Mem.txtID.Text = data_view_Members.Rows[e.RowIndex].Cells["MemberID"].Value.ToString();
                    Mem.txtfirstname.Text = data_view_Members.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                    Mem.txtlastname.Text = data_view_Members.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                    Mem.commembership.Text = data_view_Members.Rows[e.RowIndex].Cells["Col_membership"].Value.ToString();
                    Mem.comgender.Text = data_view_Members.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                    Mem.txtemail.Text = data_view_Members.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                    Mem.txtaddress.Text = data_view_Members.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                    Mem.txtphone.Text = data_view_Members.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();

                    //convert DOB 
                    if (DateTime.TryParse(data_view_Members.Rows[e.RowIndex].Cells["DateOfBirth"].Value.ToString(), out DateTime dob))
                    {
                        Mem.Dateofbirth.Value=dob;
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format for date of birth ");
                    }
                    if (DateTime.TryParse(data_view_Members.Rows[e.RowIndex].Cells["JoinDate"].Value.ToString(), out DateTime join_date))
                    {
                        Mem.datejoin.Value = join_date;
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format for date of join ");
                    }
                    Mem.btnInsert.Enabled=false;
                    Mem.btnUpdate.Enabled = true;
                    Mem.ShowDialog();
                    load_data_gride();
                }
            }
        }
        

        private void data_view_Members_DoubleClick(object sender, EventArgs e)
        {

           
                
        }

        private void Frm_data_Members_Activated(object sender, EventArgs e)
        {
            load_data_gride();
        }

        private void data_view_Members_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //delete data 
            try
            {
                if (data_view_Members.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    if (DialogResult.Yes == MessageBox.Show("តើអ្នកចង់លុបមែនទេ ?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        my_member.Mem_id = Convert.ToInt16(data_view_Members.Rows[e.RowIndex].Cells["MemberID"].Value);
                        my_member.DeleteMembers();

                        MessageBox.Show("Data has been delete  ", "Data delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_data_gride();
                    }
                    else
                    {
                        MessageBox.Show(" You can not delete this record ", "Data delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_data_gride();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You can not delete this record ", "Data delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data_gride();
            }
        }

        private void data_view_Members_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
