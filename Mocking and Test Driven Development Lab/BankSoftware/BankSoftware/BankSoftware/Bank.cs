using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSoftware
{
    public class Bank
    {

        private IBankDb database;
        private  ITimeHelper timeHelper;

        public Bank(IBankDb database, ITimeHelper timeHelper)
        {
            this.database = database;
            this.timeHelper = timeHelper;

            Users = database.ReadUsers();
        }


        //public void TransferMoney(User from, User to, decimal amount)
        //{
        //    from.Account.WithdrawMoney(amount);
        //    to.Account.DepositMoney(amount);

        //    database.Update(this);

        //}

        public List<User> Users { get; set; }
        public void TransferMoney(string fromName, string toName, decimal amount)
        {
            User from = Users.First(u => u.Name == fromName);
            User to = Users.First(u => u.Name == toName);

            if (timeHelper.ShouldGetCommissiom())
            {
                from.Account.WithdrawMoney(1);
                to.Account.WithdrawMoney(1);

            }


          
            
            from.Account.WithdrawMoney(amount);
            to.Account.DepositMoney(amount);

            database.Update(this);
        }

        public void AddUser(User user)
        { 
            Users.Add(user);

            database.Update(this);

        }
        public void RemoUser(User user)
        {
            Users.Remove(user);

            database.Update(this);
        }
    }
}
