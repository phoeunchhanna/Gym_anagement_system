using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_management_system.Controller
{
    internal class Controller_Membership :Model.Model_Membership
    {
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public SqlDataAdapter ada= new SqlDataAdapter();
        public void load_membership()
        {
            string sql = "SELECT * FROM Memberships";
            SqlCommand cmd = new SqlCommand(sql, conn);
            ada.SelectCommand = cmd;
            ds.Clear();
            ada.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Insertmembership()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "InsertMembership";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@MembershipType", SqlDbType.NVarChar).Value = Membership_type;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = Duration;
                cmd.Parameters.Add("@Usernote", SqlDbType.VarChar).Value = usernote;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
       public void Updatemembership()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UpdateMembership";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MembershipID", SqlDbType.Int).Value = Memship_id;
                cmd.Parameters.Add("@MembershipType", SqlDbType.NVarChar).Value = Membership_type;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = Duration;
                cmd.Parameters.Add("@UsernoteUpdate", SqlDbType.VarChar).Value = usernoteupdate;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        public void Deletemembership()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Deletemembersip";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@memebership_id", SqlDbType.Int).Value = Memship_id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
