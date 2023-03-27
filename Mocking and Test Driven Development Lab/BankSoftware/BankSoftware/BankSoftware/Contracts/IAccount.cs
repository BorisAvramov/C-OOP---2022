using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Contracts
{
    public interface IAccount
    {
        void DepositMoney(decimal amount);


        void WithdrawMoney(decimal amount);

        public decimal Amount { get; set; }

    }
}
