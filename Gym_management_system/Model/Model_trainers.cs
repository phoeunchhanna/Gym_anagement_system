using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_management_system.Model
{
    internal class Model_trainers :Connection 
    {
        public int trainer_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public int phonenumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string spaecial { get; set; }
        public DateTime DOB { get; set; }
        public DateTime hiretdate { get; set; }
        public string usernote { get; set; }
        public string usernoteupdate { get; set; }
    }
}
