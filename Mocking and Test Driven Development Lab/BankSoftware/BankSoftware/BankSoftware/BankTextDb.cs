using BankSoftware.Contracts;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BankSoftware
{
    public class BankTextDb : IBankDb
    {

        private readonly string path = "../../../db.txt";

        

        public List<User> ReadUsers()
        {
            if (!File.Exists(path))
            {
                return new List<User>();  
            }


            string json;
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            List<User> jsonUsers = JsonConvert.DeserializeObject<List<User>>(json);
            return jsonUsers;
        }

        public void Update(Bank bank)
        {
            string jsonUsers = JsonConvert.SerializeObject(bank.Users);

            using (StreamWriter writer = new StreamWriter(path,false))
            {
                writer.WriteLine(jsonUsers);
            }
        }
    }
}
