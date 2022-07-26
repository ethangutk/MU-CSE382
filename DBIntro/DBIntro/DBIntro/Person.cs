using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DBIntro
{
    class Person
    {
        // PrimaryKey is typically numeric 
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DOB { get; set; }
        public string SSN { get; set; }
        public int Income { get; set; }

        public override string ToString()
        {
            if (Gender)
            {
                return string.Format("{0} {1} F {2} {3}", Name, SSN, DOB.ToShortDateString(), Income.ToString());
            }
            return string.Format("{0} {1} M {2} {3}", Name, SSN, DOB.ToShortDateString(), Income.ToString());
        }
    }
}
