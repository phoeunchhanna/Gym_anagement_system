using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_management_system.Controller
{
    internal class Controller_Members:Model.Model_Members 
    {
        //load data membership
        public DataTable dtship = new DataTable();
        public DataSet dsship = new DataSet();
        public void load_data_ship()
        {
            string sqlship = "SELECT * FROM Memberships;";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlship,conn);
            adapter.Fill(dsship, "Memberships");
            dtship = dsship.Tables["Memberships"];
        }

        public DataTable dtM = new DataTable();
        public DataSet dsM = new DataSet();
        public SqlDataAdapter daM = new SqlDataAdapter();
        public void load_data_member()
        {
            string sqle = "SELECT * FROM V_Members";
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(sqle, conn);
            daM.SelectCommand = cmd;
            dsM.Clear();
            daM.Fill(dsM);
            dtM = dsM.Tables[0];
        }
        //insert
        public void Insert()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "InsertMember";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = Fistname;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastnamme;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = Gender;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = DOB;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.Int).Value = Phonenumber;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
                cmd.Parameters.Add("@JoinDate", SqlDbType.Date).Value = join_date;
                cmd.Parameters.Add("@MembershipID", SqlDbType.Int).Value =Membership_id;
                cmd.Parameters.Add("@Usernote", SqlDbType.VarChar).Value = usernote;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return;
            }

        }
        //update 
        public void Update()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UpdateMember";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@MemberID", SqlDbType.Int).Value = Mem_id;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = Fistname;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastnamme;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = Gender;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = DOB;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.Int).Value = Phonenumber;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
                cmd.Parameters.Add("@JoinDate", SqlDbType.Date).Value = join_date;
                cmd.Parameters.Add("@MembershipID", SqlDbType.Int).Value = Membership_id;
                cmd.Parameters.Add("@UsernoteUpdate", SqlDbType.VarChar).Value = usernoteupdate;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return;
            }

        }
        //delete 
        public void DeleteMembers()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Deletemember";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@memeber_id", SqlDbType.Int).Value = Mem_id;
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
