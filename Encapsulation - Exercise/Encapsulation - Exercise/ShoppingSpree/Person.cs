using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;
        public Person(string name, decimal money )
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }


        public IReadOnlyCollection<Product> BagOfProducts => bagOfProducts.AsReadOnly();

        public decimal Money
        {
            get { return money; }
            private set
            {
                Validator.ValidMoney(value);

                money = value;


            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                Validator.ValidName(value);

                name = value;


            }
        }

        public void Buy(Product product)
        {
            if (Money - product.Cost < 0)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                bagOfProducts.Add(product); 
                money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }


        }




    }
}
