using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Tetsts.Fake
{
    public class FakeDb : IBankDb
    {
        public List<User> ReadUsers()
        {
            return new List<User>();
        }

        public void Update(Bank bank)
        {
            
        }
    }
}
