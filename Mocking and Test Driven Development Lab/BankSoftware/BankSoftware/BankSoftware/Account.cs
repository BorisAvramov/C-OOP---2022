using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware
{
    public class Account : IAccount
    {
        public decimal Amount { get; set; }
        public User User { get; set; }

        public string History { get; set; }

        public void DepositMoney(decimal amount)
        {
            Amount += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount > Amount)
            {
                throw new ArgumentException("There is not enough money in the Amount");
            }

            Amount -= amount;   
        }
    }
}
