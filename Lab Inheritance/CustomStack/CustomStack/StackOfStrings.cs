using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {

            return this.Count == 0;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            while (this.Count > 0)
            {
                sb.Append(this.Pop());
            }
            return sb.ToString();
        }
    }
}
