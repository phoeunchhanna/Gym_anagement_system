using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

namespace Gym_management_system.Controller
{
    internal class Controller_Ttrainers :Model.Model_trainers 
    {
        public DataTable dtt= new DataTable();
        public DataSet dst = new DataSet();
        public SqlDataAdapter adat = new SqlDataAdapter();
        public void load_trainer()
        {
            string sql = "SELECT * FROM Trainers";
            SqlCommand cmd = new SqlCommand(sql,conn);
            adat.SelectCommand = cmd;
            dst.Clear();
            adat.Fill(dst);
            dtt = dst.Tables[0];
        }
        //insert 
        public void insert()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "InsertTrainer";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastname;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = DOB;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.Int).Value = phonenumber;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@HireDate", SqlDbType.Date).Value = hiretdate;
                cmd.Parameters.Add("@Specialty", SqlDbType.VarChar).Value = spaecial;
                cmd.Parameters.Add("@Usernote", SqlDbType.VarChar).Value = usernote;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return;
            }
        }
        //udpate 
        public void update()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UpdateTrainer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TrainerID", SqlDbType.Int).Value = trainer_id;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastname;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = DOB;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.Int).Value = phonenumber;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@HireDate", SqlDbType.Date).Value = hiretdate;
                cmd.Parameters.Add("@Specialty", SqlDbType.VarChar).Value = spaecial;
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
        public void delete()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DeleteTrainer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TrainerID", SqlDbType.Int).Value = trainer_id;
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
