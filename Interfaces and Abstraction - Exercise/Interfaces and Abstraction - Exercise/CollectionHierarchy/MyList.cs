using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {


        private List<string> myList;

        public MyList()
        {
            myList = new List<string>();
        }

        public int Used => myList.Count;

        public int Add(string item)
        {
            myList.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string last = myList[0];
            myList.RemoveAt(0);
            return last;
        }
    }
}
