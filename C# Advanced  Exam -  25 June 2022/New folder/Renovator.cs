using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {

        //•	Name: string
        //•	Type: string
        //•	Rate: double
        //•	Days: int
        //•	Hired: boolean - false by default

        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired;

        public Renovator(string name, string type, double rate, int days )
        {
           
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
            hired = false;
        }

        public bool Hired
        {
            get { return hired; }
            set { hired = value; }
        }

        public int Days
        {
            get { return days; }
            set { days = value; }
        }

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {Name}");
            sb.AppendLine($"--Specialty: {Type}");
            sb.AppendLine($"--Rate per day: {Rate} BGN");

            return sb.ToString().TrimEnd();
        }


    }
}
