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
    public partial class Frm_Memberships : Form
    {
        public Frm_Memberships()
        {
            InitializeComponent();
        }
        Controller.Controller_Membership my_membership = new Controller.Controller_Membership();
        public void load_data()
        {
            my_membership.load_membership();
            data_view_membership.DataSource = my_membership.dt;
        }
        private void Frm_Memberships_Load(object sender, EventArgs e)
        {
            load_data();
            disable();
            txtship_id.Enabled = false;
        }
        //enable
        private void enable()
        {
            txtmembershiptype.Enabled= true;
            txtprice.Enabled= true;
            txtducation.Enabled= true;
        }
        //disable
        private void disable()
        {
            txtmembershiptype.Enabled = false;
            txtprice.Enabled = false;
            txtducation.Enabled = false;
        }
        //clears
        private void clears()
        {
            txtmembershiptype.Clear();
            txtprice.Clear();
            txtducation.Clear();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Add News")
            {
                enable();
                btnInsert.Text = "Save";
                btnUpdate.Text = "Clears";
                btnUpdate.Enabled = true;
               
            }
            else if (btnInsert.Text=="Clears")
            {
                clears();
                btnInsert.Text = "Add News";
                btnUpdate.Text = "Update";
                btnUpdate.Enabled = false;
                disable();
            }
            else if (btnInsert.Text == "Save")
            {
                if (txtmembershiptype.Text == "" )
                {
                    MessageBox.Show("Please check membership  again!", "Chack", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if ( txtducation.Text == "" )
                {
                    MessageBox.Show("Please check Ducation  again!", "Chack", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if ( txtprice.Text == "")
                {
                    MessageBox.Show("Please check price  again!", "Chack", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    my_membership.Membership_type = txtmembershiptype.Text;
                    my_membership.Duration=Convert.ToInt32(txtducation.Text);
                    my_membership.price = Convert.ToInt32(txtprice.Text);
                    my_membership.usernote = Userdetail.UserName;
                    my_membership.Insertmembership();

                    MessageBox.Show("Success data !", "Chack", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clears();
                    btnUpdate.Text = "Update";
                    btnUpdate.Enabled = false;
                    btnInsert.Text = "Add News";
                    load_data();
                }
            }
        }

        private void data_view_membership_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (data_view_membership.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtship_id.Text = data_view_membership.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtmembershiptype.Text = data_view_membership.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtducation.Text = data_view_membership.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtprice.Text = data_view_membership.Rows[e.RowIndex].Cells[3].Value.ToString();

                    enable();
                    txtship_id.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnInsert.Text = "Clears";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (btnUpdate.Text == "Clears")
            {
                enable();
                btnInsert.Text = "Add News";
                btnUpdate.Text = "Update";
                btnUpdate.Enabled = false;
                disable();

            }
            else 
            {
                try
                {
                    my_membership.Memship_id = Convert.ToInt32(txtship_id.Text);
                    my_membership.Membership_type = txtmembershiptype.Text;
                    my_membership.Duration = Convert.ToInt32(txtducation.Text);
                    my_membership.price = Convert.ToInt32(txtprice.Text);
                    my_membership.usernoteupdate = Userdetail.UserName;
                    my_membership.Updatemembership();

                    MessageBox.Show("Update Success data !", "Chack", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clears();
                    load_data();
                    disable();
                    btnUpdate.Text = "Update";
                    btnUpdate.Enabled = false;
                    btnInsert.Text = "Add News";
           
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return ;
                }
            }
        }

        private void data_view_membership_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (data_view_membership.Columns[e.ColumnIndex].HeaderText== "លុប")
                {
                    if (DialogResult.Yes == MessageBox.Show("Do you want to delete record?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        my_membership.Memship_id = Convert.ToInt32(data_view_membership.Rows[e.RowIndex].Cells["IdCol"].Value);
                        my_membership.Deletemembership();

                        MessageBox.Show("Data hase deleted ", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("You cannot delete !", "Fail delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_data();
                    }
                  
                }
               
            }
            catch(Exception)
            {
                MessageBox.Show("You cannot delete !", "Fail delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
            }
        }
        SqlDataAdapter adp;
        DataTable Dta;
        Connection conn;
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            adp = new SqlDataAdapter("SELECT * FROM Memberships WHERE MembershipType LIKE '%"+txtsearch.Text+"%'",my_membership.conn);
            Dta = new DataTable();
            adp.Fill(Dta);
            data_view_membership.DataSource = Dta;
        }
    }
}
