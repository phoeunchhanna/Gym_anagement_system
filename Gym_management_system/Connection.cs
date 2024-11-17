using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym_management_system
{
    internal class Connection
    {
        public SqlConnection conn;
        public Connection()
        {
            try
            {
                string connectionstring;
                connectionstring = @"Data Source=DESKTOP-R3B18TQ;Initial Catalog=Gym_ms_db; User Id=sa; password=chhannacode;";
                conn = new SqlConnection(connectionstring);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                return;
            }
        }
    }
}
