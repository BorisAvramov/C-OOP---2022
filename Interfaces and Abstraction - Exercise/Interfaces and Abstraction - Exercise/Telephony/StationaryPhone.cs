using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : Phone
    {
        public override void Call(string number)
        {
            
                Console.WriteLine($"Dialing... {number}");
           
           
        }
    }
}
