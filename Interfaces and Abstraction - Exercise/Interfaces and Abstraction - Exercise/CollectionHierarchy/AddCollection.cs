using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAdd, IEnumerable
    {
        private ICollection<string> addCollection;


        public AddCollection()
        {
            this.addCollection = new List<string>();

        }

        public int Add(string item)
        {
            
            addCollection.Add(item);
            return addCollection.Count - 1;

        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in addCollection)
            {
                yield return item;
            }
        }
    }
}
