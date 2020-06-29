using System;
using System.Collections.Generic;
using System.Text;

namespace relinqproj.Entity
{
    public class Person
    {
        public Person() { }
        public Person(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return ID + "|" + Name;
        }
    }
}
