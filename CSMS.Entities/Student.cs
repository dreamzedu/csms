using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSMS.Entities
{
    public class Student
    {
        public string StudentNo { get; set; }
        public string ScholarNo { get; set; }

        public string Name { get; set; }

        public string FatherName { get; set; }

        public string Class { get; set; }

        public string Section { get; set; }

        public string Phone { get; set; }

        public DateTime DateOfAdmission { get; set; }

        public string Gender { get; set; }

    }
}
