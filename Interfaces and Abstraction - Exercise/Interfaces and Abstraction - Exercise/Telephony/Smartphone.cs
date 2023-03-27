using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : Phone, IBrowsable
    {


        public void Browse(string site)
        {
            
                Console.WriteLine($"Browsing: {site}!");
           
        }

        public override void Call(string number)
        {
                Console.WriteLine($"Calling... {number}");
            
        }
    }
}
