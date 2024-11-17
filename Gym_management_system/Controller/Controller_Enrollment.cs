using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_management_system.Controller.myclass
{
    internal class Controller_Enrollment :Model.myclass.Model_Enrollment
    {
        //load data member  
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public SqlDataAdapter sda= new SqlDataAdapter();
        public void load_data_member()
        {
            string sql = "SELECT * FROM  Members;";
            SqlDataAdapter data = new SqlDataAdapter(sql,conn);
            data.Fill(ds,"Members");
            dt = ds.Tables["Members"];
        }
        //load data class 
        public DataTable dtc = new DataTable();
        public DataSet dsc = new DataSet();
        public SqlDataAdapter sdac = new SqlDataAdapter();
        public void load_data_class()
        {
            string sqlc = "SELECT * FROM Classes;";
            SqlDataAdapter datac = new SqlDataAdapter(sqlc,conn);
            datac.Fill(dsc,"Classes");
            dtc = dsc.Tables["Classes"];
        }
        //load data enrollmant 
        public DataTable dte = new DataTable();
        public DataSet dse = new DataSet();
        public SqlDataAdapter dae= new SqlDataAdapter();
        public void load_data_enrollment()
        {
            string sqle = "SELECT * FROM V_Enrollment";
            SqlCommand cmd = new SqlCommand();
            cmd=new SqlCommand(sqle,conn);
            dae.SelectCommand = cmd;
            dse.Clear();
            dae.Fill(dse);
            dte = dse.Tables[0];
        }
        //Insert data Enrollments
        public void Insert()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "InsertEnrollment";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@MemberID", SqlDbType.Int).Value = Member_id;
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Class_id;
                cmd.Parameters.Add("@EnrollDate", SqlDbType.Date).Value = EnrollDate;
                cmd.Parameters.Add("@Usernote", SqlDbType.VarChar).Value = usernote;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error"+ex.Message);
                return;
            }

        }
        //Update data enrollments 
        public void Update()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UpdateEnrollment";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@EnrollmentID", SqlDbType.Int).Value = Enrol_id;
                cmd.Parameters.Add("@MemberID", SqlDbType.Int).Value = Member_id;
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = Class_id;
                cmd.Parameters.Add("@EnrollDate", SqlDbType.Date).Value = EnrollDate;
                cmd.Parameters.Add("@UsernoteUpdate", SqlDbType.VarChar).Value = usernoteupdate;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return;
            }
        }
        public void Delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DeleteEnrollment";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@EnrollmentID", SqlDbType.Int).Value = Enrol_id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return;
            }
        }

    }
}
