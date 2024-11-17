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
    public partial class Frm_Class : Form
    {
        public Frm_Class()
        {
            InitializeComponent();
        }
        Controller.myclass.Controller_class myclassfrm = new Controller.myclass.Controller_class();
        //load data to combobox Traners 
        public void load_data_to_traner()
        {
            comtriler.DataSource = null;
            myclassfrm.load_data_Trainers();
            comtriler.DataSource = myclassfrm.dt;
            comtriler.DisplayMember = "LastName";
            comtriler.ValueMember = "TrainerID";
        }
        //load data to data Grid view 
        private void load_data_class()
        {
            myclassfrm.load_data_class();
            dg_view_class.DataSource = myclassfrm.dtc;
        }
        private void Frm_Class_Load(object sender, EventArgs e)
        {
            txtclassid.Enabled = false;
            load_data_to_traner();
            load_data_class();
            disable();
        }
        //disable 
        public void disable()
        {
           
            txtclassname.Enabled= false;
            txtcapacity.Enabled= false;
            txtschedule.Enabled= false;
            txtxduration.Enabled= false;
            comtriler.Enabled= false;
        }
        //Enable 
        public void enable()
        {
          
            txtclassname.Enabled = true;
            txtcapacity.Enabled = true;
            txtschedule.Enabled = true;
            txtxduration.Enabled = true;
            comtriler.Enabled = true;
        }
        //clears 
        public void clear()
        {
            txtclassid.Clear();
            txtclassname.Clear();
            txtcapacity.Clear();
            txtschedule.Text = null;
            txtxduration.Clear();
            comtriler.Text = null;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(btnInsert.Text=="Add News")
            {
                enable();
                btnInsert.Text = "save";
                btnUpdate.Enabled= true;
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
            else if (btnInsert.Text == "save")
            {
                if (txtclassname.Text == "" || txtschedule.Value==null || txtxduration.Text == "" || comtriler.Text == "")
                {
                    MessageBox.Show("ឆែកការបញ្ចូលទិន្ន័យ !","check data",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    myclassfrm.classname=txtclassname.Text;
                    myclassfrm.capacity=Convert.ToInt32(txtcapacity.Text);
                    myclassfrm.Schedule=Convert.ToDateTime(txtschedule.Value);
                    myclassfrm.TrainerID = Convert.ToInt32(comtriler.SelectedValue);
                    myclassfrm.duration=Convert.ToInt32(txtxduration.Text);
                    myclassfrm.Usernote = Userdetail.UserName;
                    myclassfrm.InsertClass();

                    MessageBox.Show("ការបញ្ចូលទិន្នន័យជោគជ័យ","insert",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data_class();
                   
                }
            }
        }

        private void dg_view_class_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dg_view_class.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtclassid.Text = dg_view_class.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtclassname.Text = dg_view_class.Rows[e.RowIndex].Cells[1].Value.ToString();
                    comtriler.Text = dg_view_class.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtschedule.Value = Convert.ToDateTime(dg_view_class.Rows[e.RowIndex].Cells[3].Value);
                    txtxduration.Text = dg_view_class.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtcapacity.Text = dg_view_class.Rows[e.RowIndex].Cells[5].Value.ToString();

                    enable();
                    txtclassid.Enabled = true;
                    btnUpdate.Enabled = true;
                    btndelete.Enabled = true;
                    btnInsert.Text = "Clear";
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Clear")
            {
                clear();
                btnUpdate.Text = "Update";
                btndelete.Enabled = false;
                btnInsert.Text = "Add News";
                disable();
            }
            else if (btnUpdate.Text == "Update")
            {
                myclassfrm.class_id=Convert.ToInt32(txtclassid.Text);
                myclassfrm.classname=txtclassname.Text;
                myclassfrm.TrainerID=Convert.ToInt32(comtriler.SelectedValue);
                myclassfrm.Schedule=Convert.ToDateTime(txtschedule.Value);
                myclassfrm.duration=Convert.ToInt32(txtxduration.Text); 
                myclassfrm.capacity=Convert.ToInt32(txtcapacity.Text);
                myclassfrm.UsernoteUpate = Userdetail.UserName;
                myclassfrm.UpadateClass();

                MessageBox.Show("ការកែប្រែជោគជ័យ","update",MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data_class();
                
               
                btnUpdate.Enabled = false;
                btndelete.Enabled = false;
                btnInsert.Text = "Add News";
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("តើអ្នកចង់លុប" + txtclassname.Text + "មែនទេ ?", "delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                
                myclassfrm.class_id = Convert.ToInt16(txtclassid.Text);
                myclassfrm.Delteclass();
                MessageBox.Show("អ្នកបានលុបជោគជ័យ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data_class();
                clear();
                disable();
                btnInsert.Text = "Add News";
                btnUpdate.Text = "Update";
                btnUpdate.Enabled=false;
                btndelete.Enabled=false;
                

            }
        }
        SqlDataAdapter adapter;
        DataTable dt;
        Connection conn;
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM Classes WHERE ClassName LIKE '%"+txtsearch.Text+"%'",myclassfrm.conn);
            dt=new DataTable();
            adapter.Fill(dt);   
            dg_view_class.DataSource = dt;
        }
    }
}
