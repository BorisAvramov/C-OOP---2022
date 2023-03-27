using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public  class RandomList : List<string>
    {

        //public RandomList(List<string> list)
        //{

        //    this.List = list;

        //}

        //public List<string> List { get; set; }

        public string RandomString()
        {
            Random rnd = new Random();

            int index = rnd.Next(0, this.Count);
            string elemnent = this[index];
            this.RemoveAt(index);
            return elemnent;

        }
    }
}
