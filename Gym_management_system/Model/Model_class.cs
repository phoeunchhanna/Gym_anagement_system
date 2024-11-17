using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_management_system.Model.myclass
{
    internal class Model_class:Connection
    {
        public int class_id { get;set;}
        public string classname { get;set;}
        public int TrainerID { get;set;}
        public DateTime Schedule {  get;set;}
        public int duration { get;set;}
        public int capacity { get; set; }
        public string Usernote { get;set;}
        public string UsernoteUpate { get;set;}
    }
}
