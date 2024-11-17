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
    public partial class Frm_data_trainer : Form
    {
        public Frm_data_trainer()
        {
            InitializeComponent();
        }
        Controller.Controller_Ttrainers my_trainer = new Controller.Controller_Ttrainers();
        public void load_trainer()
        {
            my_trainer.load_trainer();
            dg_view_trainers.DataSource = my_trainer.dtt;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Frm_Trainer frm_Trainer = new Frm_Trainer();
            frm_Trainer.Show();
        }

        private void Frm_data_trainer_Load(object sender, EventArgs e)
        {
            load_trainer();
        }
            Frm_Trainer tran= new Frm_Trainer();
        private void dg_view_trainers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //delete
            try
            {
                if (dg_view_trainers.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    if(DialogResult.Yes == MessageBox.Show("Do you want to dalete ?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        my_trainer.trainer_id = Convert.ToInt32(dg_view_trainers.Rows[e.RowIndex].Cells["Id"].Value);
                        my_trainer.delete();

                        MessageBox.Show("Do you want to dalete ?", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_trainer() ;
                    }
                    else
                    {
                        MessageBox.Show("you can not delete", "can not delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_trainer();

                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("you can not delete", "can not delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_trainer();
            }

            //edit 
            if (dg_view_trainers.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                if (dg_view_trainers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    tran.txtID.Text = dg_view_trainers.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    tran.txtfirstname.Text = dg_view_trainers.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                    tran.txtlastname.Text = dg_view_trainers.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                    tran.comgender.Text = dg_view_trainers.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                    tran.txtphone.Text = dg_view_trainers.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
                    tran.txtemail.Text = dg_view_trainers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                    tran.txtaddress.Text = dg_view_trainers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                    tran.txtspacial.Text = dg_view_trainers.Rows[e.RowIndex].Cells["Specialty"].Value.ToString();
                    if (DateTime.TryParse(dg_view_trainers.Rows[e.RowIndex].Cells["DateOfBirth"].Value.ToString(), out DateTime DOB))
                    {
                        tran.dateDOB.Value = DOB;
                    }
                    else
                    {
                        MessageBox.Show("Invalid data formating for DOB ");

                    }
                    if (DateTime.TryParse(dg_view_trainers.Rows[e.RowIndex].Cells["HireDate"].Value.ToString(), out DateTime hirt))
                    {
                        tran.daterequest.Value = hirt;
                    }
                    else
                    {
                        MessageBox.Show("Invalid data formating for hirt date ");

                    }
                    tran.ShowDialog();
                    load_trainer();
                }
            }
            else
            {
                Frm_Trainer trainer = new Frm_Trainer();
                trainer.btnInsert.Enabled = false;
                trainer.btnUpdate.Enabled = true;
            }
        }
        SqlDataAdapter adapter;
        DataTable dt;
        Connection conn;
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM Trainers WHERE LastName LIKE '%"+guna2TextBox1.Text+"'",my_trainer.conn);
            dt= new DataTable();
            dg_view_trainers.DataSource = dt;
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            dg_view_trainers.Refresh();
        }

        private void linkMemberShips_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VIew.Frm_Memberships frm_Memberships = new VIew.Frm_Memberships();
            frm_Memberships.ShowDialog();
        }
    }
}
