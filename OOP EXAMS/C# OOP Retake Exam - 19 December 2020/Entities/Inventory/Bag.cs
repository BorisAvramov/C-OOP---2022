using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private readonly List<Item> items;

        // !!!!!!!!!!!!!!!
        public Bag()
        {
            Capacity = 100;
            items = new List<Item>();
        }
        public Bag(int capacity)
        {
             Capacity = capacity;
            items = new List<Item>();

        }
        public int Capacity { get { return capacity; }  set { capacity = value; } }

        public int Load => Items.Sum(i => i.Weight); 

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if ((Load + item.Weight) > capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);

        }

        public Item GetItem(string name)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            Item item = items.FirstOrDefault(i => i.GetType().Name == name);

            return item;

        }
    }
}
