using System;
using System.Collections.Generic;
using System.Text;

namespace GroupingLinq
{
    class Person
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Gender gender { get; set; }

        public Person(string name, int height, int weight, Gender gender)
        {
            Name = name;
            Height = height;
            Weight = weight;
            this.gender = gender;
        }

        internal enum Gender
        {
            Male,
            Female
        }
    }
}
