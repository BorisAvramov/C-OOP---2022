using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Tetsts.Fake
{
    internal class FakeAccount : IAccount
    {
        private decimal amount;
        public decimal Amount { get { return amount; } set { amount = value; } }

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
