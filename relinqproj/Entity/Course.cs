using System;
using System.Collections.Generic;
using System.Text;

namespace relinqproj.Entity
{
    public class Course
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string CourseName { get; set; }
        public override string ToString()
        {
            return ID + "|" + PersonID + "|" + CourseName;
        }
    }
}
