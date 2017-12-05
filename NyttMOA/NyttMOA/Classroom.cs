using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NyttMOA
{
    [XmlInclude(typeof(Classroom))]
    public class Classroom
    {
        public string Name { get; set; }
        public int Seats { get; set; }

        public Classroom(string name, int seats)
        {
            Name = name;
            Seats = seats;
        }

        public Classroom()
        {

        }

        public override string ToString()
        {
            return "Name: " + Name + " Number of seats: " + Seats;
        }
    }
}
