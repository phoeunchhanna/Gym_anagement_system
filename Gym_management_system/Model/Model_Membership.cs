using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_management_system.Model
{
    internal class Model_Membership:Connection
    {
        public int Memship_id { get; set; }
        public string Membership_type { get; set; }
        public float price { get; set; }
        public int Duration { get; set; }
        public string usernote { get; set; }
        public string usernoteupdate { get; set; }
    }
}
