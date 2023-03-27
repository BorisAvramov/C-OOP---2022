using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Contracts
{
    public interface IBankDb
    {
        public void Update(Bank bank);

        public List<User> ReadUsers(); 
    }
}
