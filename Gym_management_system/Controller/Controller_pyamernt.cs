using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Gym_management_system.Controller
{
    internal class Controller_pyamernt :Model.Model_payment
    {
        //load data member
        public DataTable dtm = new DataTable();
        public DataSet dsm = new DataSet();
        public void view_member()
        {
            string sql = "SELECT * FROM Members";
            SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);
            adapter.Fill(dsm,"Members");
            dtm = dsm.Tables["Members"];
        }
        

        //insert 
        public void Insert()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "InsertPayment";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@MemberID", SqlDbType.Int).Value = member_id;
                cmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = paymentdate;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = amount;
                cmd.Parameters.Add("@PaymentMethod", SqlDbType.VarChar).Value = paymenethod;
                cmd.Parameters.Add("@Usernote", SqlDbType.VarChar).Value = usernote;
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
