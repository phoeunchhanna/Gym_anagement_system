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
    internal class Controller_class :Model.myclass.Model_class
    {
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public SqlDataAdapter sqldata = new SqlDataAdapter();
        public void load_data_Trainers()
        {
            string sql = "SELECT * FROM Trainers;";
            SqlDataAdapter data = new SqlDataAdapter(sql,conn);
            data.Fill(ds, "Traner");
            dt = ds.Tables["Traner"];
        }
        public DataTable dtc = new DataTable();
        public DataSet dsc = new DataSet();
        public SqlDataAdapter sqldatac = new SqlDataAdapter();
        public void load_data_class()
        {
            string sql = "SELECT * FROM V_Class";
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(sql,conn);
            sqldatac.SelectCommand = cmd;
            dsc.Clear();
            sqldatac.Fill(dsc);
            dtc = dsc.Tables[0];
        }
        //insert data to DG View 
        public void InsertClass()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "InsertClass";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = classname;
                cmd.Parameters.Add("@TrainerID", SqlDbType.Int).Value = TrainerID;
                cmd.Parameters.Add("@Schedule", SqlDbType.Date).Value = Schedule;
                cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = duration;
                cmd.Parameters.Add("@Capacity", SqlDbType.Int).Value = capacity;
                cmd.Parameters.Add("@Usernote", SqlDbType.VarChar).Value = Usernote;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error"+ex.Message);
            }
        }

        //update data to DG view 
        public void UpadateClass()
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UpdateClass";
                cmd.CommandType= CommandType.StoredProcedure;   

                cmd.Parameters.Add("@ClassID",SqlDbType.Int).Value = class_id;
                cmd.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = classname;
                cmd.Parameters.Add("@TrainerID", SqlDbType.Int).Value = TrainerID;
                cmd.Parameters.Add("@Schedule", SqlDbType.DateTime).Value = Schedule;
                cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = duration;
                cmd.Parameters.Add("@Capacity", SqlDbType.Int).Value = capacity;
                cmd.Parameters.Add("@UsernoteUpdate", SqlDbType.VarChar).Value = UsernoteUpate;
                cmd.ExecuteNonQuery();


            }
            catch( Exception ex )
            {
                MessageBox.Show("Error" + ex.Message);
                return;
            }
           
        }
        //delete data from DG view 
        public void Delteclass()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DeleteClass";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = class_id;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                return;
            }
        }
    }
}
