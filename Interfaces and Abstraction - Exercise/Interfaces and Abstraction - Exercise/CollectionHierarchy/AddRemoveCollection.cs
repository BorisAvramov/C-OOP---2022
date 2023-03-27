using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    internal class AddRemoveCollection :  IAddRemove
    {

        private List<string> addRemoveColl;


        public AddRemoveCollection()
        {
            addRemoveColl = new List<string>();
        }
        public int Add(string item)
        {
            addRemoveColl.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string last = addRemoveColl[addRemoveColl.Count - 1];
            addRemoveColl.RemoveAt(addRemoveColl.Count - 1);
            return last;
        }

        
    }
}
