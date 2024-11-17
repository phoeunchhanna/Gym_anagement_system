using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_management_system.Model.myclass
{
    internal class Model_Enrollment:Connection
    {
        public int Enrol_id { get; set; }
        public int Member_id { get; set; }
        public int Class_id {  get; set; }
        public DateTime EnrollDate { get; set; }
        public string usernote { get; set; }
        public string usernoteupdate { get; set; }
    }
}
