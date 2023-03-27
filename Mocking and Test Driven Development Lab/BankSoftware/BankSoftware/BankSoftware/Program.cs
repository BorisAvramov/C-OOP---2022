using BankSoftware.Contracts;
using System;

namespace BankSoftware
{
    public class Program
    {
        static void Main(string[] args)
        {

            IBankDb database = new BankTextDb();
            ITimeHelper timeHelper = new TimeHelper();
              Bank bank = new Bank(database,timeHelper );

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "new")
                {
                    Console.WriteLine("Name?");
                    string name = Console.ReadLine();
                    Console.WriteLine("Amount?");
                    decimal amount = decimal.Parse(Console.ReadLine());

                    User user = new User()
                    {
                        Name = name,
                        Account = new Account()
                        {
                            Amount = amount
                        }
                    };

                    bank.AddUser(user);


                }
                if (command == "transfer")
                {
                    string from = Console.ReadLine();
                    string to = Console.ReadLine();
                    decimal amount = decimal.Parse(Console.ReadLine());
                    bank.TransferMoney(from, to, amount);

                }
                if (command == "list")
                {
                    foreach (var user in bank.Users)
                    {
                        Console.WriteLine(user);
                    }


                }




                command = Console.ReadLine();   
            }



        }
    }
}
