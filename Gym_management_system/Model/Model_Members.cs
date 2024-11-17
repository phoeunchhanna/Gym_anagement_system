using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_management_system.Model
{
    internal class Model_Members :Connection 
    {
        public int Mem_id { get; set; }
        public string Fistname { get; set; }
        public string lastnamme { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int Membership_id { get; set; }
        public string Email { get; set; }
        public int Phonenumber { get; set; }
        public string Address { get; set; }
        public DateTime join_date { get; set; }
        public string usernote { get; set; }
        public string usernoteupdate { get; set; }
    }
}
