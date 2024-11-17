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
    public partial class Frm_Enrollments : Form
    {
        public Frm_Enrollments()
        {
            InitializeComponent();
        }
        Controller.myclass.Controller_Enrollment my_enroll = new Controller.myclass.Controller_Enrollment();

        //load data enroll to combox
        public void load_data_enroll_combo()
        {
            combo_member.DataSource=null;
            my_enroll.load_data_member();
            combo_member.DataSource = my_enroll.dt;
            combo_member.DisplayMember = "LastName";
            combo_member.ValueMember = "MemberID";
        }
        //load data class to combox 
        public void load_data_class_combo()
        {
            combo_class.DataSource=null;
            my_enroll.load_data_class();
            combo_class.DataSource = my_enroll.dtc;
            combo_class.DisplayMember = "ClassName";
            combo_class.ValueMember = "ClassID";
        }
        //load data to datagrid view 
        public void load_enrollment()
        {
            my_enroll.load_data_enrollment();
            dg_view_enrollment.DataSource = my_enroll.dte;
        }
        private void Frm_Enrollments_Load(object sender, EventArgs e)
        {
            load_data_enroll_combo();
            load_data_class_combo();
            load_enrollment();
            txtenroll_id.Enabled = false;
            disable();
        }
        //disable 
        public void disable()
        {
            combo_class.Enabled = false;
            combo_member.Enabled = false;
            date_time.Enabled = false;  

        }
        public void enable()
        {
            combo_class.Enabled = true;
            combo_member.Enabled = true;
            date_time.Enabled = true;
        }
        public void clear()
        {
            combo_class.Text= null;
            combo_member.Text=null;
            date_time.Text = null;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Add News")
            {
                enable();
                btnInsert.Text = "Save";
                btnUpdate.Enabled = true;
                btnUpdate.Text = "Clear";
            }
            else if (btnInsert.Text == "Clear")
            {
                clear();
                btnInsert.Text = "Add News";
                btnUpdate.Text = "Update";
                btnUpdate.Enabled = false;
                disable();
            }
            else if (btnInsert.Text == "Save")
            {
                if (combo_member.Text == "" || combo_class.Text == "" || date_time.Value == null)
                {
                    MessageBox.Show("ចូលបញ្ចូលឡើងវិញ","Chack ",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    my_enroll.Member_id=Convert.ToInt32(combo_member.SelectedValue);
                    my_enroll.Class_id=Convert.ToInt32(combo_class.SelectedValue);
                    my_enroll.EnrollDate=Convert.ToDateTime(date_time.Value);
                    my_enroll.usernote = Userdetail.UserName;
                    my_enroll.Insert();

                    MessageBox.Show("ការបញ្ចូលបានជោគជ័យ", "Inserted ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    disable();
                    load_data_class_combo();
                    load_data_enroll_combo();
                    load_enrollment();
                    load_enrollment();
                    txtenroll_id.Enabled = true;
                    btnInsert.Text = "Add News";
                    btnUpdate.Text = "Update";
                    btnUpdate.Enabled = false;
                }
            }
        }

        private void dg_view_enrollment_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dg_view_enrollment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtenroll_id.Text = dg_view_enrollment.Rows[e.RowIndex].Cells[1].Value.ToString();
                    combo_class.Text = dg_view_enrollment.Rows[e.RowIndex].Cells[2].Value.ToString();
                    combo_member.Text = dg_view_enrollment.Rows[e.RowIndex].Cells[3].Value.ToString();
                    date_time.Value = Convert.ToDateTime( dg_view_enrollment.Rows[e.RowIndex].Cells[4].Value);

                    enable();
                    txtenroll_id.Enabled = true;
                    btnInsert.Text = "Clear";
                    btnUpdate.Enabled = true;
                    btnUpdate.Text = "Update";
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Clear")
            {
                enable();
                btnUpdate.Text = "Update";
                btnUpdate.Enabled = false;
                btnInsert.Text = "Add News";
                disable();
            }
            else
            {
                try
                {
                    my_enroll.Enrol_id = Convert.ToInt32(txtenroll_id.Text);
                    my_enroll.Class_id = Convert.ToInt32(combo_class.SelectedValue);
                    my_enroll.Member_id = Convert.ToInt32(combo_member.SelectedValue);
                    my_enroll.EnrollDate = Convert.ToDateTime(date_time.Value);
                    my_enroll.usernoteupdate = Userdetail.UserName;

                    my_enroll.Update();

                    MessageBox.Show("ការកែប្រែបានជោគជ័យ", "updated ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clear();
                    disable();
                    load_data_class_combo();
                    load_data_enroll_combo();
                    load_enrollment();

                    txtenroll_id.Enabled = true;
                    btnInsert.Text = "Add News";
                    btnUpdate.Text = "Update";
                    btnUpdate.Enabled = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error"+ex.Message);
                    return;
                }
            }
            
        }

        private void dg_view_enrollment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg_view_enrollment.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                if (DialogResult.Yes == MessageBox.Show("តើអ្នកចង់លុប" , "delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    my_enroll.Enrol_id = Convert.ToInt32(dg_view_enrollment.Rows[e.RowIndex].Cells["Delete"].Value);
                    my_enroll.Delete();


                    MessageBox.Show("ការលុបបានជោគជ័យ", "Delete ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clear() ;
                    load_data_class_combo();
                    load_data_enroll_combo();
                    load_enrollment();

                }
            }
        }
    }
}
