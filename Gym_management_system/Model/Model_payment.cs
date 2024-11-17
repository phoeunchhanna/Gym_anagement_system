using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_management_system.Model
{
    internal class Model_payment :Connection
    {
        public int pay_id {  get; set; }
        public  int member_id { get; set; }
        public  float amount { get; set; }
        public  DateTime paymentdate { get; set; }
        public  string paymenethod { get; set; }
        public string usernote { get; set; }
        public string usernoteupdate { get; set;}
    }
}
